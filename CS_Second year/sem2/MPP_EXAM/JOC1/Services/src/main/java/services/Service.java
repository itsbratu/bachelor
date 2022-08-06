package services;

import model.Game;
import model.User;
import repos.UserRepo;
import repos.GameRepo;

import java.util.ArrayList;
import java.util.List;
import java.util.Random;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

public class Service implements IService{
    private UserRepo userRepo;
    private GameRepo gameRepo;
    private List<IObserver> observers;
    public static boolean gameStarted;
    public static Integer participants;
    private final int defaultThreadsNo=5;
    public Integer valoarePoz1 = 0;
    public Integer valoarePoz2 = 0;
    public Integer valoarePoz3 = 0;
    public Integer valoarePoz4 = 0;
    public Integer valoarePoz5 = 0;
    public Integer bani = 50;
    public Integer incercari = 3;
    public Integer pozCurrent = 0;
    public ArrayList<Integer> pozitiiVizitate;
    private String usernameLogged;

    public Service(UserRepo userRepo, GameRepo gameRepo) {
        this.userRepo = userRepo;
        this.gameRepo = gameRepo;
        pozitiiVizitate = new ArrayList<Integer>();
        observers=new ArrayList<>();
        this.gameStarted=false;
        this.participants=0;
    }

    @Override
    public synchronized User login(IObserver client, String username, String password) {
        User user=userRepo.findOne(username, password);
        usernameLogged = user.getUsername();
        if(user!=null){
            observers.add(client);
            participants+=1;
            userRepo.update(user);
            startGame();
        }
        return user;
    }

    @Override
    public void logout(IObserver client, String username) {
        observers.remove(client);
        User user=userRepo.findOneByUsername(username);
        if(participants==1){
            gameStarted=false;
            participants=0;
        }
        userRepo.update(user);
        if(participants>0)
            participants-=1;
    }

    @Override
    public void updateUser(User user) {
        userRepo.update(user);
    }

    //Generate things for the new game
    @Override
    public void startGame() {
        gameStarted=true;
        ExecutorService executor= Executors.newFixedThreadPool(defaultThreadsNo);
        Random rand = new Random();
        valoarePoz1 = rand.nextInt(20) + 1;
        valoarePoz2 = rand.nextInt(20) + 1;
        valoarePoz3 = rand.nextInt(20) + 1;
        valoarePoz4 = rand.nextInt(20) + 1;
        valoarePoz5 = rand.nextInt(20) + 1;
        bani = 50;
        incercari = 3;
        pozCurrent = 0;
        updateInterface();
        for(IObserver observer:observers) {
            executor.execute(() -> {
                try {
                    System.out.println("notifying users...");
                } catch (Exception e) {
                    System.out.println("error notifying users...");
                }
            });
        }
        executor.shutdown();
    }

    //Update UI Here
    @Override
    public void updateInterface(){
        ExecutorService executor= Executors.newFixedThreadPool(defaultThreadsNo);
        for(IObserver observer:observers) {
            executor.execute(() -> {
                try {
                    observer.updateInterface(valoarePoz1, valoarePoz2, valoarePoz3, valoarePoz4, valoarePoz5, bani, incercari, pozCurrent);
                    System.out.println("notifying users...");
                } catch (Exception e) {
                    System.out.println("error notifying users...");
                }
            });
        }
        executor.shutdown();
    }

    //Choose what happens when the game is done
    @Override
    public void gameDone(boolean winner){
        gameRepo.saveGame(new Game(-1, usernameLogged, bani, 0));
        Random rand = new Random();
        valoarePoz1 = rand.nextInt(20) + 1;
        valoarePoz2 = rand.nextInt(20) + 1;
        valoarePoz3 = rand.nextInt(20) + 1;
        valoarePoz4 = rand.nextInt(20) + 1;
        valoarePoz5 = rand.nextInt(20) + 1;
        bani = 50;
        incercari = 3;
        pozCurrent = -1;
        updateInterface();
        ExecutorService executor= Executors.newFixedThreadPool(defaultThreadsNo);
        for(IObserver observer:observers) {
            executor.execute(() -> {
                try {
                    observer.gameDone(gameRepo.getGames());
                    System.out.println("notifying users...");
                } catch (Exception e) {
                    System.out.println("error notifying users...");
                }
            });
        }
        executor.shutdown();
    }

    @Override
    public void roll(){
        Random rand = new Random();
        Integer poz = rand.nextInt(3) + 1;
        Integer nouaPozitie = (pozCurrent + poz);
        if(nouaPozitie > 5){
            bani = bani + 5;
            nouaPozitie = nouaPozitie % 5;
        }
        if(!pozitiiVizitate.contains(nouaPozitie)){
            pozitiiVizitate.add(nouaPozitie);
            if(nouaPozitie == 1){
                bani = bani - valoarePoz1;
            }
            if(nouaPozitie == 2){
                bani = bani - valoarePoz2;
            }
            if(nouaPozitie == 3){
                bani = bani - valoarePoz3;
            }
            if(nouaPozitie == 4){
                bani = bani - valoarePoz4;
            }
            if(nouaPozitie == 5){
                bani = bani - valoarePoz5;
            }
        }
        pozCurrent = nouaPozitie;
        incercari = incercari - 1;
        if(incercari == 0){
            updateInterface();
            gameDone(true);
        }else{
            updateInterface();
        }

    }

    //Add functions here

}

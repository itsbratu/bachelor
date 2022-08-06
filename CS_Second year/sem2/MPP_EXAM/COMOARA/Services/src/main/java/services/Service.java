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
    public int puncte = 0;
    public int pozitieComoara = -1;
    public int valoareComoara = 0;
    public int distanta = 0;
    public int incercari = 3;
    public static boolean gameStarted;
    public static Integer participants;
    private final int defaultThreadsNo=5;
    private String usernameLogged;

    public Service(UserRepo userRepo, GameRepo gameRepo) {
        this.userRepo = userRepo;
        this.gameRepo = gameRepo;
        observers=new ArrayList<>();
        this.gameStarted=false;
        this.participants=0;
    }

    @Override
    public synchronized User login(IObserver client, String username, String password) {
        if(gameStarted==true)
            return null;
        User user=userRepo.findOne(username, password);
        usernameLogged = username;
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

    @Override
    public void startGame() {
        gameStarted=true;
        Random rand = new Random();
        pozitieComoara = rand.nextInt(9) + 1;
        valoareComoara = rand.nextInt(1000);
        System.out.println("Pozitie comoara" + pozitieComoara);
        System.out.println("Valoare comoara" + valoareComoara);
        ExecutorService executor= Executors.newFixedThreadPool(defaultThreadsNo);
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

    @Override
    public void updateInterface(){
        ExecutorService executor= Executors.newFixedThreadPool(defaultThreadsNo);
        for(IObserver observer:observers) {
            executor.execute(() -> {
                try {
                    observer.updateInterface(puncte, distanta, incercari);
                    System.out.println("notifying users...");
                } catch (Exception e) {
                    System.out.println("error notifying users...");
                }
            });
        }
        executor.shutdown();
    }

    @Override
    public void gameDone(Integer winner){
        ExecutorService executor= Executors.newFixedThreadPool(defaultThreadsNo);
        for(IObserver observer:observers) {
            executor.execute(() -> {
                try {
                    gameRepo.save(new Game(-1, usernameLogged, puncte, winner, valoareComoara));
                    puncte = 0;
                    distanta = 0;
                    incercari = 3;
                    Random rand = new Random();
                    valoareComoara = rand.nextInt(1000);
                    observer.updateInterface(puncte, distanta, incercari);
                    observer.finishGame(gameRepo.getAll());
                    System.out.println("notifying users...");
                } catch (Exception e) {
                    System.out.println("error notifying users...");
                }
            });
        }
        executor.shutdown();
    }

    @Override
    public void checkPos(int position){
        if(position == pozitieComoara) {
            puncte += valoareComoara;
            updateInterface();
            gameDone(0);
        }else{
            puncte += Math.abs(position - pozitieComoara);
            distanta = Math.abs(position - pozitieComoara);
            incercari--;
            if(incercari == 0){
                updateInterface();
                gameDone(-1);
            }
            updateInterface();
        }
    }

}

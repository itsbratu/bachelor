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
    private Integer comoaraX;
    private Integer comoaraY;
    private Integer valoareComoara;
    private Integer incercari;
    private Double distanta;
    private Integer puncte;
    private String usernameLogged;
    //public ArrayList<Integer> pozitiiVizitate;

    public Service(UserRepo userRepo, GameRepo gameRepo) {
        this.userRepo = userRepo;
        this.gameRepo = gameRepo;
        //pozitiiVizitate = new ArrayList<Integer>();
        observers=new ArrayList<>();
        this.gameStarted=false;
        this.participants=0;
    }

    @Override
    public synchronized User login(IObserver client, String username, String password) {
        if(gameStarted==true)
            return null;
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

    private void initializeVariables(){
        Random rand = new Random();
        comoaraX = rand.nextInt(3) + 1;
        comoaraY = rand.nextInt(3) + 1;
        valoareComoara = rand.nextInt(100) + 1;
        distanta = 0.0;
        puncte = 0;
        incercari = 3;
        System.out.println("COMOARA X : " + comoaraX);
        System.out.println("COMOARA Y : " + comoaraY);
        System.out.println("COMOARA  : " + valoareComoara);
    }

    private Double calculateDistance(Integer comoaraX, Integer comoaraY, Integer guessX, Integer guessY){
        return Math.sqrt((comoaraX - guessX) * (comoaraX - guessX) + (comoaraY - guessY) * (comoaraY - guessY));
    }

    //Generate things for the new game
    @Override
    public void startGame() {
        gameStarted=true;
        ExecutorService executor= Executors.newFixedThreadPool(defaultThreadsNo);
        initializeVariables();
        for(IObserver observer:observers) {
            executor.execute(() -> {
                try {
                    updateInterface();
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
                    observer.updateInterface(puncte, distanta, incercari);
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
    public void gameDone(Boolean winner){
        ExecutorService executor= Executors.newFixedThreadPool(defaultThreadsNo);
        for(IObserver observer:observers) {
            executor.execute(() -> {
                try {
                    if(winner){
                        gameRepo.saveGame(new Game(-1, usernameLogged, puncte, 1));
                        observer.gameDone(true, gameRepo.getGames(), comoaraX, comoaraY, valoareComoara, puncte);
                    }else{
                        gameRepo.saveGame(new Game(-1, usernameLogged, puncte, -1));
                        observer.gameDone(false, gameRepo.getGames(), comoaraX, comoaraY, valoareComoara, puncte);
                    }
                    System.out.println("notifying users...");
                } catch (Exception e) {
                    System.out.println("error notifying users...");
                }
            });
        }
        executor.shutdown();
    }

    //Add functions here
    @Override
    public void positionClicked(Integer guessX, Integer guessY){
        incercari--;
        System.out.println("CLICKED X" + guessX);
        System.out.println("CLICKED Y" + guessY);
        if(guessX.equals(comoaraX) && guessY.equals(comoaraY)){
            puncte+= valoareComoara;
            gameDone(true);
            updateInterface();
        }else{
            distanta = calculateDistance(comoaraX, comoaraY, guessX, guessY);
            Long computedPuncte = Math.round(distanta);
            puncte += Math.toIntExact(computedPuncte);
            if(incercari == 0){
                updateInterface();
                gameDone(false);
            }else{
                updateInterface();
            }
        }
    }

}

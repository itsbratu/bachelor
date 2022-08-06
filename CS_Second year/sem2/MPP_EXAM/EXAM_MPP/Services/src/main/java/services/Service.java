package services;

import model.Game;
import model.User;
import repos.UserRepo;
import repos.GameRepo;

import java.io.Console;
import java.lang.reflect.Array;
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
                    observer.updateInterface();
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
    public void gameDone(){
        ExecutorService executor= Executors.newFixedThreadPool(defaultThreadsNo);
        for(IObserver observer:observers) {
            executor.execute(() -> {
                try {
                    //gameRepo.saveGame(new Game(-1, usernameLogged, puncte, 0));
                    updateInterface();
                    observer.gameDone();
                    System.out.println("notifying users...");
                } catch (Exception e) {
                    System.out.println("error notifying users...");
                }
            });
        }
        executor.shutdown();
    }
}

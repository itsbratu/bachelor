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
    private ArrayList<String> cuvinte;
    private ArrayList<String> litere;
    private ArrayList<String> cuvinteGhicite;
    private String usernameLogged;
    private String mesajCuvant;
    private Integer puncte;
    private Integer incercari;


    public Service(UserRepo userRepo, GameRepo gameRepo) {
        this.userRepo = userRepo;
        this.gameRepo = gameRepo;
        cuvinte = new ArrayList<String>();
        litere = new ArrayList<String>();
        cuvinteGhicite = new ArrayList<String>();
        mesajCuvant = "";
        cuvinte.add("aer");
        cuvinte.add("ar");
        cuvinte.add("rea");
        litere.add("a");
        litere.add("r");
        litere.add("e");
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

    private void initializeData(){
        puncte = 0;
        incercari = 3;
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
        initializeData();
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
                    observer.updateInterface(litere, cuvinte, puncte, incercari, mesajCuvant);
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
                    gameRepo.saveGame(new Game(-1, usernameLogged, puncte, 0));
                    observer.gameDone(gameRepo.getGames(), cuvinte);
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
    public void submitWord(String word) {
        if(cuvinte.contains(word)){
            if(!cuvinteGhicite.contains(word)){
                puncte += word.length();
                incercari--;
                mesajCuvant = "CUVANT GHICIT!";
                cuvinteGhicite.add(word);
                updateInterface();
                if(incercari == 0){
                    gameDone();
                }
            }
        }else{
            Integer maximMatching = -1;
            for(String cuvantCurent : cuvinte){
                Integer currentMatching = 0;
                if(!cuvinteGhicite.contains(cuvantCurent)){
                    if(word.length() <= cuvantCurent.length()){
                        for(int i = 0; i < word.length(); ++i){
                            if(word.charAt(i) == cuvantCurent.charAt(i)){
                                currentMatching++;
                            }
                        }
                    }else{
                        for(int i = 0; i < cuvantCurent.length(); ++i){
                            if(word.charAt(i) == cuvantCurent.charAt(i)){
                                currentMatching++;
                            }
                        }
                    }
                    if(currentMatching > maximMatching){
                        maximMatching = currentMatching;
                    }
                }
            }
            if(maximMatching < 1){
                incercari--;
                mesajCuvant = "CUVANT GRESIT!";
                updateInterface();
                if(incercari == 0){
                    gameDone();
                }
            }else{
                incercari--;
                puncte += maximMatching;
                mesajCuvant = "CUVANT GHICIT PARTIAL!";
                updateInterface();
                if(incercari == 0){
                    gameDone();
                }
            }
        }
    }

}

package controllers;

import javafx.application.Platform;
import javafx.fxml.FXML;
import javafx.scene.control.*;
import model.Game;
import model.User;
import services.IObserver;
import services.IService;

import java.io.Serializable;
import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;
import java.text.DecimalFormat;
import java.util.ArrayList;
import java.util.Collections;

public class MainController extends UnicastRemoteObject implements IObserver, Serializable {
    private IService service;
    private User user;

    @FXML
    Label labelStart;

    @FXML
    Button buttonLogout;

    @FXML
    Button poz1;

    @FXML
    Button poz2;

    @FXML
    Button poz3;

    @FXML
    Button poz4;

    @FXML
    Button poz5;

    @FXML
    Button poz6;

    @FXML
    Button poz7;

    @FXML
    Button poz8;

    @FXML
    Button poz9;

    @FXML
    Label labelPuncte;

    @FXML
    Label valoarePuncte;

    @FXML
    Label labelDistanta;

    @FXML
    Label valoareDistanta;

    @FXML
    Label labelIncercari;

    @FXML
    Label valoareIncercari;

    @FXML
    public void pozClicked1(){
        service.positionClicked(1, 1);
    }

    @FXML
    public void pozClicked2(){
        service.positionClicked(1, 2);
    }

    @FXML
    public void pozClicked3(){
        service.positionClicked(1, 3);
    }

    @FXML
    public void pozClicked4(){
        service.positionClicked(2, 1);
    }

    @FXML
    public void pozClicked5(){
        service.positionClicked(2, 2);
    }

    @FXML
    public void pozClicked6(){
        service.positionClicked(2, 3);
    }

    @FXML
    public void pozClicked7(){
        service.positionClicked(3, 1);
    }

    @FXML
    public void pozClicked8(){
        service.positionClicked(3, 2);
    }

    @FXML
    public void pozClicked9(){
        service.positionClicked(3, 3);
    }

    @FXML
    public void logout(){
        this.service.logout(this,this.user.getUsername());
        Platform.exit();
    }

    public MainController() throws RemoteException {
    }

    public void setUser(User user){
        this.user=user;
    }

    public void setService(IService service){
        this.service=service;
        init();
    }

    public void init(){
        System.out.println(user.getUsername());
        service.startGame();
    }

    @Override
    public void startGame(){

    }

    //UPDATE INTERFACE
    @Override
    public void updateInterface(Integer puncte, Double distanta, Integer incercari){
        Platform.runLater(new Runnable() {
            @Override
            public void run() {
                DecimalFormat df = new DecimalFormat("0.00");
                valoarePuncte.setText(puncte.toString());
                valoareDistanta.setText(df.format(distanta).toString());
                valoareIncercari.setText(incercari.toString());
            }
        });
    }

    //GAME DONE
    @Override
    public void gameDone(Boolean winner, Iterable<Game> games, Integer comoaraX, Integer comoaraY, Integer valoareComoara, Integer puncteObtinute){
        Platform.runLater(new Runnable() {
            @Override
            public void run() {
                String message = "ID     USERNAME      PUNCTE        WINNER/LOSER";
                message += "\n";
                message += "Puncte obtinute : " + puncteObtinute + "\n";
                message += "Valoare comoara : " + valoareComoara + "\n";
                message += "Comoara X : " + comoaraX + "\n";
                message += "Comoara Y : " + comoaraY + "\n";
                Integer maxId = -1;
                Integer pozitie = 0;
                ArrayList<Game> gamesSorted = new ArrayList<Game>();
                for(Game g : games){
                    gamesSorted.add(g);
                    if(g.getId() > maxId){
                        maxId = g.getId();
                    }
                }
                Collections.sort(gamesSorted);
                boolean flag = false;
                for(Game g : gamesSorted){
                    if(!flag){
                        pozitie++;
                    }
                    message += g.getUsername() + "      " + g.getGameValue();
                    if(g.getWinner() == -1){
                        message += " LOSER";
                    }else{
                        message += " WINNER";
                    }
                    if(g.getId() == maxId){
                        message += "-- THIS IS YOU  --";
                        flag = true;
                    }
                    message += "\n";
                }
                message += "Pozitia in clasament : " + pozitie + "\n";
                Alert alert = new Alert(Alert.AlertType.INFORMATION);
                if(winner){
                    alert.setTitle("Clasament! FOUND");
                }else{
                    alert.setTitle("Clasament! NOT FOUND");
                }
                alert.setContentText(message);
                alert.showAndWait();
                service.startGame();
            }
        });
    }


}

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
import java.util.ArrayList;
import java.util.Collections;

public class MainController extends UnicastRemoteObject implements IObserver, Serializable {
    private IService service;
    private User user;

    @FXML
    Label labelStart;

    @FXML
    Label valoarePoz1;

    @FXML
    Label valoarePoz2;

    @FXML
    Label valoarePoz3;

    @FXML
    Label valoarePoz4;

    @FXML
    Label valoarePoz5;

    @FXML
    Label valoarePozitie;

    @FXML
    Label valoareIncercari;

    @FXML
    Label valoareBani;


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

    @FXML
    public void roll(){
        service.roll();
    }

    //Update interface here
    @Override
    public void updateInterface(Integer val1, Integer val2, Integer val3, Integer val4, Integer val5, Integer bani, Integer incercari, Integer pozitie){
        Platform.runLater(new Runnable() {
            @Override
            public void run() {
                if(incercari == 3){
                    valoarePoz1.setText(val1.toString());
                    valoarePoz2.setText(val2.toString());
                    valoarePoz3.setText(val3.toString());
                    valoarePoz4.setText(val4.toString());
                    valoarePoz5.setText(val5.toString());
                    valoareBani.setText(bani.toString());
                    valoareIncercari.setText(incercari.toString());
                    valoarePozitie.setText("-1");
                }else{
                    valoareBani.setText(bani.toString());
                    valoareIncercari.setText(incercari.toString());
                    valoarePozitie.setText(pozitie.toString());
                }
            }
        });
    }

    @Override
    public void gameDone(Iterable<Game> games){
        Platform.runLater(new Runnable() {
            @Override
            public void run() {
                String message = "ID     USERNAME      MONEY";
                Integer maxId = -1;
                message += "\n";
                ArrayList<Game> gamesSorted = new ArrayList<Game>();
                for(Game g : games){
                    gamesSorted.add(g);
                    if(g.getId() > maxId){
                        maxId = g.getId();
                    }
                }
                Collections.sort(gamesSorted);
                for(Game g : gamesSorted){
                    message += g.getId() + "     " + g.getUsername() + "      " + g.getGameValue();
                    if(g.getId() == maxId){
                        message += "-- THIS IS YOU  --";
                    }
                    message += "\n";
                }
                Alert alert = new Alert(Alert.AlertType.INFORMATION);
                alert.setTitle("Clasament!");
                alert.setContentText(message);
                alert.showAndWait();
            }
        });
    }


}

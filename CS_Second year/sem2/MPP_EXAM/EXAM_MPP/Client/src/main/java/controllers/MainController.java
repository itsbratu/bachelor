package controllers;

import javafx.application.Platform;
import javafx.fxml.FXML;
import javafx.scene.control.*;
import model.Game;
import model.User;
import services.IObserver;
import services.IService;

import javax.xml.soap.Text;
import java.io.Serializable;
import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;
import java.util.ArrayList;
import java.util.Collections;

public class MainController extends UnicastRemoteObject implements IObserver, Serializable {
    private IService service;
    private User user;

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
    public void updateInterface(){
        Platform.runLater(new Runnable() {
            @Override
            public void run() {

            }
        });
    }

    //GAME DONE
    @Override
    public void gameDone(){
        Platform.runLater(new Runnable() {
            @Override
            public void run() {
//                String message = "";
//                message += "Cuvintele sunt : \n";
//                for(String cuvant : cuvinte){
//                    message += cuvant + " ";
//                }
//                message += "\n";
//                message += "USERNAME   PUNCTE";
//                Integer maxId = -1;
//                Integer pozitie = 0;
//                message += "\n";
//                ArrayList<Game> gamesSorted = new ArrayList<Game>();
//                for(Game g : games){
//                    gamesSorted.add(g);
//                    if(g.getId() > maxId){
//                        maxId = g.getId();
//                    }
//                }
//                Collections.sort(gamesSorted);
//                boolean flag = false;
//                for(Game g : gamesSorted){
//                    if(!flag){
//                        pozitie++;
//                    }
//                    message += g.getUsername() + "      " + g.getGameValue();
//                    if(g.getId() == maxId){
//                        message += "-- THIS IS YOU  --";
//                        flag = true;
//                    }
//                    message += "\n";
//                }
//                message += "Pozitia in clasament : " + pozitie + "\n";
//                Alert alert = new Alert(Alert.AlertType.INFORMATION);
//                alert.setTitle("Clasament!");
//                alert.setContentText(message);
//                alert.showAndWait();
            }
        });
    }


}

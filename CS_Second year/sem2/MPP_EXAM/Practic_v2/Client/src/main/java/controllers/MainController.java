package controllers;

import javafx.application.Platform;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.scene.control.*;
import javafx.scene.control.cell.PropertyValueFactory;
import model.User;
import model.Word;
import services.IObserver;
import services.IService;

import java.io.Serializable;
import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;
import java.util.ArrayList;
import java.util.List;

public class MainController extends UnicastRemoteObject implements IObserver, Serializable {
    private IService service;
    private User user;

    @FXML
    Label labelStart;

    @FXML
    Label labelPuncte;

    @FXML
    Label labelPuncteValoare;

    @FXML
    Label labelDistanta;

    @FXML
    Label labelDistantaValoare;

    @FXML
    Label labelIncercari;

    @FXML
    Label labelIncercariValoare;

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

    @FXML
    public void checkPos1(){
        service.checkPos(1);
    }

    @FXML
    public void checkPos2(){
        service.checkPos(2);
    }

    @FXML
    public void checkPos3(){
        service.checkPos(3);
    }

    @FXML
    public void checkPos4(){
        service.checkPos(4);
    }

    @FXML
    public void checkPos5(){
        service.checkPos(5);
    }

    @FXML
    public void checkPos6(){
        service.checkPos(6);
    }

    @FXML
    public void checkPos7(){
        service.checkPos(7);
    }

    @FXML
    public void checkPos8(){
        service.checkPos(8);
    }

    @FXML
    public void checkPos9(){
        service.checkPos(9);
    }

    @Override
    public void startGame(){

    }

    @Override
    public void updateInterface(Integer puncte, Integer distanta, Integer incercari){
        Platform.runLater(new Runnable() {
            @Override
            public void run() {
                labelPuncteValoare.setText(puncte.toString());
                labelDistantaValoare.setText(distanta.toString());
                labelIncercariValoare.setText(incercari.toString());
            }
        });
    }

}

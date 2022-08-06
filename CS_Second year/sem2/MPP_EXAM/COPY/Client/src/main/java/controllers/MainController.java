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
    Label labelStart;

    @FXML
    Label labelLitere;

    @FXML
    TextField inputCuvant;

    @FXML
    Label labelAtentionare;

    @FXML
    Button submitButton;

    @FXML
    Label valoarePuncte;

    @FXML
    Label valoareIncercari;

    @FXML
    public void logout(){
        this.service.logout(this,this.user.getUsername());
        Platform.exit();
    }

    @FXML
    public void submitWord(){
        String cuvantIntrodus = inputCuvant.getText();
        if (cuvantIntrodus.length() < 1){
            Alert alert = new Alert(Alert.AlertType.ERROR);
            alert.setTitle("ERROR");
            alert.setContentText("Cuvant introdus invalid!");
            alert.showAndWait();
            inputCuvant.setText("");
        }else{
            inputCuvant.setText("");
            service.submitWord(cuvantIntrodus);
        }

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
    public void updateInterface(ArrayList<String> litere, ArrayList<String> cuvinte, Integer puncte, Integer incercari, String mesajCuvant){
        Platform.runLater(new Runnable() {
            @Override
            public void run() {
                String message = "LITERE DISPONIBILE : ";
                labelLitere.setText("");
                for(String litera : litere){
                    message += litera + " ";
                }
                labelLitere.setText(message);
                valoarePuncte.setText(puncte.toString());
                valoareIncercari.setText(incercari.toString());
                labelAtentionare.setText(mesajCuvant);
            }
        });
    }

    //GAME DONE
    @Override
    public void gameDone(Iterable<Game> games, ArrayList<String> cuvinte){
        Platform.runLater(new Runnable() {
            @Override
            public void run() {
                String message = "ID     USERNAME      PUNCTE";
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
                alert.setContentText("");
                alert.showAndWait();
            }
        });
    }


}

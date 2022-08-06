package client.gui;

import javafx.application.Platform;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.scene.Node;
import javafx.scene.control.Alert;
import javafx.scene.control.Button;
import javafx.scene.control.Control;
import javafx.scene.control.Label;
import javafx.scene.layout.Background;
import model.AttackDTO;
import model.Game;
import model.User;
import model.UserBoatDTO;
import service.IObserver;
import service.IServices;
import service.ServiceException;

import javax.management.ValueExp;
import java.util.Objects;

public class MenuController implements IObserver {

    public Button btn1;
    public Button btn2;
    public Button btn3;
    public Button btn4;
    public Button btn5;
    public Button btn6;
    public Button btn7;
    public Button btn8;
    public Button btn9;
    public Button btn10;
    public Button btn11;
    public Button btn12;
    public Button btn13;
    public Button btn14;
    public Button btn15;
    public Button btn16;
    public Button btne1;
    public Button btne2;
    public Button btne3;
    public Button btne4;
    public Button btne5;
    public Button btne6;
    public Button btne7;
    public Button btne8;
    public Button btne9;
    public Button btne10;
    public Button btne11;
    public Button btne12;
    public Button btne13;
    public Button btne14;
    public Button btne15;
    public Button btne16;
    public Button btnStartGame;
    public Label LabelUser1;
    public Label LabelUser2;
    private IServices server;
    private User user;
    private Boolean counter = false;
    private Game actualGame=null;

    private Integer x;
    private Integer y;

    public void logout() {
        try {
            System.out.println("Before logout " + user);
            server.logout(user, this);
        } catch (ServiceException e) {
            System.out.println("Logout error " + e);
        }
    }

    public void login(String username, String pass) throws ServiceException {
        User userL = new User(username, pass);
        server.login(userL, this);
        user = userL;
        System.out.println("Autentificarea e ok!!! " + user);
    }

    @FXML
    public void initialize(){
        btnStartGame.setDisable(true);
        for (int i = 1; i <= 16; i++) {
            String btnId = "btne" + i;
            selectedButton(btnId).setDisable(true);
        }
    }

    public void setServer(IServices s) {
        server = s;
    }

    public void setModel() {

    }

    private void alertStartGame(Game game){

        actualGame = game;
        System.out.println(actualGame);
        if(Objects.equals(actualGame.getUser1(), user.getID())){

            LabelUser1.setText(actualGame.getUser1());
            LabelUser2.setText(actualGame.getUser2());

            for (int i = 1; i <= 16; i++) {
                String btnId = "btne" + i;
                selectedButton(btnId).setDisable(false);
            }
        } else {
            LabelUser2.setText(actualGame.getUser1());
            LabelUser1.setText(actualGame.getUser2());
        }

        Alert alert = new Alert(Alert.AlertType.INFORMATION);
        alert.setTitle("Information Dialog");
        alert.setHeaderText(null);
        alert.setContentText("Game started!" + game.toString());
        alert.showAndWait();
    }

    @Override
    public void gameUpdate(Game game) {
        Platform.runLater(()->{
            alertStartGame(game);
        });
    }

    @Override
    public void attackUpdate(AttackDTO attack) throws ServiceException {
        Platform.runLater(()->{
            alertAttackGame(attack);
        });
    }

    private void alertAttackGame(AttackDTO attack) {
        actualGame = attack.getGame();
        if(Objects.equals(user.getID(), attack.getUser().getID())){
            Button atkBtn = selectedButton("btne"+attack.getAttack());
            for (int i = 1; i <= 16; i++) {
                String btnId = "btne" + i;
                selectedButton(btnId).setDisable(true);
            }
            if(Objects.equals(actualGame.getUser1(), user.getID())){
                Integer X2 = actualGame.getX2();
                Integer Y2 = actualGame.getY2();
                if(Objects.equals((X2/10-1)*4+X2%10, attack.getAttack()) || Objects.equals((Y2/10-1)*4+Y2%10, attack.getAttack())){
                    //atkBtn.setStyle("-fx-background-color: #ff0000; ");
                    atkBtn.setStyle("-fx-font-size:20");
                    atkBtn.setText("X");
                } else {
                    //atkBtn.setStyle("-fx-background-color: rgb(0,255,208); ");
                    atkBtn.setStyle("-fx-font-size:20");
                    atkBtn.setText("0");
                }
            } else {
                Integer X1 = actualGame.getX1();
                Integer Y1 = actualGame.getY1();
                if(Objects.equals((X1/10-1)*4+X1%10, attack.getAttack()) || Objects.equals((Y1/10-1)*4+Y1%10, attack.getAttack())){
                    //atkBtn.setStyle("-fx-background-color: #ff0000; ");
                    atkBtn.setStyle("-fx-font-size:20");
                    atkBtn.setText("X");
                } else {
                    //atkBtn.setStyle("-fx-background-color: rgb(0,255,208); ");
                    atkBtn.setStyle("-fx-font-size:20");
                    atkBtn.setText("0");
                }
            }
        } else {
            Button atkBtn = selectedButton("btn"+attack.getAttack());
            atkBtn.setStyle("-fx-font-size:20");
            atkBtn.setText("X");
            for (int i = 1; i <= 16; i++) {
                String btnId = "btne" + i;
                Button ibtn = selectedButton(btnId);
                if(Objects.equals(ibtn.getText(), ""))
                    ibtn.setDisable(false);
            }
        }

        if(Objects.equals(attack.getGame().getWinner(), user.getID())){
            Alert alert = new Alert(Alert.AlertType.INFORMATION);
            alert.setTitle(user.getID());
            alert.setHeaderText(null);
            alert.setContentText("YOU WIN!!");
            alert.showAndWait();
        } else if (!Objects.equals(attack.getGame().getWinner(), "")){
            Alert alert = new Alert(Alert.AlertType.INFORMATION);
            alert.setTitle(user.getID());
            alert.setHeaderText(null);
            alert.setContentText("YOU LOSE!!");
            alert.showAndWait();
        }
    }

    public void handleLogout(ActionEvent actionEvent) {
        logout();
        ((Node) (actionEvent.getSource())).getScene().getWindow().hide();
    }

    public void chooseBoatLocation(ActionEvent event) {
        int posx=0, posy=0;
        if (!counter) {
            String buttonId = ((Control) event.getSource()).getId();
            System.out.println(buttonId);

            Button pressedBtn = selectedButton(buttonId);
            pressedBtn.setStyle("-fx-background-color: #001aff; ");

            for (int i = 1; i <= 16; i++) {
                String btnId = "btn" + i;
                selectedButton(btnId).setDisable(true);
                if(selectedButton(btnId) == pressedBtn){
                    posx = (i-1)/4+1;
                    posy = (i-1)%4+1;
                    x = posx*10 + posy;
                }
            }
            int idCalc;
            posx--;
            if(posx!=0){
                idCalc = (posx-1)*4+posy;
                selectedButton("btn"+idCalc).setDisable(false);
            }
            posx++;
            posy--;
            if(posy!=0){
                idCalc = (posx-1)*4+posy;
                selectedButton("btn"+idCalc).setDisable(false);
            }
            posy++;
            posx++;
            if(posx!=5){
                idCalc = (posx-1)*4+posy;
                selectedButton("btn"+idCalc).setDisable(false);
            }
            posx--;
            posy++;
            if(posy!=5){
                idCalc = (posx-1)*4+posy;
                selectedButton("btn"+idCalc).setDisable(false);
            }
            counter = true;
        } else {
            String buttonId = ((Control) event.getSource()).getId();
            System.out.println(buttonId);

            Button pressedBtn = selectedButton(buttonId);
            pressedBtn.setStyle("-fx-background-color: #001aff; ");

            for (int i = 1; i <= 16; i++) {
                String btnId = "btn" + i;
                selectedButton(btnId).setDisable(true);
                if(selectedButton(btnId) == pressedBtn){
                    posx = (i-1)/4+1;
                    posy = (i-1)%4+1;
                    y = posx*10 + posy;
                }
            }
            btnStartGame.setDisable(false);
        }

    }

    private Button selectedButton(String id) {
        return switch (id) {
            case "btn1" -> btn1;
            case "btn2" -> btn2;
            case "btn3" -> btn3;
            case "btn4" -> btn4;
            case "btn5" -> btn5;
            case "btn6" -> btn6;
            case "btn7" -> btn7;
            case "btn8" -> btn8;
            case "btn9" -> btn9;
            case "btn10" -> btn10;
            case "btn11" -> btn11;
            case "btn12" -> btn12;
            case "btn13" -> btn13;
            case "btn14" -> btn14;
            case "btn15" -> btn15;
            case "btn16" -> btn16;
            case "btne1" -> btne1;
            case "btne2" -> btne2;
            case "btne3" -> btne3;
            case "btne4" -> btne4;
            case "btne5" -> btne5;
            case "btne6" -> btne6;
            case "btne7" -> btne7;
            case "btne8" -> btne8;
            case "btne9" -> btne9;
            case "btne10" -> btne10;
            case "btne11" -> btne11;
            case "btne12" -> btne12;
            case "btne13" -> btne13;
            case "btne14" -> btne14;
            case "btne15" -> btne15;
            case "btne16" -> btne16;
            default -> null;
        };
    }

    public void startGame(ActionEvent event) throws ServiceException {

        btnStartGame.setDisable(true);
        server.startGame(new UserBoatDTO(user, x, y), this);
        Alert alert = new Alert(Alert.AlertType.INFORMATION);
        alert.setTitle("Information Dialog");
        alert.setHeaderText(null);
        alert.setContentText("Looking for a game!");
        alert.showAndWait();
    }

    public void attack(ActionEvent event) throws ServiceException {
        String buttonId = ((Control) event.getSource()).getId();
        buttonId = buttonId.substring(4);
        System.out.println(buttonId);
        ((Control) event.getSource()).setDisable(true);
        server.attack(new AttackDTO(user, actualGame, Integer.valueOf(buttonId)), this);
    }
}

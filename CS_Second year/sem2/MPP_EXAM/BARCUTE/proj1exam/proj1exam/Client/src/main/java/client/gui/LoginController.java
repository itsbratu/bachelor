package client.gui;


import javafx.event.ActionEvent;
import javafx.event.EventHandler;
import javafx.fxml.FXML;
import javafx.scene.Node;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.Alert;
import javafx.scene.control.Label;
import javafx.scene.control.PasswordField;
import javafx.scene.control.TextField;
import javafx.stage.Stage;
import javafx.stage.WindowEvent;
import model.User;
import service.IServices;
import service.ServiceException;

public class LoginController {
    @FXML
    private Label errorLabel;
    @FXML
    private TextField usernameTextField;
    @FXML
    private PasswordField passwordField;

    private IServices server;
    private MenuController menuCtrl;
    private User crtUser;
    Parent mainParent;

    public void setServer(IServices s){
        server=s;
    }
    public void setParent(Parent p){
        mainParent=p;
    }
    public void setUser(User user) {
        this.crtUser = user;
    }
    public void setChatController(MenuController menuController) {
        this.menuCtrl = menuController;
    }


    @FXML
    public void initialize(){ }

    @FXML
    public void handleLoginButtonAction(ActionEvent actionEvent) {
        String username = usernameTextField.getText();
        String password = passwordField.getText();
        crtUser = new User(username, password);
        System.out.println("In login " + crtUser);
        try {
            //menuCtrl.setUser(crtUser);
            //server.login(crtUser, menuCtrl);
            menuCtrl.login(username, password);
            Stage stage=new Stage();
            stage.setTitle("Main Window for " + crtUser.getID());
            stage.setScene(new Scene(mainParent));

            stage.setOnCloseRequest(new EventHandler<WindowEvent>() {
                @Override
                public void handle(WindowEvent event) {
                    menuCtrl.logout();
                    System.out.println("user logged out");
                    System.exit(0);
                }
            });

            stage.show();
            //menuCtrl.setModel();
            ((Node)(actionEvent.getSource())).getScene().getWindow().hide();
            System.out.println("Client - " + username + " logged");

        } catch (ServiceException e) {
            Alert alert = new Alert(Alert.AlertType.INFORMATION);
            alert.setTitle("MPP chat");
            alert.setHeaderText("Authentication failure");
            alert.setContentText("Wrong username or password");
            alert.showAndWait();
        }
    }
}
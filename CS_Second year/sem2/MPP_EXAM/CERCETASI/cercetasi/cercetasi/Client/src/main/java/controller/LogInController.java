package controller;


import Services.ServiceInterface;
import concurs.domain.User;
import javafx.event.EventHandler;
import javafx.fxml.FXML;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.Alert;
import javafx.scene.control.PasswordField;
import javafx.scene.control.TextField;
import javafx.stage.Stage;
import javafx.stage.WindowEvent;


public class LogInController {
    ServiceInterface service;
    private Parent parent;
    //Stage primaryStage;

    private MainController ctrl;
    @FXML
    TextField username;
    @FXML
    PasswordField password;

    public void setParent(Parent parent){ this.parent=parent; }


    public void setServer(ServiceInterface service) {
        this.service = service;
    }
    public void setController(MainController controller){ this.ctrl=controller; }


    @FXML
    protected void onButtonLogInClick() throws Exception {
        String username = this.username.getText();
        String password = this.password.getText();
        this.username.clear();
        this.password.clear();
       // User user = service.findUser_username(username);
        if(username.isEmpty() || password.isEmpty()) {
            Alert errorAlert = new Alert(Alert.AlertType.ERROR);
            errorAlert.setHeaderText("Invalid username");
            errorAlert.showAndWait();
            return;
        }
        System.out.println(username+" "+password);
        User account=null;
        try {
            account=service.login(new User(username,password),ctrl);
            System.out.println("am trecut");

        } catch (Exception e) {
            Alert errorAlert = new Alert(Alert.AlertType.ERROR);
            errorAlert.setHeaderText("Invalid username2");
            errorAlert.showAndWait();
            return;
        }
        System.out.println("in connect");
        connect(account);
        this.password.getScene().getWindow().hide();

    }
    private void connect(User account) throws Exception {
        Stage stage=new Stage();
        stage.setTitle("Window for " +account.getUsername() + " at point nr " + account.getPunct());
        stage.setScene(new Scene(parent));
        ctrl.setAccount(account);
        ctrl.prepare();

        stage.setOnCloseRequest(new EventHandler<WindowEvent>() {
            @Override
            public void handle(WindowEvent event) {
                ctrl.logout();
                System.exit(0);
            }
        });

        stage.show();
        ctrl.setAccount(account);
        //((Node)(password.getScene().getScene()).getWindow().hide();
    }


}


import Services.ServiceInterface;
import controller.LogInController;
import controller.MainController;
import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.stage.Stage;
import objectProtocol.ServicesObjectProxy;

import java.io.IOException;
import java.util.Properties;

public class StartObjectClient  extends Application {
    private static int defaultPort =55556;
    private static String defaultServer="localhost";
    public static void main(String[] args) {
        launch(args);
    }

    @Override
    public void start(Stage primaryStage) throws Exception {
        Properties clientProps=new Properties();
        try {
            clientProps.load(StartObjectClient.class.getResourceAsStream("/client.properties"));
            System.out.println("Client properties set. ");
            clientProps.list(System.out);
        } catch (IOException e) {
            System.err.println("Cannot find client.properties "+e);
            return;
        }
        String serverIP=clientProps.getProperty("server.host",defaultServer);
        int serverPort= defaultPort;
        try{
            serverPort=Integer.parseInt(clientProps.getProperty("server.port"));
        }catch(NumberFormatException ex){
            System.err.println("Wrong port number "+ex.getMessage());
            System.out.println("Using default port: "+ defaultPort);
        }
        System.out.println("Using server IP "+serverIP);
        System.out.println("Using server port "+serverPort);

        ServiceInterface server=new ServicesObjectProxy(serverIP, serverPort);
        FXMLLoader loader = new FXMLLoader(
                getClass().getClassLoader().getResource("/logIn-View.fxml"));
        loader.setLocation(getClass().getResource("/logIn-View.fxml"));
        Parent root=loader.load();

        LogInController ctrl =
                loader.<LogInController>getController();
        ctrl.setServer(server);

        FXMLLoader mloader = new FXMLLoader(
                getClass().getClassLoader().getResource("/main-view.fxml"));
        mloader.setLocation(getClass().getResource("/main-view.fxml"));
        Parent croot=mloader.load();



        MainController chatCtrl =
                mloader.<MainController>getController();
        chatCtrl.setServer(server);

        ctrl.setController(chatCtrl);
        ctrl.setParent(croot);

        primaryStage.setTitle("Login Jumpings");
        primaryStage.setScene(new Scene(root));
        primaryStage.setWidth(800);
        primaryStage.show();
    }
}

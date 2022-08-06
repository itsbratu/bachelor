package client;

import client.gui.LoginController;
import client.gui.MenuController;
import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.stage.Stage;
import rpcprotocol.BarcuteServicesRpcProxy;
import service.IServices;

import java.io.IOException;
import java.util.Properties;

public class StartRpcClientFX extends Application {

    private Stage primaryStage;

    private static int defaultChatPort = 55555;
    private static String defaultServer = "localhost";

    @Override
    public void start(Stage primaryStage) throws Exception {
        System.out.println("In start");
        Properties clientProps = new Properties();

        try {
            clientProps.load(StartRpcClientFX.class.getResourceAsStream("/client.properties"));
            System.out.println("Client - Client properties set. ");
            clientProps.list(System.out);
        } catch (IOException e) {
            System.err.println("Cannot find client.properties " + e);
            return;
        }
        String serverIP = clientProps.getProperty("agency.server.host", defaultServer);
        int serverPort = defaultChatPort;

        try {
            serverPort = Integer.parseInt(clientProps.getProperty("agency.server.port"));
        } catch (NumberFormatException ex) {
            System.out.println("Client - in catch error");
            System.err.println("Wrong port number " + ex.getMessage());
            System.out.println("Using default port: " + defaultChatPort);
        }
        System.out.println("Using server IP " + serverIP);
        System.out.println("Using server port " + serverPort);

        IServices server = new BarcuteServicesRpcProxy(serverIP, serverPort);
//        IAgencyServices server = new ProtoAgencyProxy(serverIP, serverPort);

        //login view
        FXMLLoader loader = new FXMLLoader(getClass().getClassLoader().getResource("login-view.fxml"));
        Parent root=loader.load();
        LoginController ctrl =
                loader.<LoginController>getController();
        ctrl.setServer(server);

        //main stage view
        FXMLLoader cloader = new FXMLLoader(
                getClass().getClassLoader().getResource("main-view.fxml"));
        Parent croot=cloader.load();
        MenuController chatCtrl =
                cloader.<MenuController>getController();
        chatCtrl.setServer(server);

        ctrl.setChatController(chatCtrl);
        ctrl.setParent(croot);

        primaryStage.setTitle("MPP chat");
        primaryStage.setScene(new Scene(root, 800, 600));
        primaryStage.show();

    }
}
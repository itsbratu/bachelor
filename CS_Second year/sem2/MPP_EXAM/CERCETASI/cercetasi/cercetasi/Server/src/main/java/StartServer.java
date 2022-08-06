import concurs.database.ChildRepository;
import concurs.database.UserRepository;
import utils.AbstractServer;
import utils.ObjectConcurrentServer;

import java.io.IOException;
import java.util.Properties;

public class StartServer {
    private static int defaultPort=55555;
    public static void main(String[] args) {
        Properties serverProps=new Properties();
        try {
            serverProps.load(StartServer.class.getResourceAsStream("/server.properties"));
            System.out.println("Server properties set. ");
            serverProps.list(System.out);
        } catch (IOException e) {
            System.err.println("Cannot find server.properties "+e);
            return;
        }
        UserRepository userRepo=new UserRepository(serverProps);
        ChildRepository playersRepo = new ChildRepository(serverProps);
        ServiceImpl mainPageService=new ServiceImpl(userRepo,playersRepo);
        int serverPort=defaultPort;
        try {
            serverPort = Integer.parseInt(serverProps.getProperty("server.port"));
        }catch (NumberFormatException nef){
            System.err.println("Wrong  Port Number"+nef.getMessage());
            System.err.println("Using default port "+defaultPort);
        }
        System.out.println("Starting server on port: "+serverPort);
        AbstractServer server = new ObjectConcurrentServer(serverPort, mainPageService);
        try {
            server.start();
        } catch (Exception e) {
            System.err.println("Error starting the server" + e.getMessage());
        }
    }
}

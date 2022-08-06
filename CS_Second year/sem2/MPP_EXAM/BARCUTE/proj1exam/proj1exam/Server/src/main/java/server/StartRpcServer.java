package server;

import repository.GameOrmRepo;
import repository.GameRepo;
import repository.UserRepo;
import service.IServices;
import utils.AbstractServer;
import utils.BarcuteRpcConcurrentServer;
import utils.ServerException;

import java.io.IOException;
import java.util.Properties;

public class StartRpcServer {
    private static int defaultPort=55555;

    public static void main(String[] args) {
        Properties serverProps=new Properties();
        try {
            serverProps.load(StartRpcServer.class.getResourceAsStream("/server.properties"));
            System.out.println("Server properties set. ");
            serverProps.list(System.out);
        } catch (IOException e) {
            System.err.println("Cannot find chatserver.properties "+e);
            return;
        }
        UserRepo userRepo=new UserRepo(serverProps);
        System.out.println(userRepo.findOne("gigi"));
    //    GameRepo gameRepo=new GameRepo(serverProps);
        GameOrmRepo gameRepo=new GameOrmRepo(serverProps);
        IServices agencyServerImpl=new ServicesImpl(userRepo, gameRepo);
        int agencyServerPort = defaultPort;
        try {
            agencyServerPort = Integer.parseInt(serverProps.getProperty("agency.server.port"));
        }catch (NumberFormatException nef){
            System.err.println("Wrong  Port Number"+nef.getMessage());
            System.err.println("Using default port "+defaultPort);
        }
        System.out.println("Starting server on port: " + agencyServerPort);
        AbstractServer server = new BarcuteRpcConcurrentServer(agencyServerPort, agencyServerImpl);
        try {
            server.start();
        } catch (ServerException e) {
            System.err.println("Error starting the server" + e.getMessage());
        }finally {
            try {
                server.stop();
            }catch(ServerException e){
                System.err.println("Error stopping server "+e.getMessage());
            }
        }
    }
}

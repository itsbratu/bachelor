package objectProtocol;


import Services.ObserverInterface;
import Services.ServiceInterface;
import jumps.domain.Player;

import jumps.domain.User;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.net.Socket;
import java.util.List;

public class ClientObjectWorker implements Runnable, ObserverInterface {
        private ServiceInterface server;
        private Socket connection;

        private ObjectInputStream input;
        private ObjectOutputStream output;
        private volatile boolean connected;
    public ClientObjectWorker(ServiceInterface server, Socket connection) {
            this.server = server;
            this.connection = connection;
            try{
                output=new ObjectOutputStream(connection.getOutputStream());
                output.flush();
                input=new ObjectInputStream(connection.getInputStream());
                connected=true;
            } catch (IOException e) {
                e.printStackTrace();
            }
        }

        public void run() {
            while(connected){
                try {;
                    Object request=input.readObject();
                    System.out.println("Run of clientobjworker"+request);
                    Object response=handleRequest((Request)request);
                    System.out.println(response);
                    if (response!=null){
                        sendResponse((Response) response);
                    }
                } catch (IOException e) {
                    e.printStackTrace();
                } catch (ClassNotFoundException e) {
                    e.printStackTrace();
                }
                try {
                    Thread.sleep(1000);
                } catch (InterruptedException e) {
                    e.printStackTrace();
                }
            }
            try {
                input.close();
                output.close();
                connection.close();
            } catch (IOException e) {
                System.out.println("Error "+e);
            }
        }

        private Object handleRequest(Request request){
            Response response=null;
            if (request instanceof LoginRequest){
                System.out.println("Login request ...");
                LoginRequest logReq=(LoginRequest)request;
                User user= logReq.getUser();
                try {
                    User account=server.login(user,this);
                    System.out.println("aici");
                    return new LoginResponse(account);
                } catch ( Exception e) {
                    connected=false;
                    return new ErrorResponse(e.getMessage());
                }
            }

            if (request instanceof LogoutRequest){
                System.out.println("Logout request");
                LogoutRequest logReq=(LogoutRequest)request;
                User user= logReq.getUser();
                try {
                    server.logout(user, this);
                    // input.close();
                    // output.close();
                    //connection.close();
                    connected=false;
                    return new OkResponse();

                } catch (Exception e) {
                    return new ErrorResponse(e.getMessage());
                }
            }
            if (request instanceof PlayersRequest) {
                System.out.println("Players request ...");
                PlayersRequest logReq = (PlayersRequest) request;
                try {
                    System.out.println("aici");
                    return new PlayersResponse((List<Player>) server.getAllPlayers());
                } catch (Exception e) {
                    connected = false;
                    return new ErrorResponse(e.getMessage());
                }

            }
            if(request instanceof PointsRequest){
                System.out.println("Sell ticket request");
                PointsRequest pointsRequest=(PointsRequest) request;
                Player player = pointsRequest.getPlayer();
                Integer points= pointsRequest.getPoints();
                String status = pointsRequest.getStatus();
                try {
                    server.addPoints(player,points,status);
                    return new OkResponse();
                } catch (Exception e) {
                    return new ErrorResponse(e.getMessage());
                }
            }
            return response;
        }

        private void sendResponse(Response response) throws IOException{
            System.out.println("sending response "+response);
            output.writeObject(response);
            output.flush();
        }

    @Override
    public void addPoints(Player player, Integer points, String status) throws Exception {
        System.out.println("Points added "+player.getPoints());
        try {
            sendResponse(new PointsResponse(player,points,status));
        } catch (IOException e) {
            throw new Exception("Sending error: "+e);
        }
    }
}

package objectProtocol;



import Services.ObserverInterface;
import Services.ServiceInterface;
import jumps.domain.Player;
import jumps.domain.User;

import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.net.Socket;
import java.util.concurrent.BlockingQueue;
import java.util.concurrent.LinkedBlockingQueue;

public class ServicesObjectProxy implements ServiceInterface {
    private final String host;
    private final int port;

    private ObserverInterface client;

    private ObjectInputStream input;
    private ObjectOutputStream output;
    private Socket connection;

    private BlockingQueue<Response> qresponses;
    private volatile boolean finished;

    public ServicesObjectProxy(String host, int port) {
        this.host = host;
        this.port = port;
        //responses=new ArrayList<Response>();
        qresponses=new LinkedBlockingQueue<Response>();
       // this.service = service;
    }



    @Override
    public User login(User user, ObserverInterface client) throws Exception {

        initializeConnection();
        sendRequest(new LoginRequest(user));
        Response response=readResponse();System.out.println("in loginproxy");
        System.out.println("in proxy");
        if (response instanceof LoginResponse){
            System.out.println();
            this.client=client;
            return ((LoginResponse) response).getUser();
        }
        if (response instanceof OkResponse){
            this.client=client;
            return null;
        }
        if (response instanceof ErrorResponse){
            ErrorResponse err=(ErrorResponse)response;
            closeConnection();
            throw new Exception(err.getMessage());
        }
        return null;
    }


    @Override
    public void logout(User user, ObserverInterface client) throws Exception {
        sendRequest(new LogoutRequest(user));
        Response response=readResponse();
        closeConnection();
        if (response instanceof ErrorResponse){
            ErrorResponse err=(ErrorResponse)response;
            throw new Exception(err.getMessage());
        }

    }

    @Override
    public Iterable<Player> getAllPlayers() throws Exception {
        sendRequest(new PlayersRequest());
        Response response=readResponse();
        if (response instanceof ErrorResponse){
            ErrorResponse err=(ErrorResponse)response;
            throw new Exception(err.getMessage());
        }
        if(response instanceof PlayersResponse)
            return ((PlayersResponse)response).getPlayersResponse();
        return null;
    }

    @Override
    public void addPoints(Player player, Integer points, String status) throws Exception {
        sendRequest(new PointsRequest(player,points,status));
        System.out.println("player id: " + player.getId());
        Response response=readResponse();
        if (response instanceof ErrorResponse){
            ErrorResponse err=(ErrorResponse)response;
            throw new Exception(err.getMessage());
        }
        System.out.println("Ticket sold - proxy");

    }


    private void sendRequest(Request request)throws Exception {
        try {
            output.writeObject(request);
            output.flush();
        } catch (IOException e) {
            throw new  Exception("Error sending object "+e);
        }

    }

    private Response readResponse() throws Exception {
        Response response=null;
        try{
            System.out.println("in readReposne try");
            response=qresponses.take();
            System.out.println("response " + response);

        } catch (InterruptedException e) {
            e.printStackTrace();
        }
        System.out.println("in readReposne");
        System.out.println("response" + response);
        return response;
    }
    private void initializeConnection() {
        try {
            connection=new Socket(host,port);
            output=new ObjectOutputStream(connection.getOutputStream());
            output.flush();
            input=new ObjectInputStream(connection.getInputStream());
            finished=false;
            startReader();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    private void closeConnection() {
        finished=true;
        try {
            input.close();
            output.close();
            connection.close();
            client=null;
        } catch (IOException e) {
            e.printStackTrace();
        }

    }
    private void startReader(){
        Thread tw=new Thread(new ReaderThread());
        tw.start();
    }
    private class ReaderThread implements Runnable{
        public void run() {
            while(!finished){
                try {
                    System.out.println("waiting for response");
                    Object response=input.readObject();
                    System.out.println("in rum" + response);
                    System.out.println("response received "+response);
                    if (response instanceof UpdateResponse){
                        handleUpdate((UpdateResponse)response);
                    }else{
                        try {
                            qresponses.put((Response)response);
                        } catch (InterruptedException e) {
                            e.printStackTrace();
                        }
                    }
                } catch (IOException e) {
                    System.out.println("Reading error "+e);
                } catch (ClassNotFoundException e) {
                    System.out.println("Reading error "+e);
                }
            }
        }
    }
    private void handleUpdate(UpdateResponse update){

        if (update instanceof PointsResponse){
            PointsResponse pointsResponse=(PointsResponse) update;
            Player player =((PointsResponse) update).getPlayer();
            Integer points = ((PointsResponse) update).getPoints();
            String status = ((PointsResponse) update).getStatus();
            System.out.println("Some points were added");
            try{
                client.addPoints(player,points,status);
            }catch (Exception e){
                e.printStackTrace();
            }
        }
   }

}

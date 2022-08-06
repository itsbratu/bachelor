package rpcprotocol;

import model.AttackDTO;
import model.Game;
import model.User;
import model.UserBoatDTO;
import service.IObserver;
import service.IServices;
import service.ServiceException;
import utils.ServerException;

import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.net.Socket;

public class BarcuteClientRpcWorker implements Runnable, IObserver {
    private IServices server;
    private Socket connection;

    private ObjectInputStream input;
    private ObjectOutputStream output;
    private volatile boolean connected;

    public BarcuteClientRpcWorker(IServices server, Socket connection) {
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

    @Override
    public void run() {
        while(connected){
            try {
                Object request = input.readObject();
                System.out.println("Worker - Run of ClientRpcWorker" + request);
                Response response = handleRequest((Request)request);
                System.out.println("Worker - Responese " + response);
                if (response != null){
                    sendResponse(response);
                }
            } catch (IOException | ClassNotFoundException e) {
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

    private static Response okResponse=new Response.Builder().type(ResponseType.OK).build();
    //  private static Response errorResponse=new Response.Builder().type(ResponseType.ERROR).build();

    private Response handleRequest(Request request){
        Response response = null;
        if (request.type()== RequestType.LOGIN){
            System.out.println("Worker - Login request ..." + request.type());
            User user=(User) request.data();
            System.out.println("Worker - Logged client: " + user);
            try {
                server.login(user, this);
                //return okResponse;
                return new Response.Builder().type(ResponseType.OK).data(user).build();
            } catch (ServiceException e) {
                connected=false;
                return new Response.Builder().type(ResponseType.ERROR).data(e.getMessage()).build();
            }
        }
        if (request.type()== RequestType.LOGOUT){
            System.out.println("Worker - Logout request");
            // LogoutRequest logReq=(LogoutRequest)request;
            User user=(User) request.data();
            System.out.println("Worker - user: " + user);
            try {
                server.logout(user, this);
                connected=false;
                //return okResponse;
                return new Response.Builder().type(ResponseType.OK).data(user).build();

            } catch (ServiceException e) {
                return new Response.Builder().type(ResponseType.ERROR).data(e.getMessage()).build();
            }
        }
        if (request.type()== RequestType.START_GAME){
            System.out.println("START_GAME");
            UserBoatDTO userBoatDTO = (UserBoatDTO) request.data();
            try {
                server.startGame(userBoatDTO, this);
                return okResponse;
            } catch (ServiceException e) {
                return new Response.Builder().type(ResponseType.ERROR).data(e.getMessage()).build();
            }
        }
        if (request.type()== RequestType.ATTACK){
            System.out.println("ATTACK");
            AttackDTO attackDTO = (AttackDTO) request.data();
            try {
                server.attack(attackDTO, this);
                return okResponse;
            } catch (ServiceException e) {
                return new Response.Builder().type(ResponseType.ERROR).data(e.getMessage()).build();
            }
        }
//
//        if (request.type()== RequestType.GET_TRIPS){
//            System.out.println("Worker - Get Trips by dest and time Request ...");
//            TripDTO tripDTO = (TripDTO) request.data();
//            try {
//                Iterable<Trip> trips = server.searchTripByDestinationAndTime(tripDTO);
//                return new Response.Builder().type(ResponseType.GET_TRIPS).data(trips).build();
//
//            } catch (AgencyServicesException e) {
//                return new Response.Builder().type(ResponseType.ERROR).data(e.getMessage()).build();
//            }
//        }
//        if(request.type() == RequestType.GET_ALL_TRIPS) {
//            System.out.println("Worker - Get Trips Request ...");
//            AgencyUser user = (AgencyUser) request.data();
//            try {
//                Iterable<Trip> trips = server.getAllTrips(user, this);
//                return new Response.Builder().type(ResponseType.GET_ALL_TRIPS).data(trips).build();
//            } catch (AgencyServicesException e) {
//                e.printStackTrace();
//            }
//        }
        return response;
    }

    private void sendResponse(Response response) throws IOException{
        System.out.println("Worker - Sending response " + response);
        output.writeObject(response);
        output.flush();
    }

//    @Override
//    public void reservationMade(TripsDTO tripsDTO) throws AgencyServicesException {
//        Response resp=new Response.Builder().type(ResponseType.NEW_RESERVATION).data(tripsDTO).build();
//        System.out.println("Worker - Reservation made " + tripsDTO);
//        try {
//            sendResponse(resp);
//        } catch (IOException e) {
//            throw new AgencyServicesException("Sending error: "+e);
//        }
//    }

    @Override
    public void gameUpdate(Game game) throws ServiceException {
        Response resp=new Response.Builder().type(ResponseType.UPDATE_GAME).data(game).build();
        System.out.println("Game created notifying users " + game);
        try {
            sendResponse(resp);
        } catch (IOException e) {
            throw new ServiceException("Sending error: "+e);
        }
    }

    @Override
    public void attackUpdate(AttackDTO attack) throws ServiceException {
        Response resp=new Response.Builder().type(ResponseType.ATTACK).data(attack).build();
        System.out.println("Attack made notifying users " + attack);
        try {
            sendResponse(resp);
        } catch (IOException e) {
            throw new ServiceException("Sending error: "+e);
        }
    }
}

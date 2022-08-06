package rpcprotocol;

import model.AttackDTO;
import model.Game;
import model.User;
import model.UserBoatDTO;
import service.IObserver;
import service.IServices;
import service.ServiceException;

import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.net.Socket;
import java.util.concurrent.BlockingQueue;
import java.util.concurrent.LinkedBlockingQueue;

public class BarcuteServicesRpcProxy implements IServices {

    private String host;
    private int port;

    private IObserver client;

    private ObjectInputStream input;
    private ObjectOutputStream output;
    private Socket connection;

    private BlockingQueue<Response> qresponses;
    private volatile boolean finished;

    public BarcuteServicesRpcProxy(String host, int port) {
        this.host = host;
        this.port = port;
        qresponses=new LinkedBlockingQueue<Response>();
    }
    @Override
    public void login(User user, IObserver client) throws ServiceException {
        initializeConnection();
        Request req = new Request.Builder().type(RequestType.LOGIN).data(user).build();
        sendRequest(req);
        Response response = readResponse();
        if (response.type() == ResponseType.OK){
            this.client=client;
            System.out.println("Proxy - Client logged");
            return;
        }
        if (response.type() == ResponseType.ERROR){
            String err = response.data().toString();
            closeConnection();
            throw new ServiceException(err);
        }
    }

    @Override
    public void logout(User user, IObserver observer) throws ServiceException {
        Request req = new Request.Builder().type(RequestType.LOGOUT).data(user).build();
        sendRequest(req);
        Response response = readResponse();
        closeConnection();
        if (response.type() == ResponseType.ERROR){
            String err = response.data().toString();
            throw new ServiceException(err);
        }
    }

    @Override
    public void startGame(UserBoatDTO userBoatDTO, IObserver observer) throws ServiceException {
        Request req = new Request.Builder().type(RequestType.START_GAME).data(userBoatDTO).build();
        sendRequest(req);
        Response response = readResponse();
        if (response.type() == ResponseType.ERROR){
            String err = response.data().toString();
            throw new ServiceException(err);
        }
    }

    @Override
    public void attack(AttackDTO attack, IObserver observer) throws ServiceException {
        Request req = new Request.Builder().type(RequestType.ATTACK).data(attack).build();
        sendRequest(req);
        Response response = readResponse();
        if (response.type() == ResponseType.ERROR){
            String err = response.data().toString();
            throw new ServiceException(err);
        }
    }


//    @Override
//    public void makeReservation(RezervationDTO reservationDTO) throws AgencyServicesException {
//        Request req = new Request.Builder().type(RequestType.MAKE_RESERVATION).data(reservationDTO).build();
//        sendRequest(req);
//        Response response = readResponse();
//        if (response.type() == ResponseType.ERROR){
//            String err = response.data().toString();
//            throw new AgencyServicesException(err);
//        }
//        System.out.println("Proxy - Some tickets were reserved!");
//    }
//
//    @Override
//    public Iterable<Trip> searchTripByDestinationAndTime(TripDTO tripDTO) throws AgencyServicesException {
//        Request req = new Request.Builder().type(RequestType.GET_TRIPS).data(tripDTO).build();
//        sendRequest(req);
//        Response response = readResponse();
//        if(response.type() == ResponseType.ERROR) {
//            String err = response.data().toString();
//            throw new AgencyServicesException(err);
//        }
//        Iterable<Trip> trips =(Iterable<Trip>) response.data();
//        return trips;
//    }

//    @Override
//    public Iterable<Trip> getAllTrips(AgencyUser user, IAgencyObserver client) throws AgencyServicesException {
//        Request req = new Request.Builder().type(RequestType.GET_ALL_TRIPS).data(user).build();
//        sendRequest(req);
//        Response response = readResponse();
//        if(response.type() == ResponseType.ERROR) {
//            String err = response.data().toString();
//            throw new AgencyServicesException(err);
//        }
//        Iterable<Trip> trips =(Iterable<Trip>) response.data();
//        return trips;
//    }

    private void closeConnection() {
        finished = true;
        try {
            input.close();
            output.close();
            connection.close();
            client=null;
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    private void sendRequest(Request request) throws ServiceException {
        try {
            output.writeObject(request);
            output.flush();
        } catch (IOException e) {
            throw new ServiceException("Error sending object " + e);
        }

    }

    private Response readResponse() throws ServiceException {
        Response response=null;
        try{
            response=qresponses.take();
        } catch (InterruptedException e) {
            e.printStackTrace();
        }
        return response;
    }

    private void initializeConnection() throws ServiceException {
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

    private void startReader(){
        Thread tw=new Thread(new ReaderThread());
        tw.start();
    }

    private void handleUpdate(Response response) {
        if (response.type()== ResponseType.UPDATE_GAME){
            Game game = (Game) response.data();
            try {
                client.gameUpdate(game);
            } catch (ServiceException e) {
                e.printStackTrace();
            }
        } else if (response.type()== ResponseType.ATTACK){
            AttackDTO attackDTO = (AttackDTO) response.data();
            try {
                client.attackUpdate(attackDTO);
            } catch (ServiceException e) {
                e.printStackTrace();
            }
        }
    }

    private boolean isUpdate(Response response){
        return response.type()== ResponseType.UPDATE_GAME || response.type()== ResponseType.ATTACK;
    }



    private class ReaderThread implements Runnable{
        public void run() {
            while(!finished){
                try {
                    Object response=input.readObject();
                    System.out.println("Proxy - Response received " + response);
                    if (isUpdate((Response)response)){
                        handleUpdate((Response)response);
                    } else{
                        try {
                            qresponses.put((Response)response);
                        } catch (InterruptedException e) {
                            e.printStackTrace();
                        }
                    }
                } catch (IOException | ClassNotFoundException e) {
                    System.out.println("Reading error "+e);
                }
            }
        }
    }
}

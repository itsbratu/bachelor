package services;

import model.Game;

import java.rmi.Remote;
import java.rmi.RemoteException;
import java.util.ArrayList;

public interface IObserver extends Remote {
    void startGame() throws RemoteException;
    void updateInterface(ArrayList<String> litere, ArrayList<String> cuvinte, Integer puncte, Integer incercari, String mesajCuvant) throws RemoteException;
    void gameDone(Iterable<Game> games, ArrayList<String> cuvinte) throws RemoteException;
}

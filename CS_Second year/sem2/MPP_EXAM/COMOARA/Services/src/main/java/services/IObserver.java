package services;

import model.Game;
import repos.GameRepo;

import java.rmi.Remote;
import java.rmi.RemoteException;

public interface IObserver extends Remote {
    void startGame() throws RemoteException;
    void updateInterface(Integer puncte, Integer distanta, Integer incercari) throws RemoteException;
    void finishGame(Iterable<Game> games) throws RemoteException;
}

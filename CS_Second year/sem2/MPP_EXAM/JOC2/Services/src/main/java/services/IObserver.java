package services;

import model.Game;

import java.rmi.Remote;
import java.rmi.RemoteException;

public interface IObserver extends Remote {
    void startGame() throws RemoteException;
    void updateInterface(Integer puncte, Double distanta, Integer incercari) throws RemoteException;
    void gameDone(Boolean winner, Iterable<Game> games, Integer comoaraX, Integer comoaraY, Integer valoareComoara, Integer puncte) throws RemoteException;
}

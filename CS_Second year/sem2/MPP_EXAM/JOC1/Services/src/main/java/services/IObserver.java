package services;

import model.Game;

import java.rmi.Remote;
import java.rmi.RemoteException;

public interface IObserver extends Remote {
    void startGame() throws RemoteException;
    void updateInterface(Integer valoarePoz1, Integer valoarePoz2, Integer valoarePoz3, Integer valoarePoz4, Integer valoarePoz5, Integer bani, Integer incercari, Integer pozitie) throws RemoteException;
    void gameDone(Iterable<Game> games) throws RemoteException;
}

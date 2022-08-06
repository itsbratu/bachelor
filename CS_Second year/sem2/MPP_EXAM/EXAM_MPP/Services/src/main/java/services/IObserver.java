package services;

import model.Game;

import java.rmi.Remote;
import java.rmi.RemoteException;
import java.util.ArrayList;

public interface IObserver extends Remote {
    void startGame() throws RemoteException;
    void updateInterface() throws RemoteException;
    void gameDone() throws RemoteException;
}

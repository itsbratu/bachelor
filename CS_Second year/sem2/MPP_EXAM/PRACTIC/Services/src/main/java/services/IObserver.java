package services;

import model.User;
import model.Word;

import java.rmi.Remote;
import java.rmi.RemoteException;
import java.util.List;

public interface IObserver extends Remote {
    void startGame() throws RemoteException;
    void updateInterface(Integer puncte, Integer distanta, Integer incercari) throws RemoteException;
}

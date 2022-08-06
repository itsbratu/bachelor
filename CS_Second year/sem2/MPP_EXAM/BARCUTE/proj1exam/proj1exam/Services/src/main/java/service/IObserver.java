package service;

import model.AttackDTO;
import model.Game;

public interface IObserver {
    void gameUpdate(Game game) throws ServiceException;

    void attackUpdate(AttackDTO attack) throws ServiceException;
}

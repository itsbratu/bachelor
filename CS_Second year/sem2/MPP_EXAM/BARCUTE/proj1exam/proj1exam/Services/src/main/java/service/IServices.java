package service;

import model.AttackDTO;
import model.User;
import model.UserBoatDTO;

public interface IServices {
    void login(User user, IObserver observer) throws ServiceException;
    void logout(User user, IObserver observer) throws ServiceException;
    void startGame(UserBoatDTO userBoatDTO, IObserver observer) throws ServiceException;

    void attack(AttackDTO attack, IObserver observer) throws ServiceException;
}

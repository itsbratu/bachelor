package services;

import model.User;
import model.Word;

public interface IService {
    User login(IObserver client, String username, String password);
    void logout(IObserver client, String username);
    void updateUser(User user);
    void updateInterface();
    void startGame();
    void checkPos(int position);
    void gameDone(boolean winner);
}

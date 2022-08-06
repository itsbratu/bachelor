package services;

import model.User;

public interface IService {
    User login(IObserver client, String username, String password);
    void logout(IObserver client, String username);
    void updateUser(User user);
    void updateInterface();
    void startGame();
    void gameDone();
    void submitWord(String word);
}

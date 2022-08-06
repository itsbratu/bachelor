package Services;

import concurs.domain.Child;
import concurs.domain.User;

import java.time.LocalTime;

public interface ServiceInterface {
    User login(User user, ObserverInterface client) throws Exception;
    void logout(User user, ObserverInterface client)throws Exception;
    void addPoint(Child child, String time, Integer point) throws Exception;
    Iterable<Child> getAllPlayers() throws Exception;
}

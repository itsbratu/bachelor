package Services;

import jumps.domain.Player;
import jumps.domain.User;

public interface ServiceInterface {

    User login(User user, ObserverInterface client) throws Exception;
    void logout(User user, ObserverInterface client)throws Exception;

    Iterable<Player> getAllPlayers() throws Exception;
    void addPoints(Player player,Integer points,String status) throws Exception;

}

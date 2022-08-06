package Services;

import jumps.domain.Player;

public interface ObserverInterface {
    void addPoints(Player player,Integer points,String status) throws Exception;
}

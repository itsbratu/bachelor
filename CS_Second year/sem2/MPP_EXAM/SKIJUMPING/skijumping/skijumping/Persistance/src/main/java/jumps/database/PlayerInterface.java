package jumps.database;

import jumps.domain.Player;

public interface PlayerInterface {
    Player findOne(Integer id);
    Iterable<Player> findAll();
    Player update(Player player);


}

package repository;

import model.Game;

public interface GameInterface {
    Game findOne(Integer id);
    Iterable<Game> findAll();
    Game update(Game player);
    Iterable<Game> findGamesForUser(String id);
}

package repos;

import model.Game;

public interface IGameRepo {
    public Iterable<Game> getGames();
    public void saveGame(Game g);
    public Game findGame(Integer id);
}

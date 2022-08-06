package repos;

import model.Game;

public interface IGameRepo {
    public Iterable<Game> getAll();
    public void save(Game g);
}

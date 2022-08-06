package repository;


import com.j256.ormlite.dao.Dao;
import com.j256.ormlite.dao.DaoManager;
import com.j256.ormlite.jdbc.JdbcConnectionSource;
import com.j256.ormlite.support.ConnectionSource;
import model.Game;
import org.springframework.stereotype.Component;

import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;
import java.util.Objects;
import java.util.Properties;

@Component
public class GameOrmRepo implements GameInterface{
    private Dao<Game, Integer> utilizatorDao;
    ConnectionSource connectionSource = null;

    public GameOrmRepo(Properties porps) {
        try {
            connectionSource = new JdbcConnectionSource("jdbc:sqlite:identifier.sqlite");
            utilizatorDao = DaoManager.createDao(connectionSource, Game.class);
        } catch (SQLException throwables) {
            throwables.printStackTrace();
        } finally {
            if (connectionSource != null) {
                try {
                    connectionSource.close();
                } catch (Exception e) {
                    e.printStackTrace();
                }
            }
        }}

    //    @Override
    public Game save(Game entity) {
        try {
            utilizatorDao.create(entity);
            return entity;
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return null;
    }

    @Override
    public Game findOne(Integer id) {
        try {
            return utilizatorDao.queryForId(id);
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return null;
    }

    @Override
    public Iterable<Game> findAll() {
        try {
            return utilizatorDao.queryForAll();
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return null;
    }

    @Override
    public Game update(Game game) {
        try {
//            UpdateBuilder<Game, Integer> updateBuilder = utilizatorDao.updateBuilder();
//            set the criteria like you would a QueryBuilder
//            updateBuilder.where().eq("ID", game.getID());
//             update the value of your field(s)
//            updateBuilder.updateColumnValue("tries1", 1111111);
//            updateBuilder.update();
            utilizatorDao.update(game);
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return  null;
    }

    @Override
    public Iterable<Game> findGamesForUser(String id) {
        List<Game> games = new ArrayList<>();
       for(Game el : findAll())
       {
           if(Objects.equals(el.getUser1(), id) || Objects.equals(el.getUser2(), id))
               games.add(el);
       }
       return games;
    }

}

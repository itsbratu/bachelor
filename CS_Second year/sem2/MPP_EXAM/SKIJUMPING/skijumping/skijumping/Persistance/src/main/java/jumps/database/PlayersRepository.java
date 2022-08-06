package jumps.database;

import com.j256.ormlite.dao.Dao;
import com.j256.ormlite.dao.DaoManager;
import com.j256.ormlite.jdbc.JdbcConnectionSource;
import com.j256.ormlite.support.ConnectionSource;
import jumps.domain.Player;
import jumps.domain.User;
import org.springframework.stereotype.Component;

import java.sql.SQLException;
import java.util.Properties;
@Component
public class PlayersRepository implements PlayerInterface{
    private Dao<Player, Integer> utilizatorDao;
    ConnectionSource connectionSource = null;

    public PlayersRepository(Properties porps) {
        try {
            connectionSource = new JdbcConnectionSource("jdbc:sqlite:identifier.sqlite");
            utilizatorDao = DaoManager.createDao(connectionSource, Player.class);
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

    @Override
    public Player findOne(Integer id) {
        try {
            return utilizatorDao.queryForId(id);
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return null;
    }

    @Override
    public Iterable<Player> findAll() {
        try {
            return utilizatorDao.queryForAll();
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return null;
    }

    @Override
    public Player update(Player player) {
        try {
            utilizatorDao.update(player);
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return  null;
    }
}

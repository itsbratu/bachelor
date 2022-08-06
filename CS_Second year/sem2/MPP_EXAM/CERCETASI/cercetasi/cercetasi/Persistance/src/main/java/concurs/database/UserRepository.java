package concurs.database;

import com.j256.ormlite.dao.Dao;
import com.j256.ormlite.dao.DaoManager;
import com.j256.ormlite.jdbc.JdbcConnectionSource;
import com.j256.ormlite.support.ConnectionSource;
import concurs.domain.User;

import java.sql.SQLException;
import java.util.Properties;

public class UserRepository  implements UserInterface{
    private Dao<User, Integer> utilizatorDao;
    ConnectionSource connectionSource = null;

    public UserRepository(Properties porps) {
        try {
            //connectionSource = new JdbcConnectionSource(porps.getProperty("jdbc.url"));
            connectionSource = new JdbcConnectionSource("jdbc:sqlite:identifier.sqlite");
            utilizatorDao = DaoManager.createDao(connectionSource, User.class);
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
    public User findOne(Integer id) {
        try {
            return utilizatorDao.queryForId(id);
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return null;
    }

    @Override
    public Iterable<User> findAll() {
        try {
            return utilizatorDao.queryForAll();
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return null;
    }
}

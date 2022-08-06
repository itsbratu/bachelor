package concurs.database;

import com.j256.ormlite.dao.Dao;
import com.j256.ormlite.dao.DaoManager;
import com.j256.ormlite.jdbc.JdbcConnectionSource;
import com.j256.ormlite.support.ConnectionSource;
import concurs.domain.Child;
import org.springframework.stereotype.Component;

import java.sql.SQLException;
import java.util.Properties;
@Component
public class ChildRepository implements ChildInterface{
    private Dao<Child, Integer> utilizatorDao;
    ConnectionSource connectionSource = null;

    public ChildRepository(Properties porps) {
        try {
            connectionSource = new JdbcConnectionSource("jdbc:sqlite:identifier.sqlite");
            utilizatorDao = DaoManager.createDao(connectionSource, Child.class);
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
    public Child findOne(Integer id) {
        try {
            return utilizatorDao.queryForId(id);
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return null;
    }

    @Override
    public Iterable<Child> findAll() {
        try {
            return utilizatorDao.queryForAll();
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return null;
    }

    @Override
    public Child update(Child player) {
        try {
            utilizatorDao.update(player);
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return  null;
    }

    public Child save(Child child)
    {
        try {
            utilizatorDao.create(child);
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return null;
    }
}

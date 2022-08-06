package repository;

import model.User;
import utils.JdbcUtils;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;
import java.util.Properties;

public class UserRepo {
    private final JdbcUtils dbUtils;

    public JdbcUtils getDbUtils() {
        return dbUtils;
    }

    public UserRepo(Properties props) {
        dbUtils = new JdbcUtils(props);
    }

    public User findOne(String id) {
        Connection conn = dbUtils.getConnection();
        User user = null;
        try(PreparedStatement preparedStatement = conn.prepareStatement("select * from Users where ID = ?")){

            preparedStatement.setString(1, id);

            try(ResultSet resultSet = preparedStatement.executeQuery()){
                while (resultSet.next()){
                    String password = resultSet.getString("password");
                    user = new User(id,password);
                }
            }
        } catch (SQLException e) {
            System.err.println("Error DB "+e);
        }
        return user;
    }

    public Iterable<User> findAll() {
        Connection conn = dbUtils.getConnection();
        List<User> users =new ArrayList<>();
        try(PreparedStatement preparedStatement = conn.prepareStatement("select * from Users")){

            try(ResultSet resultSet = preparedStatement.executeQuery()){
                while (resultSet.next()){
                    String ID = resultSet.getString("ID");
                    String password = resultSet.getString("password");
                    users.add(new User(ID,password));
                }
            }
        } catch (SQLException e) {
            System.err.println("Error DB "+e);
        }
        return users;
    }
}

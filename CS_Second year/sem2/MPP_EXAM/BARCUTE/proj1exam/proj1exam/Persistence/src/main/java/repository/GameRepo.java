package repository;

import model.Game;
import model.User;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;
import utils.JdbcUtils;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;
import java.util.Properties;

public class GameRepo {

    private final JdbcUtils dbUtils;

    public JdbcUtils getDbUtils() {
        return dbUtils;
    }

    public GameRepo(Properties props) {
        dbUtils = new JdbcUtils(props);
    }

    public Game findOne(Integer id) {
        Connection conn = dbUtils.getConnection();
        Game game = null;
        try(PreparedStatement preparedStatement = conn.prepareStatement("select * from Games where ID = ?")){

            preparedStatement.setInt(1, id);

            try(ResultSet resultSet = preparedStatement.executeQuery()){
                while (resultSet.next()){

                    String user1 = resultSet.getString("user1");
                    String user2 = resultSet.getString("user2");
                    String winner = resultSet.getString("winner");
                    Integer x1 = resultSet.getInt("x1");
                    Integer y1 = resultSet.getInt("y1");
                    Integer x2 = resultSet.getInt("x2");
                    Integer y2 = resultSet.getInt("y2");
                    Integer tries1 = resultSet.getInt("tries1");
                    Integer tries2 = resultSet.getInt("tries2");

                    game = new Game(id, user1, user2, winner, x1, y1, x2, y2, tries1, tries2);
                }
            }
        } catch (SQLException e) {
            System.err.println("Error DB "+e);
        }
        return game;
    }

    public Iterable<Game> findAll() {
        Connection conn = dbUtils.getConnection();
        List<Game> games =new ArrayList<>();
        try(PreparedStatement preparedStatement = conn.prepareStatement("select * from Games")){

            try(ResultSet resultSet = preparedStatement.executeQuery()){
                while (resultSet.next()){
                    Integer ID = resultSet.getInt("ID");
                    String user1 = resultSet.getString("user1");
                    String user2 = resultSet.getString("user2");
                    String winner = resultSet.getString("winner");
                    Integer x1 = resultSet.getInt("x1");
                    Integer y1 = resultSet.getInt("y1");
                    Integer x2 = resultSet.getInt("x2");
                    Integer y2 = resultSet.getInt("y2");
                    Integer tries1 = resultSet.getInt("tries1");
                    Integer tries2 = resultSet.getInt("tries2");

                    games.add(new Game(ID, user1, user2, winner, x1, y1, x2, y2, tries1, tries2));
                }
            }
        } catch (SQLException e) {
            System.err.println("Error DB "+e);
        }
        return games;
    }

    public Iterable<Game> findGamesForUser(String id) {
        Connection conn = dbUtils.getConnection();
        List<Game> games =new ArrayList<>();
        try(PreparedStatement preparedStatement = conn.prepareStatement("select * from Games where user1=? or user2=?")){
            preparedStatement.setString(1, id);
            preparedStatement.setString(2, id);
            try(ResultSet resultSet = preparedStatement.executeQuery()){
                while (resultSet.next()){
                    Integer ID = resultSet.getInt("ID");
                    String user1 = resultSet.getString("user1");
                    String user2 = resultSet.getString("user2");
                    String winner = resultSet.getString("winner");
                    Integer x1 = resultSet.getInt("x1");
                    Integer y1 = resultSet.getInt("y1");
                    Integer x2 = resultSet.getInt("x2");
                    Integer y2 = resultSet.getInt("y2");
                    Integer tries1 = resultSet.getInt("tries1");
                    Integer tries2 = resultSet.getInt("tries2");

                    games.add(new Game(ID, user1, user2, winner, x1, y1, x2, y2, tries1, tries2));
                }
            }
        } catch (SQLException e) {
            System.err.println("Error DB "+e);
        }
        return games;
    }

    public void update(Game game) {
        Connection conn = dbUtils.getConnection();
        try(PreparedStatement preparedStatement = conn.prepareStatement("update Games set winner=?, tries1=?, tries2=? where ID = ?")){

            preparedStatement.setString(1, game.getWinner());
            preparedStatement.setInt(2, game.getTries1());
            preparedStatement.setInt(3, game.getTries2());
            preparedStatement.setInt(4, game.getID());

            preparedStatement.executeUpdate();
        } catch (SQLException e) {
            System.err.println("Error DB "+e);
        }
    }

    public Game save(Game game){
        Connection conn = dbUtils.getConnection();
        try(PreparedStatement preparedStatement = conn.prepareStatement("insert into Games (user1, user2, winner, x1, y1, x2, y2, tries1, tries2) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)")){

            preparedStatement.setString(1, game.getUser1());
            preparedStatement.setString(2, game.getUser2());
            preparedStatement.setString(3, game.getWinner());
            preparedStatement.setInt(4, game.getX1());
            preparedStatement.setInt(5, game.getY1());
            preparedStatement.setInt(6, game.getX2());
            preparedStatement.setInt(7, game.getY2());
            preparedStatement.setInt(8, game.getTries1());
            preparedStatement.setInt(9, game.getTries2());

            preparedStatement.executeUpdate();

            ResultSet rs = preparedStatement.getGeneratedKeys();
            if (rs.next()) {
                int newId = rs.getInt(1);
                game.setID(newId);
            }
        } catch (SQLException e) {
            System.err.println("Error DB "+e);
        }
        return game;
    }
}

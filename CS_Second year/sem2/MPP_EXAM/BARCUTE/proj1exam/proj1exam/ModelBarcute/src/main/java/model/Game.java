package model;

import com.j256.ormlite.field.DatabaseField;
import com.j256.ormlite.table.DatabaseTable;

import java.io.Serializable;

@DatabaseTable(tableName = "Games")
public class Game implements Serializable {
    @DatabaseField(generatedId = true,allowGeneratedIdInsert = true, columnName = "ID")
    private Integer ID;
    @DatabaseField(columnName = "user1")
    private String user1;
    @DatabaseField(columnName = "user2")
    private String user2;
    @DatabaseField(columnName = "winner")
    private String winner;
    @DatabaseField(columnName = "x1")
    private Integer x1;
    @DatabaseField(columnName = "y1")
    private Integer y1;
    @DatabaseField(columnName = "x2")
    private Integer x2;
    @DatabaseField(columnName = "y2")
    private Integer y2;
    @DatabaseField(columnName = "tries1")
    private Integer tries1;
    @DatabaseField(columnName = "tries2")
    private Integer tries2;

    public Game(String user1, String user2, Integer x1, Integer y1, Integer x2, Integer y2) {
        this.user1 = user1;
        this.user2 = user2;
        this.x1 = x1;
        this.y1 = y1;
        this.x2 = x2;
        this.y2 = y2;
        tries1 = 0;
        tries2 = 0;
        winner = "";
    }

    public Game(Integer ID, String user1, String user2, String winner, Integer x1, Integer y1, Integer x2, Integer y2, Integer tries1, Integer tries2) {
        this.ID = ID;
        this.user1 = user1;
        this.user2 = user2;
        this.winner = winner;
        this.x1 = x1;
        this.y1 = y1;
        this.x2 = x2;
        this.y2 = y2;
        this.tries1 = tries1;
        this.tries2 = tries2;
    }

    public Game(){}

    public Integer getID() {
        return ID;
    }

    public void setID(Integer ID) {
        this.ID = ID;
    }

    public String getWinner() {
        return winner;
    }

    public void setWinner(String winner) {
        this.winner = winner;
    }

    public Integer getTries1() {
        return tries1;
    }

    public void setTries1(Integer tries1) {
        this.tries1 = tries1;
    }

    public Integer getTries2() {
        return tries2;
    }

    public void setTries2(Integer tries2) {
        this.tries2 = tries2;
    }

    public String getUser1() {
        return user1;
    }

    public String getUser2() {
        return user2;
    }

    public Integer getX1() {
        return x1;
    }

    public Integer getY1() {
        return y1;
    }

    public Integer getX2() {
        return x2;
    }

    public Integer getY2() {
        return y2;
    }

    @Override
    public String toString() {
        return "Game{" +
                "ID=" + ID +
                ", user1='" + user1 + '\'' +
                ", user2='" + user2 + '\'' +
                ", winner='" + winner + '\'' +
                ", x1=" + x1 +
                ", y1=" + y1 +
                ", x2=" + x2 +
                ", y2=" + y2 +
                ", tries1=" + tries1 +
                ", tries2=" + tries2 +
                '}';
    }
}

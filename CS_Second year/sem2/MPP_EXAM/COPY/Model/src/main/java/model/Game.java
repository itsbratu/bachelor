package model;

import javax.persistence.*;
import java.io.Serializable;

@Entity
@Table(name = "Game")
public class Game implements Serializable, Comparable<Game> {
    private Integer id;
    private String username;
    private Integer gameValue;
    private Integer winner;

    public Game() {
    }

    public Game(Integer id, String username, Integer gameValue, Integer winner){
        this.id = id;
        this.username = username;
        this.gameValue = gameValue;
        this.winner = winner;
    }

    @Id
    @Column(name="Id")
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    public Integer getId() {
        return id;
    }
    public void setId(Integer id) {
        this.id = id;
    }

    @Column(name = "Username")
    public String getUsername() {
        return username;
    }
    public void setUsername(String username) {
        this.username = username;
    }

    @Column(name="Gamevalue")
    public Integer getGameValue() {
        return gameValue;
    }
    public void setGameValue(Integer value) {
        this.gameValue = value;
    }

    @Column(name="Winner")
    public Integer getWinner() {
        return winner;
    }
    public void setWinner(Integer winner) {
        this.winner = winner;
    }

    @Override
    public int compareTo(Game o) {
        int comparePoints=((Game)o).getGameValue();
        return comparePoints-this.getGameValue();
    }

}

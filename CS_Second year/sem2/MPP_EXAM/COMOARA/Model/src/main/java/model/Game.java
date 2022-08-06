package model;

import javax.persistence.*;
import java.io.Serializable;

@Entity
@Table(name = "Game")
public class Game implements Serializable {
    private Integer id;
    private String username;
    private Integer gameValue;
    private Integer winner;
    private Integer treasureValue;

    public Game() {
    }

    public Game(Integer id, String username, Integer gameValue, Integer winner, Integer treasureValue){
        this.id = id;
        this.username = username;
        this.gameValue = gameValue;
        this.winner = winner;
        this.treasureValue = treasureValue;
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
    public void setGameValue(Integer gameValue) {
        this.gameValue = gameValue;
    }

    @Column(name="Winner")
    public Integer getWinner() {
        return winner;
    }
    public void setWinner(Integer winner) {
        this.winner = winner;
    }

    @Column(name="Treasurevalue")
    public Integer getTreasureValue() { return treasureValue; }
    public void setTreasureValue(Integer treasureValue) { this.treasureValue = treasureValue; }

}

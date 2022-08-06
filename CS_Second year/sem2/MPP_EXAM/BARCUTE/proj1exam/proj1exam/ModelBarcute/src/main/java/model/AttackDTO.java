package model;

import java.io.Serializable;

public class AttackDTO implements Serializable {
    private User user;
    private Game game;
    private Integer attack;

    public AttackDTO(User user, Game game, Integer attack) {
        this.user = user;
        this.game = game;
        this.attack = attack;
    }

    public AttackDTO(){

    }

    public User getUser() {
        return user;
    }

    public void setUser(User user) {
        this.user = user;
    }

    public Game getGame() {
        return game;
    }

    public void setGame(Game game) {
        this.game = game;
    }

    public Integer getAttack() {
        return attack;
    }

    public void setAttack(Integer attack) {
        this.attack = attack;
    }

    @Override
    public String toString() {
        return "AttackDTO{" +
                "user=" + user +
                ", game=" + game +
                ", attack=" + attack +
                '}';
    }
}

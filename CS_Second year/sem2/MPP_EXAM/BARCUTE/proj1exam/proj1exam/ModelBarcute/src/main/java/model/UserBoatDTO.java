package model;

import java.io.Serializable;

public class UserBoatDTO implements Serializable {
    private User user;
    private Integer x;
    private Integer y;

    public UserBoatDTO(User user, Integer x, Integer y) {
        this.user = user;
        this.x = x;
        this.y = y;
    }

    public User getUser() {
        return user;
    }

    public void setUser(User user) {
        this.user = user;
    }

    public Integer getX() {
        return x;
    }

    public void setX(Integer x) {
        this.x = x;
    }

    public Integer getY() {
        return y;
    }

    public void setY(Integer y) {
        this.y = y;
    }
}

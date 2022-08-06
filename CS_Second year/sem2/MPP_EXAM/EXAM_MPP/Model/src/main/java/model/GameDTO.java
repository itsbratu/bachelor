package model;

import javax.persistence.*;
import java.io.Serializable;

public class GameDTO {
    private String username;
    private Integer gameValue;

    public GameDTO() {
    }

    public GameDTO(String username, Integer gameValue){
        this.username = username;
        this.gameValue = gameValue;
    }

    public String getUsername() {
        return username;
    }
    public void setUsername(String username) {
        this.username = username;
    }

    public Integer getGameValue() {
        return gameValue;
    }
    public void setGameValue(Integer value) {
        this.gameValue = value;
    }
}

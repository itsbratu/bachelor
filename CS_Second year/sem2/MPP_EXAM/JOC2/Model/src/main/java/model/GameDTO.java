package model;

import javax.persistence.*;
import java.io.Serializable;

public class GameDTO {
    private String username;
    private Integer gameValue;
    private String found;

    public GameDTO() {
    }

    public GameDTO(String username, Integer gameValue, String found){
        this.username = username;
        this.gameValue = gameValue;
        this.found = found;
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

    public String getFound() { return found;}
    public void setFound(String found) { this.found = found; }
}

package model;

import java.io.Serializable;

public class User implements Serializable {
    private String ID;
    private String password;

    public User(String ID, String password) {
        this.ID = ID;
        this.password = password;
    }

    public User(){}

    public String getID() {
        return ID;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    @Override
    public String toString() {
        return "User{" +
                "ID='" + ID + '\'' +
                ", password='" + password + '\'' +
                '}';
    }
}

package domain;

import java.util.List;
import java.util.Objects;

public class User extends Entity<Long>{
    private String mail;
    private String password;
    private String name;
    private List<User> friends;

    public User(String mail, String password , String name) {
        this.mail = mail;
        this.password = password;
        this.name = name;
    }

    public String getMail() { return mail; }

    public String getPassword() { return password; }

    public String getName() { return name; }

    public void setMail(String mail) { this.mail = mail;}

    public void setPassword(String password) {this.password = password;}

    public void setName(String name) { this.name = name;}

}

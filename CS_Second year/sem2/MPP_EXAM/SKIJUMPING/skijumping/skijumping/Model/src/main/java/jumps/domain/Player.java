package jumps.domain;

import com.j256.ormlite.field.DatabaseField;
import com.j256.ormlite.table.DatabaseTable;

import java.io.Serializable;
@DatabaseTable(tableName = "players")
public class Player implements Serializable {
    @DatabaseField(generatedId = true,allowGeneratedIdInsert = true, columnName = "id")
    private Integer id;
    @DatabaseField(columnName = "name")
    private String name;
    @DatabaseField(columnName = "status")
    private String status;
    @DatabaseField(columnName = "points")
    private Integer points;

    public Player(String name, String status, Integer points) {
        this.name = name;
        this.status = status;
        this.points = points;
    }

    public Player() {
    }

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getStatus() {
        return status;
    }

    public void setStatus(String status) {
        this.status = status;
    }

    public Integer getPoints() {
        return points;
    }

    public void setPoints(Integer points) {
        this.points = points;
    }
}

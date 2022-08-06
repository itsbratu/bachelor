package concurs.domain;

import com.j256.ormlite.field.DataType;
import com.j256.ormlite.field.DatabaseField;
import com.j256.ormlite.table.DatabaseTable;

import java.io.Serializable;
import java.time.LocalTime;
@DatabaseTable(tableName = "children")
public class Child implements Serializable {
    @DatabaseField(generatedId = true,allowGeneratedIdInsert = true, columnName = "id")
    private Integer id;
    @DatabaseField(columnName = "name")
    private String name;
    @DatabaseField(columnName = "time")
    private String time;
    @DatabaseField(columnName = "lastpoint")
    private Integer point;

    public Child(String name, String time, Integer points) {
        this.name = name;
        this.time = time;
        this.point = points;
    }

    public Child() {
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

    public String getTime() {
        return time;
    }

    public void setTime(String time) {
        this.time = time;
    }

    public Integer getPoint() {
        return point;
    }

    public void setPoint(Integer points) {
        this.point = points;
    }
}

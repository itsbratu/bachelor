package model;

public class Config {
    private Integer id;
    private Integer coordx;
    private Integer coordy;
    private Integer value;

    public Config() {
    }

    public Config(Integer id, Integer coordX, Integer coordY, Integer value){
        this.id = id;
        this.coordx = coordX;
        this.coordy = coordY;
        this.value = value;
    }

    public Integer getId() {
        return id;
    }
    public void setId(Integer ID) {
        this.id = ID;
    }

    public Integer getCoordx() {
        return coordx;
    }
    public void setCoordx(Integer coord) {
        this.coordx = coord;
    }

    public Integer getCoordy() {
        return coordy;
    }
    public void setCoordy(Integer coord) {
        this.coordy = coord;
    }

    public Integer getValue() {
        return value;
    }
    public void setValue(Integer value) {
        this.value = value;
    }

    @Override
    public String toString() {
        return "Config{" +
                "ID=" + id +
                " CoordX= " + coordx +
                " CoordY="  + coordy +
                " Value= " + value +
                '}';
    }

}

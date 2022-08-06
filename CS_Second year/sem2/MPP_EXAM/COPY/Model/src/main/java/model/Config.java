package model;

public class Config {
    private Integer id;
    private Integer firstValue;
    private Integer secondValue;
    private Integer thirdValue;
    private Integer forthValue;
    private Integer fifthValue;

    public Config() {
    }

    public Config(Integer id, Integer value1, Integer value2, Integer value3, Integer value4, Integer value5){
        this.id = id;
        this.firstValue = value1;
        this.secondValue = value2;
        this.thirdValue = value3;
        this.forthValue = value4;
        this.fifthValue = value5;
    }

    public Integer getFirstValue() {
        return firstValue;
    }
    public void setFirstValue(Integer value1) {
        this.firstValue = value1;
    }

    public Integer getSecondValue() {
        return secondValue;
    }
    public void setSecondValue(Integer value2) {
        this.secondValue = value2;
    }

    public Integer getThirdValue() {
        return thirdValue;
    }
    public void setThirdValue(Integer value3) {
        this.thirdValue = value3;
    }

    public Integer getForthValue() {
        return forthValue;
    }
    public void setForthValue(Integer value4) {
        this.forthValue = value4;
    }

    public Integer getFifthValue() {
        return fifthValue;
    }
    public void setFifthValue(Integer value5) {
        this.fifthValue = value5;
    }

    @Override
    public String toString() {
        return "Meci{" +
                "ID=" + id +
                " Poz1= " + firstValue +
                " Poz1= " + secondValue +
                " Poz1= " + thirdValue +
                " Poz1= " + forthValue +
                " Poz1= " + fifthValue +
                '}';
    }

}

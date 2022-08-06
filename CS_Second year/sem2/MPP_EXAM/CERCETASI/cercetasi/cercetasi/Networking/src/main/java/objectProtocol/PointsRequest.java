package objectProtocol;


import concurs.domain.Child;

import java.time.LocalTime;

public class PointsRequest implements Request{
    private Child player;
    private String time;
    private Integer point;

    public PointsRequest(Child player, String time, Integer point) {
        this.player = player;
        this.time = time;
        this.point = point;
    }

    public Child getPlayer() {
        return player;
    }

    public void setPlayer(Child player) {
        this.player = player;
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

    public void setPoint(Integer point) {
        this.point = point;
    }
}

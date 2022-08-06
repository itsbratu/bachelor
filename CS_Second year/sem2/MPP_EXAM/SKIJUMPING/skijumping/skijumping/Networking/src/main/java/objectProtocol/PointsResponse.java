package objectProtocol;

import jumps.domain.Player;

public class PointsResponse implements  UpdateResponse{
    private Player player;
    private Integer points;
    private String status;

    public Player getPlayer() {
        return player;
    }

    public void setPlayer(Player player) {
        this.player = player;
    }

    public Integer getPoints() {
        return points;
    }

    public void setPoints(Integer points) {
        this.points = points;
    }

    public String getStatus() {
        return status;
    }

    public void setStatus(String status) {
        this.status = status;
    }

    public PointsResponse(Player player, Integer points, String status) {

        this.player = player;
        this.points = points;
        this.status = status;
    }
}

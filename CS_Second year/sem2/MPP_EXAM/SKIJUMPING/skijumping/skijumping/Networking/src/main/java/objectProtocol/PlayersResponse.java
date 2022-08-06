package objectProtocol;

import jumps.domain.Player;

import java.util.List;

public class PlayersResponse implements Response{
    List<Player> playerList;

    public PlayersResponse(List<Player> artistSpectacleResponse) {
        this.playerList = artistSpectacleResponse;
    }

    public Iterable<Player> getPlayersResponse() {
        return playerList;
    }
}

package objectProtocol;


import concurs.domain.Child;

import java.util.List;

public class PlayersResponse implements Response{
    List<Child> playerList;

    public PlayersResponse(List<Child> artistSpectacleResponse) {
        this.playerList = artistSpectacleResponse;
    }

    public Iterable<Child> getPlayersResponse() {
        return playerList;
    }
}

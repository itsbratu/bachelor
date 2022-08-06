package users;

import model.Config;
import model.Game;
import model.GameDTO;
import model.User;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import repos.GameRepo;
import repos.UserRepo;

import java.util.ArrayList;
import java.util.List;

@CrossOrigin
@RestController
@RequestMapping("/games")
public class UsersController {
    private static final String template="TemplatePaper";

    @Autowired
    private UserRepo userRepo;

    @RequestMapping(value = "/{username}", method = RequestMethod.GET)
    public ResponseEntity<?> getGamesUsername(@PathVariable String username){
        GameRepo gamesRepo = new GameRepo();
        List<GameDTO> games = new ArrayList<GameDTO>();
        for(Game g : gamesRepo.getGames()){
            if(g.getUsername().equals(username)){
                if(g.getWinner() == -1){
                    games.add(new GameDTO(g.getUsername(), g.getGameValue(), "NOT FOUND"));
                }
                else{
                    games.add(new GameDTO(g.getUsername(), g.getGameValue(), "FOUND"));
                }
            }
        }
        if(username == null){
            return new ResponseEntity<String>("User not found!", HttpStatus.NOT_FOUND);
        }
        else{
            return new ResponseEntity<List<GameDTO>>(games, HttpStatus.OK);
        }
    }

    @RequestMapping(method = RequestMethod.POST)
    public void createConfig(@RequestBody Config config){
        System.out.println("Inserting new config... : " + config.toString());
    }

}


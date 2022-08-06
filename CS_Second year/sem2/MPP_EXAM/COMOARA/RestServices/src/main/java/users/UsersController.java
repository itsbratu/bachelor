package users;

import model.Game;
import model.User;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.Configuration;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import repos.GameRepo;
import repos.UserRepo;

import java.util.ArrayList;
import java.util.List;

@SuppressWarnings("ALL")
@CrossOrigin
@RestController
@RequestMapping("/users")
public class UsersController {
    private static final String template="TemplatePaper";

    @Autowired
    private UserRepo userRepo;

    @RequestMapping(value = "/{username}", method = RequestMethod.GET)
    public ResponseEntity<?> getGamesUsername(@PathVariable String username){
        GameRepo gamesRepo = new GameRepo();
        List<Game> games = new ArrayList<Game>();
        for(Game g : gamesRepo.getAll()){
            games.add(g);
        }
        if(username == null){
            return new ResponseEntity<String>("User not found!", HttpStatus.NOT_FOUND);
        }
        else{
            return new ResponseEntity<List<Game>>(games, HttpStatus.OK);
        }
    }

}


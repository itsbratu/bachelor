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
import java.util.Random;

@CrossOrigin
@RestController
@RequestMapping("/games")
public class UsersController {
    private static final String template="TemplatePaper";

    @Autowired
    private UserRepo userRepo;

//    @RequestMapping(value = "/{username}", method = RequestMethod.GET)
//    public ResponseEntity<?> getGamesUsername(@PathVariable String username){
//        GameRepo gamesRepo = new GameRepo();
//        List<GameDTO> games = new ArrayList<GameDTO>();
//        for(Game g : gamesRepo.getGames()){
//            if(g.getUsername().equals(username)){
//                games.add(new GameDTO(g.getUsername(), g.getGameValue()));
//            }
//        }
//        if(username == null){
//            return new ResponseEntity<String>("User not found!", HttpStatus.NOT_FOUND);
//        }
//        else{
//            return new ResponseEntity<List<GameDTO>>(games, HttpStatus.OK);
//        }
//    }
//
//    @RequestMapping(method = RequestMethod.POST)
//    public void createConfig(@RequestBody Config config){
//        Random rand = new Random();
//        config.setId(rand.nextInt(100) + 1);
//        System.out.println("Inserting new config... : " + config.toString());
//    }

}


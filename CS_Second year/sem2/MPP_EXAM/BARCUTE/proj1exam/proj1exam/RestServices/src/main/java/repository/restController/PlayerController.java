package repository.restController;


import model.Game;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;
import repository.GameOrmRepo;
import repository.GameRepo;

import java.util.List;
import java.util.stream.StreamSupport;

@RestController
@CrossOrigin
@RequestMapping("/games")
public class PlayerController {
    @Autowired
    private GameOrmRepo gamesRepository;

    @RequestMapping(value="/{id}",method = RequestMethod.GET)
    public Game[] findAll(@PathVariable String id){
        int size = (int) StreamSupport.stream(gamesRepository.findGamesForUser(id).spliterator(), false).count();
        Game[] result = new Game[size];
        result = ((List<Game>) gamesRepository.findGamesForUser(id)).toArray(result);
        //result = ((List<Artist>) repository.findAll()).toArray(result);
        return result;
    }

    @RequestMapping(method = RequestMethod.GET)
    public Game[] findAll(){
        int size = (int) StreamSupport.stream(gamesRepository.findAll().spliterator(), false).count();
        Game[] result = new Game[size];
        result = ((List<Game>) gamesRepository.findAll()).toArray(result);

        //result = ((List<Artist>) repository.findAll()).toArray(result);
        return result;
    }

}

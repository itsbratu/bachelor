package jumps.restController;

import jumps.database.PlayersRepository;
import jumps.domain.Player;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.stream.StreamSupport;

@RestController
@RequestMapping("/players")
public class PlayerController {
    @Autowired
    private PlayersRepository playersRepository;

    @RequestMapping(method = RequestMethod.GET)
    public Player[] findAll(){
        int size = (int) StreamSupport.stream(playersRepository.findAll().spliterator(), false).count();
        Player[] result = new Player[size];
        int i = 0;
        for(Player a : playersRepository.findAll())
            result[i++] = a;
        //result = ((List<Artist>) repository.findAll()).toArray(result);
        return result;
    }
    @RequestMapping(value="/{status}",method = RequestMethod.GET)
    public Player[] findAll(@PathVariable String status){
        int size = (int) StreamSupport.stream(playersRepository.findAll().spliterator(), false).count();
        Player[] result = new Player[size];
        int i = 0;
        for(Player a : playersRepository.findAll())
            if(a.getStatus().equals(status))
                result[i++] = a;
        return result;
    }
}

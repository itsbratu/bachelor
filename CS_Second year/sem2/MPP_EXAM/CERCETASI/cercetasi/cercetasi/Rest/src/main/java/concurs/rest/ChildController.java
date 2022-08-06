package concurs.rest;

import concurs.database.ChildRepository;
import concurs.domain.Child;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

import java.util.stream.StreamSupport;
@RestController
@RequestMapping("/children")
public class ChildController {    @Autowired
private ChildRepository playersRepository;

    @RequestMapping(method = RequestMethod.GET)
    public Child[] findAll(){
        int size = (int) StreamSupport.stream(playersRepository.findAll().spliterator(), false).count();
        Child[] result = new Child[size];
        int i = 0;
        for(Child a : playersRepository.findAll())
            result[i++] = a;
        //result = ((List<Artist>) repository.findAll()).toArray(result);
        return result;
    }
    @RequestMapping(value="/{point}",method = RequestMethod.GET)
    public Child[] findAll(@PathVariable Integer point){
        int size = (int) StreamSupport.stream(playersRepository.findAll().spliterator(), false).count();
        Child[] result = new Child[size];
        int i = 0;
        for(Child a : playersRepository.findAll())
            if(a.getPoint() == point)
                result[i++] = a;
        return result;
    }
}


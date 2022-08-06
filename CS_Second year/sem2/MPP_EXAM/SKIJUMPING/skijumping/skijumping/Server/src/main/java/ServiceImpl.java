import Services.ObserverInterface;
import Services.ServiceInterface;
import jumps.database.PlayersRepository;
import jumps.database.UserRepository;
import jumps.domain.Player;
import jumps.domain.User;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;
import java.util.concurrent.ConcurrentHashMap;
import java.util.stream.Collectors;
import java.util.stream.StreamSupport;

public class ServiceImpl implements ServiceInterface {
    private UserRepository userRepository;
    private PlayersRepository playersRepository;
    private Map<String, ObserverInterface> loggedClients;

    public ServiceImpl(UserRepository userRepository,PlayersRepository playersRepository) {
        this.userRepository = userRepository;
        this.playersRepository = playersRepository;
        loggedClients=new ConcurrentHashMap<>();
    }


    public User findUser_username(String username) {
        List<User> user = new ArrayList<>();
        user.addAll(StreamSupport.stream(userRepository.findAll().spliterator(), false)
                .filter(x -> x.getUsername().compareTo(username) == 0)
                .collect(Collectors.toList()));
        if (user.isEmpty())
            return null;
        return user.get(0);
    }
    @Override
    public synchronized User login(User user, ObserverInterface client) throws Exception {
        System.out.println("entered login servicesImpl");
        User userR = findUser_username(user.getUsername());
        System.out.println("user found " + userR.getId());
        if (userR!=null){
            if(loggedClients.get(user.getUsername())!=null)
                throw new Exception("User already logged in.");
            System.out.println(userR.getUsername() + " userR");
            loggedClients.put(user.getUsername(), client);
            System.out.println("aici");
            return userR;
        }else {
            System.out.println("faild login");
            throw new Exception("Authentication failed.");
        }
    }

    @Override
    public synchronized void logout(User user, ObserverInterface client) throws Exception {
        System.out.println("entered logout concert.ServicesImpl");
        ObserverInterface localClient=loggedClients.remove(user.getUsername());
        if (localClient==null)
            throw new Exception("jumps.domain.User "+user.getId()+" is not logged in.");
    }

    @Override
    public synchronized Iterable<Player> getAllPlayers() {
        return playersRepository.findAll();
    }

    @Override
    public synchronized void addPoints(Player player, Integer points,String status) throws Exception {
        try {
            Player player1 = playersRepository.findOne(player.getId());
            player1.setPoints(player1.getPoints()+points);
            player1.setStatus(status);
            playersRepository.update(player1);
            loggedClients.forEach((x,y)->{
                try {
                    y.addPoints(player,points,status);
                } catch (Exception e) {
                    e.printStackTrace();
                }
            });
        } catch ( Exception e) {
            throw new Exception(e.getMessage());
        }

    }

}

package server;

import model.AttackDTO;
import model.Game;
import model.User;
import model.UserBoatDTO;
import repository.GameOrmRepo;
import repository.GameRepo;
import repository.UserRepo;
import service.IObserver;
import service.IServices;
import service.ServiceException;

import java.util.ArrayList;
import java.util.Map;
import java.util.Objects;
import java.util.concurrent.ConcurrentHashMap;

public class ServicesImpl implements IServices {
    private UserRepo userRepo;
    private GameOrmRepo gameRepo;
    private Map<String, IObserver> loggedClients;

    private Boolean x1;
    private Boolean y1;
    private Boolean x2;
    private Boolean y2;


    private User waitingUser;
    private User waitingUser2;
    private Integer waitingX;
    private Integer waitingY;

    public ServicesImpl(UserRepo userRepo, GameOrmRepo gameRepo) {
        this.userRepo = userRepo;
        this.gameRepo = gameRepo;
        x1 = false;
        y1 = false;
        x2 = false;
        y2 = false;
        loggedClients = new ConcurrentHashMap<>();
        waitingUser = null;
    }

    private final int defaultThreadsNo=5;
    @Override
    public synchronized void login(User user, IObserver client) throws ServiceException {
        System.out.println("entered login AgencyServicesImpl");
        User userR=userRepo.findOne(user.getID());
        if (Objects.equals(userR.getPassword(), user.getPassword())){
            if(loggedClients.get(user.getID())!=null)
                throw new ServiceException("User already logged in.");
            loggedClients.put(userR.getID(), client);
            System.out.println("ServiceImpl - all good here! " + loggedClients);
            //notifyFriendsLoggedIn(user);
        }else
            throw new ServiceException("Authentication failed.");
    }

    @Override
    public synchronized void logout(User user, IObserver client) throws ServiceException {
        System.out.println("entered logout AgencyServicesImpl" + user);
        IObserver localClient = loggedClients.remove(user.getID());
        if (localClient == null)
            throw new ServiceException("User " + user.getID() + " is not logged in.");
    }

    @Override
    public synchronized void startGame(UserBoatDTO user, IObserver client) throws ServiceException {
        if(waitingUser == null){
            waitingUser = user.getUser();
            waitingX = user.getX();
            waitingY = user.getY();
            System.out.println(waitingUser);
            System.out.println(user.getX());
            System.out.println(user.getY());
        } else {
            Game game = new Game(user.getUser().getID(), waitingUser.getID(), user.getX(), user.getY(), waitingX, waitingY);
            game = gameRepo.save(game);
            waitingUser2 = user.getUser();
            notifyUsers(game);
            waitingUser = null;
            waitingX = 0;
            waitingY = 0;

            x1 = false;
            y1 = false;
            x2 = false;
            y2 = false;

        }
    }

    @Override
    public synchronized void attack(AttackDTO attack, IObserver observer) throws ServiceException {
        if(Objects.equals(attack.getUser().getID(), attack.getGame().getUser1())){
            attack.getGame().setTries1(attack.getGame().getTries1()+1);
            Integer X2 = attack.getGame().getX2();
            Integer Y2 = attack.getGame().getY2();
            if(Objects.equals(attack.getAttack(), (X2/10-1)*4+X2%10)){
                x2 = true;
            } else if(Objects.equals(attack.getAttack(), (Y2/10-1)*4+Y2%10)){
                y2 = true;
            }
            if(x2 && y2){
                attack.getGame().setWinner(attack.getUser().getID());
            }
        } else {
            attack.getGame().setTries2(attack.getGame().getTries2()+1);
            Integer X1 = attack.getGame().getX1();
            Integer Y1 = attack.getGame().getY1();
            if(Objects.equals(attack.getAttack(), (X1/10-1)*4+X1%10)){
                x1 = true;
            } else if(Objects.equals(attack.getAttack(), (Y1/10-1)*4+Y1%10)){
                y1 = true;
            }
            if(x1 && y1){
                attack.getGame().setWinner(attack.getUser().getID());
            }
        }
        System.out.println(attack.getGame());
        gameRepo.update(attack.getGame());
        notifyAttack(attack);
    }

    private void notifyAttack(AttackDTO attack) throws ServiceException {
        IObserver client1 = loggedClients.get(attack.getGame().getUser1());
        client1.attackUpdate(attack);
        IObserver client2 = loggedClients.get(attack.getGame().getUser2());
        client2.attackUpdate(attack);
    }

    private synchronized void notifyUsers(Game game) throws ServiceException {
        IObserver client1 = loggedClients.get(waitingUser.getID());
        client1.gameUpdate(game);
        IObserver client2 = loggedClients.get(waitingUser2.getID());
        client2.gameUpdate(game);
    }

}

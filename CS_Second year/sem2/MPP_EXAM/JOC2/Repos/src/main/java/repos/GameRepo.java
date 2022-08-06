package repos;

import model.Game;
import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.hibernate.Transaction;

import java.util.List;

public class GameRepo implements IGameRepo {
    static SessionFactory sessionFactory;
    private JdbcUtils jdbcUtils=new JdbcUtils();

    public GameRepo() {
        System.out.println("Initializing WordRepo... ");
        sessionFactory=jdbcUtils.getSessionFactory();
    }


    //GET GAMES
    @Override
    public Iterable<Game> getGames() {
        try(Session session=sessionFactory.openSession()){
            Transaction tx=null;
            try{
                tx=session.beginTransaction();
                List<Game> games =
                        session.createQuery("from Game", Game.class)
                                .setFirstResult(0).setMaxResults(20).list();
                tx.commit();
                return games;
            }catch (Exception e){
                if (tx != null)
                    tx.rollback();
                System.out.println("No games found... ");
                e.printStackTrace();
                return null;
            }
        }
    }

    //SAVE GAME
    @Override
    public void saveGame(Game g) {
        try(Session session=sessionFactory.openSession()){
            Transaction tx = null;
            try {
                tx = session.beginTransaction();
                session.save(g);
                tx.commit();
                System.err.println("Am adaugat jocul");
            } catch (RuntimeException ex) {
                if (tx != null)
                    tx.rollback();
            }
        }
    }

    //FIND GAME
    @Override
    public Game findGame(Integer id) {
        try(Session session=sessionFactory.openSession()){
            Transaction tx=null;
            try{
                tx=session.beginTransaction();
                List<Game> games =
                        session.createQuery("from Game as g where g.id= ?", Game.class)
                                .setParameter(0, id)
                                .setFirstResult(0).setMaxResults(100).list();
                tx.commit();
                return games.get(0);
            }catch (Exception e){
                if (tx != null)
                    tx.rollback();
                e.printStackTrace();
                return null;
            }
        }
    }

}

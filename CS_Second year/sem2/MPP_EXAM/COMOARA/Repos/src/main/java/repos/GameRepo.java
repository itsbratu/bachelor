package repos;

import model.Game;
import model.User;
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

    @Override
    public Iterable<Game> getAll() {
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
                System.out.println("No users found... ");
                e.printStackTrace();
                return null;
            }
        }
    }

    @Override
    public void save(Game g){
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

}

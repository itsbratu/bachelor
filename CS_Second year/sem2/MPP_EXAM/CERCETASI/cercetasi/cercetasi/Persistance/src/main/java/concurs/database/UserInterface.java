package concurs.database;

import concurs.domain.User;

public interface UserInterface {
    User findOne(Integer id);
    Iterable<User> findAll();

}

package jumps.database;

import jumps.domain.User;

public interface UserInterface {
    User findOne(Integer id);
    Iterable<User> findAll();
}

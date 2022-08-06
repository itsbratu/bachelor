package concurs.database;

import concurs.domain.Child;

public interface ChildInterface {
    Child findOne(Integer id);
    Iterable<Child> findAll();
    Child update(Child child);
}

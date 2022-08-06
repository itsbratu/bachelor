package ro.ubbcluj.map.pb3.repository.file;

import ro.ubbcluj.map.pb3.domain.Utilizator;
import ro.ubbcluj.map.pb3.domain.validators.Validator;


import java.util.List;

public class UtilizatorFile extends AbstractFileRepository<Long, Utilizator> {

    public UtilizatorFile(String fileName, Validator<Utilizator> validator) {
        super(fileName, validator);
    }

    @Override
    public Utilizator extractEntity(List<String> attributes) {
        Utilizator us = new Utilizator(attributes.get(1) , attributes.get(2));
        us.setId(Long.parseLong(attributes.get(0)));
        return us;
    }

    @Override
    protected String createEntityAsString(Utilizator entity) {
        return entity.getId().toString() + ";" + entity.getLastName() + ";" + entity.getFirstName();
    }
}

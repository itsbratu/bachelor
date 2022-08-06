package model;

public abstract class Task {
    private String id;
    private String descriere;

    public Task(String id, String descriere) {
        this.id = id;
        this.descriere = descriere;
    }

    @Override
    public String toString() {
        return id + " " + descriere + "\n";
    }

    public abstract void execute();
}


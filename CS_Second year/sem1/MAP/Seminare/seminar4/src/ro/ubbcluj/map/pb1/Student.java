package ro.ubbcluj.map.pb1;

import java.util.Objects;

public class Student implements Comparable<Student>{
    private String nume;
    private float media;

    public Student(String nume, float media) {
        this.nume = nume;
        this.media = media;
    }

    @Override
    public String toString() {
        return "Student{" +
                "nume='" + nume + '\'' +
                ", media=" + media +
                '}';
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        Student student = (Student) o;
        return Float.compare(student.media, media) == 0 && Objects.equals(nume, student.nume);
    }

    @Override
    public int hashCode() {
        return Objects.hash(nume, media);
    }



    public String getNume() {
        return nume;
    }

    public float getMedia() {
        return media;
    }


    @Override
    public int compareTo(Student o) {
        return this.nume.compareTo(o.getNume());
    }
}

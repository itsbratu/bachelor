package ro.ubbcluj.map;

import ro.ubbcluj.map.pb1.Student;
import ro.ubbcluj.map.pb2.MyMap;
import ro.ubbcluj.map.pb3.domain.Utilizator;
import ro.ubbcluj.map.pb3.domain.validators.UtilizatorValidator;
import ro.ubbcluj.map.pb3.repository.Repository;
import ro.ubbcluj.map.pb3.repository.file.UtilizatorFile;

import java.util.Arrays;
import java.util.HashSet;
import java.util.Set;

public class Main {

    public static void main(String[] args) {
//        Student s1 = new Student("Dan", 4.5f);
//        Student s2 = new Student("Ana", 8.5f);
//        Student s3 = new Student("Dan", 4.5f);
//        Student s4 = new Student("Andrei", 1.1f);
//        Student s5 = new Student("Barbu", 10.0f);
//
//        Set<Student> set1 = new HashSet<>();
//        set1.addAll(Arrays.asList(s1, s2, s3, s4, s5));
//        System.out.println(set1);

        Repository<Long , Utilizator> repository = new UtilizatorFile("data/users.csv" , new UtilizatorValidator());


    }
}

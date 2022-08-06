package ro.ubbcluj.map.pb2;

import ro.ubbcluj.map.pb1.Student;

import java.util.Arrays;
import java.util.HashSet;
import java.util.Set;

public class TestPb2 {
    public static void main(String[] args) {
        Student s1 = new Student("Dan", 9.5f);
        Student s2 = new Student("Ana", 8.5f);
        Student s3 = new Student("Dan", 8.6f);
        Student s4 = new Student("Andrei", 9.75f);
        Student s5 = new Student("Barbu", 7f);

        MyMap map1 = new MyMap();
        map1.add(s1);
        map1.add(s2);
        map1.add(s3);
        map1.add(s4);
        map1.add(s5);
        map1.getEntries().forEach(x -> System.out.println(x));
    }
}

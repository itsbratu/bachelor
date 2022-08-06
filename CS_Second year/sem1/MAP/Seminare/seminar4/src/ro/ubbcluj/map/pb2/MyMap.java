package ro.ubbcluj.map.pb2;
import ro.ubbcluj.map.pb1.Student;

import java.util.*;

public class MyMap {

    private Map<Integer , List<Student>> gradesMap;

    private static class ComparatorDupaMedie implements Comparator<Integer>{
        @Override
        public int compare(Integer o1, Integer o2) {
            return o2 - o1;
        }
    }

    public void add(Student s){
        if(gradesMap.get(Math.round(s.getMedia())) == null){
            List <Student> studenti = new ArrayList<Student>();
            studenti.add(s);
            gradesMap.put(Math.round(s.getMedia()) , studenti);
        }else{
            gradesMap.get(Math.round(s.getMedia())).add(s);
        }
    }

    public Set<Map.Entry<Integer , List<Student>>> getEntries(){
        return gradesMap.entrySet();
    }
 
    public MyMap() {
        this.gradesMap = new TreeMap<>(new ComparatorDupaMedie());
    }
}

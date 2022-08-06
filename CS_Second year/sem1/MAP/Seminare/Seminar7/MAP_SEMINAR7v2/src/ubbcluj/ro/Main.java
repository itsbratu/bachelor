package ubbcluj.ro;

import domain.Nota;
import domain.NotaDto;
import domain.Student;
import domain.Tema;

import java.time.LocalDate;
import java.util.Arrays;
import java.util.List;
import java.util.function.Predicate;

public class Main {
    private static List<Student> getStudents() {
        Student s1 = new Student("andrei", 221);
        s1.setId(2l);
        Student s2 = new Student("dan", 222);
        s2.setId(2l);
        Student s3 = new Student("gigi", 221);
        s3.setId(2l);
        Student s4 = new Student("costel", 222);
        s4.setId(2l);
        return Arrays.asList(s1, s2, s3, s4);
    }
    private static List<Tema> getTeme() {
        return Arrays.asList(
                new Tema("t1", "desc1"),
                new Tema("t2", "desc2"),
                new Tema("t3", "desc3"),
                new Tema("t4", "desc4")
        );
    }
    private static List<Nota> getNote(List<Student> stud, List<Tema> teme) {
        return Arrays.asList(
                new Nota(stud.get(0), teme.get(0), 10d, LocalDate.of(2019, 11, 2), "profesor1"),
                new Nota(stud.get(1), teme.get(0), 9d, LocalDate.of(2019, 11, 2).minusWeeks(1), "profesor1"),
                new Nota(stud.get(1), teme.get(1), 10d, LocalDate.of(2019, 10, 20), "profesor2"),
                new Nota(stud.get(1), teme.get(2), 10d, LocalDate.of(2019, 10, 20), "profesor2"),
                new Nota(stud.get(2), teme.get(1), 7d, LocalDate.of(2019, 10, 28), "profesor1"),
                new Nota(stud.get(2), teme.get(3), 9d, LocalDate.of(2019, 10, 27), "profesor2"),
                new Nota(stud.get(1), teme.get(3), 10d, LocalDate.of(2019, 10, 29), "profesor2")
        );
    }

    /**
     * creati/afisati o lista de obiecte NotaDto apoi filtrati dupa profesor si grupa
     * (toate notele acordate de un anumit profesor, la o anumita grupa)
     * GENERALIZARE: FILTRU COMPUS
     */
    private static List<NotaDto> report1(List<Nota> note) {

        Predicate<Nota> filterByTeacher = x -> x.getProfesor().equals("profesor1");
        Predicate<Nota> filterByGroup = x -> x.getStudent().getGroup() == 221;
        Predicate<Nota> filterByAll = filterByTeacher.and(filterByGroup);

        return note.stream()
                .filter(filterByAll)
                .map(x -> new NotaDto(x.getStudent().getName() , x.getTema().getId() , x.getValue() ,
                        x.getProfesor()))
                .sorted((x,y) -> x.getStudentName().compareTo(y.getStudentName()))
                .toList();
    }

    /**
     * media notelor de lab pt fiecare student
     *
     * @param note
     */
    private static void report2(List<Nota> note) {
        Map<Student , List<Nota>> studentsGrouped = note.stream().
                collect(Collectors.groupingBy(x->x.getStudent()))
        studentsGrouped.entrySet().forEach(x ->{
            double sum;
            x.getValue()
                    .stream()
                    .map(y->y.getValue())
                    .reduce((double)0,(u,v)->u+v);
            double av = sum/4;
            System.out.println(x.getKey().getName() + " " + av);
        });
    }

    /**
     * media notelor la o anumita tema
     * @param note
     */
    private static void report3(List<Nota> note) {
        Map<Tema, List<Nota>> temeGrouped = note.stream()
                .collect(Collectors.groupingBy(x -> x.getTema()));
        temeGrouped.entrySet()
                .forEach(x -> {
                    double sum = x.getValue()
                            .stream()
                            .map(y -> y.getValue())
                            .reduce(0d, (a,b) -> a+b);
                    double average = sum / x.getValue().size();
                    System.out.println(x.getKey() + " media " + average);
                });
    }

    public static void main(String[] args) {
        System.out.println(report1(getNote(getStudents() , getTeme())));
        System.out.println(report2(getNote(getStudents() , getTeme())));
    }
}

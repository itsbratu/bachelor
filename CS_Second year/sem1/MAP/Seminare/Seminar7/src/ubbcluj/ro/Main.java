package ubbcluj.ro;

import java.util.Arrays;
import java.util.List;
import java.util.Optional;

public class Main {
    public static void main(String[] args) {
        //1.
//        List<String> list = Arrays.asList("asf", "bcd", "asd", "bed", "bbb");
//        list.stream()
//                .filter(x -> {
//                    System.out.println(x);
//                    return x.startsWith("b");
//                })
//                .map(x -> {
//                    System.out.println(x);
//                    return x.toUpperCase();
//                })
//                .forEach(System.out::println);
        //2.
//        List<String> list = Arrays.asList("asf", "bcd", "asd", "bed", "bbb");
//        String rez=list.stream()
//                .filter(x -> {
//                    return x.startsWith("b");
//                })
//                .map(x -> {
//                    return x.toUpperCase();
//                })
//                .reduce("",(x,y)->x+y);
//        System.out.println(rez);

        //3.
//        List<String> list = Arrays.asList("asf", "bcd", "asd", "bed", "bbb");
//        Optional<String> rez=list.stream()
//                .filter(x -> {
//                    //System.out.println("filter: " + x);
//                    return x.startsWith("b");
//                })
//                .map(x -> {
//                    //System.out.println("map: " + x);
//                    return x.toUpperCase();
//                })
//                .reduce((x,y)->x+y);
//        if (!rez.isEmpty())
//            System.out.println(rez.get());
//        rez.ifPresent(x-> System.out.println(x));
    }
}

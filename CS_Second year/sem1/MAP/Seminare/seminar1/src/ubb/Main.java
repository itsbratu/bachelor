package ubb;

import model.MessageTask;
import model.Task;

public class Main {

    public static void main(String[] args) {
//        Task t = new Task("id1" , "Primul task");
//        System.out.println(t.toString());
//
//        System.out.println(t);
        MessageTask my_task = new MessageTask("id1" , "superdescriere" , "Ana" , "Cornel" ,"un msg");
        System.out.println(my_task);
    }
}

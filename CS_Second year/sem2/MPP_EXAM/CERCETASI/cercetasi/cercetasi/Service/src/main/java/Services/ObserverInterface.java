package Services;

import concurs.domain.Child;

import java.time.LocalTime;

public interface ObserverInterface {
    void addPoint(Child child, String time, Integer point) throws Exception;
}

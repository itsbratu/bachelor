package jumps.restController;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.ComponentScan;

@ComponentScan("jumps")
@SpringBootApplication
public class StartRest {
    public static void main(String[] args) {
        SpringApplication.run(StartRest.class, args);
    }

}

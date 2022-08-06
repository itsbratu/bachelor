package repository.restController;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.ComponentScan;

import java.io.IOException;
import java.util.Properties;

@ComponentScan("repository")
@SpringBootApplication
public class StartRest {
    public static void main(String[] args) {
        SpringApplication.run(StartRest.class, args);
    }
   /* @Bean(name="props")
    public Properties getProps(){
        Properties props=new Properties();
        try{
            props.load(StartRest.class.getResourceAsStream("/server.properties"));
            System.out.println(props);
            props.list(System.out);
        } catch (IOException e) {
            System.out.println("Cannot find properties file "+e);

        }
        return props;
    }*/
}

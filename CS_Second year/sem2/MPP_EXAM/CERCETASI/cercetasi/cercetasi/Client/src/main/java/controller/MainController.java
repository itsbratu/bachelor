package controller;


import Services.ObserverInterface;
import Services.ServiceInterface;
import concurs.domain.Child;
import concurs.domain.User;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.fxml.FXML;
import javafx.scene.control.*;
import javafx.scene.control.cell.PropertyValueFactory;


import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.time.LocalTime;
import java.time.format.DateTimeFormatter;
import java.time.format.DateTimeFormatterBuilder;
import java.util.ArrayList;
import java.util.List;


public class MainController implements ObserverInterface {

    private User account;
    private ObservableList<Child> model = FXCollections.observableArrayList();
    private ServiceInterface server;

    @FXML
    private TableView<Child> tablePlayers;
    @FXML
    private TableColumn<Child,String> name;
    @FXML
    private TableColumn<Child,String> time;
    @FXML
    private TableColumn<Child,Integer> point;
    @FXML
    private Button addPoint;


    public void setServer(ServiceInterface server){
        this.server=server;

    }
    public void setAccount(User account) throws Exception {
        this.account=account;
        initModel();
    }
    public void initModel() throws Exception {
        model.setAll(getPlayers());
    }

    private List<Child> getPlayers() throws Exception {
        List<Child> children= new ArrayList<>();
        for(Child c : server.getAllPlayers())
        {
            if(account.getPunct() == 0) {
                children.add(c);
                addPoint.setDisable(true);
            }
            else if (c.getPoint() == account.getPunct()-1 && account.getPunct() != 0)
                children.add(c);
        }

        return children;
    }
    public void prepare() {
        try {
            initModel();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
    @FXML
    public void initialize() {
        name.setCellValueFactory(new PropertyValueFactory<Child, String>("name"));
        time.setCellValueFactory(new PropertyValueFactory<Child, String>("time"));
        point.setCellValueFactory(new PropertyValueFactory<Child, Integer>("point"));
        tablePlayers.setItems(model);


    }
    public void logout() {
        try {
            server.logout(account,this);
        } catch (Exception e) {
            Alert errorAlert = new Alert(Alert.AlertType.ERROR);
            errorAlert.setHeaderText(e.getMessage());
            errorAlert.showAndWait();

        }
    }

    @Override
    public void addPoint(Child player, String time, Integer point) throws Exception {
        System.out.println("intram in add cu " + point);
        int ok = 0;
        for(int index=0;index<model.size();index++){
            Child player1=model.get(index);
            if(player1.getId().intValue()==player.getId()){
                player1.setPoint(point);
                player1.setTime(time);
                model.set(index,player1);
            }
            if(player1.getPoint() != account.getPunct()-1) {
                model.remove(player1);
                ok = 1;
            }
        }
        if(player.getPoint()+1 == account.getPunct()-1) {
            Child pl = player;
            pl.setTime(time);
            pl.setPoint(point);
            model.add(model.size(), pl);
        }
    }
    @FXML
    private void onAddPointClick() throws Exception
    {
        Child player = tablePlayers.getSelectionModel().getSelectedItem();
        if(point == null)
        {
            Alert errorAlert = new Alert(Alert.AlertType.ERROR);
            errorAlert.setHeaderText("Please select points ");
            errorAlert.showAndWait();
        }
        else if(player == null)
        {
            Alert errorAlert = new Alert(Alert.AlertType.ERROR);
            errorAlert.setHeaderText("Select a player");
            errorAlert.showAndWait();
        }
        else {
            try {
                LocalTime time = LocalTime.now();
                String timeString = time.format(DateTimeFormatter.ofPattern("HH:mm"));
                server.addPoint(player, timeString,account.getPunct());
                Alert informationAlert = new Alert(Alert.AlertType.INFORMATION);
                informationAlert.setHeaderText("Points added successfully");
                informationAlert.showAndWait();
            } catch (Exception e) {
                System.out.println("sunt in exceptie service");
                Alert errorAlert = new Alert(Alert.AlertType.ERROR);
                errorAlert.setHeaderText(e.getMessage());
                errorAlert.showAndWait();
            }
        }
    }
}

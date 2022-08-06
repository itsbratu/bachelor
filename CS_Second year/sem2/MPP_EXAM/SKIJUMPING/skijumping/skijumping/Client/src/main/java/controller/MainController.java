package controller;


import Services.ObserverInterface;
import Services.ServiceInterface;
import jumps.domain.Player;
import jumps.domain.User;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.fxml.FXML;
import javafx.scene.control.*;
import javafx.scene.control.cell.PropertyValueFactory;

import java.util.List;


public class MainController implements ObserverInterface {

    private User account;
    private ObservableList<Player> model = FXCollections.observableArrayList();
    private ServiceInterface server;

    @FXML
    private TableView<Player> tablePlayers;
    @FXML
    private TableColumn<Player,String> name;
    @FXML
    private TableColumn<Player,String> status;
    @FXML
    private TableColumn<Player,Integer> points;
    @FXML
    private Button addPoints;
    @FXML
    private Spinner<Integer> spinner;



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

    private List<Player> getPlayers() throws Exception {
        return (List<Player>) server.getAllPlayers();
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
        name.setCellValueFactory(new PropertyValueFactory<Player, String>("name"));
        status.setCellValueFactory(new PropertyValueFactory<Player, String>("status"));
        points.setCellValueFactory(new PropertyValueFactory<Player, Integer>("points"));
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
    public void addPoints(Player player, Integer points,String status) throws Exception {
        System.out.println("intram in add cu " + points + " puncte");
        for(int index=0;index<model.size();index++){
            Player player1=model.get(index);
            if(player1.getId().intValue()==player.getId()){
                player1.setPoints(player1.getPoints()+points);
                player1.setStatus(status);
                model.set(index,player1);
            }
        }
    }
    @FXML
    private void onAddPointsClick() throws Exception
    {
        Player player = tablePlayers.getSelectionModel().getSelectedItem();
        Integer points = spinner.getValue();
        if(points == null)
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
                if(player.getStatus().equals("NoJumps"))
                    server.addPoints(player,points,"FirstJump");
                else if(player.getStatus().equals("FirstJump"))
                    server.addPoints(player,points,"Finished");
                else if(player.getStatus().equals("Finished"))
                {
                    Alert errorAlert = new Alert(Alert.AlertType.ERROR);
                    errorAlert.setHeaderText("Already finished!");
                    errorAlert.showAndWait();
                    return;
                }
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

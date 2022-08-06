package model;

public class MessageTask extends Task {

    private final String from_atr;
    private final String to_atr;
    private final String message;

    public MessageTask(String id, String descriere , String from_atr , String to_atr , String message) {
        super(id , descriere);
        this.from_atr = from_atr;
        this.to_atr = to_atr;
        this.message = message;
    }

    @Override
    public String toString(){
        return super.toString()+ "Message from : " + from_atr + " , message to : " + to_atr + " , message : " + message;
    }

    @Override
    public void execute() {

    }
}

package utils;


import Services.ServiceInterface;
import objectProtocol.ClientObjectWorker;

import java.net.Socket;

public class ObjectConcurrentServer extends  AbsConcurrentServer{
    private ServiceInterface services;
    public ObjectConcurrentServer(int port, ServiceInterface server) {
        super(port);
        this.services = server;
        System.out.println("ObjectConcurrentServer");

    }

    @Override
    protected Thread createWorker(Socket client) {
        ClientObjectWorker worker=new ClientObjectWorker(services, client);
        Thread tw=new Thread(worker);
        return tw;
    }

}

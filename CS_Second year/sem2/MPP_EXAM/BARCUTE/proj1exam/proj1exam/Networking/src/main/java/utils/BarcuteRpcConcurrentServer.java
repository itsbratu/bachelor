package utils;

import rpcprotocol.BarcuteClientRpcWorker;
import service.IServices;

import java.net.Socket;

public class BarcuteRpcConcurrentServer extends AbsConcurrentServer {
    private IServices agencyServer;
    public BarcuteRpcConcurrentServer(int port, IServices agencyServer) {
        super(port);
        this.agencyServer = agencyServer;
        System.out.println("Agency - AgencyRpcConcurrentServer");
    }

    @Override
    public void stop(){
        System.out.println("Stopping services ...");
    }

    @Override
    protected Thread createWorker(Socket client) {
         BarcuteClientRpcWorker worker = new BarcuteClientRpcWorker(agencyServer, client);

        Thread tw = new Thread(worker);
        return tw;

    }
}

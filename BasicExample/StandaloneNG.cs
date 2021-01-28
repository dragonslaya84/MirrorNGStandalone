using Mirror.Runtime.Client;
using Mirror.Runtime.Server;
using Mirror.Runtime.Transport.KCP;

namespace Mirror.Example
{
    public class StandaloneNG
    {
        public NetworkServer server;
        KcpTransport servertransport;

        public NetworkClient client;
        KcpTransport clienttransport;

        public StandaloneNG()
        {
            server = new NetworkServer();
            servertransport = new KcpTransport();
            server.Transport = servertransport;
            _ = server.ListenAsync();

            client = new NetworkClient();
            clienttransport = new KcpTransport();
            client.Transport = clienttransport;
            client.ConnectAsync("localhost");
        }

        public void Update()
        {
            servertransport.Update();
            clienttransport.Update();
        }
    }
}
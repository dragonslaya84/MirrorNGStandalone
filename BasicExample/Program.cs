using Mirror.Runtime.Server;
using Mirror.Runtime.Transport.KCP;

namespace Mirror.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            NetworkServer server = new NetworkServer();
            server.Transport = new KcpTransport();

            _ = server.ListenAsync();

            while (true)
            {

            }
        }
    }
}
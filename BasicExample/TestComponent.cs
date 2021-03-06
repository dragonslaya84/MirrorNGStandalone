﻿using Mirror.Runtime.Common;
using Mirror.Runtime.Logging;

namespace Mirror.Example
{
    public class TestComponent
    {
        static readonly ILogger logger = LogFactory.GetLogger(typeof(TestComponent));

        StandaloneNG network;

        bool connected;

        public TestComponent(StandaloneNG standalone)
        {
            network = standalone;

            network.server.Connected += OnServerConnected;
            network.client.Connected += OnClientConnected;
        }

        public void Update()
        {
            if (connected) network.client.Send("TEST PASSED");
        }

        void OnServerConnected(INetworkConnection conn)
        {
            conn.RegisterHandler<string>(MsgReceived);
        }

        void OnClientConnected(INetworkConnection conn)
        {
            connected = true;
        }

        void MsgReceived(INetworkConnection conn, string text)
        {
            logger.LogError(text);
        }
    }
}
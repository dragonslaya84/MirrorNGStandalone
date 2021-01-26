using System;
using System.IO;
using System.Net;
using Cysharp.Threading.Tasks;
using Mirror.Runtime.Common;

namespace Mirror.Runtime.Transport
{
    public interface IConnection : INetworkBase
    {
        UniTask SendAsync(ArraySegment<byte> data, byte channel = (byte) Channels.Reliable);

        /// <summary>
        /// reads a message from connection
        /// </summary>
        /// <param name="buffer">buffer where the message will be written</param>
        /// <returns>The channel where we got the message</returns>
        /// <remark> throws System.IO.EndOfStreamException if the connetion has been closed</remark>
        UniTask<byte> ReceiveAsync(MemoryStream buffer);

        /// <summary>
        /// the address of endpoint we are connected to
        /// Note this can be IPEndPoint or a custom implementation
        /// of EndPoint, which depends on the transport
        /// </summary>
        /// <returns></returns>
        EndPoint GetEndPointAddress();
    }
}

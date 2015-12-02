using System.IO;
using NSmtp.Models;
using NSmtp.Enums;
using System.Net.Sockets;
using System.Net.Security;
using System;

namespace NSmtp.Utilities
{
    public class StreamFactory : IStreamFactory
    {
        private readonly IHostInfo _hostInfo;
        public StreamFactory(IHostInfo hostInfo)
        {
            _hostInfo = hostInfo;
        }

        public Stream Create()
        {
            var tcpClient = new TcpClient(_hostInfo.Host, _hostInfo.Port);
            switch (_hostInfo.SslType)
            {
                case SslType.None:
                case SslType.StartTls:
                    return tcpClient.GetStream();
                case SslType.ImplicitSsl:
                    var stream = new SslStream(tcpClient.GetStream());
                    stream.AuthenticateAsClient(_hostInfo.Host);
                    return stream;
                default:
                    throw new ArgumentOutOfRangeException("Invalid SSL type given");
            }
        }
    }
}

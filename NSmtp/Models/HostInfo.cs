using NSmtp.Enums;

namespace NSmtp.Models
{
    public class HostInfo : IHostInfo
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public AuthType AuthType { get; set; }
        public SslType SslType { get; set; }
    }
}

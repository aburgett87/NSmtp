using NSmtp.Enums;

namespace NSmtp.Models
{
    public interface IHostInfo
    {
        string Host { get; set; }
        int Port { get; set; }
        string Username { get; set; }
        string Password { get; set; }
        SslType SslType { get; set; }
    }
}

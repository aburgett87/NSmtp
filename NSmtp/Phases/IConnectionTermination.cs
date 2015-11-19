using NSmtp.Models.Responses;

namespace NSmtp.Phases
{
    public interface IConnectionTermination
    {
        IResponse Terminate();
    }
}

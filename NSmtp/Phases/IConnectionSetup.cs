using NSmtp.Models.Responses;

namespace NSmtp.Phases
{
    public interface IConnectionSetup
    {
        IResponse Setup();
    }
}

namespace Opener.Models
{
    public interface IOpenerService
    {
        OpenerResult Open(OpenerConfiguration configuration);
    }
}

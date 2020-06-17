using TMS.Permissions.Models;

namespace TMS.Permissions
{
    public interface ICurrentUserAccessor
    {
        IUser GetCurrentUser();
    }
}

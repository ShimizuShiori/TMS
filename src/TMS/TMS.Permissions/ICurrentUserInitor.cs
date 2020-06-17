using System.Web;
using TMS.Permissions.Models;

namespace TMS.Permissions
{
    public interface ICurrentUserInitor
    {
        IUser Init(HttpContext httpContext);
    }
}

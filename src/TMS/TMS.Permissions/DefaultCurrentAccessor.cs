using Reface.AppStarter.Attributes;
using System.Web;
using TMS.Permissions.Models;

namespace TMS.Permissions
{
    [Component]
    public class DefaultCurrentAccessor : ICurrentUserAccessor
    {
        public IUser Get()
        {
            HttpContext httpContext = HttpContext.Current;
            if (!httpContext.Items.Contains(Constant.HTTP_CONTEXT_KEY_CURRENT_USER))
                return new NotLoginUser();

            return (IUser)httpContext.Items[Constant.HTTP_CONTEXT_KEY_CURRENT_USER];
        }
    }
}

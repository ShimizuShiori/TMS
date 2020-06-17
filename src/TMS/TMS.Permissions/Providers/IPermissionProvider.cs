using System.Collections.Generic;
using TMS.Permissions.Models;

namespace TMS.Permissions.Providers
{
    /// <summary>
    /// 提供所有授权的功能
    /// </summary>
    public interface IPermissionProvider
    {
        IEnumerable<Permission> Provide();
    }
}

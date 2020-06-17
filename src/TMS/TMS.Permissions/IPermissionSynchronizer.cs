using System.Collections.Generic;
using TMS.Permissions.Models;

namespace TMS.Permissions
{
    /// <summary>
    /// 将系统中收集到的授权同步到数据库的组件
    /// </summary>
    public interface IPermissionSynchronizer
    {
        void Synchronize(IEnumerable<Permission> permissions);
    }
}

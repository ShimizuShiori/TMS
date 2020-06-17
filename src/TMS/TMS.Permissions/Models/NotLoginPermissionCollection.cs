namespace TMS.Permissions.Models
{
    public class NotLoginPermissionCollection : IPermissionCollection
    {
        public bool HasPermission(IPermission permission)
        {
            return false;
        }
    }
}

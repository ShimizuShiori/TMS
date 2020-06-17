namespace TMS.Permissions.Models
{
    public interface IPermissionCollection
    {
        bool HasPermission(IPermission permission);
    }
}

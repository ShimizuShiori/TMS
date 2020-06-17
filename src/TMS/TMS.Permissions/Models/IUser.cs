namespace TMS.Permissions.Models
{
    public interface IUser
    {
        string Code { get; }
        string DisplayName { get; }

        IPermissionCollection Permissions { get; }
    }
}

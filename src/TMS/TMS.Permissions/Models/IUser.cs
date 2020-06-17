namespace TMS.Permissions.Models
{
    public interface IUser
    {
        string Code { get; }

        string DisplayName { get; }

        UserStates State { get; }

        IPermissionCollection Permissions { get; }
    }
}

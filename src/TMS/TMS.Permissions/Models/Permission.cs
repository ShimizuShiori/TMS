namespace TMS.Permissions.Models
{
    public class Permission : IPermission
    {
        public string Code { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
    }
}

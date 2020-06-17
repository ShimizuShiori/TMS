using TMS.Permissions.Models;

namespace TMS.Permissions.Dtos
{
    public class UserDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public UserStates State { get; set; }
    }
}

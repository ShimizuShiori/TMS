using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Permissions.Models
{
    public class NotLoginUser : IUser
    {
        public string Code => "";

        public string DisplayName { get; private set; }

        public UserStates State => UserStates.NotLogin;

        public IPermissionCollection Permissions { get; private set; }

        public NotLoginUser(string displayName = "")
        {
            DisplayName = displayName;
            this.Permissions = new NotLoginPermissionCollection();
        }
    }
}

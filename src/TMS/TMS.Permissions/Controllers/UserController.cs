using Reface.AppStarter.WebApi.Attributes;
using System.Web.Http;
using TMS.Permissions.Dtos;
using TMS.Permissions.Models;

namespace TMS.Permissions.Controllers
{
    [ApiRoute("user")]
    public class UserController : ApiController
    {
        private readonly ICurrentUserAccessor currentUserAccessor;

        public UserController(ICurrentUserAccessor currentUserAccessor)
        {
            this.currentUserAccessor = currentUserAccessor;
        }

        [HttpGet]
        [Route("whoami")]
        public UserDto WhoAmI()
        {
            IUser user = this.currentUserAccessor.Get();
            return new UserDto()
            {
                Id = user.Code,
                Name = user.DisplayName,
                State = user.State
            };
        }
    }
}

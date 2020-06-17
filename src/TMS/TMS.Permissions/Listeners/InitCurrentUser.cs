using Reface.AppStarter;
using Reface.AppStarter.Attributes;
using Reface.AppStarter.WebApi.Events;
using Reface.EventBus;

namespace TMS.Permissions.Listeners
{
    [Listener]
    public class InitCurrentUser : IEventListener<BeginRequestEvent>
    {
        private readonly IWork work;

        public InitCurrentUser(IWork work)
        {
            this.work = work;
        }

        public void Handle(BeginRequestEvent @event)
        {
            ICurrentUserInitor initor;
            if (!this.work.TryCreateComponent<ICurrentUserInitor>(out initor))
                return;

            @event.HttpContext.Items[Constant.HTTP_CONTEXT_KEY_CURRENT_USER] = initor.Init(@event.HttpContext);
        }
    }
}

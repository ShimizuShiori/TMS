using Reface.AppStarter.Attributes;
using Reface.AppStarter.Events;
using Reface.EventBus;
using System;
using System.Collections.Generic;

namespace TMS.QueryBus.Listeners
{
    [Listener]
    public class CheckDuplicateQueryType : IEventListener<AppStartedEvent>
    {
        private readonly IEnumerable<IQueryHandler> queryHandlers;

        public CheckDuplicateQueryType(IEnumerable<IQueryHandler> queryHandlers)
        {
            this.queryHandlers = queryHandlers;
        }

        public void Handle(AppStartedEvent @event)
        {
            HashSet<string> existsQueryType = new HashSet<string>();
            foreach (var handler in queryHandlers)
            {
                if (existsQueryType.Contains(handler.Type))
                    throw new ApplicationException($"已存在 QueryType = [{handler.Type}] 的查询处理器，与 {handler.GetType()} 冲突");
                existsQueryType.Add(handler.Type);
            }
        }
    }
}

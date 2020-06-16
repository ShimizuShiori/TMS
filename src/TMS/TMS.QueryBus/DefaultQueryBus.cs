using Newtonsoft.Json.Linq;
using Reface.AppStarter.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TMS.QueryBus
{
    [Component]
    public class DefaultQueryBus : IQueryBus
    {
        private readonly IEnumerable<IQueryHandler> queriers;

        public DefaultQueryBus(IEnumerable<IQueryHandler> queriers)
        {
            this.queriers = queriers;
        }

        public T Query<T>(QueryRequest request)
        {
            return (T)this.Query(request, typeof(T));
        }

        public object Query(QueryRequest request, Type returnType)
        {
            IQueryHandler querier = this.queriers.FirstOrDefault(x => x.Type == request.QueryType);
            if (querier == null)
                throw new NotImplementedException();

            object result = querier.Handle(request);
            return JObject.FromObject(result).ToObject(returnType);
        }
    }
}

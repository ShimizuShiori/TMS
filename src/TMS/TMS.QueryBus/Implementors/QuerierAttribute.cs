using Reface.AppStarter.Attributes;
using Reface.AppStarter.Proxy;
using System;
using System.Reflection;
using TMS.QueryBus.Attributes;

namespace TMS.QueryBus.Implementors
{
    [AttributeUsage(AttributeTargets.Interface)]
    public class QuerierAttribute : ImplementorAttribute
    {
        public string QueryType { get; private set; }

        public QuerierAttribute(string queryType)
        {
            QueryType = queryType;
        }

        public IQueryBus QueryBus { get; set; }

        public override void Intercept(InterfaceInvocationInfo info)
        {
            string queryType = this.QueryType;

            string queryMode = info.Method.Name;
            QueryModeAttribute queryModeAttribute = info.Method.GetCustomAttribute<QueryModeAttribute>();
            if (queryModeAttribute != null)
                queryMode = queryModeAttribute.Mode;
            QueryRequest request;

            if (info.Arguments.Length == 0)
                request = new QueryRequest(queryType, queryMode);
            else
                request = new QueryRequest(queryType, queryMode, info.Arguments[0]);

            info.ReturnValue = this.QueryBus.Query(request, info.Method.ReturnType);
        }
    }
}

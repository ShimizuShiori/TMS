using Reface.AppStarter;
using System;
using System.Collections.Generic;
using System.Reflection;
using TMS.QueryBus.Attributes;

namespace TMS.QueryBus
{
    public abstract class QueryHandler : IQueryHandler
    {
        private readonly Dictionary<string, MethodInfo> queryModeToMethodMap = new Dictionary<string, MethodInfo>();

        public QueryHandler()
        {
            this.GetType().GetMethods()
                .ForEach(method =>
                {
                    if (method.GetParameters().Length > 1) return;

                    QueryModeAttribute attribute = method.GetCustomAttribute<QueryModeAttribute>();

                    if (attribute != null)
                        this.queryModeToMethodMap[attribute.Mode] = method;
                    else
                        this.queryModeToMethodMap[method.Name] = method;
                });
        }

        public abstract string Type { get; }

        public object Handle(QueryRequest request)
        {
            MethodInfo method;
            if (!this.queryModeToMethodMap.TryGetValue(request.QueryMode, out method))
                throw new NotImplementedException();

            var parameters = method.GetParameters();
            if (parameters.Length == 0)
                return method.Invoke(this, null);

            object parameter = request.Parameters.ToObject(parameters[0].ParameterType);
            return method.Invoke(this, new object[] { parameter });
        }
    }
}

using Reface.AppStarter;
using System;
using System.Collections.Generic;
using System.Reflection;
using TMS.QueryBus.Attributes;

namespace TMS.QueryBus
{
    public abstract class QueryHandler : IQueryHandler
    {
        // todo : 将方法与 Mode 的映射缓存，以提高性能
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
            // todo : 将方法的调用通过 Emit 实现

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

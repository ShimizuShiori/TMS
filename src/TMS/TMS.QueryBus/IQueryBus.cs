using System;

namespace TMS.QueryBus
{
    public interface IQueryBus
    {
        T Query<T>(QueryRequest request);

        object Query(QueryRequest request, Type returnType);
    }
}

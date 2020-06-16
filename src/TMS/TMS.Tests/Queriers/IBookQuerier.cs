using TMS.QueryBus.Implementors;
using TMS.Tests.Models.Requests;
using TMS.Tests.Models.Response;

namespace TMS.Tests.Queriers
{
    [Querier("Book")]
    public interface IBookQuerier
    {
        GetBookByIdResponse GetById(GetBookByIdRequest request);
    }
}

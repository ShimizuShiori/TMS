using Newtonsoft.Json.Linq;
using Reface.AppStarter.Attributes;
using TMS.QueryBus;
using TMS.Tests.Models;
using TMS.Tests.Models.Requests;

namespace TMS.Tests.Queriers
{
    [Component]
    public class BookQueryHandler : QueryHandler
    {

        public override string Type => "Book";

        public Book GetById(GetBookByIdRequest request)
        {
            return new Book() { Id = request.Id, Name = $"Book_{request.Id}" };
        }
    }
}

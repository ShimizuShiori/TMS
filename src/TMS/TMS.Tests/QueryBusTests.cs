using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reface.AppStarter.UnitTests;
using TMS.QueryBus;
using TMS.Tests.AppModules;
using TMS.Tests.Models.Requests;
using TMS.Tests.Models.Response;
using TMS.Tests.Queriers;

namespace TMS.Tests
{
    [TestClass]
    public class QueryBusTests : TestClassBase<TestAppModule>
    {
        public class BookQueryResult
        {
            public string Name { get; set; }
        }

        [TestMethod]
        public void Query()
        {
            var bus = this.ComponentContainer.CreateComponent<IQueryBus>();
            BookQueryResult result = bus.Query<BookQueryResult>(new QueryRequest("Book", "GetById", new { Id = 1 }));
            Assert.AreEqual("Book_1", result.Name);
        }

        [TestMethod]
        public void QueryByQuerier()
        {
            var querier = this.ComponentContainer.CreateComponent<IBookQuerier>();
            GetBookByIdResponse response = querier.GetById(new GetBookByIdRequest() { Id = 1 });
            Assert.AreEqual("Book_1", response.Name);
        }
    }
}

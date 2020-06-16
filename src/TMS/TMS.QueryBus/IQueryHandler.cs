namespace TMS.QueryBus
{
    public interface IQueryHandler
    {
        string Type { get; }

        object Handle(QueryRequest request);
    }
}

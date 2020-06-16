using Newtonsoft.Json.Linq;

namespace TMS.QueryBus
{
    /// <summary>
    /// 查询请求
    /// </summary>
    public class QueryRequest
    {
        public string QueryType { get; private set; }
        public string QueryMode { get; private set; }

        public JObject Parameters { get; private set; }

        public QueryRequest(string queryType, string queryMode, object parameters = null)
        {
            this.QueryType = queryType;
            this.QueryMode = queryMode;
            if (parameters != null)
                this.Parameters = JObject.FromObject(parameters);
        }
    }
}

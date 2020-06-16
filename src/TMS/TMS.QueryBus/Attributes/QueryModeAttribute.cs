using System;

namespace TMS.QueryBus.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class QueryModeAttribute : Attribute
    {
        public string Mode { get; private set; }

        public QueryModeAttribute(string mode)
        {
            Mode = mode;
        }
    }
}

using System.Collections.Generic;

namespace BD.DataAccess.DbContextEvents
{
    public class DbContextEventHandlerContext
    {
        readonly IDictionary<string, object> values = new Dictionary<string, object>();

        public T GetValue<T>(string key)
        {
            return values.ContainsKey(key)
                 ? (T)values[key] : default(T);
        }

        public void SetValue<T>(string key, T value)
        {
            values[key] = value;
        }
    }
}

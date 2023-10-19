using System.Data;

namespace JijaShop.Context.Settings
{
    public class DataBaseSettings
    {
        public DataBaseType Type { get; private set; }
        public string ConnectionString { get; private set; }
    }
}

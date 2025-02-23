

using clean_arch.Persistence.Interfaces;

namespace clean_arch.Persistence
{
    public class MySqlDbSettings : IMySqlDbSettings
    {
        public string ConnectionString { get; set; }
    }
}

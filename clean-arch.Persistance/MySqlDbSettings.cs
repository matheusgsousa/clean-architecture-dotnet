

using clean_arch.Persistance.Interfaces;

namespace clean_arch.Persistance
{
    public class MySqlDbSettings : IMySqlDbSettings
    {
        public string ConnectionString { get; set; }
    }
}

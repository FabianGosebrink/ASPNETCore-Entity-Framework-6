using System.Data.Entity;
using AspnetCoreEF6Example.Models;

namespace AspnetCoreEF6Example
{
    [DbConfigurationType(typeof (CodeConfig))]
    public class DataBaseContext : DbContext
    {
        public DbSet<MyModel> MyModels { get; set; }

        public DataBaseContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }
    }

    public class CodeConfig : DbConfiguration
    {
        public CodeConfig()
        {
            SetProviderServices("System.Data.SqlClient", System.Data.Entity.SqlServer.SqlProviderServices.Instance);
        }
    }
}

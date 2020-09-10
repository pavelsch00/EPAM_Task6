using ORM.Interfaces;

namespace ORM
{
    public abstract class DbContext : IDbContext
    {
        public DbContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public string ConnectionString { get; set; }
    }
}

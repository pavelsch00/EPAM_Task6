using ORM.Interfaces;

namespace ORM
{
    /// <summary>
    /// Class describes the DbContext.
    /// </summary>
    public abstract class DbContext : IDbContext
    {
        /// <summary>
        /// The constructor initializes the class object.
        /// </summary>
        /// <param name="connectionString">Database connection string.</param>
        public DbContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        /// <summary>
        /// The property stores information about database connection string.
        /// </summary>
        public string ConnectionString { get; set; }
    }
}

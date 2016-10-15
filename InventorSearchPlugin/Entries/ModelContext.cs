using System.Data.Entity;
using InventorSearchPlugin.Configuration;
using Npgsql;

namespace InventorSearchPlugin.Entries
{
    [DbConfigurationType(typeof(NpgsqlConfiguration))]
    public class ModelContext : DbContext
    {
        private static string connectionString =
            string.Format("Server={0};User ID={1};Password={2};Database={3};syncnotification=false;port={4}",
                Settings.Host, Settings.User, Settings.Password, Settings.DbName, Settings.Port);

        public ModelContext()
            : base(new NpgsqlConnection(connectionString), true)
        {
            
        }

        public DbSet<Model> Models { get; set; }
    }
}
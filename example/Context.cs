using Microsoft.EntityFrameworkCore;

namespace example
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<MessageType> MessageTypes { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<MessageLog> MessageLogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Veritabanı bağlantısıı
            optionsBuilder.UseSqlServer("data source=IDEAPAD3\\DUYGUCAN;initial catalog=MessageDb;integrated security=true;TrustServerCertificate=True;");
        }
    }
}
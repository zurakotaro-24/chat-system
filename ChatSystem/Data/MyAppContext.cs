using ChatSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatSystem.Data
{
    public class MyAppContext : DbContext
    {
        public MyAppContext(DbContextOptions<MyAppContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemClient>().HasKey(
                ic => new
                {
                    ic.itemId,
                    ic.clientId
                });

            modelBuilder.Entity<ItemClient>()
                .HasOne(i => i.item)
                .WithMany(ic => ic.itemClients)
                .HasForeignKey(i => i.itemId);

            modelBuilder.Entity<ItemClient>()
                .HasOne(c => c.client)
                .WithMany(ic => ic.itemClients)
                .HasForeignKey(c => c.clientId);

            modelBuilder.Entity<Item>().HasData(
                new Item { id = 5, name = "controller", price = 321.69, serialNumberId=10 }
                );

            modelBuilder.Entity<SerialNumber>().HasData(
                new SerialNumber { id = 10, name = "cont", itemId = 5 }
                );

            modelBuilder.Entity<Category>().HasData(
                new Category { id = 1, name= "electronics" },
                new Category { id = 2, name= "books" }
                );

            modelBuilder.Entity<UserInformation>().HasData(
                new UserInformation { id = 1, firstName = "First", lastName = "Last", middleName = "Middle", extensionName = null, sex = "Male", birthday = new DateOnly(2003, 02, 24) }
                );

            modelBuilder.Entity<UserAccount>().HasData(
                new UserAccount { id = 1, username = "user", password = "pass" }
                );

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<SerialNumber> SerialNumbers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ItemClient> ItemClients { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<UserInformation> UserInformations { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using WebixDhtmlxDemos.Models.Webix;
using WebixDhtmlxDemos.Models.Dhtmlx;

namespace WebixDhtmlxDemos
{
    public class DemosDbContext : DbContext
    {
        // Webix
        public DbSet<Sheet> Sheets { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Person> Persons { get; set; }

        // DHTMLX
        public DbSet<Card> Cards { get; set; }
        public DbSet<CardAttachment> CardAttachments { get; set; }
        public DbSet<CardUser> CardUsers { get; set; }
        public DbSet<Column> Columns { get; set; }
        public DbSet<Row> Rows { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=demos.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // configures one-to-many relationship and cascade delete
            modelBuilder.Entity<Card>()
                .HasMany<CardAttachment>(g => g.Attachments)
                .WithOne(s => s.Card)
                .HasForeignKey(s => s.CardId)
                .OnDelete(DeleteBehavior.NoAction);

            // configures one-to-many relationship and cascade delete
            modelBuilder.Entity<Card>()
                .HasMany<CardUser>(g => g.CardUsers)
                .WithOne(s => s.Card)
                .HasForeignKey(s => s.CardId)
                .OnDelete(DeleteBehavior.NoAction);

            // configures one-to-many relationship and cascade delete
            modelBuilder.Entity<User>()
                .HasMany<CardUser>(g => g.CardUsers)
                .WithOne(s => s.User)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
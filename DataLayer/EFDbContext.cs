using DataLayer.Entity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DataLayer
{
    public class EFDBContext : DbContext
    {
        public DbSet<Groups> Groups { get; set; }
        public DbSet<Permissions> Permissions { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<UsersPermissions> UsersPermissions { get; set; }
        public DbSet<GroupsPermissions> GroupsPermissions { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=IbaTestDb.db", options =>
            {
                options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroupsPermissions>()
            .HasKey(t => new { t.GroupsId, t.PermissionsId });

            modelBuilder.Entity<UsersPermissions>()
            .HasKey(t => new { t.UsersId, t.PermissionsId });

            modelBuilder.Entity<UsersGroups>()
            .HasKey(t => new { t.GroupsId, t.UsersId });
        }

    }

}


using System;
using Microsoft.EntityFrameworkCore;
using DBModels;
using System.Text.RegularExpressions;

namespace DBCore
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }

        public DbSet<User_Group> User_Group { get; set; }

        public DbSet<User_State> User_State { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("VKInternship");

            modelBuilder.Entity<User>().HasKey(x => x.Id);
            modelBuilder.Entity<User_Group>().HasKey(x => x.Id);
            modelBuilder.Entity<User_State>().HasKey(x => x.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}


using ChatApp.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApp
{
    public class ClientDataStoreDbContext : DbContext
    {
        public DbSet<LoginCredentialsDataModel> LoginCredentials { get; set; }

        public ClientDataStoreDbContext(DbContextOptions<ClientDataStoreDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<LoginCredentialsDataModel>().HasKey(a => a.Id);

        }
    }
}

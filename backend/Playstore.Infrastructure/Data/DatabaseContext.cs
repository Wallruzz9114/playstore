using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Playstore.Domain.Abstractions;
using Playstore.Domain.Entities;

namespace Playstore.Infrastructure.Data
{
    public class DatabaseContext : DbContext, IUnitOfWork
    {
        #region Public Properties

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        #endregion

        #region Constructor

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        #endregion

        #region IUnitOfWork Member

        public async Task<bool> Commit()
        {
            foreach (var entry in ChangeTracker.Entries().Where(e => e.Entity.GetType().GetProperty("RegistrationDate") != null))
            {
                if (entry.State == EntityState.Added)
                    entry.Property("RegistrationDate").CurrentValue = DateTime.Now;

                if (entry.State == EntityState.Modified)
                    entry.Property("RegistrationDate").IsModified = false;
            }

            return await base.SaveChangesAsync() > 0;
        }

        #endregion

        #region Overriden Methods

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(x => x.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);
        }

        #endregion
    }
}
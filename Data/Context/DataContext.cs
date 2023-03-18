using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Projeto_Mobile_Sustentabilidade.Data.Models;

namespace Projeto_Mobile_Sustentabilidade.Data.Context
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}

        public DbSet<Status> Status { get; set; }
        // public DbSet<Tipo> Tipo { get; set; }
        // public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // modelBuilder.Entity<Proposta>()
            //     .HasOne<Usuario>(x => x.usuarioIniciador)
            //     .WithMany()
            //     .OnDelete(DeleteBehavior.NoAction);

            // modelBuilder.Entity<Proposta>()
            //     .HasOne<Gerencia>(x => x.gerencia)
            //     .WithMany()
            //     .OnDelete(DeleteBehavior.NoAction);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) 
        {
            AddTimestamps();
            return base.SaveChangesAsync();
        }

        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }

        private void AddTimestamps()
        {
            var entities = ChangeTracker.Entries()
                .Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                var now = DateTime.Now;

                if (entity.State == EntityState.Added)
                {
                    ((BaseEntity)entity.Entity).CreatedAt = now;
                }
                ((BaseEntity)entity.Entity).UpdatedAt = now;
            }
        }
    }
}
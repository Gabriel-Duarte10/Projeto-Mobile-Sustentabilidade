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

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Posto> Postos { get; set; }
        public DbSet<DonoPosto> DonosPosto { get; set; }
        public DbSet<FuncionarioPosto> FuncionariosPosto { get; set; }
        public DbSet<Liquido> Liquidos { get; set; }
        public DbSet<TransacaoPosto> TransacoesPosto { get; set; }
        public DbSet<PostoAceitaLiquido> PostosAceitamLiquido { get; set; }
        public DbSet<Usina> Usinas { get; set; }
        public DbSet<TransacaoUsina> TransacoesUsina { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Adicione aqui as configurações de relacionamento entre as entidades
            modelBuilder.Entity<Administrador>()
                .HasOne<Usuario>(x => x.Usuario)
                .WithMany()
                .HasForeignKey(x => x.IdUsuario)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Cliente>()
                .HasOne<Usuario>(x => x.Usuario)
                .WithMany()
                .HasForeignKey(x => x.IdUsuario)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<DonoPosto>()
                .HasOne<Usuario>(x => x.Usuario)
                .WithMany()
                .HasForeignKey(x => x.IdUsuario)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<FuncionarioPosto>()
                .HasOne<Usuario>(x => x.Usuario)
                .WithMany()
                .HasForeignKey(x => x.IdUsuario)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<FuncionarioPosto>()
                .HasOne<Posto>(x => x.Posto)
                .WithMany()
                .HasForeignKey(x => x.IdPosto)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Liquido>()
                .HasOne<Administrador>(x => x.Administrador)
                .WithMany()
                .HasForeignKey(x => x.IdAdministrador)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Posto>()
                .HasOne<Administrador>(x => x.Administrador)
                .WithMany()
                .HasForeignKey(x => x.IdAdministrador)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Posto>()
                .HasOne<DonoPosto>(x => x.DonoPosto)
                .WithMany()
                .HasForeignKey(x => x.IdDonoPosto)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PostoAceitaLiquido>()
                .HasOne<Posto>(x => x.Posto)
                .WithMany()
                .HasForeignKey(x => x.IdPosto)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PostoAceitaLiquido>()
                .HasOne<Liquido>(x => x.Liquido)
                .WithMany()
                .HasForeignKey(x => x.IdLiquido)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TransacaoPosto>()
                .HasOne<FuncionarioPosto>(x => x.FuncionarioPosto)
                .WithMany()
                .HasForeignKey(x => x.IdFuncionarioPosto)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TransacaoPosto>()
                .HasOne<Liquido>(x => x.Liquido)
                .WithMany()
                .HasForeignKey(x => x.IdLiquido)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<TransacaoPosto>()
                .HasOne<Cliente>(x => x.Cliente)
                .WithMany()
                .HasForeignKey(x => x.IdCliente)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TransacaoUsina>()
                .HasOne<Usina>(x => x.Usina)
                .WithMany()
                .HasForeignKey(x => x.IdUsina)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TransacaoUsina>()
                .HasOne<FuncionarioPosto>(x => x.FuncionarioPosto)
                .WithMany()
                .HasForeignKey(x => x.IdFuncionarioPosto)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TransacaoUsina>()
                .HasOne<Liquido>(x => x.Liquido)
                .WithMany()
                .HasForeignKey(x => x.IdLiquido)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Usina>()
                .HasOne<Administrador>(x => x.Administrador)
                .WithMany()
                .HasForeignKey(x => x.IdAdministrador)
                .OnDelete(DeleteBehavior.NoAction);
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
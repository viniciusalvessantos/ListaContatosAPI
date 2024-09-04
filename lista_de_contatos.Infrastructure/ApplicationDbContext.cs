using lista_de_contatos.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lista_de_contatos.Infrastructure {
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string> {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {}
        public DbSet<Pessoas> Pessoas { get; set; }
        public DbSet<Contatos> Contatos { get; set; }
        public override int SaveChanges() {
            SetAuditFields();
            return base.SaveChanges();
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) {
            SetAuditFields();
            return await base.SaveChangesAsync(cancellationToken);
        }

        protected void SetAuditFields() {
            var changeEntities = ChangeTracker.Entries<BaseEntity>()
                .Where(ce => ce.State is EntityState.Added or EntityState.Modified);
            foreach (var auditableEntity in changeEntities) {
                var currentDate = DateTime.UtcNow;
                switch (auditableEntity.State) { 
                    case EntityState.Added:
                        auditableEntity.Entity.DataCriacao = currentDate;
                        auditableEntity.Entity.DataModificacao = currentDate;
                        auditableEntity.Entity.CriadoPor = "";
                        auditableEntity.Entity.ModificadoPor = "";
                        break;
                    case EntityState.Modified:
                        auditableEntity.Entity.DataModificacao = currentDate;
                        auditableEntity.Entity.ModificadoPor = "";
                        break;
                }
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pessoas>(entity => {
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Nome)
                    .IsRequired()
                    .HasMaxLength(60);
                entity.Property(t => t.SobreNome)
                    .IsRequired()
                    .HasMaxLength(60);
                entity.Property(t => t.Telefone)
                   .HasMaxLength(11);

                entity.Property(t => t.Email);


                entity.HasMany(t => t.Contatos)
                    .WithOne(u => u.Pessoas)
                    .HasForeignKey(u => u.PessoaId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Contatos>(entity => {
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Nome)
                    .IsRequired()
                    .HasMaxLength(60);
                entity.Property(t => t.Telefone)
                   .HasMaxLength(11);
                entity.Property(t => t.WhatsApp)
                  .HasMaxLength(11);
                entity.Property(t => t.Email);
                entity.HasOne(u => u.Pessoas)
                .WithMany(t => t.Contatos) 
                .HasForeignKey(u => u.PessoaId);
                    
            });

        }

    }
}

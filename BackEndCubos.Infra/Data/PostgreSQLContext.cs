using BackEndCubos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BackEndCubos.Infra.Data
{
    public class PostgreSQLContext : DbContext
    {
        public PostgreSQLContext()
        {
        }

        public PostgreSQLContext(DbContextOptions<PostgreSQLContext> options) : base(options)
        {
        }

        public DbSet<Person> Person { get; set; }
        public DbSet<PersonAccount> PersonAccount { get; set; }
        public DbSet<Card> Card { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(c =>
            {
                c.HasKey(p => p.Id);
                c.Property(x => x.Name).HasMaxLength(100);
                c.Property(x => x.Document).HasMaxLength(18);
                c.Property(x => x.Password);
                c.Property(x => x.CreatedAt);
                c.Property(x => x.UpdatedAt);
            });

            modelBuilder.Entity<PersonAccount>(c =>
            {
                c.HasKey(p => p.Id);
                c.Property(x => x.Branch).HasMaxLength(4);
                c.Property(x => x.Account).HasMaxLength(9);
                c.Property(x => x.Balance);
                c.Property(x => x.CreatedAt);
                c.Property(x => x.UpdatedAt);

                c.HasOne(p => p.Person)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(p => p.PersonId);
            });

            modelBuilder.Entity<Card>(c =>
            {
                c.HasKey(p => p.Id);
                c.Property(x => x.Type);
                c.Property(x => x.Number);
                c.Property(x => x.CVV);
                c.Property(x => x.CreatedAt);
                c.Property(x => x.UpdatedAt);

                c.HasOne(p => p.Account)
                    .WithMany(p => p.Cards)
                    .HasForeignKey(p => p.AccountId);
            });

            modelBuilder.Entity<Transaction>(c =>
            {
                c.HasKey(p => p.Id);
                c.Property(x => x.Description);
                c.Property(x => x.Value);
                c.Property(x => x.CreatedAt);
                c.Property(x => x.UpdatedAt);

                c.HasOne(p => p.Account)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(p => p.AccountId);
            });
        }
    }
}

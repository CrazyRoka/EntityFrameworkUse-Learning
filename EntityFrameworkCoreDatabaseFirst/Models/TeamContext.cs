using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;

namespace EntityFrameworkCoreDatabaseFirst.Models
{
    public partial class TeamContext : DbContext
    {
        private LoggerFactory loggerFactory;
        public TeamContext(DbContextOptions<TeamContext> options, LoggerFactory loggerFactory) : base(options)
        {
            this.loggerFactory = loggerFactory;
        }

        public virtual DbSet<Footballer> Footballer { get; set; }
        public virtual DbSet<Team> Team { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity<Footballer>(entity =>
            {
                entity.HasKey(f => f.Id);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.Footballer)
                    .HasForeignKey(d => d.TeamId);
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasKey(t => t.Id);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLoggerFactory(loggerFactory);
        }
    }
}

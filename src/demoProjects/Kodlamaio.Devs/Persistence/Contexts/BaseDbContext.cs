using Core.Security.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        
        protected IConfiguration Configuration { get; set; }
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<AppUser> Users { get; set; }


        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgrammingLanguage>(a =>
            {

                a.ToTable("ProgrammingLanguages").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id").UseIdentityColumn();
                a.Property(p => p.Name).HasColumnName("Name");
                a.HasMany(p => p.Technologies);
            });


            modelBuilder.Entity<Technology>(a =>
            {

                a.ToTable("Technologies").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id").UseIdentityColumn();
                a.Property(p => p.ProgrammingLanguageId).HasColumnName("ProgrammingLanguageId");
                a.Property(p => p.TechnologyName).HasColumnName("TechnologyName");
                a.HasOne(p => p.ProgrammingLanguage);
            });

            //modelBuilder.Entity<User>(a =>
            //{

            //    a.ToTable("Users").HasKey(k => k.Id);
            //    a.Property(p => p.Id).HasColumnName("Id").UseIdentityColumn();
            //    a.Property(p => p.Status).HasColumnName("Status");
            //    a.Property(p => p.FirstName).HasColumnName("FirstName");
            //    a.Property(p => p.RefreshTokens).HasColumnName("RefreshTokens");
            //});
        }
    }
}

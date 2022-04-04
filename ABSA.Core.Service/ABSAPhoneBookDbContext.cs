using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ABSA.Core.Service.Models;

namespace ABSA.Core.Service
{
    public partial class ABSAPhoneBookDbContext : DbContext
    {
        public ABSAPhoneBookDbContext()
        {
        }

        public ABSAPhoneBookDbContext(DbContextOptions<ABSAPhoneBookDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PhoneBookView> PhoneBookView { get; set; }
        public virtual DbSet<entry> entry { get; set; }
        public virtual DbSet<phonebook> phonebook { get; set; }
               

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PhoneBookView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("PhoneBookView");
            });

            modelBuilder.Entity<entry>(entity =>
            {
                entity.Property(e => e.id).ValueGeneratedOnAdd() ;
            });

            modelBuilder.Entity<phonebook>(entity =>
            {
                entity.Property(e => e.id).ValueGeneratedOnAdd();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

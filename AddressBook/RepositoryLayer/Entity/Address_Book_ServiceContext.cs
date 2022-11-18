using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RepositoryLayer.Entity
{
    public partial class Address_Book_ServiceContext : DbContext
    {
        public Address_Book_ServiceContext()
        {
        }

        public Address_Book_ServiceContext(DbContextOptions<Address_Book_ServiceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PhoneBook> PhoneBook { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\MSSQL; Database=Address_Book_Service;Trusted_Connection=True;");
            }*/
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PhoneBook>(entity =>
            {
                entity.HasKey(e => e.ContactId);

                entity.Property(e => e.ContactId).HasColumnName("ContactID");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

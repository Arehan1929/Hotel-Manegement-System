using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace HotelManagementSystem.DomainLayer.Models
{
    public partial class HMSDBContext : DbContext
    {
        public HMSDBContext()
        {
        }

        public HMSDBContext(DbContextOptions<HMSDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BookingDetail> BookingDetails { get; set; }
        public virtual DbSet<CustomerDetail> CustomerDetails { get; set; }
        public virtual DbSet<RoomDetail> RoomDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=HMSDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<BookingDetail>(entity =>
            {
                entity.HasKey(e => e.Bookingid)
                    .HasName("PK__BookingD__C6D307057F51FE9A");

                entity.Property(e => e.Bookingid)
                    .ValueGeneratedNever()
                    .HasColumnName("bookingid");

                entity.Property(e => e.Bookingdate)
                    .HasColumnType("date")
                    .HasColumnName("bookingdate");

                entity.Property(e => e.Bookingstatus)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("bookingstatus");

                entity.Property(e => e.Checkin)
                    .HasColumnType("date")
                    .HasColumnName("checkin");

                entity.Property(e => e.Checkout)
                    .HasColumnType("date")
                    .HasColumnName("checkout");

                entity.Property(e => e.Custid).HasColumnName("custid");

                entity.Property(e => e.Roomnumber).HasColumnName("roomnumber");

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.BookingDetails)
                    .HasForeignKey(d => d.Custid)
                    .HasConstraintName("FK__BookingDe__custi__29572725");

                entity.HasOne(d => d.RoomnumberNavigation)
                    .WithMany(p => p.BookingDetails)
                    .HasForeignKey(d => d.Roomnumber)
                    .HasConstraintName("FK__BookingDe__roomn__267ABA7A");
            });

            modelBuilder.Entity<CustomerDetail>(entity =>
            {
                entity.HasKey(e => e.Custid)
                    .HasName("PK__Customer__973AFEFEDC87CC16");

                entity.Property(e => e.Custid)
                    .ValueGeneratedNever()
                    .HasColumnName("custid");

                entity.Property(e => e.Custname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("custname");
            });

            modelBuilder.Entity<RoomDetail>(entity =>
            {
                entity.HasKey(e => e.Roomnumber)
                    .HasName("PK__RoomDeta__20A5E4998E78DC06");

                entity.Property(e => e.Roomnumber)
                    .ValueGeneratedNever()
                    .HasColumnName("roomnumber");

                entity.Property(e => e.Roomstatus)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("roomstatus");

                entity.Property(e => e.Roomtype)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("roomtype");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

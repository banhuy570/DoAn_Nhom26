using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ModelEF.Model
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<MayTinh> MayTinhs { get; set; }
        public virtual DbSet<NguoiDung> NguoiDungs { get; set; }
        public virtual DbSet<PhieuDKMuonPhong> PhieuDKMuonPhongs { get; set; }
        public virtual DbSet<PhongMay> PhongMays { get; set; }
        public virtual DbSet<SuCo> SuCoes { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<ThoiKhoaBieu> ThoiKhoaBieux { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MayTinh>()
                .Property(e => e.MaMT)
                .IsUnicode(false);

            modelBuilder.Entity<MayTinh>()
                .Property(e => e.MaPMT)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.MaND)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.Quyen)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PhieuDKMuonPhong>()
                .Property(e => e.MaDK)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuDKMuonPhong>()
                .Property(e => e.MaND)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuDKMuonPhong>()
                .Property(e => e.MaPMT)
                .IsUnicode(false);

            modelBuilder.Entity<PhongMay>()
                .Property(e => e.MaPMT)
                .IsUnicode(false);

            modelBuilder.Entity<SuCo>()
                .Property(e => e.MaSC)
                .IsUnicode(false);

            modelBuilder.Entity<SuCo>()
                .Property(e => e.MaND)
                .IsUnicode(false);

            modelBuilder.Entity<SuCo>()
                .Property(e => e.MaPMT)
                .IsUnicode(false);

            modelBuilder.Entity<SuCo>()
                .Property(e => e.MaMT)
                .IsUnicode(false);

            modelBuilder.Entity<ThoiKhoaBieu>()
                .Property(e => e.MaTKB)
                .IsUnicode(false);

            modelBuilder.Entity<ThoiKhoaBieu>()
                .Property(e => e.MaND)
                .IsUnicode(false);

            modelBuilder.Entity<ThoiKhoaBieu>()
                .Property(e => e.MaPMT)
                .IsUnicode(false);
        }
    }
}

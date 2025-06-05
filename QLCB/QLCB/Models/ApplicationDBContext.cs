using Microsoft.EntityFrameworkCore;

namespace QLCB.Models
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<MayBay> MayBays { get; set; }
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<SanBay> SanBays { get; set; }
        public DbSet<ChuyenBay> ChuyenBays { get; set; }
        public DbSet<VeBay> VeBays { get; set; }
        public DbSet<HanhKhach> HanhKhachs { get; set; }
        public DbSet<ChungNhan> ChungNhans { get; set; }
        public DbSet<PhanCong> PhanCongs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Config bảng SanBay
            modelBuilder.Entity<SanBay>()
                .HasKey(sb => sb.MaSanBay);

            modelBuilder.Entity<SanBay>()
                .HasMany(sb => sb.ChuyenBaysDi)
                .WithOne(cb => cb.SanBayDi)
                .HasForeignKey(cb => cb.MaSanBayDi)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SanBay>()
                .HasMany(sb => sb.ChuyenBaysDen)
                .WithOne(cb => cb.SanBayDen)
                .HasForeignKey(cb => cb.MaSanBayDen)
                .OnDelete(DeleteBehavior.Restrict);

            // Config bảng MayBay
            modelBuilder.Entity<MayBay>()
                .HasKey(mb => mb.MaMayBay);

            modelBuilder.Entity<MayBay>()
                .HasMany(mb => mb.ChuyenBays)
                .WithOne(cb => cb.MayBay)
                .HasForeignKey(cb => cb.MaMayBay)
                .OnDelete(DeleteBehavior.Cascade);

            // Config bảng ChuyenBay
            modelBuilder.Entity<ChuyenBay>()
                .HasKey(cb => cb.MaChuyenBay);

            // Config bảng VeBay
            modelBuilder.Entity<VeBay>()
                .Property(v => v.GiaVe)
                .HasColumnType("decimal(18,2)");

            // Config bảng HanhKhach
            modelBuilder.Entity<HanhKhach>()
                .HasKey(hk => hk.MaHanhKhach);

            modelBuilder.Entity<HanhKhach>()
                .Property(hk => hk.Email)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<HanhKhach>()
                .Property(hk => hk.Password)
                .IsRequired()
                .HasMaxLength(255); // Đặt chiều dài tối đa hợp lý cho mật khẩu mã hóa

            modelBuilder.Entity<HanhKhach>()
                .Property(hk => hk.HoTen)
                .IsRequired()
                .HasMaxLength(200);

            modelBuilder.Entity<HanhKhach>()
                .Property(hk => hk.SoDienThoai)
                .IsRequired()
                .HasMaxLength(15);

            modelBuilder.Entity<HanhKhach>()
                .Property(hk => hk.CMND)
                .IsRequired()
                .HasMaxLength(12);
        }
    }
}

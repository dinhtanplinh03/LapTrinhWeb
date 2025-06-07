using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace QLCB.Models
{
    public class ApplicationDBContext :DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options){

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
			// Config bảng SanBay
			modelBuilder.Entity<SanBay>()
				.HasKey(sb => sb.MaSanBay);

			modelBuilder.Entity<SanBay>()
				.HasMany(sb => sb.ChuyenBaysDi)
				.WithOne(cb => cb.SanBayDi)
				.HasForeignKey(cb => cb.MaSanBayDi)
				.OnDelete(DeleteBehavior.Restrict);  // Tắt cascade xóa

			modelBuilder.Entity<SanBay>()
				.HasMany(sb => sb.ChuyenBaysDen)
				.WithOne(cb => cb.SanBayDen)
				.HasForeignKey(cb => cb.MaSanBayDen)
				.OnDelete(DeleteBehavior.Restrict);  // Tắt cascade xóa

			// Config bảng MayBay
			modelBuilder.Entity<MayBay>()
				.HasKey(mb => mb.MaMayBay);

			modelBuilder.Entity<MayBay>()
				.HasMany(mb => mb.ChuyenBays)
				.WithOne(cb => cb.MayBay)
				.HasForeignKey(cb => cb.MaMayBay)
				.OnDelete(DeleteBehavior.Cascade); // Có thể giữ cascade xóa nếu muốn

			// Config bảng ChuyenBay
			modelBuilder.Entity<ChuyenBay>()
				.HasKey(cb => cb.MaChuyenBay);

			// Config bảng VeBay nếu cần thêm
			modelBuilder.Entity<VeBay>()
				.Property(v => v.GiaVe)
				.HasColumnType("decimal(18,2)");

			base.OnModelCreating(modelBuilder);
		}
	}
}

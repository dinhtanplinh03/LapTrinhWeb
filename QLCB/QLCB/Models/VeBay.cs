using System.ComponentModel.DataAnnotations;

namespace QLCB.Models
{
	public class VeBay
	{
		public VeBay()
		{
			MaVeBay = string.Empty;
			MaChuyenBay = string.Empty;
			MaHanhKhach = string.Empty;
			NgayDatVe = DateTime.Now;
			GiaVe = 0;
		}
		[Key]
		public string MaVeBay { get; set; }

		public string MaChuyenBay { get; set; }
		public string MaHanhKhach { get; set; }
		public DateTime NgayDatVe { get; set; }
		public decimal GiaVe { get; set; }
		public ChuyenBay ChuyenBay { get; set; }
		public HanhKhach HanhKhach
		{
			get; set;
		}
		public string MaNhanVien { get; set; }
		public NhanVien NhanVien { get; set; }
		public string MaSanBayDi { get; set; }
		public SanBay SanBayDi { get; set; }
		public string MaSanBayDen { get; set; }
		public SanBay SanBayDen { get; set; }
		public string MaMayBay { get; set; }
		public MayBay MayBay { get; set; }
		public string MaChungNhan { get; set; }
		public ChungNhan ChungNhan { get; set; }
		public string MaPhanCong { get; set; }
		public PhanCong PhanCong { get; set; }
	}
}

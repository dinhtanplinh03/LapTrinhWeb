using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLCB.Models
{
	public class ChuyenBay
	{
		[Key]
		[StringLength(5)]
		public string MaChuyenBay { get; set; }

		[Required]
		[StringLength(100)]
		public string TenChuyenBay { get; set; }

		public DateTime ThoiGianKhoiHanh { get; set; }

		public DateTime ThoiGianDen { get; set; }

		public int SoGhe { get; set; }

		[Required]
		[StringLength(5)]
		public string MaMayBay { get; set; }

		[Required]
		[StringLength(5)]
		public string MaSanBayDi { get; set; }

		[Required]
		[StringLength(5)]
		public string MaSanBayDen { get; set; }

		// Navigation properties
		[ForeignKey(nameof(MaMayBay))]
		public MayBay MayBay { get; set; }

		[ForeignKey(nameof(MaSanBayDi))]
		public SanBay SanBayDi { get; set; }

		[ForeignKey(nameof(MaSanBayDen))]
		public SanBay SanBayDen { get; set; }
	}
}

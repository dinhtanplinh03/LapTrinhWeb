using System.ComponentModel.DataAnnotations;

namespace QLCB.Models
{
	public class HanhKhach
	{
		public HanhKhach()
		{
			MaHanhKhach = string.Empty;
			HoTen = string.Empty;
			SoDienThoai = string.Empty;
			Email = string.Empty;
			CMND = string.Empty;
		}
		[Key]
		public string MaHanhKhach { get; set; }
		public string HoTen { get; set; }

		public string SoDienThoai { get; set; }

		public string Email { get; set; }
		public string CMND { get; set; }
	}
}

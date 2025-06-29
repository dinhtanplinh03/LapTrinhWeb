﻿using System.ComponentModel.DataAnnotations;
namespace QLCB.Models
{
	public class PhanCong
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string MaChuyenBay { get; set; }

		public ChuyenBay ChuyenBay { get; set; }

		[Required]
		public string MaNhanVien { get; set; }
		public NhanVien NhanVien { get; set; }

		[Required]
		public DateTime NgayPhanCong { get; set; }
	}
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLCB.Models;

namespace QLCB.Controllers
{
	public class ChuyenBayController : Controller
	{
		private readonly ApplicationDBContext _context;

		public ChuyenBayController(ApplicationDBContext context)
		{
			_context = context;
		}

		public async Task<IActionResult> Index()
		{
			var danhSachChuyenBay = await _context.ChuyenBays
				.Include(cb => cb.MayBay)
				.Include(cb => cb.SanBayDi)
				.Include(cb => cb.SanBayDen)
				.ToListAsync();

			return View(danhSachChuyenBay);
		}
	}
}

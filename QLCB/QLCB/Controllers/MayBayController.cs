using Microsoft.AspNetCore.Mvc;
using QLCB.Models;
using QLCB.Repositories;

namespace QLCB.Controllers
{
	public class MayBayController : Controller
	{
		private readonly IMayBayRepository _mayBayRepo;

		public MayBayController(IMayBayRepository mayBayRepo)
		{
			_mayBayRepo = mayBayRepo;
		}

		// GET: MayBay
		public async Task<IActionResult> Index()
		{
			var mayBays = await _mayBayRepo.GetAllAsync();
			return View(mayBays);
		}

		// GET: MayBay/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: MayBay/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(MayBay mayBay)
		{
			if (ModelState.IsValid)
			{
				if (await _mayBayRepo.ExistsAsync(mayBay.MaMayBay))
				{
					ModelState.AddModelError("MaMayBay", "Mã máy bay đã tồn tại.");
					return View(mayBay);
				}

				await _mayBayRepo.AddAsync(mayBay);
				return RedirectToAction(nameof(Index));
			}
			return View(mayBay);
		}

		// GET: MayBay/Edit/5
		public async Task<IActionResult> Edit(string id)
		{
			if (id == null) return NotFound();

			var mayBay = await _mayBayRepo.GetByIdAsync(id);
			if (mayBay == null) return NotFound();

			return View(mayBay);
		}

		// POST: MayBay/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(string id, MayBay mayBay)
		{
			if (id != mayBay.MaMayBay) return NotFound();

			if (ModelState.IsValid)
			{
				await _mayBayRepo.UpdateAsync(mayBay);
				return RedirectToAction(nameof(Index));
			}
			return View(mayBay);
		}

		// GET: MayBay/Delete/5
		public async Task<IActionResult> Delete(string id)
		{
			if (id == null) return NotFound();

			var mayBay = await _mayBayRepo.GetByIdAsync(id);
			if (mayBay == null) return NotFound();

			return View(mayBay);
		}

		// POST: MayBay/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(string id)
		{
			await _mayBayRepo.DeleteAsync(id);
			return RedirectToAction(nameof(Index));
		}
	}
}

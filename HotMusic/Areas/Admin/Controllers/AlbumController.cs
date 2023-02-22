using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotMusic.Models;
using AspNetCoreHero.ToastNotification.Abstractions;
using PagedList.Core;
using HotMusic.Helpper;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace HotMusic.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AlbumController : Controller
    {
        private readonly HotMusicContext _context;
        public INotyfService _notifyService { get; }
        public AlbumController(HotMusicContext context, INotyfService notifyService)
        {
            _context = context;
            _notifyService = notifyService;
        }

        // GET: Admin/Album
        public async Task<IActionResult> Index(int page = 1, int cateid = 0)
        {
            var pageNumber = page;
            var pageSize = 10;
            List<Album> lscate = new List<Album>();
            if (cateid != 0)
            {
                lscate = _context.Albums
                .AsNoTracking()
                .Where(x => x.CategoryId == cateid)
                .Include(x => x.Category)
                .OrderBy(x => x.Id).ToList();
            }
            else
            {
                lscate = _context.Albums
                .AsNoTracking()
                .Include(x => x.Category)
                .OrderBy(x => x.Id).ToList();
            }

            PagedList<Album> models = new PagedList<Album>(lscate.AsQueryable(), pageNumber, pageSize);
            ViewBag.CurrentCateID = cateid;

            ViewBag.CurrentPage = pageNumber;

            ViewData["theloai"] = new SelectList(_context.Categories, "Id", "CategoryName");

            return View(models);
        }

        // GET: Admin/Album/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _context.Albums
                .Include(a => a.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }

        // GET: Admin/Album/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "CategoryName");
            return View();
        }

        // POST: Admin/Album/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Imange,Url,CategoryId,Createdate,Description,FavoriteQuantity")] Album album, Microsoft.AspNetCore.Http.IFormFile fImgae)
        {
            if (ModelState.IsValid)
            {
                album.Name = Utilities.ToTitleCase(album.Name);
                if (fImgae != null)
                {
                    string extension = Path.GetExtension(fImgae.FileName);
                    string image = Utilities.SEOUrl(album.Name) + extension;
                    album.Imange = await Utilities.UploadFile(fImgae, @"Album", image.ToLower());
                }
                if (string.IsNullOrEmpty(album.Imange)) album.Imange = "default.jpg";
                _context.Add(album);
                await _context.SaveChangesAsync();
                _notifyService.Success("Them Thanh Cong");
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "CategoryName", album.CategoryId);
            return View(album);
        }

        // GET: Admin/Album/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _context.Albums.FindAsync(id);
            if (album == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "CategoryName", album.CategoryId);
            return View(album);
        }

        // POST: Admin/Album/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Imange,Url,CategoryId,Createdate,Description,FavoriteQuantity")] Album album, Microsoft.AspNetCore.Http.IFormFile fImgae)
        {
            if (id != album.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    album.Name = Utilities.ToTitleCase(album.Name);
                    if (fImgae != null)
                    {
                        string extension = Path.GetExtension(fImgae.FileName);
                        string image = Utilities.SEOUrl(album.Name) + extension;
                        album.Imange = await Utilities.UploadFile(fImgae, @"Album", image.ToLower());
                    }
                    if (string.IsNullOrEmpty(album.Imange)) album.Imange = "default.jpg";
                    _notifyService.Success("Cap Nhat Thanh Cong");
                    _context.Update(album);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlbumExists(album.Id))
                    {
                        _notifyService.Error("Loi!!!");
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "CategoryName", album.CategoryId);
            return View(album);
        }

        // GET: Admin/Album/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _context.Albums
                .Include(a => a.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }

        // POST: Admin/Album/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var album = await _context.Albums.FindAsync(id);
            _context.Albums.Remove(album);
            _notifyService.Success("Xoa Thanh Cong");
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlbumExists(int id)
        {
            return _context.Albums.Any(e => e.Id == id);
        }
    }
}

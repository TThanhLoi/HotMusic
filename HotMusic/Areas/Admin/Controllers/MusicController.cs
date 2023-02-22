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
    public class MusicController : Controller
    {
        private readonly HotMusicContext _context;
        public INotyfService _notifyService { get; }

        public MusicController(HotMusicContext context, INotyfService notifyService)
        {
            _context = context;
            _notifyService = notifyService;
        }

        // GET: Admin/Music
        public async Task<IActionResult> Index(int page=1, int authorId = 0)
        {
            var pageNumber = page;
            var pageSize = 10;
            List<Music> lsProducts = new List<Music>();
            if (authorId != 0)
            {
                lsProducts = _context.Musics
                .AsNoTracking()
                .Where(x => x.AuthorId == authorId)
                .Include(x => x.Author)
                .OrderBy(x => x.Id).ToList();
            }
            else
            {
                lsProducts = _context.Musics
                .AsNoTracking()
                .Include(x => x.Author)
                .OrderBy(x => x.Id).ToList();
            }

            PagedList<Music> models = new PagedList<Music>(lsProducts.AsQueryable(), pageNumber, pageSize);
            ViewBag.CurrentCateID = authorId;

            ViewBag.CurrentPage = pageNumber;

            ViewData["tacgia"] = new SelectList(_context.Authors, "Id", "AuthorName");

            return View(models);
        }
        public IActionResult Filtter(int authorId = 0)
        {
            var url = $"/Admin/Music?authorId={authorId}";
            if (authorId == 0)
            {
                url = $"/Admin/Music";
            }
            return Json(new { status = "success", redirectUrl = url });
        }

        // GET: Admin/Music/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var music = await _context.Musics
                .Include(m => m.Author)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (music == null)
            {
                return NotFound();
            }

            return View(music);
        }

        // GET: Admin/Music/Create
        public IActionResult Create()
        {
            ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "AuthorName");
            return View();
        }

        // POST: Admin/Music/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MusiceName,Image,Description,AuthorId,Url,ListenQuantity,DownloadQuantity,FavoriteQuantity,IsVip")] Music music,Microsoft.AspNetCore.Http.IFormFile fImgae)
        {
            if (ModelState.IsValid)
            {
                music.MusiceName=Utilities.ToTitleCase(music.MusiceName);
                if(fImgae != null)
                {
                    string extension = Path.GetExtension(fImgae.FileName);
                    string image = Utilities.SEOUrl(music.MusiceName)+extension;
                    music.Image = await Utilities.UploadFile(fImgae, @"BaiHat", image.ToLower());
                }
                if (string.IsNullOrEmpty(music.Image)) music.Image = "default.jpg";
                _context.Add(music);
                await _context.SaveChangesAsync();
                _notifyService.Success("Them Thanh Cong");
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "AuthorName", music.AuthorId);
            return View(music);
        }

        // GET: Admin/Music/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var music = await _context.Musics.FindAsync(id);
            if (music == null)
            {
                return NotFound();
            }
            ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "AuthorName", music.AuthorId);
            return View(music);
        }

        // POST: Admin/Music/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MusiceName,Image,Description,AuthorId,Url,ListenQuantity,DownloadQuantity,FavoriteQuantity,IsVip")] Music music, Microsoft.AspNetCore.Http.IFormFile fImgae)
        {
            if (id != music.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    music.MusiceName = Utilities.ToTitleCase(music.MusiceName);
                    if (fImgae != null)
                    {
                        string extension = Path.GetExtension(fImgae.FileName);
                        string image = Utilities.SEOUrl(music.MusiceName) + extension;
                        music.Image = await Utilities.UploadFile(fImgae, @"BaiHat", image.ToLower());
                    }
                    if (string.IsNullOrEmpty(music.Image)) music.Image = "default.jpg";

                    _context.Update(music);
                    await _context.SaveChangesAsync();
                    _notifyService.Success("Cap Nhat Thanh Cong");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MusicExists(music.Id))
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
            ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "AuthorName", music.AuthorId);
            return View(music);
        }

        // GET: Admin/Music/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var music = await _context.Musics
                .Include(m => m.Author)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (music == null)
            {
                return NotFound();
            }

            return View(music);
        }

        // POST: Admin/Music/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var music = await _context.Musics.FindAsync(id);
            _context.Musics.Remove(music);
            _notifyService.Success("Xoa Thanh Cong");
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MusicExists(int id)
        {
            return _context.Musics.Any(e => e.Id == id);
        }
    }
}

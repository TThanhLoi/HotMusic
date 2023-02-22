using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotMusic.Models;

namespace HotMusic.Controllers
{
    public class AlbumController : Controller
    {
        private readonly HotMusicContext _context;

        public AlbumController(HotMusicContext context)
        {
            _context = context;
        }

        // GET: Album
        public async Task<IActionResult> Index()
        {
            var hotMusicContext = _context.Albums.Include(a => a.Category);
            return View(await hotMusicContext.ToListAsync());
        }

        //GET: Album/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var ab = _context.AlbumMusics.AsNoTracking().Include(t=>t.Album).FirstOrDefault(x => x.AlbumId == id);
            if (ab == null)
            {
                return RedirectToAction("Index","Categories");
            }
            var lstalbum = _context.AlbumMusics
                .AsNoTracking().Include(a => a.Music)
                .Where(x => x.AlbumId == id)
                .ToList();
            ViewBag.lstalbum = lstalbum;

            return View(ab);
        }
    }
}


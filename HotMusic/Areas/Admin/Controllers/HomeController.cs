using AspNetCoreHero.ToastNotification.Abstractions;
using HotMusic.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq;
using System.Security.Principal;

namespace HotMusic.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private readonly HotMusicContext _context;
        public HomeController(HotMusicContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var accountcount = _context.Accounts.AsNoTracking().ToList();
            ViewBag.count = accountcount.Count();
            var musiccount = _context.Musics.AsNoTracking().ToList();
            ViewBag.mscount = musiccount.Count();
            var alcount = _context.Albums.AsNoTracking().ToList();
            ViewBag.alcount = alcount.Count();
            return View();
        }
    }
}

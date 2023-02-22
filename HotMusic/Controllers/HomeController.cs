using HotMusic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HotMusic.Controllers
{
    public class HomeController : Controller
    {
        HotMusicContext ctx = new HotMusicContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            HomeModel objHomeModel = new HomeModel();
            //1.db --> toys
            objHomeModel.ListMusic = ctx.Musics.ToList();
            objHomeModel.ListAlbum = ctx.Albums.ToList();

            //2.passing data to view
            var lstbxh = ctx.Musics
                .AsNoTracking()
                .Take(10).OrderByDescending(x => x.ListenQuantity)
                .ToList();
            ViewBag.lstbxh = lstbxh;

            return View(objHomeModel);
        }
            public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Vip()
        {
            return View();
        }
    }
}

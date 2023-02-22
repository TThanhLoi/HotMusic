using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotMusic.Models;
using PagedList.Core;
using Microsoft.AspNetCore.Http;
using AspNetCoreHero.ToastNotification.Abstractions;
using System.IO;
using static System.Reflection.Metadata.BlobBuilder;

namespace HotMusic.Controllers
{
    public class MusicController : Controller
    {
        private readonly HotMusicContext _context;
        public INotyfService _notyfService { get; }
        public MusicController(HotMusicContext context, INotyfService notyfService) 
        {
            _context = context;
            _notyfService = notyfService;
        }

        // GET: Music
        public async Task<IActionResult> Index(int? page)
        {
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pagesize = 10;
            var lstmusic = _context.Musics.AsNoTracking().OrderByDescending(x => x.MusiceName).Include(t=>t.Author);
            PagedList<Music> models = new PagedList<Music>(lstmusic,pageNumber,pagesize);
            ViewBag.CurrentPage=pageNumber;
            return View(models);
        }

        // GET: Music/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var music = _context.Musics.Include(m=>m.Author).Include(a=>a.Comments).AsNoTracking().SingleOrDefault(x => x.Id == id);
            if(music == null)
            {
                return RedirectToAction("Index");
            }
            var lstlienquan = _context.Musics
                .AsNoTracking()
                .Where(x => x.Id != id && x.ListenQuantity>9000)
                .Take(3).OrderByDescending(x=>x.ListenQuantity)
                .ToList();
            ViewBag.baihatlienquan = lstlienquan;
            return View(music);
        }
        public IActionResult Search(string keyword)
        {

            var music = _context.Musics.Include(b=>b.Author).ToList();
            if (!String.IsNullOrEmpty(keyword))
            {
                keyword = keyword.ToLower();
                music = (List<Music>)music.Where(b => b.MusiceName.ToLower().Contains(keyword)).ToList();
            }
            return View(music.ToList());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Createcmt(Comment cmt, int? id)
        {
            try
            {
                var taikhoanID = HttpContext.Session.GetString("Id");
                if (taikhoanID == null)
                {
                    return RedirectToAction("DangNhap", "Account");
                }
                if (ModelState.IsValid)
                {
                    var taikhoan = _context.Accounts.Find(Convert.ToInt32(taikhoanID));
                    if (taikhoan == null) return RedirectToAction("DangNhap", "Account");
                    Comment comment = new Comment
                    {
                        MusicId = cmt.MusicId = id,
                        AccountId = cmt.AccountId = taikhoan.Id,
                        Comment1 = cmt.Comment1.Trim().ToLower(),
                    };
                    _context.Add(comment);
                    await _context.SaveChangesAsync();
                    _notyfService.Success("Da binh luan bai hat");
                    //return RedirectToAction("Index","Home");
                    
                }
            }
            catch(Exception ex)
            {

            }
            return RedirectToAction("Details", new {id});
        }



        private bool MusicExists(int id)
        {
            return _context.Musics.Any(e => e.Id == id);
        }
    }
}

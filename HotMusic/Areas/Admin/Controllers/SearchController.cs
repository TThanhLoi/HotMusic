using HotMusic.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace HotMusic.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SearchController : Controller
    {
        private readonly HotMusicContext _context;
        public SearchController(HotMusicContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult FindMusic(string keyword)
        {
            List<Music> lst = new List<Music>();
            if (string.IsNullOrEmpty(keyword) || keyword.Length < 1)
            {
                return PartialView("ListMusicsSearchPartial",null);
            }
            lst = _context.Musics
                .AsNoTracking()
                .Include(a=>a.Author)
                .Where(x=>x.MusiceName.Contains(keyword))
                .OrderByDescending(x=>x.MusiceName)
                .Take(10)
                .ToList();
            if(lst==null)
            {
                return PartialView("ListMusicsSearchPartial", null);
            }
            else
            {
                return PartialView("ListMusicsSearchPartial", lst);
            }
        }
    }
}

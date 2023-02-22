using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotMusic.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PagedList.Core;
using System.Security.Principal;
using Microsoft.AspNetCore.Authorization;
using AspNetCoreHero.ToastNotification.Abstractions;
using HotMusic.ModelViews;
using HotMusic.Extension;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace HotMusic.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AccountController : Controller
    {
        private readonly HotMusicContext _context;
        public INotyfService _notyfService { get; }
        public AccountController(HotMusicContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }

        // GET: Admin/Account
        public async Task<IActionResult> Index(int page=1,string Role="")
        {
            var pageNumber = page;
            var pagesize = 20;
            List<Account> lstaccount = new List<Account>();
            if(Role != "")
            {
                lstaccount = _context.Accounts.AsNoTracking().Where(x=>x.Role==Role).ToList();
            }
            else
            {
                lstaccount = _context.Accounts.AsNoTracking().ToList();
            }
            
            PagedList<Account> models = new PagedList<Account>(lstaccount.AsQueryable(), pageNumber, pagesize);
            ViewBag.currentquyen=Role;
            ViewBag.CurrentPage = pageNumber;
            ViewData["quyenntaikhoan"] = new SelectList(_context.Accounts, "Role", "Role",Role);
            return View(models);
        }
       
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts
                .Include(a => a.IdVipNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // GET: Admin/Account/Create
        public IActionResult Create()
        {
            ViewData["IdVip"] = new SelectList(_context.Cbvips, "Id", "Id");
            return View();
        }

        // POST: Admin/Account/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserName,Password,Role,FullName,Address,Phone,Email,IdVip,StartTime,EndTime")] Account account)
        {
            if (ModelState.IsValid)
            {
                Account khachhang = new Account
                {
                    UserName = account.UserName,
                    Password = account.Password.ToMD5(),
                    Role = account.Role,
                    FullName = account.FullName,
                    Address = account.Address,
                    Phone = account.Phone,
                    Email = account.Email,
                    IdVip = account.IdVip,
                    StartTime = account.StartTime,
                    EndTime = account.EndTime,
                };
                _context.Add(khachhang);
                await _context.SaveChangesAsync();
                _notyfService.Success("Tạo mới tài khoản thành công");
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdVip"] = new SelectList(_context.Cbvips, "Id", "Id", account.IdVip);
            return View(account);
        }

        public IActionResult ChangePassword()
        {
            ViewData["QuyenTruyCap"] = new SelectList(_context.Accounts, "Role", "Role");
            return View();
        }


        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var taikhoan = _context.Accounts.AsNoTracking().SingleOrDefault(x => x.Email == model.Email);
                if (taikhoan == null) return RedirectToAction("Login", "Accounts");
                var pass = (model.PasswordNow.Trim()).ToMD5();
                {
                    string passnew = (model.Password.Trim()).ToMD5();
                    taikhoan.Password = passnew;
                    _context.Update(taikhoan);
                    _context.SaveChanges();
                    _notyfService.Success("Đổi mật khẩu thành công");
                    return RedirectToAction("Login", "Accounts", new { Area = "Admin" });
                }
            }
            return View();
        }
        // GET: Admin/Account/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }
            ViewData["IdVip"] = new SelectList(_context.Cbvips, "Id", "Id", account.IdVip);
            return View(account);
        }

        // POST: Admin/Account/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserName,Password,Role,FullName,Address,Phone,Email,IdVip,StartTime,EndTime")] Account account)
        {
            if (id != account.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(account);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountExists(account.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdVip"] = new SelectList(_context.Cbvips, "Id", "Id", account.IdVip);
            return View(account);
        }

        // GET: Admin/Account/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts
                .Include(a => a.IdVipNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // POST: Admin/Account/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var account = await _context.Accounts.FindAsync(id);
            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountExists(int id)
        {
            return _context.Accounts.Any(e => e.Id == id);
        }

        [AllowAnonymous]
        [Route("login.html", Name = "Login")]
        public IActionResult AdminLogin()
        {
            var taikhoanID = HttpContext.Session.GetString("Id");
            if (taikhoanID != null) return RedirectToAction("Index", "Home", new { Area = "Admin" });
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("login.html", Name = "Login")]
        public async Task<IActionResult> AdminLogin(LoginViewModel model/*, string returnUrl = null*/)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Account kh = _context.Accounts
                    .AsNoTracking().SingleOrDefault(p => p.Email.ToLower() == model.UserName.ToLower().Trim());

                    //var role = _context.Accounts.SingleOrDefault(p => p.Role.Trim() == model.Role.Trim());

                    if (kh.Role != "Admin")
                    {
                        _notyfService.Error("Tai khoan khong co quyen truy cap");
                        return RedirectToAction("AdminLogin", "Account", new { Area = "Admin" });  
                    }

                    if (kh == null)
                    {
                        ViewBag.Error = "Thông tin đăng nhập chưa chính xác";
                    }
                    string pass = (model.Password.Trim()).ToMD5();
                    // + kh.Salt.Trim()
                    if (kh.Password.Trim() != pass)
                    {
                        ViewBag.Error = "Thông tin đăng nhập chưa chính xác";
                        return View(model);
                    }
                    //đăng nhập thành công

                    var taikhoanID = HttpContext.Session.GetString("Id");
                    //identity
                    //luuw seccion Makh
                    HttpContext.Session.SetString("Id", kh.Id.ToString());

                    //identity
                    var userClaims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, kh.FullName),
                        new Claim(ClaimTypes.Email, kh.Email),
                        new Claim("Id", kh.Id.ToString()),
                        new Claim("Role", kh.Role.ToString()),
                        new Claim(ClaimTypes.Role, kh.Role)
                    };
                    var grandmaIdentity = new ClaimsIdentity(userClaims, "User Identity");
                    var userPrincipal = new ClaimsPrincipal(new[] { grandmaIdentity });
                    await HttpContext.SignInAsync(userPrincipal);



                    return RedirectToAction("Index", "Home", new { Area = "Admin" });
                }
            }
            catch
            {
                return RedirectToAction("AdminLogin", "Account", new { Area = "Admin" });
            }
            return RedirectToAction("AdminLogin", "Account", new { Area = "Admin" });
        }
        [Route("logout.html", Name = "Logout")]
        public IActionResult AdminLogout()
        {
            HttpContext.SignOutAsync();
            HttpContext.Session.Remove("Id");
            return RedirectToAction("AdminLogin", "Account", new { Area = "Admin" });
        }
    }
}

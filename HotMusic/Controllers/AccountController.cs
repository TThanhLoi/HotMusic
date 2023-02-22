using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using AspNetCoreHero.ToastNotification.Notyf;
using HotMusic.Extension;
using HotMusic.Helpper;
using HotMusic.Models;
using HotMusic.ModelViews;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HotMusic.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly HotMusicContext _context;
        public INotyfService _notifyService { get;}
        public AccountController(HotMusicContext context, INotyfService notifyService)
        {
            _context = context;
            _notifyService = notifyService;
        }
        public IActionResult Dashboard()
        {
            var Id = HttpContext.Session.GetString("Id");
            if (Id != null)
            {
                var hhachhang = _context.Accounts.AsNoTracking().SingleOrDefault(x => x.Id == Convert.ToInt32(Id));
                if (hhachhang != null)
                {
                    return View(hhachhang);
                }
            }
            return RedirectToAction("DangNhap");
        }


        public async Task<IActionResult> Edit(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts.FindAsync(Id);
            if (account == null)
            {
                return NotFound();
            }
            ViewData["IdVip"] = new SelectList(_context.Cbvips, "Id", "Id", account.IdVip);
            return View(account);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int Id, [Bind("Id,UserName,Password,Role,FullName,Address,Phone,Email,IdVip,StartTime,EndTime")] Account account)
        {
            if (Id != account.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {       
                    _context.Update(account);
                    await _context.SaveChangesAsync();
                _notifyService.Success("Cập Nhật Thành Công");
                return RedirectToAction("Dashboard" , "Account");
            }
            ViewData["IdVip"] = new SelectList(_context.Cbvips, "Id", "Id", account.IdVip);
            return View(account);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> DangKy(RegisterVM taikhoan, string phone, string email)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var ekhachhang = _context.Accounts.AsNoTracking().SingleOrDefault(x => x.Email.ToLower() == email.ToLower());
                    if (ekhachhang != null)
                    {
                        _notifyService.Error("Email:" + email + "đã sử dụng");
                        return RedirectToAction("DangKy", "Account");
                    }

                    var pkhachhang = _context.Accounts.AsNoTracking().SingleOrDefault(x => x.Phone.ToLower() == phone.ToLower());
                    if (pkhachhang != null)
                    {
                        _notifyService.Error("Số Điện thoại" + phone + "đã sử dụng");
                        return RedirectToAction("DangKy", "Account");
                    }

                    Account khachhang = new Account
                    {
                        FullName = taikhoan.FullName,
                        Phone = taikhoan.Phone.Trim().ToLower(),
                        Email = taikhoan.Email.Trim().ToLower(),
                        UserName= taikhoan.Email.Trim().ToLower(),
                        Password = (taikhoan.Password.Trim()).ToMD5(),
                        
                    };
                    try
                    {
                        _context.Add(khachhang);
                        await _context.SaveChangesAsync();
                        HttpContext.Session.SetString("Id", khachhang.Id.ToString());
                        var taikhoanid = HttpContext.Session.GetString("Id");

                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, khachhang.FullName),
                            new Claim("Id",khachhang.Id.ToString())
                        };
                        ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,"DangNhap");
                        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                        await HttpContext.SignInAsync(claimsPrincipal);

                        return RedirectToAction("Index", "Home");
                    }
                    catch(Exception ex)
                    {
                        return RedirectToAction("DangKy", "Account");
                    }
                }
                else
                {
                    return View(taikhoan);
                }
            }
            catch
            {
                return View(taikhoan);
            }
            
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult DangNhap()
        {
            var Id = HttpContext.Session.GetString("Id");
                if(Id != null)
                {
                return RedirectToAction("Index", "Home");
                }
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> DangNhap(LoginViewModel cs)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    bool isEmail = Utilities.IsValidEmail(cs.UserName);
                    if(!isEmail) return View(cs);
                    var khachhang = _context.Accounts.AsNoTracking().SingleOrDefault(x => x.Email.Trim()==cs.UserName.Trim());
                    if(khachhang == null) return RedirectToAction("DangKy");
                    string pass = (cs.Password.Trim()).ToMD5();
                    if(khachhang.Password != pass)
                    {
                        _notifyService.Error("Thông tin đăng nhập chưa chính xác");
                        return View(cs);
                    }


                    HttpContext.Session.SetString("Id", khachhang.Id.ToString());
                    var taikhoanid = HttpContext.Session.GetString("Id");

                    var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, khachhang.FullName),
                            new Claim("Id",khachhang.Id.ToString()),
                        };
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Login");
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    await HttpContext.SignInAsync(claimsPrincipal);
                    _notifyService.Success("Đăng nhập Thành Công");
                    return RedirectToAction("Index", "Home");
                }
            }
            catch
            {
                return RedirectToAction("Dangky", "Account");
            }
            return View();
        }
        public IActionResult DangXuat()
        {
            HttpContext.SignOutAsync();
            HttpContext.Session.Remove("Id");
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
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
                    var pass = (model.PasswordNow.Trim()).ToMD5();
                    if(pass == taikhoan.Password)
                    {
                        string passnew = (model.Password.Trim()).ToMD5();
                        taikhoan.Password = passnew;
                        _context.Update(taikhoan);
                        _context.SaveChanges();
                        _notifyService.Success("Đổi mật khẩu thành công");
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            catch
            {
                _notifyService.Error("Thay đổi mật khẩu không thành công");
                return RedirectToAction("ChangePassword", "Account");
            }
            _notifyService.Error("Thay đổi mật khẩu không thành công");
            return RedirectToAction("ChangePassword", "Account");
        }
    }
}

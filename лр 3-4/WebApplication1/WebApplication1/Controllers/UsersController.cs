using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    //[Authorize(RoleStoreBase="Admin")]
    public class UsersController : Controller
    {
        public readonly ApplicationDbContext _context;
        public readonly IEmailSender _emailSender;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        public UsersController(ApplicationDbContext context,UserManager<ApplicationUser> userManager,
                               IEmailSender emailSender, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _emailSender = emailSender;
            _roleManager = roleManager;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.ToListAsync());
        }

        /// <summary>
        /// Переход на страницу редактирования/регистрации пользователя
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Edit(string id, [FromServices] ApplicationDbContext db)
        {
            if(id!=null)
            {
                ViewData["Title"] = "Редактирование";
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
                if (user != null)
                    return View(user);
                return NotFound();
            }
            else
            {
                ViewData["Title"] = "Регистрация";
                var user = new ApplicationUser
                {
                    Email = "test@mail.ru",
                    Name = "TestName",
                    Surname="TestSurname",
                    Patronomic="TestPatronomic"
                };
                return View(user);
            }
        }

        /// <summary>
        /// Процедура регистрации/редактирования пользователя с сохранением
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Edit(ApplicationUser user, 
                                              [FromServices] ApplicationDbContext db,
                                              [FromServices] UserManager<ApplicationUser> userManager)
        {
            try
            {
                // TODO: Add update logic here
                var editUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
                if(editUser!=null)
                {
                    editUser.Email = user.Email;
                    editUser.Name = user.Name;
                    editUser.Surname = user.Surname;
                    editUser.Patronomic = user.Patronomic;
                    editUser.UserName = user.Email;
                    await _userManager.UpdateAsync(editUser);
                }
                else
                {
                    user.UserName = user.Email;
                    await _userManager.CreateAsync(user);
                    var password = await _userManager.GeneratePasswordResetTokenAsync(user);
                    var urlEncode = HttpUtility.UrlEncode(password);
                    var callbackUrl = $"{Request.Scheme}://{Request.Host.Value}/Identity/Account/ResetPassword?userId={user.Id}&code={urlEncode}";
                    var subject = $"Сброс пароля {Request.Host.Value}";
                    var htmlMessage = $"<b>Для сброса пароля перейдите по ссылке <a href='{callbackUrl}'>Сброс пароля</a></b>";
                    await _emailSender.SendEmailAsync(user.Email, subject, htmlMessage);
                }
                    return RedirectToAction("Index");
            }
            catch
            {
                return NotFound();
            }
        }

        public async Task<IActionResult> Remove (string id,
                                                [FromServices] UserManager<ApplicationUser> userManager)
        {
            try
            {
                // TODO: Add update logic here
                if(id!=null)
                {
                    var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
                    if (user != null)
                    {
                        await _userManager.DeleteAsync(user);
                        return RedirectToAction("Index");
                    }
                }

                return NotFound();
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet]
        public async Task<IActionResult> ToggleAdmin(string id, 
            [FromServices] UserManager<ApplicationUser> userManager)
        {
            var role = await _roleManager.FindByNameAsync("Admin");
            if (role == null)
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            var user = await _userManager.FindByIdAsync(id);
            var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");
            if (isAdmin)
            {
                await _userManager.RemoveFromRoleAsync(user, "Admin");
            }
            else
            {
                await _userManager.AddToRoleAsync(user, "Admin");
            }
            return RedirectToAction("Index");
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Users/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }


}
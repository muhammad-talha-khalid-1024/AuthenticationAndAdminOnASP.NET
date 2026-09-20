using System.Security.Claims;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyFirstDotNetApp.Data;
using MyFirstDotNetApp.Dto;
using MyFirstDotNetApp.Models;

namespace MyFirstDotNetApp.Controllers
{
    public class AuthController(AppDbContext _context) : Controller
    {
        // private readonly AppDbContext _context;
        // public AuthController(AppDbContext context)
        // {
        //     _context = context;
        // }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UserRegistration(UserDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View("Register", dto);
            }

            var email = dto.Email.Trim().ToLower();

            var existingUser = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email);

            if (existingUser != null)
            {
                ModelState.AddModelError(
                    "Email",
                    "This email is already registered."
                );

                return View("Register", dto);
            }

            var user = new User
            {
                Name = dto.Name.Trim(),
                Email = email
            };

            var passwordHasher = new PasswordHasher<User>();

            user.Password = passwordHasher.HashPassword(
                user,
                dto.Password
            );

            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] =
                "Registration successful! You can now login.";

            return RedirectToAction("Login");
        }

        [HttpPost]
        public async Task<IActionResult> UserLogin(UserLoginDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View("Login", dto);
            }

            var email = dto.Email.Trim().ToLower();

            var isUserExixt = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email);

            if (isUserExixt == null)
            {
                ModelState.AddModelError(
                    "Email",
                    "The credentials are invalid."
                );

                return View("Login", dto);
            }

            var passwordHasher = new PasswordHasher<User>();

            var result = passwordHasher.VerifyHashedPassword(
                isUserExixt,
                isUserExixt.Password,
                dto.Password
            );

            if (result == PasswordVerificationResult.Failed)
            {
                ModelState.AddModelError(
                    "Email",
                    "The credentials are invalid."
                );
                return View("Login", dto);
            }

            // Start Create authentication cookie
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, isUserExixt.Id.ToString()),
                new Claim(ClaimTypes.Name, isUserExixt.Name),
                new Claim(ClaimTypes.Email, isUserExixt.Email)
            };

            var identity = new ClaimsIdentity(
                claims,
                CookieAuthenticationDefaults.AuthenticationScheme
            );

            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal
            );
            // End Create authentication cookie

            TempData["SuccessMessage"] =
                "You are successfully logged in.";

            return RedirectToAction("Index","Dashboard");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            TempData["SuccessMessage"] =
                "You are successfully logged out.";
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme
            );

            return RedirectToAction("Login");
        }
    }
}
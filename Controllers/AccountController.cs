using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using cleo.Data;
using cleo.Models;
using System.Security.Claims;

namespace cleo.Controllers;

public class AccountController : Controller
{
    private readonly CleoDbContext _db;

    public AccountController(CleoDbContext db)
    {
        _db = db;
    }

    [Route("google-login")]
    public IActionResult GoogleLogin()
    {
        var properties = new AuthenticationProperties { RedirectUri = Url.Action("GoogleResponse") };
        return Challenge(properties, GoogleDefaults.AuthenticationScheme);
    }

    [Route("signin-google-callback")]
    public async Task<IActionResult> GoogleResponse()
    {
        var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        if (!result.Succeeded)
            return RedirectToAction("Login", "Public");

        var claims = result.Principal.Identities.FirstOrDefault()?.Claims;
        var email = claims?.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
        var name = claims?.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
        var googleId = claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        var profilePicture = claims?.FirstOrDefault(c => c.Type == "picture")?.Value;

        if (string.IsNullOrEmpty(email))
            return RedirectToAction("Login", "Public");

        var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == email || u.GoogleId == googleId);

        if (user == null)
        {
            user = new UserAccount
            {
                Email = email,
                Name = name ?? "Google User",
                GoogleId = googleId,
                ProfilePictureUrl = profilePicture,
                JoinDate = DateTime.UtcNow,
                Status = AccountStatus.Active
            };
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
        }
        else
        {
            // Update profile picture if it changed
            if (!string.IsNullOrEmpty(profilePicture) && user.ProfilePictureUrl != profilePicture)
            {
                user.ProfilePictureUrl = profilePicture;
                user.GoogleId = googleId; // Ensure GoogleId is set
                await _db.SaveChangesAsync();
            }
        }

        // Set Session variables for compatibility with existing logic
        HttpContext.Session.SetInt32("UserId", user.Id);
        HttpContext.Session.SetString("Role", "User");
        HttpContext.Session.SetString("Email", user.Email);
        HttpContext.Session.SetString("Name", user.Name);
        if (!string.IsNullOrEmpty(user.ProfilePictureUrl))
        {
            HttpContext.Session.SetString("ProfilePicture", user.ProfilePictureUrl);
        }

        return RedirectToAction("Index", "Dashboard");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        HttpContext.Session.Clear();
        return RedirectToAction("Home", "Public");
    }
}

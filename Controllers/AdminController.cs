using Microsoft.AspNetCore.Mvc;
using cleo.Data;
using cleo.Models;
using Microsoft.EntityFrameworkCore;

namespace cleo.Controllers;

public class AdminController : Controller
{
    private readonly CleoDbContext _db;

    public AdminController(CleoDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public IActionResult Index() => RedirectToAction(nameof(Dashboard));

    [HttpGet]
    public IActionResult Login() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(string email, string password)
    {
        // Simple authentication check against the database
        var admin = await _db.Admins.FirstOrDefaultAsync(a => a.Email == email && a.Password == password);
        if (admin != null)
        {
            HttpContext.Session.SetString("Role", "Admin");
            HttpContext.Session.SetString("Email", admin.Email);
            HttpContext.Session.SetString("AdminName", admin.Name);
            return RedirectToAction(nameof(Dashboard));
        }

        ViewBag.Error = "Invalid credentials";
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Dashboard()
    {
        var guard = EnsureAdminSession();
        if (guard != null) return guard;

        ViewBag.AdminEmail = HttpContext.Session.GetString("Email") ?? "admin@cleo.app";
        ViewBag.Stats = new
        {
            TotalUsers = await _db.Users.CountAsync(),
            ActiveUsers = await _db.Users.CountAsync(u => u.Status == AccountStatus.Active),
            CyclesLogged = await _db.CycleTracks.CountAsync(),
            SystemHealth = "98%",
            StorageUsed = "42%"
        };

        // Static activity for now, log logic pending
        ViewBag.RecentActivity = new[]
        {
            new { User = "System", Action = "DB Initialized", Time = "10 mins ago" }
        };

        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Users()
    {
        var guard = EnsureAdminSession();
        if (guard != null) return guard;

        ViewBag.Stats = new
        {
            TotalUsers = await _db.Users.CountAsync(),
            ActiveUsers = await _db.Users.CountAsync(u => u.Status == AccountStatus.Active),
            BlockedUsers = await _db.Users.CountAsync(u => u.Status == AccountStatus.Blocked)
        };

        ViewBag.UsersList = await _db.Users.ToListAsync();
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Roles()
    {
        var guard = EnsureAdminSession();
        if (guard != null) return guard;

        ViewBag.AdminStats = new 
        { 
            Total = await _db.Admins.CountAsync(), 
            Super = await _db.Admins.CountAsync(a => a.IsSuperAdmin), 
            Active = await _db.Admins.CountAsync(), 
            Inactive = 0 
        };
        ViewBag.AdminsList = await _db.Admins.ToListAsync();

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddAdmin(string name, string email, string password)
    {
        var guard = EnsureAdminSession();
        if (guard != null) return guard;

        if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(email))
        {
            _db.Admins.Add(new AdminMember { Name = name, Email = email, Password = password ?? "Password123" });
            await _db.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Roles));
    }

    [HttpGet]
    public async Task<IActionResult> Content()
    {
        var guard = EnsureAdminSession();
        if (guard != null) return guard;

        ViewBag.ArticlesList = await _db.Articles.ToListAsync();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddArticle(string title, string category, string content)
    {
        var guard = EnsureAdminSession();
        if (guard != null) return guard;

        if (!string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(content))
        {
            _db.Articles.Add(new ContentArticle { Title = title, Category = category ?? "General", Content = content });
            await _db.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Content));
    }

    [HttpGet]
    public IActionResult Settings(string tab = "general")
    {
        var guard = EnsureAdminSession();
        if (guard != null) return guard;

        ViewBag.Tab = tab.ToLower();
        ViewBag.Settings = new
        {
            SystemName = "CLEO Admin Portal",
            AdminEmail = "admin@cleo.app",
            EnableLogs = true,
            MaintenanceMode = false
        };

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Logout()
    {
        var guard = EnsureAdminSession();
        if (guard != null) return guard;

        HttpContext.Session.Clear();
        return RedirectToAction(nameof(Login));
    }

    private IActionResult? EnsureAdminSession()
    {
        var role = HttpContext.Session.GetString("Role");
        return string.Equals(role, "Admin", StringComparison.OrdinalIgnoreCase)
            ? null
            : RedirectToAction(nameof(Login));
    }
}

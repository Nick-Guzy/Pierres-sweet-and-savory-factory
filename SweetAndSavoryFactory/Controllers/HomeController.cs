using Microsoft.AspNetCore.Mvc;
using SweetAndSavoryFactory.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System.Security.Claims;

namespace SweetAndSavoryFactory.Controllers
{
  [Authorize]
    public class HomeController : Controller
    {
      private readonly SweetAndSavoryFactoryContext _db;
      private readonly UserManager<ApplicationUser> _userManager;

      public HomeController(UserManager<ApplicationUser> userManager, SweetAndSavoryFactoryContext db)
      {
        _userManager = userManager;
        _db = db;
      }

      // [HttpGet("/")]
      // public async Task<ActionResult> Index()
      // {
      //   Treat[] treats = _db.Treats.ToArray();
      //   Flavor[] flavors = _db.Flavors.ToArray();
      //   Dictionary<string,object[]> model = new Dictionary<string, object[]>();
      //   // 
      //   model.Add("treats", treats);
      //   model.Add("flavors", flavors);
      //   //
      //   string userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      //   ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);
      //   if (currentUser != null)
      //   {
      //     Treat[] treat = _db.Treats
      //                 .Where(entry => entry.User.Id == currentUser.Id)
      //                 .ToArray();
      //     model.Add("treats", treats);
      //     Flavor[] flavor = _db.Flavors
      //                 .Where(entry => entry.User.Id == currentUser.Id)
      //                 .ToArray();
      //     model.Add("flavors", flavors);
      //   }
      //   return View(model);


      [HttpGet("/")]
      public async Task<ActionResult> Index()
      {
        Treat[] treat = _db.Treats.ToArray();
        Flavor[] flavors = _db.Flavors.ToArray();
        Dictionary<string,object[]> model = new Dictionary<string, object[]>();
        model.Add("treats", treat);
        model.Add("flavors", flavors);
        string userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);
        if (currentUser != null)
        {
          Treat[] treats = _db.Treats
          .Where(entry => entry.User.Id == currentUser.Id).ToArray();
          model.Add("treat", treat);
          Flavor[] flavor = _db.Flavors
          .Where(entry => entry.User.Id == currentUser.Id).ToArray();
          model.Add("flavor", flavor);
        }
        return View(model);
      }
    }
}
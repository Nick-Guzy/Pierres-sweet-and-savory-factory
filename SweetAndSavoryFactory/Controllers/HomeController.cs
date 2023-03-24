using Microsoft.AspNetCore.Mvc;
using SweetAndSavoryFactory.Models;
using System.Collections.Generic;
using System.Linq;

namespace SweetAndSavoryFactory.Controllers
{
    public class HomeController : Controller
    {
      private readonly SweetAndSavoryFactoryContext _db;

      public HomeController(SweetAndSavoryFactoryContext db)
      {
        _db = db;
      }

      [HttpGet("/")]
      public ActionResult Index()
      {
        Treat[] treats = _db.Treats.ToArray();
        Machine[] machines = _db.Machines.ToArray();
        Dictionary<string,object[]> model = new Dictionary<string, object[]>();
        model.Add("treats", treats);
        model.Add("machines", machines);
        return View(model);
      }
    }
}
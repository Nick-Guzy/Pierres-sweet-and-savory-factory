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
        Engineer[] engineers = _db.Engineers.ToArray();
        Machine[] machines = _db.Machines.ToArray();
        Dictionary<string,object[]> model = new Dictionary<string, object[]>();
        model.Add("engineers", engineers);
        model.Add("machines", machines);
        return View(model);
      }
    }
}
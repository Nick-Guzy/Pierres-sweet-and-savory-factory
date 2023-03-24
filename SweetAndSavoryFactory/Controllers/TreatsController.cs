using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using SweetAndSavoryFactory.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SweetAndSavoryFactory.Controllers
{
  public class TreatsController : Controller
  {
    private readonly SweetAndSavoryFactoryContext _db;

    public TreatsController(SweetAndSavoryFactoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Treat> model = _db.Treats.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Treat treat)
    {
      if (!ModelState.IsValid)
      {
          ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name", "MachineDetails");
          return View(treat);
      }
      else
      {
        _db.Treats.Add(treat);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
    }

    public ActionResult Details(int id)
    {
      Treat thisTreat = _db.Treats
        .Include(join => join.JoinEntities)
        .ThenInclude(machine => machine.Machine)
        .FirstOrDefault(treat => treat.TreatId == id);
      return View(thisTreat);
    }

    public ActionResult Edit(int id)
    {
      Treat thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
      return View(thisTreat);
    }

    [HttpPost]
    public ActionResult Edit(Treat treat)
    {
      _db.Treats.Update(treat);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Treat thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
      return View(thisTreat);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Treat thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
      _db.Treats.Remove(thisTreat);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

     public ActionResult AddMachine(int id)
    {
      Treat thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Description", "MachineDetails");
      return View(thisTreat);
    } 

[HttpPost]
public ActionResult AddMachine(Treat treat, int machineId)
{
  #nullable enable
  MachineEngineer? joinEntity = _db.MachineEngineer.FirstOrDefault(join => (join.MachineId == machineId && join.TreatId == treat.TreatId));
  #nullable disable
  if (joinEntity == null && machineId != 0)
  {
    _db.MachineEngineer.Add(new MachineEngineer() {
      MachineId = machineId, TreatId = treat.TreatId
    });
    _db.SaveChanges();
  }
  return RedirectToAction("Details", new { id = treat.TreatId });
}

    [HttpPost]
    public ActionResult DeleteJoin(int joinId)
    {
      MachineEngineer joinEntry = _db.MachineEngineer.FirstOrDefault(entry => entry.MachineEngineerId == joinId);
      _db.MachineEngineer.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    } 
  }
}
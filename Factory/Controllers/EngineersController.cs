using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Factory.Controllers
{
  public class EngineersController : Controller
  {
    private readonly FactoryContext _db;

    public EngineersController(FactoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Engineer> model = _db.Engineers.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Engineer engineer)
    {
      if (!ModelState.IsValid)
      {
          ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name", "MachineDetails");
          return View(engineer);
      }
      else
      {
        _db.Engineers.Add(engineer);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
    }

    public ActionResult Details(int id)
    {
      Engineer thisEngineer = _db.Engineers
        .Include(join => join.JoinEntities)
        .ThenInclude(machine => machine.Machine)
        .FirstOrDefault(engineer => engineer.EngineerId == id);
      return View(thisEngineer);
    }

    public ActionResult Edit(int id)
    {
      Engineer thisEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
      return View(thisEngineer);
    }

    [HttpPost]
    public ActionResult Edit(Engineer engineer)
    {
      _db.Engineers.Update(engineer);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Engineer thisEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
      return View(thisEngineer);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Engineer thisEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
      _db.Engineers.Remove(thisEngineer);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

     public ActionResult AddMachine(int id)
    {
      Engineer thisEngineer = _db.Engineers.FirstOrDefault(engineers => engineers.EngineerId == id);
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Description", "MachineDetails");
      return View(thisEngineer);
    }
    // Left in to see the diference of a post that doesn't work. Look at thew differences between this one and the one below it.
    // [HttpPost]
    // public ActionResult AddMachine(Engineer engineer, int machineId)
    // {
    //   #nullable enable
    //   MachineEngineer? joinEntity = _db.MachineEngineer.FirstOrDefault(join => (join.EngineerId == join.EngineerId && join.MachineId == join.MachineId));
    //   #nullable disable
    //   if (joinEntity == null && engineer.EngineerId != 0)
    //   {
    //     _db.MachineEngineer.Add(new MachineEngineer() { EngineerId = engineer.EngineerId, MachineId = machineId });
    //     _db.SaveChanges();
    //   }
    //   return RedirectToAction("Details", new { id = engineer.EngineerId });
    // }   

[HttpPost]
public ActionResult AddMachine(Engineer engineer, int machineId)
{
  #nullable enable
  MachineEngineer? joinEntity = _db.MachineEngineer.FirstOrDefault(join => (join.MachineId == machineId && join.EngineerId == engineer.EngineerId));
  #nullable disable
  if (joinEntity == null && machineId != 0)
  {
    _db.MachineEngineer.Add(new MachineEngineer() {
      MachineId = machineId, EngineerId = engineer.EngineerId
    });
    _db.SaveChanges();
  }
  return RedirectToAction("Details", new { id = engineer.EngineerId });
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
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace SweetAndSavoryFactory.Models
{
  public class Treat
  {
    public int TreatId { get; set; }
    [Required(ErrorMessage = "The Treat's name can't be empty!")]
    public string Name { get; set; }
    public string TreatDetails { get; set; }
    public Flavor Flavor { get; set; }
    public List<FlavorTreat> JoinEntities { get; }
  }
}
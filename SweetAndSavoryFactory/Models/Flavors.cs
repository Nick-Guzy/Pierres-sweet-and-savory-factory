using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SweetAndSavoryFactory.Models
{
  public class Flavor
  {
    public int FlavorId { get; set; }
    [Required(ErrorMessage = "The Flavor's description can't be empty!")]
    public string Description { get; set; }
    public string FlavorDetails { get; set; }
    public Treat Treat { get; set; }
    public List<FlavorTreat> JoinEntities { get; }
  }
}
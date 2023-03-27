using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace SweetAndSavoryFactory.Models
{
  public class Treat
  {
    public int TreatId { get; set; }
    public string Name { get; set; }
    [Required(ErrorMessage = "The Treat's name can't be empty!")]
    public string TreatDetails { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "You must add your Treat to a Flavor. Have you created a Flavor yet?")]
    public Flavor Flavor { get; set; }
    public List<FlavorTreat> JoinEntities { get; }
    public ApplicationUser User { get; set; }
  }
}
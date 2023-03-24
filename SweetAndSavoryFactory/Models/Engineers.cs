using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace SweetAndSavoryFactory.Models
{
  public class Engineer
  {
    public int EngineerId { get; set; }
    [Required(ErrorMessage = "The Engineer's name can't be empty!")]
    public string Name { get; set; }
    public string EnginieerDetails { get; set; }
    
    public List<MachineEngineer> JoinEntities { get; }
  }
}
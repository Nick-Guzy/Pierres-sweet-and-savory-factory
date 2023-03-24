using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Factory.Models
{
  public class Machine
  {
    public int MachineId { get; set; }
    [Required(ErrorMessage = "The Machine's description can't be empty!")]
    public string Description { get; set; }
    public string MachineDetails { get; set; }
    public Engineer Engineer { get; set; }
    public List<MachineEngineer> JoinEntities { get; }
  }
}
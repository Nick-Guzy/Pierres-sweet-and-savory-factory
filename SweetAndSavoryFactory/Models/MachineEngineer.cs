namespace SweetAndSavoryFactory.Models
{
  public class MachineEngineer
    {       
        public int MachineEngineerId { get; set; }
        public int MachineId { get; set; }
        public Machine Machine { get; set; }
        public int TreatId { get; set; }
        public Treat Treat { get; set; }
    }
}
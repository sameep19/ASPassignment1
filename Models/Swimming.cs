using System.ComponentModel.DataAnnotations;

namespace swimming.Models;
public class Swimming{
    public int Id{get; set; }
    public string PoolName{get; set; }
    public string PoolLength{get; set; }
    public string PoolLocation{get; set; }
    public string PoolCapacity{get; set; }
    public string PoolTimings{get; set; }
    public string PoolDays{get; set; }
    public decimal PoolSize{get; set; }

    [DataType(DataType.Date)]
    public DateTime EntryDeadline{get; set; }

    public bool Selected{get; set; } = false;
}
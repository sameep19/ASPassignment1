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
}
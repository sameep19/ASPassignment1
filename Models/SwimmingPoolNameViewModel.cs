using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace swimming.Models

{

    public class SwimmingPoolNameViewModel
    {
        public List<Swimming>? Swimming { get; set; }
        public SelectList? PoolName { get; set; }
        public string? SwimmingPoolName{ get; set; }
        public string? SearchParamString { get; set; }
        public string? PoolSizeSearchNumber { get; set; }
        public string? EntryDeadline { get; set; }
    }
}
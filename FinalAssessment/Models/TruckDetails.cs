using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalAssessment.Models
{
    
    public class TruckDetails 
    {
        public int Id { get; set; }
        public string TruckRGNumber { get; set; }
        public string TruckFitnessExpiry { get; set; }
        public string TruckModel { get; set; }

        public decimal TruckHaulingCapacity { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace FinalAssessment.Models​
{
    public partial class DriverDetail
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LicenseNumber { get; set; }
        public DateTime? LicenseExpiryDate { get; set; }
    }
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int temperature { get; set; }

      /*  public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);*/
       public string latitude { get; set; }
        public string longitude { get; set; }

        public int driverId { get; set; }

        public string truckrn { get; set; }
    }
}

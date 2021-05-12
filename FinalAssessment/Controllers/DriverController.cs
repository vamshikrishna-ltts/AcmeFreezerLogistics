using FinalAssessment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalAssessment.Controllers
{
    [ApiController]
    /* [Route("api/[controller]")]*/
    public class DriverController : Controller
    {
        private static readonly string[] Summaries = new[]
               {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<DriverController> _logger;

        public DriverController(ILogger<DriverController> logger)
        {
            _logger = logger;
        }

        [Route("api/acme/stat/getdata")]
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {

            try
            {
                var rng = new Random();
                return Enumerable.Range(1, 1).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    temperature = rng.Next(-20, 55),
                    latitude = Summaries[rng.Next(Summaries.Length)],
                    longitude = Summaries[rng.Next(Summaries.Length)],
                    driverId = 1,
                    truckrn = "KA09TS1234"
                })
                .ToArray();
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        [Route("api/acme/stat/getdata/{id}")]
        [HttpGet]
        public DriverDetail Get(int id = 0)

        {

            try
            {
                using (AcmeFreezerLogisticsContext entities = new AcmeFreezerLogisticsContext())
                {
                    return entities.DriverDetails.FirstOrDefault(e => e.Id == id);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        [Route("api/[controller]/postDriver")]
        [HttpPost]
        public string Post([FromBody] DriverDetail driverDetail)
        {

            try
            {
                //  WebapiContext context = new WebapiContext();
                using (AcmeFreezerLogisticsContext entities = new AcmeFreezerLogisticsContext())
                {
                    entities.DriverDetails.Add(driverDetail);
                    entities.SaveChanges();
                    return "success";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
            
        }


        [Route("api/[controller]/update/{id}")]
        [HttpPut]
        public string Put([FromBody] DriverDetail driverDetail,int id=0)
        {
            try
            {
                AcmeFreezerLogisticsContext context = new AcmeFreezerLogisticsContext();

                var entity = context.DriverDetails.FirstOrDefault(e => e.Id == id);
                if (entity == null)
                {
                    return "";
                    // "Employee with Id " + id.ToString() + " not found to update");
                }
                else
                {
                    entity.FirstName = driverDetail.FirstName;
                    entity.LastName = driverDetail.LastName;
                    entity.LicenseNumber = driverDetail.LicenseNumber;
                    entity.LicenseExpiryDate = driverDetail.LicenseExpiryDate;
                    context.Update(entity);
                    context.SaveChanges();


                    //  return new Request.CreateResponse(HttpStatusCode.OK, entity);
                    return "success";
                }

            }
            catch (Exception ex)
            {
                return "error";
                // new HttpResponseMessage
            }
            
        }


        [HttpDelete]
        [Route("api/[controller]/delete/{id}")]
        public string Delete(int id)
        {
            try
            {
                AcmeFreezerLogisticsContext context = new AcmeFreezerLogisticsContext();
                context.DriverDetails.Remove(context.DriverDetails.FirstOrDefault(e => e.Id == id));
                context.SaveChanges();
                return "Drvier with Id " + id.ToString() + " ie deleted";
            }
            catch (Exception ex)
            {
                return "Not deleted";
            }
           
        }
    }
}

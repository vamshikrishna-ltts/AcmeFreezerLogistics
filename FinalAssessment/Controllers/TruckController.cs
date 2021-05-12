using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalAssessment.Models;
namespace FinalAssessment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TruckController : Controller
    {
        [Route("getTruckDetails")]
        [HttpGet]
        public string Get()
        {
            
            return "truck";
        }


        [Route("postTruckdetails")]

        [HttpPost]

        public string PostTruck([FromBody] TruckDetails truckDetails)
        {

            try
            {
                using (AcmeFreezerLogisticsContext entities = new AcmeFreezerLogisticsContext())
                {
                    entities.TruckDetails.Add(truckDetails);
                    entities.SaveChanges();
                    //  return new Request.CreateResponse(HttpStatusCode.OK, entity);
                    return "success";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }


            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Bl;
using Dto;

namespace api3.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/statusDose")]
    public class StatusDoseController : ApiController
    {
        [HttpGet]
        [Route("allStatusWithDishes/{statusMeal}")]
        public IHttpActionResult GetAllStatusDoseWithDishes([FromUri]int statusMeal)
        {
            List<StatusDoseDto> statusDoses = StatusDoseBL.GetALlStatusWithDishes(statusMeal);
            if (statusDoses != null)
                return Ok(statusDoses);
            return BadRequest();
        }
    }
}

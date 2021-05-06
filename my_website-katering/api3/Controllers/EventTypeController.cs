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
    [RoutePrefix("api/eventType")]
    public class EventTypeController : ApiController
    {
        [HttpGet]
        [Route("getEventType/{isBasic}/{statusShabbat}/{statusMeal}")]
        public IHttpActionResult GetAllRecommendations([FromUri] bool isBasic, [FromUri] int statusShabbat, [FromUri] int statusMeal)
        {
            try
            {
                EventTypeDishesDto eventTypeDishes = new EventTypeDishesDto();
                eventTypeDishes.eventType = EventTypeBL.GetEventType(isBasic, statusShabbat, statusMeal);
                eventTypeDishes.statusDose = StatusDoseBL.GetStatusWithDishes(statusMeal, statusShabbat, isBasic);
                return Ok(eventTypeDishes);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}

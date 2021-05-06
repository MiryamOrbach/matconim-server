using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Cors;
using System.Web.Http;
namespace api3.Controllers
    
{
    [EnableCors("*","*","*")]
    [RoutePrefix("api/menu")]
    public class MenuController : ApiController
    {
        [HttpGet]
        [Route("GetAllDishesByStatusMeal/{statusMeal}")]
        public IHttpActionResult GetAllDishesByStatusMeal(int statusMeal)
        {
            List<Dto.DishDto> dishes = Bl.MenuBL.Menu(statusMeal);
            if (dishes != null)
                return Ok(dishes);
            return BadRequest();
        }
    }
}

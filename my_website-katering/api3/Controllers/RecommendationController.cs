using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Bl;
using Dto;
using Newtonsoft.Json.Linq;

namespace api3.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/recommendation")]
    public class RecommendationController : ApiController
    {
        [HttpGet]
        [Route("allRecommendations")]
        public IHttpActionResult GetAllRecommendations()
        {
            List<Dto.RecommendationDto> recommendations = RecommendationBL.GetAllRecommendation();
            if (recommendations != null)
                return Ok(recommendations);
            return BadRequest();
        }
        [HttpGet]
        [Route("recommendationByIsDisplay/{isDisplay}")]
        public IHttpActionResult GetAllRecommendations([FromUri] bool isDisplay)
        {
            List<Dto.RecommendationDto> recommendations = RecommendationBL.GetRecommendationByIsDisplay(isDisplay);
            if (recommendations != null)
                return Ok(recommendations);
            return BadRequest();
        }
        [HttpPost]
        [Route("updateIsDisplay")]
        public IHttpActionResult updateIsDisplay([FromBody]List<RecommendationDto> recommendations)
        {
            try
            {
                RecommendationBL.UpdateIsDisplay(recommendations);
                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
           
          
        }
        [HttpPost]
        [Route("add")]
        public IHttpActionResult AddRecommendation([FromBody] Dto.RecommendationDto recommendation)
        {
            try
            {
               
                recommendation = RecommendationBL.AddRecommendation(recommendation);
                if (recommendation != null)
                    return Ok(recommendation);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

    }
}

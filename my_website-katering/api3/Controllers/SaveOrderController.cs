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
    [RoutePrefix("api/saveOrder")]
    public class SaveOrderController : ApiController
    {
        [HttpPost]
        [Route("add")]
        public IHttpActionResult AddOrder([FromBody] SaveOrderDto saveOrder)
        {
            try
            {
                OrderDto o = OrderBL.AddOrder(saveOrder.order);
                int succDish= OrderBL.AddOrderDish(saveOrder.dishes, o.idOrder);
                int succExtra = OrderBL.AddExtraToOrder(saveOrder.extras, o.idOrder);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        [HttpGet]
        [Route("getOrder/{customerId}")]
        public IHttpActionResult GetOrder([FromUri] int customerId)
            {
            try
            {
                OrderDto o = OrderBL.GetOrderFull(customerId);
                EventsTypeDto t = EventTypeBL.GetEventTypeById(o.idEvent.Value);
                List<DishDto> dishes = OrderBL.GetOrderDishes(o.idOrder);
                OrderDetailsDto oo = new OrderDetailsDto() { amount = o.amount ,Customer=o.Customer,dateOrder=o.dateOrder,dateInsert=o.dateInsert
                ,EventsType=o.EventsType,idOrder=o.idOrder,idEvent=o.idEvent,idCustomer=o.idCustomer,nameEvent=o.nameEvent,statusOrder=o.statusOrder};
                oo.extras = OrderBL.GetExtras(o.idOrder);
                oo.TotalPrice = t.priceAll.Value * o.amount.Value;
                oo.extras.ForEach(e => oo.TotalPrice +=(decimal) e.extra.priceExtra);



                var x=dishes.GroupBy(gg => gg.typeDose);
                List<StatusDoseDto> g = new List<StatusDoseDto>();
                foreach (var item in x)
                { StatusDoseDto oc = Bl.StatusDoseBL.GetStatusById(item.Key.Value);
                    oc.Dishes= item.ToList();
                    g.Add(oc);
                }
                oo.dishes = g;

                //int succDish = OrderBL.AddOrderDish(saveOrder.dishes, o.idOrder);
                //int succExtra = OrderBL.AddExtraToOrder(saveOrder.extras, o.idOrder);
                return Ok(oo);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

    }
}

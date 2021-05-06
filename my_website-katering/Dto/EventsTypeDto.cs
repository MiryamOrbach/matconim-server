using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
   public class EventsTypeDto
    {

        public int idEvent { get; set; }
        public string eventName { get; set; }
        public Nullable<int> amountMin { get; set; }
        public Nullable<int> statusMeal { get; set; }
        public Nullable<int> priceAll { get; set; }
        public Nullable<bool> isBasic { get; set; }
        public Nullable<int> statusShabat { get; set; }
        public EventsTypeDto()
        {

        }
        public EventsTypeDto(Dal.EventsType e)
        {
            idEvent = e.idEvent;
            eventName = e.eventName;
            amountMin = e.amountMin;
            statusMeal = e.statusMeal;
            priceAll = e.priceAll;
            isBasic = e.isBasic;
            statusShabat = e.statusShabat;
            
        }
        public static Dal.EventsType Todal(EventsTypeDto e)
        {
            return new Dal.EventsType
            {
            idEvent = e.idEvent,
            eventName = e.eventName,
            amountMin = e.amountMin,
            statusMeal = e.statusMeal,
            priceAll = e.priceAll,
            isBasic=e.isBasic,
            statusShabat=e.statusShabat
        };
        }
    }
}

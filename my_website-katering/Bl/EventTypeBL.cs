using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dto;

namespace Bl
{
    public class EventTypeBL
    {
        public static EventsTypeDto GetEventType(bool isBasic, int statusShabbat, int statusMeal)
        {
            EventsType e = EventTypeDal.GetEventType(isBasic,statusShabbat,statusMeal);
            EventsTypeDto eventType =new EventsTypeDto(e);
            return eventType;
        }
        public static EventsTypeDto GetEventTypeById(int id)
        {
            EventsType e = EventTypeDal.GetEventTypeById(id);
            EventsTypeDto eventType = new EventsTypeDto(e);
            return eventType;
        }
    }
}

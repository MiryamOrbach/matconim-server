using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class EventTypeDal
    {
        public static EventsType GetEventType(bool isBasic, int statusShabbat, int statusMeal)
        {
            using (myProjectEntities db = new myProjectEntities())
            {
                try
                {
                    EventsType e = db.EventsTypes.Where(r => r.isBasic == isBasic && r.statusShabat == statusShabbat && r.statusMeal == statusMeal).FirstOrDefault();
                    return e;
                }
                catch (Exception e)
                {

                    return null;
                }

            }
        }
        public static EventsType GetEventTypeById(int id)
        {
            using (myProjectEntities db = new myProjectEntities())
            {
                try
                {
                    EventsType e = db.EventsTypes.Where(p=>p.idEvent==id).FirstOrDefault();
                    return e;
                }
                catch (Exception e)
                {

                    return null;
                }

            }
        }
    }
}

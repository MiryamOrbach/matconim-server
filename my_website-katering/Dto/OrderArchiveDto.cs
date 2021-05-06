using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    class OrderArchiveDto
    {
        public int idOrder { get; set; }
        public string tz { get; set; }
        public Nullable<int> idEvent { get; set; }
        public string orderDetails { get; set; }
        public Nullable<System.DateTime> dateOrder { get; set; }
        public Nullable<bool> statusOrder { get; set; }
        public OrderArchiveDto(Dal.OrderArchive o)
        {
            this.idOrder = o.idOrder;
            this.tz = o.tz;
            this.idEvent = o.idEvent;
            this.dateOrder = o.dateOrder;
            this.statusOrder = o.statusOrder;
          
        }
        public static Dal.OrderArchive Todal(OrderArchiveDto o)
        {
            return new Dal.OrderArchive
            {
            idOrder = o.idOrder,
            tz = o.tz,
            idEvent = o.idEvent,
            dateOrder = o.dateOrder,
            statusOrder = o.statusOrder
        };
        }
    }
}

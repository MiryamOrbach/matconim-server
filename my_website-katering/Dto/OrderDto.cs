using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
   public class OrderDto
    {
        public int idOrder { get; set; }
        public Nullable<int> idCustomer { get; set; }
        public Nullable<int> idEvent { get; set; }
        public Nullable<System.DateTime> dateOrder { get; set; }
        public Nullable<System.DateTime> dateInsert { get; set; }
        public Nullable<bool> statusOrder { get; set; }
        public string nameEvent { get; set; }
        public Nullable<int> amount { get; set; }
        public Dictionary<int,DishDto> dishes { get; set; }

        public virtual CustDto Customer { get; set; }
        public virtual EventsTypeDto EventsType { get; set; }

        public OrderDto()
        {

        }
        public OrderDto(Dal.Order o)
        {
            idOrder = o.idOrder;
            dateOrder = o.dateOrder;
            dateInsert = o.dateInsert;
            statusOrder = o.statusOrder;
            nameEvent = o.nameEvent;
            amount = o.amount;
            idCustomer = o?.idCustomer;
            idEvent = o.idEvent;
            Customer =new CustDto(o.Customer);
        }
        public static Dal.Order Todal(OrderDto o)
        {
            return new Dal.Order
            {
                idOrder = o.idOrder,
                dateOrder = o.dateOrder,
                dateInsert=o.dateInsert,
                statusOrder = o.statusOrder,
                nameEvent = o.nameEvent,
                amount = o.amount,
                idCustomer = o.idCustomer,
                idEvent = o.idEvent,
                
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
   public class OrderDetailsDto
    {
        public int idOrder { get; set; }
        public Nullable<int> idCustomer { get; set; }
        public Nullable<int> idEvent { get; set; }
        public Nullable<System.DateTime> dateOrder { get; set; }
        public Nullable<System.DateTime> dateInsert { get; set; }
        public Nullable<bool> statusOrder { get; set; }
        public string nameEvent { get; set; }
        public Nullable<int> amount { get; set; }
        public List<StatusDoseDto> dishes { get; set; }
        public List<ExtraToOrderDto> extras { get; set; }
        public decimal TotalPrice { get; set; }

        public virtual CustDto Customer { get; set; }
        public virtual EventsTypeDto EventsType { get; set; }
    }
}

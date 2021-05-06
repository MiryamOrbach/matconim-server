using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
   public class ExtraToOrderDto
    {
        public int ExtraOrdId { get; set; }
        public int idExtra { get; set; }
        public int idOrder { get; set; }
        public virtual EventExtensionDto extra { get; set; }
        public ExtraToOrderDto()
        {

        }
        public ExtraToOrderDto(Dal.ExtraToOrder e)
        {
            this.ExtraOrdId = e.ExtraOrdId;
            this.idExtra = e.idExtra;
            this.idOrder = e.idOrder;
            extra = new EventExtensionDto(e.EventExtension);

        }
        public static Dal.ExtraToOrder Todal(ExtraToOrderDto e)
        {
            return new Dal.ExtraToOrder
            {
            ExtraOrdId = e.ExtraOrdId,
            idExtra = e.idExtra,
            idOrder = e.idOrder
        };
        }
    }
}

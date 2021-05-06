using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
  public  class EventExtensionDto
    {
        public int idExtra { get; set; }
        public string nameExtra { get; set; }
        public Nullable<decimal> priceExtra { get; set; }

        public EventExtensionDto()
        {

        }
        public EventExtensionDto(Dal.EventExtension e)
        {
            this.idExtra = e.idExtra;
            this.nameExtra = e.nameExtra;
            this.priceExtra = e.priceExtra;
         


        }
        public static Dal.EventExtension Todal(EventExtensionDto e)
        {
            return new Dal.EventExtension
            {
              idExtra = e.idExtra,
           nameExtra = e.nameExtra,
           priceExtra = e.priceExtra
        };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
  public  class EventTypeDishesDto
    {
      public  EventsTypeDto eventType { get; set; }
       public List<StatusDoseDto> statusDose { get; set; }
    }
}

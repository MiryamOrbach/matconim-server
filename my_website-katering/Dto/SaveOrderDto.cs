using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class SaveOrderDto
    {
      public  OrderDto order { get; set; }
      public  List<int> dishes { get; set; }
      public  List<int> extras { get; set; }
    }
}

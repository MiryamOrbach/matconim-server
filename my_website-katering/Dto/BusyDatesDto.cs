//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Dto
//{
//    class BusyDatesDto
//    {

//        public System.DateTime idDate { get; set; }
//        public Nullable<System.DateTime> busyDate1 { get; set; }

//        public BusyDatesDto(Dal.BusyDate b)
//        {
//            this.idDate = b.idDate;
//            this.busyDate1 = b.busyDate1;
       
//        }
//        public static Dal.BusyDate Todal(BusyDatesDto b)
//        {
//            return new Dal.BusyDate
//            {
//                idDate = b.idDate,
//                busyDate1 = b.busyDate1
           
//            };
//        }
//    }
//}

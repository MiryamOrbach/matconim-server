using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    class EventPacketsDto
    {

        public int idEventpacket { get; set; }
        public Nullable<int> idDose { get; set; }
        public Nullable<int> amount { get; set; }
        public EventPacketsDto(Dal.EventPacket e)
        {
            this.idEventpacket = e.idEventpacket;
            this.idDose = e.idDose;
            this.amount = e.amount;
        }
        public static Dal.EventPacket Todal(EventPacketsDto e)
        {
            return new Dal.EventPacket
            {
            idEventpacket = e.idEventpacket,
            idDose = e.idDose,
            amount = e.amount
        };
        }
    }
}


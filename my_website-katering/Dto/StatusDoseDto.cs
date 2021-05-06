using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;

namespace Dto
{
    public class StatusDoseDto
    {
        public int idStatusDose { get; set; }
        public string statusDoseName { get; set; }
        public int? sumChooseBase { get; set; }
        public int ?sumChooseUpgrade { get; set; }
        public bool? IsDisplayBase { get; set; }

        public virtual List<DishDto> Dishes { get; set; }
        public StatusDoseDto()
        {

        }
        public StatusDoseDto(StatusDose s)
        {
            idStatusDose = s.idStatusDose;
            statusDoseName = s.statusDoseName;
            sumChooseBase = s.sumChooseBase;
            sumChooseUpgrade = s.sumChooseUpgrade;
            IsDisplayBase = s.IsDisplayBase;
            //Dishes = s.Dishes.Select(x => new DishDto(x)).ToList();z
        }
        public static StatusDose ToDal(StatusDoseDto s)
        {
            return new StatusDose()
            {
                idStatusDose = s.idStatusDose,
                statusDoseName = s.statusDoseName,
                sumChooseUpgrade = s.sumChooseUpgrade,
                IsDisplayBase = s.IsDisplayBase,
                sumChooseBase = s.sumChooseBase

            };
}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dto
{
    public class DishDto
    {
        public int idDose { get; set; }
        public string doseName { get; set; }
        public string doseDescription { get; set; }
        public Nullable<decimal> priceDose { get; set; }
        public byte[] picture { get; set; }
        public Nullable<int> statusMeal { get; set; }
        public Nullable<int> typeDose { get; set; }

        
        public DishDto(Dal.Dish d)
        {
            this.idDose = d.idDose;
            this.doseName = d.doseName;
            this.doseDescription = d.doseDescription;
            this.priceDose = d.priceDose;
            this.picture = d.picture;
            this.statusMeal = d.statusMeal;
            this.typeDose = d.typeDose;

        }

        public static Dal.Dish Todal(DishDto d)
        {
            return new Dal.Dish
            {
                idDose = d.idDose,
                doseName = d.doseName,
                doseDescription = d.doseDescription,
                priceDose = d.priceDose,
                picture = d.picture,
                statusMeal = d.statusMeal,
                typeDose = d.typeDose
                
            };
        }

        public static List<Dal.Dish> Todal(List<DishDto> d)
        {
            return d.Select(m => new Dal.Dish
            {
                idDose = m.idDose,
                doseName = m.doseName,
                doseDescription = m.doseDescription,
                priceDose = m.priceDose,
                picture = m.picture,
                statusMeal = m.statusMeal,
                typeDose = m.typeDose

            }).ToList();
        }
    }
}
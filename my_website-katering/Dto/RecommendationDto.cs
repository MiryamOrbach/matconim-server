using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
   public class RecommendationDto
    {
        public Nullable<System.DateTime> dateR { get; set; }
        public string textR { get; set; }
        public int idRecommendations { get; set; }
        public Nullable<bool> isDisplay { get; set; }

        public CustDto Customer { get; set; }

        public RecommendationDto()
        {

        }
        public RecommendationDto(Dal.Recommendation r)
        {
            dateR = r.dateR;
            textR = r.textR;
            idRecommendations = r.idRecommendations;
            isDisplay = r.isDisplay;
            Customer = new CustDto() { idCustomer = r.Customer.idCustomer ,firstName=r.Customer.firstName,lastName=r.Customer.lastName};
        }
        public static Dal.Recommendation Todal(RecommendationDto r)
        {
            return new Dal.Recommendation
            {
                dateR = r.dateR,
                textR = r.textR,
                idRecommendations = r.idRecommendations,
                isDisplay = r.isDisplay,
               idCustomer=r.Customer.idCustomer
        };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class ContactUsDto
    {
        public int idContactUs { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string textC { get; set; }
        public Nullable<bool> isTreated { get; set; }

        public ContactUsDto()
        {

        }
        public ContactUsDto(Dal.ContactU c)
        {
            idContactUs = c.idContactUs;
            firstName = c.firstName;
            lastName = c.lastName;
            email = c.email;
            textC = c.textC;
            isTreated = c.isTreated;

        }

        public static Dal.ContactU Todal(ContactUsDto c)
        {
            return new Dal.ContactU
            {
                idContactUs = c.idContactUs,
                firstName = c.firstName,
                lastName = c.lastName,
                email = c.email,
                textC = c.textC,
                isTreated = c.isTreated
            };
        }
    }
}


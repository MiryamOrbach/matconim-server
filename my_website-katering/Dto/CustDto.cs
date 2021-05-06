using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class CustDto
    {
        public int idCustomer { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string tel { get; set; }
        public string email { get; set; }
        public Nullable<int> permissionCode { get; set; }
        public string password { get; set; }
        public CustDto(Dal.Customer c)
        {
            idCustomer = c.idCustomer;
            firstName=c.firstName;
            lastName = c.lastName;
            tel = c.tel;
            email = c.email;
            permissionCode = c.permissionCode;
            password = c.password;


        }
        public CustDto()
        {

        }
        public static Dal.Customer Todal(CustDto c)
        {
            return new Dal.Customer
            {
                idCustomer = c.idCustomer,
                firstName = c.firstName,
                lastName = c.lastName,
                tel = c.tel,
                email = c.email,
                permissionCode = 2,
                password=c.password,
            };
        }
    }
}

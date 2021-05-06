using System;
using System.Linq;
using System.Collections.Generic;
using Dal;
namespace Dal
{
    public class CustDal
    {
        public static int Register(Customer cust)
        {

            try
            {
                using (myProjectEntities db = new myProjectEntities())
                {
                    db.Customers.Add(cust);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw e ;
            }
            return cust.idCustomer;

        }

        public static Customer Login(string email, string password)
        {

            try
            {
                using (myProjectEntities db = new myProjectEntities())
                {
                    List<Customer> cu = db.Customers.ToList();
                    Customer cust = db.Customers.ToList().Where(c => c.email == email && c.password == password).First();
                    return cust;
                }
            }
            catch (Exception e)
            {
                return null;
            }

         
        }
    }
}
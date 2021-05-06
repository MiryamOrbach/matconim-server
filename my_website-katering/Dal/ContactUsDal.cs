using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class ContactUsDal
    {
        public static List<ContactU> GetAllContacts()
        {
            using (myProjectEntities db = new myProjectEntities())
            {
                try
                {
                    List<ContactU> contacts = db.ContactUs.ToList();
                    return contacts;
                }
                catch (Exception e)
                {

                    return null;
                }

            }
        }
        public static List<ContactU> GetContactsByIsTreated(bool isTreated)
        {
            using (myProjectEntities db = new myProjectEntities())
            {
                try
                {
                    List<ContactU> contacts = db.ContactUs.Where(r => r.isTreated == isTreated).ToList();
                    return contacts;
                }
                catch (Exception e)
                {

                    return null;
                }

            }
        }

        public static int AddContactUs(ContactU model)
        {
            using (myProjectEntities db = new myProjectEntities())
            {
                try
                {
                    db.ContactUs.Add(model);
                    db.SaveChanges();
                    return model.idContactUs;
                }
                catch (Exception e)
                {

                    throw e;
                }

            }

        }
        public static void UpdateIsTreated(int id)
        {
            using (myProjectEntities db = new myProjectEntities())
            {
                try
                {
                    ContactU c = db.ContactUs.Where(r => r.idContactUs == id).FirstOrDefault();
                    c.isTreated = true;
                    db.SaveChanges();
                }
                catch (Exception e)
                {

                    throw e;
                }

            }

        }
    }
}

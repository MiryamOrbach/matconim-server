using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dto;

namespace Bl
{
   public class ContactUsBL
    {
        public static List<ContactUsDto> GetAllContacts()
        {
            List<ContactU> contacts = ContactUsDal.GetAllContacts();
            List<ContactUsDto> contactsDto = contacts.Select(c=> new ContactUsDto(c)).Reverse().ToList();
            return contactsDto;
        }
        public static List<ContactUsDto> GetContactByIsTreated(bool isTreated)
        {
            List<ContactU> contacts = ContactUsDal.GetContactsByIsTreated(isTreated);
            List<ContactUsDto> contactsDto = contacts.Select(c => new ContactUsDto(c)).Reverse().ToList();
            return contactsDto;
        }
        public static ContactUsDto AddContact(ContactUsDto c)
        {
            ContactU contact = ContactUsDto.Todal(c);
            c.idContactUs = ContactUsDal.AddContactUs(contact);
            return c;

        }
        public static void UpdateIsTreated(int id)
        {
            ContactUsDal.UpdateIsTreated(id);
        }
    }
}

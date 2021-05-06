using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;
using System.Web.Http.Cors;
using Bl;
using Newtonsoft.Json.Linq;

namespace api3.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/contactus")]
    public class ContactUsController : ApiController
    {
        [HttpGet]
        [Route("allContacts")]
        public IHttpActionResult GetAllContacts()
        {
            List<Dto.ContactUsDto> c = ContactUsBL.GetAllContacts();
            if (c != null)
                return Ok(c);
            return BadRequest();
        }
        [HttpGet]
        [Route("contactByIsTreated/{isTreated}")]
        public IHttpActionResult GetContactByIsTreated([FromUri] bool isTreated)
        {
            List<Dto.ContactUsDto> c = ContactUsBL.GetContactByIsTreated(isTreated);
            if (c != null)
                return Ok(c);
            return BadRequest();
        }
        [HttpPost]
        [Route("sendEmail")]
        public IHttpActionResult SendEmail([FromBody] JObject message)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("נפגש בשמחות nipagesbismachot@gmail.com");
                mail.To.Add(message["to"].ToString());
                mail.Subject = "יש לך הודעה חדשה...";
                mail.Body = message["html"].ToString();
                mail.IsBodyHtml = true;
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("nipagesbismachot@gmail.com", "nipages8923");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                
                ContactUsBL.UpdateIsTreated((int)message["id"]);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("add")]
        public IHttpActionResult AddContactUs([FromBody] Dto.ContactUsDto contactUs)
        {
            try
            {

                contactUs = ContactUsBL.AddContact(contactUs);
                if (contactUs != null)
                    return Ok(contactUs);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Cors;
using System.Web.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Net.Mail;

namespace api3.Controllers
    
{
    [EnableCors("*","*","*")]
[RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        [HttpPost]
        [Route("register")]
        public HttpResponseMessage Register([FromBody] Dto.CustDto cust )
        {
            try
            {
                cust= Bl.CustBl.Register(cust);
                return Request.CreateResponse(HttpStatusCode.OK, cust);
            }
            catch(Exception e)
            {
               return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.InnerException.InnerException.Message);
            }

           
        }
        //[HttpPost]
        //[Route("sendEmail")]
        //public async Task SendEmail([FromBody] JObject objData)
        //{
        //    var message = new MailMessage();
        //    //message.To.Add(new MailAddress(objData["toname"].ToString() + " <" + objData["toemail"].ToString() + ">"));
        //    message.To.Add(new MailAddress("miri.orbach23@gmail.com"));
        //    message.From = new MailAddress("Miryam Kanal <miri.orbach23@gmail.com>");
        //    message.Subject = "hello";
        //    message.Body = "hhhhh";
        //    message.IsBodyHtml = false;
        //    using (var smtp = new SmtpClient())
        //    {
        //        await smtp.SendMailAsync(message);
        //        await Task.FromResult(0);
        //    }
        //}
        //}
        [HttpPost]
        [Route("sendEmail")]
        public IHttpActionResult SendEmail([FromBody] JObject message)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("נפגש בשמחות nipagesbismachot@gmail.com");
                mail.To.Add("nipagesbismachot@gmail.com");
                mail.Subject = "יש לך הודעה ממשתמש...";
                mail.Body = message["html"].ToString();
                mail.IsBodyHtml = true;
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("nipagesbismachot@gmail.com", "nipages8923");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);


                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("login/{email}/{password}")]
        public IHttpActionResult Login([FromUri] string email, [FromUri] string password)
        {
            Dto.CustDto c = Bl.CustBl.Login(email, password);
            if (c != null)
                return Ok(c);
            return Ok(false);
        }
    }
}

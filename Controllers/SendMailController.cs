using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
namespace LabourWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SendMailController : ControllerBase
    {
        [HttpGet]
        public JsonResult DefaultSendMail()
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress("Surya_Chauhan", "surya.chauhan@newgensoft.com"));
            email.To.Add(new MailboxAddress("The Bro", "suryach2014@gmail.com"));
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = "Mail Body for testing purpose"
            };
            using (var client = new SmtpClient())
            {
                client.Connect("smtp.office365.com", 587, false);
                client.Authenticate("surya.chauhan", "Labour0-");
                var result = client.Send(email);
            }
            return new JsonResult("Accepted");
        }
    }
}

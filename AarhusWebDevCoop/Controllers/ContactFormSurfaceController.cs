using AarhusWebDevCoop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Core.Models;
using Umbraco.Web.Mvc;
using System.Net.Mail;


namespace AarhusWebDevCoop.Controllers
{
    public class ContactFormSurfaceController : SurfaceController
    {
        // GET: ContactFormSurface
        public ActionResult Index()
        {
            return PartialView("ContactForm", new ContactForm());
        }

        [HttpPost]
        public ActionResult HandleFormSubmit(ContactForm model)
        {
            if (!ModelState.IsValid) { return CurrentUmbracoPage(); }
            /*MailMessage message = new MailMessage();
            message.To.Add("pecata_11@yahoo.com");
            message.Subject = model.Subject;
            message.From = new MailAddress(model.Email, model.Name);
            message.Body = model.Message;

            using (SmtpClient smtp = new SmtpClient())
            {
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = true;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("doublepe11@gmail.com", "mmmdfpkkhyojxrrz");
                smtp.EnableSsl = true;
                // send mail
                smtp.Send(message);
            }*/

            // Create comment
            var commentIdRequest = Convert.ToInt32(Request["commentId"]);
            int commentId = commentIdRequest;    
            if (commentId > 0)
            {
                commentId = commentIdRequest;
            } else
            {
                commentId = CurrentPage.Id;
            }

            IContent message = Services.ContentService.CreateContent(model.Subject, commentId, "Message");

            // assign values
            message.SetValue("messageName", model.Name);
            message.SetValue("email", model.Email);
            message.SetValue("subject", model.Subject);
            message.SetValue("message", model.Message);

			Services.ContentService.Save(message);

            // Save and Publish
            // Services.ContentService.SaveAndPublishWithStatus(message, model.Name, true);

            TempData["success"] = true;    
            return RedirectToCurrentUmbracoPage();
        }
    }
}
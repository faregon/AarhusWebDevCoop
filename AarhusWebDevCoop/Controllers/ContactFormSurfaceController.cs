using System.Web.Mvc;
using Umbraco.Web.Mvc;
using AarhusWebDevCoop.ViewModels;
using System.Net.Mail;
using Umbraco.Core.Models;

namespace AarhusWebDevCoop.Controllers
{
    public class ContactFormSurfaceController : SurfaceController
        {
        // GET: ContactFormSurface

        public ActionResult Index()
        {
            return PartialView("ContactForm", new ContactForm());
        }

        public ActionResult HandleFormSubmit(ContactForm model)
        {
            if (!ModelState.IsValid) { return CurrentUmbracoPage(); }
            MailMessage message = new MailMessage();
            message.To.Add("minko.todorov@gmail.com");
            message.Subject = model.Subject;
            message.From = new MailAddress(model.Email, model.Name);
            message.Body = model.Message;


            // Parameters – name, parentId, contentTypeAlias
            IContent comment = Services.ContentService.CreateContent(model.Subject, CurrentPage.Id, "Message");

            // assign values
            comment.SetValue("messageName", model.Name);
            comment.SetValue("email", model.Email);
            comment.SetValue("subject", model.Subject);
            comment.SetValue("message", model.Message);
            // save to Umbraco
            Services.ContentService.Save(comment);
            //Services.ContentService.SaveAndPublish(comment);


            TempData["Success"] = true;

   

            return RedirectToCurrentUmbracoPage();


        }
        

    }
}
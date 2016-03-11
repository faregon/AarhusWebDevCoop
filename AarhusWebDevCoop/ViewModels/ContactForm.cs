using System.ComponentModel.DataAnnotations;

namespace AarhusWebDevCoop.ViewModels
{
    public class ContactForm
    {
        [Required(ErrorMessage = "Please fill your name")]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage ="This is not a valid email adress")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please specify a Subject")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "DOn't just send me empty messages")]
        public string Message { get; set; }
    }
}
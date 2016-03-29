using System.ComponentModel.DataAnnotations;

namespace AarhusWebDevCoop.ViewModels
{
    public class ContactForm
    {
        [Required(ErrorMessage = "Please fill your name")]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage ="This is not a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please specify a subject")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Don't just send me empty")]
        public string Message { get; set; }
    }
}
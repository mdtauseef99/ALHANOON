using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtility
{
   public class ContactModel
    {
        public int Id { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string ContactPerson_1 { get; set; }

        public string ContactPerson_2 { get; set; }
        public string MailFrom { get; set; }
        public string MailTo { get; set; }
        public string SmtpClient { get; set; }
        public int Port { get; set; }
        public string smtp_Email { get; set; }
        public string Password { get; set; }

        public bool IsActive { get; set; }

        public List<ContactModel> ContactList { get; set; }
    }
}

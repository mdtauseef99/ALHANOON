using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtility
{
    public class LogonModel
    {
        public string AdminId { get; set; }
        [Required]
        public string EmailId { get; set; }
        [Required]
        public string Password { get; set; }

        public string Returnurl { get; set; }
    }
}

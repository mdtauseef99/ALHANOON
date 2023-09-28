using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtility
{
    public class AdminWebModel
    {


        public int AdminId { get; set; }
        [Required]

        //[Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Email is not valid")]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Password is required"), DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please confirm your Password"), DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("ConfirmPassword", ErrorMessage = "Please check your password")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please enter your New Password")]
        public string NewPassword { get; set; }
        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtility
{
  public  class AdministrationModel
    {
      public int AdminId { get; set; }
      public string EmailId { get; set; }

      public string Password { get; set; }

      public string NewPassword { get; set; }

      public string ConfirmPassword { get; set; }

    }
}

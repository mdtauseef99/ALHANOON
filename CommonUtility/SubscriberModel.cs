using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtility
{
   public class SubscriberModel
    {
       public int Id { get; set; }
       public string Email { get; set; }
       public bool IsActive { get; set; }

       public List<SubscriberModel> SubscriberList { get; set; }
    }
}

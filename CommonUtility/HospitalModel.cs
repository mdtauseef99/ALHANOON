using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtility
{
  public  class HospitalModel
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public bool IsActive { get; set; }
        public List<HospitalModel> HospitalList { get; set; }
    }
}

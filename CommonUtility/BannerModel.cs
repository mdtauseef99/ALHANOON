using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtility
{
   public  class BannerModel
    {
        public int BannerId { get; set; }
        public string BannerName { get; set; }
        public bool IsActive { get; set; }
        public List<BannerModel> BannerList { get; set; }
    }
}

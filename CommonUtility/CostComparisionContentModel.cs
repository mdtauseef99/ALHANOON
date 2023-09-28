using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtility
{
   public  class CostComparisionContentModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
      
        public string Description { get; set; }
        public string ChartTitle { get; set; }
        public string Disclaimer { get; set; }
        public bool IsActive { get; set; }
        public List<CostComparisionContentModel> CostComparisionContentList { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtility
{
   public class CostComparisionChartModel
    {
        public int Id { get; set; }
        [Required]
        public string Procedures { get; set; }
        [Required]

        public decimal US { get; set; }
        public decimal UK { get; set; }
        public decimal  Bangkok { get; set; }
        public decimal India { get; set; }
        public decimal Singapore { get; set; }
        public bool IsActive { get; set; }
        public List<CostComparisionChartModel> CostComparisionChartList { get; set; }
    }
}

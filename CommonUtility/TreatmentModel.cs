using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtility
{
  public   class TreatmentModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Disease { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public List<TreatmentModel> TreatmentList { get; set; }
    }
}

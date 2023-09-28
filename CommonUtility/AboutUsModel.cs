using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtility
{
   public  class AboutUsModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }

        public string InnerTitle { get; set; }
        [Required]
        public string InnerDescription { get; set; }

        public string Image { get; set; }

        public bool IsActive { get; set; }
        public List<AboutUsModel> AboutUsList { get; set; }
    }
}

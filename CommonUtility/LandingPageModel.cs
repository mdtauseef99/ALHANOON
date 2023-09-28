using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtility
{
   public  class LandingPageModel
    {
       public List<BannerModel> BannerList { get; set; }

       public List<HomeModel> HomeList { get; set; }
       public List<ServicesModel> ServicesList { get; set; }
       public List<DoctorModel> DoctorList { get; set; }

       public List<DepartmentModel> DepartmentList { get; set; }

       public List<HospitalModel> HospitalList { get; set; }

       public List<TreatmentModel> TreatmentList { get; set; }

       public List<TreatmentModel> TreatmentListById { get; set; }

       public List<LatestNewsModel> latestNewsList { get; set; }

   
       public List<SubscriberModel> SubscriberList { get; set; }

       public List<DoctorModel> DoctorListByDepartment { get; set; }

       public List<AboutUsModel> AboutUsList { get; set; }

       public List<CostComparisionContentModel> CostComparisionContentList { get; set; }

       public List<CostComparisionChartModel> CostComparisionChartList { get; set; }

       public List<ScheduleTripModel> ScheduleTripList { get; set; }

       public List<TestimonialModel> TestimonialList { get; set; }


       /*--------------------------------subscriber---------------------------------------*/
       public string Email { get; set; }
       /*--------------------------------end subscriber---------------------------------------*/

   


       /*--------------------------------enquiry---------------------------------------*/


       [Required(ErrorMessage = "*")]
       public string FName { get; set; }
       [Required(ErrorMessage = "*")]
       [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "*")]
       public string Emails { get; set; }
       [Required(ErrorMessage = "*")]
       public string Mobile { get; set; }


       public string Country { get; set; }

       [Required(ErrorMessage = "*")]
       public string Message { get; set; }

        /*------------------------------end--enquiry---------------------------------------*/


      


    }
 
}

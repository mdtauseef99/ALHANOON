using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommonUtility;
using Alhanoon.Bll;
using System.Text.RegularExpressions;
using CommonUtility;
using System.Net.Mail;


namespace Alhanoon1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            LandingPageModel model = new LandingPageModel();
            model.BannerList = new IndexBLL { }.GetAllBanner();
            model.HomeList = new HomeBLL { }.HomeList();

            model.ServicesList = new IndexBLL { }.GetAllServices();
            model.DoctorList = new IndexBLL { }.GetAllDoctor();
            model.HospitalList = new IndexBLL { }.GetAllHospital();

            model.TreatmentList = new IndexBLL { }.GetAllTreatment();

            model.latestNewsList = new IndexBLL { }.GetAllLatestNews();

         
            return View(model);
        }

        public ActionResult Treatment(int id=0)
        {
            LandingPageModel model = new LandingPageModel();
            model.TreatmentList = new TreatmentBLL { }.GetAllTreatment();
            if (id == 0)
            {
                id = 1;
            }
            if (id != 0)
            {

                model.TreatmentListById = new TreatmentBLL { }.GetAllTreatmentListById(id);
            }
            return View(model);
        }

      
        public ActionResult Doctors(int id = 0)
        {
            if (id == 0)
            {
                id = 1;
            }
               LandingPageModel model = new LandingPageModel();

               model.DepartmentList=new DepartmentBLL{}.GetAllDepartment();

            if (id != 0)
            {
                model.DoctorList = new DoctorBLL { }.DoctorListByDepartment(id);
                
            }
            return View(model);
        }
        public ActionResult Hospital()
        {
            LandingPageModel model = new LandingPageModel();

            model.HospitalList = new IndexBLL { }.GetAllHospital();
            return View(model);
        }
        public ActionResult Contact()
        {
            
            LandingPageModel model = new LandingPageModel();
            return View(model);
        }

        [HttpPost]
        public ViewResult Contact(LandingPageModel model)
        {
            if (ModelState.IsValid)
            {
                //I need the Email sender to go here.
                MailMessage message = new MailMessage();
                message.From = new MailAddress("sender@alhanoon.com");
                message.To.Add(new MailAddress("mdtauseef99@gmail.com"));
                message.Subject = "New Message from Website";
                message.Body = "maseesge: " + model.Message + "\n" + "Name: " + model.FName + "\r\n" + "Phone: " + model.Mobile;

                SmtpClient smtp = new SmtpClient("mail.FRMT.IN", 25);

                message.Priority = MailPriority.Normal;

                smtp.Credentials = new System.Net.NetworkCredential("no_reply@FRMT.IN", "Farzana@123");

                smtp.Timeout = 60000;

                smtp.EnableSsl = false;

                smtp.Send(message);
                //client.Send(message);
                ModelState.Clear();
                Session["Success"] = "Your Message sent successfully !";
                return View("Contact");
            }
            else
            {
                return View("Contact");
            }
        }

        /*   ----------------------------------------------Enquiry---------------------------- */
        [HttpPost]
        public ViewResult Enquiry(LandingPageModel model)
        {


            //this code is for View 
            model.BannerList = new IndexBLL { }.GetAllBanner();
            model.HomeList = new HomeBLL { }.HomeList();

            model.ServicesList = new IndexBLL { }.GetAllServices();
            model.DoctorList = new IndexBLL { }.GetAllDoctor();
            model.HospitalList = new IndexBLL { }.GetAllHospital();

            model.TreatmentList = new IndexBLL { }.GetAllTreatment();

            model.latestNewsList = new IndexBLL { }.GetAllLatestNews();

            //this code is for View 


            if (ModelState.IsValid)
            {
                //I need the Email sender to go here.
                MailMessage message = new MailMessage();
                message.From = new MailAddress("enquiry@alhanoon.com");
                message.To.Add(new MailAddress("mdtauseef99@gmail.com"));
                message.Subject = "Enquiry from Website";
                message.Body = "message: " + model.Message + "\n" + "Name: " + model.FName + "\r\n" + "Email: " + model.Emails + "\r\n" + "Phone: " + model.Mobile + "\r\n" + "Country: " + model.Country;

                SmtpClient smtp = new SmtpClient("mail.FRMT.IN", 25);

                message.Priority = MailPriority.Normal;

                smtp.Credentials = new System.Net.NetworkCredential("no_reply@FRMT.IN", "Farzana@123");

                smtp.Timeout = 60000;

                smtp.EnableSsl = false;

                smtp.Send(message);
                //client.Send(message);
                ModelState.Clear();
                model.FName = "";
                model.Message = "";
                model.Emails = "";
                model.Mobile = "";
                model.Country = "";
                Session["enquiry"] = "Thanking you for Enquiry!";
                return View("Index",model);
            }
            else
            {
                return View("Index", model);
            }
        }

        /*   ----------------------------------------------about---------------------------- */
        public ActionResult About()
        {

            LandingPageModel model = new LandingPageModel();
            model.AboutUsList = new AboutUsBLL { }.GetAllAboutUs();
            model.TestimonialList = new TestimonialBLL { }.TestimonialList();

            return View(model);
        }

        /*   -------------------------------------------end---about---------------------------- */


        /*   ----------------------------------------------CostComparison---------------------------- */
        public ActionResult CostComparison()
        {

            LandingPageModel model = new LandingPageModel();
            model.CostComparisionContentList = new CostComparisionContentBLL { }.GetAllCostComparisionContent();

            model.CostComparisionChartList = new CostComparisionChartBLL { }.GetAllCostComparisionChart();
            return View(model);
        }

        /*   -------------------------------------------end---CostComparison---------------------------- */

        /*   ----------------------------------------------ScheduleYpur Trip---------------------------- */
        public ActionResult ScheduleTrip()
        {

            LandingPageModel model = new LandingPageModel();
            model.ScheduleTripList = new ScheduleTripBLL { }.GetAllScheduleTrip();

            return View(model);
        }

        /*   -------------------------------------------end---ScheduleYpur Trip----------------------------- */

        /*   --------------------------------------------Services-------------------------- */
        public ActionResult Services()
        {
            LandingPageModel model = new LandingPageModel();
            model.ServicesList = new IndexBLL { }.GetAllServices();
            return View(model);
        }

        /*   -------------------------------------------end---Services---------------------------- */

        /*   --------------------------------------------Testimonial-------------------------- */
        public ActionResult Testimonial()
        {

            LandingPageModel model = new LandingPageModel();

            model.TestimonialList = new TestimonialBLL { }.TestimonialList();
            return View(model);
        }

        /*   -------------------------------------------end---Testimonial---------------------------- */
     

/*   ----------------------------------------------using for insert subscriber in database---------------------------- */


     
        public ActionResult AddEditSubscriber(LandingPageModel model)
        {
            try
            {
                int _UserId = Convert.ToInt32(Session["AdminUserId"]);
                if (ModelState.IsValid)
                {
                    int res = new SubscriberBLL { }.AddEditSubscriber(new SubscriberModel
                    {
                        Email = model.Email,
                        IsActive =true,
                    });
                    if (res != 0)
                    {
                        Session["Success"] = "Thanking You for Subscribing !";
                        return RedirectToAction("index");
                    }
                }
                Session["Error"] = "An Error has occured";
                return RedirectToAction("index");
            }
            catch (Exception)
            {
                Session["Error"] = "An Error has occured";
                return RedirectToAction("index");
                throw;
            }
        }
        /*   ----------------------------------------------using for insert subscriber in database---------------------------- */
    }
}

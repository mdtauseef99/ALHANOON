using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommonUtility;
using Alhanoon.Bll;
using Alhanoon1.Areas.Admin.Filters;


namespace Alhanoon1.Areas.Admin.Controllers
{
    public class MasterDataController : Controller
    {
        //
        // GET: /Admin/MasterData/
        //AlhanoonEntities context = new AlhanoonEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Banner()
        {
            BannerModel model = new BannerModel();
            model.BannerList = new BannerBLL { }.BannerList();
            return View(model);
        }

        public ActionResult AddEditBanner(int id = 0)
        {
            BannerModel model = new BannerModel();
            if (id != 0)
            {
                BannerModel BannerModel = new BannerBLL { }.GetBannerById(id);
                if (BannerModel != null)
                {
                    model.BannerId = BannerModel.BannerId;
                    model.BannerName = BannerModel.BannerName;

                    model.IsActive = Convert.ToBoolean(BannerModel.IsActive);

                }
            }
            return View(model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult AddEditBanner(BannerModel model, List<HttpPostedFileBase> file)
        {
            try
            {
                int _UserId = Convert.ToInt32(Session["AdminUserId"]);
                string strFileName = "";
                string path = "";
                Random rnd = new Random();
                if (ModelState.IsValid)
                {
                    int res = 0;

                    foreach (var item in file)
                    {
                        if (item != null)
                        {
                            strFileName = "BannerImg_" + rnd.Next(100, 100000000) + "." + item.FileName.Split('.')[1].ToString();
                            path = Server.MapPath("~/Areas/Admin/img/" + strFileName);

                            res = new BannerBLL { }.AddEditBanner(new BannerModel
                            {
                                BannerId = model.BannerId,
                                BannerName = strFileName,
                                // Description = model.Description,
                                IsActive = model.IsActive,
                            });
                            if (res != 0)
                            {
                                item.SaveAs(path);
                            }
                        }
                        else
                        {
                            res = new BannerBLL { }.AddEditBanner(new BannerModel
                            {
                                BannerId = model.BannerId,
                                BannerName = strFileName,
                                // Description = model.Description,
                                IsActive = model.IsActive,
                            });
                        }
                    }

                    if (res != 0)
                    {
                        Session["Success"] = "Successfully Added The Record";
                        return RedirectToAction("Banner");
                    }
                }
                Session["Error"] = "An Error has occured";
                return View(model);
            }
            catch (Exception)
            {
                Session["Error"] = "An Error has occured";
                return View(model);
                throw;
            }
        }

        public JsonResult ChangeBannerStatus(int id)
        {
            bool Result = false;
            bool ChangeStatus = new BannerBLL { }.ChangeStatus(id);
            if (ChangeStatus)
            {
                Result = true;
            }
            return Json(Result);
        }


        /******************************************************************************About us********************************************************************/
        public ActionResult AboutUs()
        {
            AboutUsModel model = new AboutUsModel();
            model.AboutUsList = new AboutUsBLL { }.AboutUsList();
            return View(model);
        }

        public ActionResult AddEditAboutUs(int id = 0)
        {
            AboutUsModel model = new AboutUsModel();
            if (id != 0)
            {
                AboutUsModel AboutUsmodel = new AboutUsBLL { }.GetAboutUsById(id);
                if (AboutUsmodel != null)
                {
                    model.Id = AboutUsmodel.Id;
                    model.Title = AboutUsmodel.Title;
                    model.Description = AboutUsmodel.Description;
                    model.InnerTitle = AboutUsmodel.InnerTitle;
                    model.InnerDescription = AboutUsmodel.InnerDescription;
                    model.Image = AboutUsmodel.Image;
                    model.IsActive = Convert.ToBoolean(AboutUsmodel.IsActive);

                }
            }
            return View(model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult AddEditAboutUs(AboutUsModel model,List<HttpPostedFileBase> file)
        {
            try
            {
                int _UserId = Convert.ToInt32(Session["AdminUserId"]);
                string strFileName = "";
                string path = "";
                Random rnd = new Random();
                if (ModelState.IsValid)
                {
                    int res = 0;

                    foreach (var item in file)
                    {
                        if (item != null)
                        {
                            strFileName = "AbtImg_" + rnd.Next(100, 100000000) + "." + item.FileName.Split('.')[1].ToString();
                            path = Server.MapPath("~/Areas/Admin/img/" + strFileName);

                            res = new AboutUsBLL { }.AddEditAboutUs(new AboutUsModel
                            {
                                Id=model.Id,
                                Title = model.Title,
                                Description=model.Description,
                                InnerTitle=model.InnerTitle,
                                InnerDescription=model.InnerDescription,
                                Image = strFileName,
                                // Description = model.Description,
                                IsActive = model.IsActive,
                            });
                            if (res != 0)
                            {
                                item.SaveAs(path);
                            }
                        }
                        else
                        {
                            res = new AboutUsBLL { }.AddEditAboutUs(new AboutUsModel
                            {
                                Id=model.Id,
                                Title = model.Title,
                                Description = model.Description,
                                InnerTitle = model.InnerTitle,
                                InnerDescription = model.InnerDescription,
                                Image = strFileName,
                                // Description = model.Description,
                                IsActive = model.IsActive,
                            });
                        }
                    }

                    if (res != 0)
                    {
                        Session["Success"] = "Successfully Added The Record";
                        return RedirectToAction("AboutUs");
                    }
                }
                Session["Error"] = "An Error has occured";
                return View(model);
            }
            catch (Exception)
            {
                Session["Error"] = "An Error has occured";
                return View(model);
                throw;
            }
        }

        public JsonResult ChangeAboutUsStatus(int id)
        {
            bool Result = false;
            bool ChangeStatus = new AboutUsBLL { }.ChangeStatus(id);
            if (ChangeStatus)
            {
                Result = true;
            }
            return Json(Result);
        }
        /*************************************About us end********************************************************************/

        /******************************************************************************Department ********************************************************************/
        public ActionResult Department()
        {
            DepartmentModel model = new DepartmentModel();
            model.DepartmentList = new DepartmentBLL { }.DepartmentList();
            return View(model);
        }

        public ActionResult AddEditDepartment(int id = 0)
        {
            DepartmentModel model = new DepartmentModel();
            if (id != 0)
            {
                DepartmentModel Departmentmodel = new DepartmentBLL { }.GetDepartmentById(id);
                if (Departmentmodel != null)
                {
                    model.Id = Departmentmodel.Id;
                    model.DepartmentName = Departmentmodel.DepartmentName;
                    model.IsActive = Convert.ToBoolean(Departmentmodel.IsActive);

                }
            }
            return View(model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult AddEditDepartment(DepartmentModel model)
        {
            try
            {
                int _UserId = Convert.ToInt32(Session["AdminUserId"]);
                if (ModelState.IsValid)
                {
                    int res = new DepartmentBLL { }.AddEditDepartment(new DepartmentModel
                    {
                        Id = model.Id,
                        DepartmentName = model.DepartmentName,
                        IsActive = model.IsActive,
                    });
                    if (res != 0)
                    {
                        Session["Success"] = "Successfully Added The Record";
                        return RedirectToAction("Department");
                    }
                }
                Session["Error"] = "An Error has occured";
                return View(model);
            }
            catch (Exception)
            {
                Session["Error"] = "An Error has occured";
                return View(model);
                throw;
            }
        }

        public JsonResult ChangeDepartmentStatus(int id)
        {
            bool Result = false;
            bool ChangeStatus = new DepartmentBLL { }.ChangeStatus(id);
            if (ChangeStatus)
            {
                Result = true;
            }
            return Json(Result);
        }
        /*************************************Department end********************************************************************/

        /******************************************************************************Doctor ********************************************************************/
        public ActionResult Doctor()
        {
            DoctorModel model = new DoctorModel();
            //model.DoctorsList = new DoctorBLL { }.DoctorList();
            model.DoctorList = new DoctorBLL { }.DoctorList();
            return View(model);
        }

        public ActionResult AddEditDoctor(int id = 0)
        {
            DoctorModel model = new DoctorModel();
            model = new DoctorBLL { }.GetListOfDoctors();
          
            if (id != 0)
            {

                DoctorModel Doctormodel = new DoctorBLL { }.GetDoctorById(id);
                if (Doctormodel != null)
                {
                    model.DoctorId = Doctormodel.DoctorId;
                    model.DoctorName = Doctormodel.DoctorName;
                    model.Designation = Doctormodel.Designation;
                    model.Photo = Doctormodel.Photo;
                    model.Details = Doctormodel.Details;
                    model.DepartmentId = Doctormodel.DepartmentId;
                    model.IsActive = Convert.ToBoolean(Doctormodel.IsActive);
                    model.DepartmentName=Doctormodel.DepartmentName;

                    model.DoctorsLists = new List<SelectListItem> { new SelectListItem { Text = model.DepartmentName, Value = model.DepartmentId.ToString() } };
                }
            }
         
            //CustomMethods.BindDepartments(model);
            return View(model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult AddEditDoctor(DoctorModel model, List<HttpPostedFileBase> file)
        {
            try
            {
                int _UserId = Convert.ToInt32(Session["AdminUserId"]);
                string strFileName = "";
                string path = "";
                Random rnd = new Random();
                if (ModelState.IsValid)
                {
                    int res = 0;

                    foreach (var item in file)
                    {
                        if (item != null)
                        {
                            strFileName = "DocImg_" + rnd.Next(100, 100000000) + "." + item.FileName.Split('.')[1].ToString();
                            path = Server.MapPath("~/Areas/Admin/img/" + strFileName);

                            res = new DoctorBLL { }.AddEditDoctor(new DoctorModel
                            {
                                DoctorId = model.DoctorId,
                                DoctorName = model.DoctorName,
                                Designation = model.Designation,
                                Photo = strFileName,
                                Details = model.Details,
                                DepartmentId = model.DepartmentId,
                                IsActive = model.IsActive,
                            });
                            if (res != 0)
                            {
                                item.SaveAs(path);
                            }
                        }
                        else
                        {
                            res = new DoctorBLL { }.AddEditDoctor(new DoctorModel
                            {
                                DoctorId = model.DoctorId,
                                DoctorName = model.DoctorName,
                                Designation = model.Designation,
                                Photo = strFileName,
                                Details = model.Details,
                                DepartmentId = model.DepartmentId,
                                IsActive = model.IsActive,
                            });
                        }
                    }

                    if (res != 0)
                    {
                        Session["Success"] = "Successfully Added The Record";
                        return RedirectToAction("Doctor");
                    }
                }
                Session["Error"] = "An Error has occured";
                return View(model);
            }
            catch (Exception)
            {
                Session["Error"] = "An Error has occured";
                return View(model);
                throw;
            }

        }

        public JsonResult ChangeDoctorStatus(int id)
        {
            bool Result = false;
            bool ChangeStatus = new DoctorBLL { }.ChangeStatus(id);
            if (ChangeStatus)
            {
                Result = true;
            }
            return Json(Result);
        }
        /*************************************Doctor end********************************************************************/

        /******************************************************************************Home***************************************************************/
        public ActionResult Home()
        {
            HomeModel model = new HomeModel();

            //model.HomeList = new HomeBLL { }.HomeList;
            model.HomeList = new HomeBLL { }.HomeList();
            return View(model);
        }

        public ActionResult AddEditHome(int id = 0)
        {
            HomeModel model = new HomeModel();
            if (id != 0)
            {
                HomeModel Homemodel = new HomeBLL { }.GetHomeById(id);
                if (Homemodel != null)
                {
                    model.Id = Homemodel.Id;
                    model.Title = Homemodel.Title;
                    model.Description = Homemodel.Description;
                    model.IsActive = Convert.ToBoolean(Homemodel.IsActive);

                }
            }
            return View(model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult AddEditHome(HomeModel model)
        {
            try
            {
                int _UserId = Convert.ToInt32(Session["AdminUserId"]);
                if (ModelState.IsValid)
                {
                    int res = new HomeBLL { }.AddEditHome(new HomeModel
                    {
                        Id = model.Id,
                        Title = model.Title,
                        Description = model.Description,
                        IsActive = model.IsActive,
                    });
                    if (res != 0)
                    {
                        Session["Success"] = "Successfully Added The Record";
                        return RedirectToAction("Home");
                    }
                }
                Session["Error"] = "An Error has occured";
                return View(model);
            }
            catch (Exception)
            {
                Session["Error"] = "An Error has occured";
                return View(model);
                throw;
            }
        }

        public JsonResult ChangeHomeStatus(int id)
        {
            bool Result = false;
            bool ChangeStatus = new HomeBLL { }.ChangeStatus(id);
            if (ChangeStatus)
            {
                Result = true;
            }
            return Json(Result);
        }
        /*************************************Home end********************************************************************/

        /***************************************Hospital end********************************************************************/

        public ActionResult Hospital()
        {
            HospitalModel model = new HospitalModel();
            model.HospitalList = new HospitalBLL { }.HospitalList();
            return View(model);
        }

        public ActionResult AddEditHospital(int id = 0)
        {
            HospitalModel model = new HospitalModel();
            if (id != 0)
            {
                HospitalModel HospitalModel = new HospitalBLL { }.GetHospitalById(id);
                if (HospitalModel != null)
                {
                    model.Id = HospitalModel.Id;
                    model.Image = HospitalModel.Image;

                    model.IsActive = Convert.ToBoolean(HospitalModel.IsActive);

                }
            }
            return View(model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult AddEditHospital(HospitalModel model, List<HttpPostedFileBase> file)
        {
            try
            {
                int _UserId = Convert.ToInt32(Session["AdminUserId"]);
                string strFileName = "";
                string path = "";
                Random rnd = new Random();
                if (ModelState.IsValid)
                {
                    int res = 0;

                    foreach (var item in file)
                    {
                        if (item != null)
                        {
                            strFileName = "HospitalImg_" + rnd.Next(100, 100000000) + "." + item.FileName.Split('.')[1].ToString();
                            path = Server.MapPath("~/Areas/Admin/img/" + strFileName);

                            res = new HospitalBLL { }.AddEditHospital(new HospitalModel
                            {
                                Id = model.Id,
                                Image = strFileName,
                                // Description = model.Description,
                                IsActive = model.IsActive,
                            });
                            if (res != 0)
                            {
                                item.SaveAs(path);
                            }
                        }
                        else
                        {
                            res = new HospitalBLL { }.AddEditHospital(new HospitalModel
                            {
                                Id = model.Id,
                                Image = strFileName,
                                // Description = model.Description,
                                IsActive = model.IsActive,
                            });
                        }
                    }

                    if (res != 0)
                    {
                        Session["Success"] = "Successfully Added The Record";
                        return RedirectToAction("Hospital");
                    }
                }
                Session["Error"] = "An Error has occured";
                return View(model);
            }
            catch (Exception)
            {
                Session["Error"] = "An Error has occured";
                return View(model);
                throw;
            }
        }

        public JsonResult ChangeHospitalStatus(int id)
        {
            bool Result = false;
            bool ChangeStatus = new HospitalBLL { }.ChangeStatus(id);
            if (ChangeStatus)
            {
                Result = true;
            }
            return Json(Result);
        }


        /******************************************************************************Hospital end********************************************************************/


        /*************************************************************Schedule Trip***************************************************************/
        public ActionResult ScheduleTrip()
        {
            ScheduleTripModel model = new ScheduleTripModel();

            //model.HomeList = new HomeBLL { }.HomeList;
            model.ScheduleTripList = new ScheduleTripBLL { }.ScheduleTripList();
            return View(model);
        }

        public ActionResult AddEditScheduleTrip(int id = 0)
        {
            ScheduleTripModel model = new ScheduleTripModel();
            if (id != 0)
            {
                ScheduleTripModel Schedulemodel = new ScheduleTripBLL { }.GetScheduleTripById(id);
                if (Schedulemodel != null)
                {
                    model.Id = Schedulemodel.Id;
                    model.Title = Schedulemodel.Title;
                    model.Description = Schedulemodel.Description;
                    model.IsActive = Convert.ToBoolean(Schedulemodel.IsActive);

                }
            }
            return View(model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult AddEditScheduleTrip(ScheduleTripModel model)
        {
            try
            {
                int _UserId = Convert.ToInt32(Session["AdminUserId"]);
                if (ModelState.IsValid)
                {
                    int res = new ScheduleTripBLL { }.AddEditScheduleTrip(new ScheduleTripModel
                    {
                        Id = model.Id,
                        Title = model.Title,
                        Description = model.Description,
                        IsActive = model.IsActive,
                    });
                    if (res != 0)
                    {
                        Session["Success"] = "Successfully Added The Record";
                        return RedirectToAction("ScheduleTrip");
                    }
                }
                Session["Error"] = "An Error has occured";
                return View(model);
            }
            catch (Exception)
            {
                Session["Error"] = "An Error has occured";
                return View(model);
                throw;
            }
        }

        public JsonResult ChangeScheduleTripStatus(int id)
        {
            bool Result = false;
            bool ChangeStatus = new ScheduleTripBLL { }.ChangeStatus(id);
            if (ChangeStatus)
            {
                Result = true;
            }
            return Json(Result);
        }
        /*************************************ScheduleTrip end********************************************************************/

        /*************************************************************Services**************************************************************/
        public ActionResult Services()
        {
            ServicesModel model = new ServicesModel();

            //model.HomeList = new HomeBLL { }.HomeList;
            model.ServicesList = new ServicesBLL { }.ServicesList();
            return View(model);
        }

        public ActionResult AddEditServices(int id = 0)
        {
            ServicesModel model = new ServicesModel();
            if (id != 0)
            {
                ServicesModel Servicesmodel = new ServicesBLL { }.GetServicesById(id);
                if (Servicesmodel != null)
                {
                    model.Id = Servicesmodel.Id;
                    model.Title = Servicesmodel.Title;
                    model.Description = Servicesmodel.Description;
                    model.IsActive = Convert.ToBoolean(Servicesmodel.IsActive);

                }
            }
            return View(model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult AddEditServices(ServicesModel model)
        {
            try
            {
                int _UserId = Convert.ToInt32(Session["AdminUserId"]);
                if (ModelState.IsValid)
                {
                    int res = new ServicesBLL { }.AddEditServices(new ServicesModel
                    {
                        Id = model.Id,
                        Title = model.Title,
                        Description = model.Description,
                        IsActive = model.IsActive,
                    });
                    if (res != 0)
                    {
                        Session["Success"] = "Successfully Added The Record";
                        return RedirectToAction("Services");
                    }
                }
                Session["Error"] = "An Error has occured";
                return View(model);
            }
            catch (Exception)
            {
                Session["Error"] = "An Error has occured";
                return View(model);
                throw;
            }
        }

        public JsonResult ChangeServicesStatus(int id)
        {
            bool Result = false;
            bool ChangeStatus = new ServicesBLL { }.ChangeStatus(id);
            if (ChangeStatus)
            {
                Result = true;
            }
            return Json(Result);
        }
        /*************************************Services end********************************************************************/

        /*************************************************************Treatment**************************************************************/
        public ActionResult Treatment()
        {
            TreatmentModel model = new TreatmentModel();

            //model.HomeList = new HomeBLL { }.HomeList;
            model.TreatmentList = new TreatmentBLL { }.TreatmentList();
            return View(model);
        }

        public ActionResult AddEditTreatment(int id = 0)
        {
            TreatmentModel model = new TreatmentModel();
            if (id != 0)
            {
                TreatmentModel treatModel = new TreatmentBLL { }.GetTreatmentById(id);
                if (treatModel != null)
                {
                    model.Id = treatModel.Id;
                    model.Title = treatModel.Title;
                    model.Disease = treatModel.Disease;
                    model.Description = treatModel.Description;
                    model.IsActive = Convert.ToBoolean(treatModel.IsActive);

                }
            }
            return View(model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult AddEditTreatment(TreatmentModel model)
        {
            try
            {
                int _UserId = Convert.ToInt32(Session["AdminUserId"]);
                if (ModelState.IsValid)
                {
                    int res = new TreatmentBLL { }.AddEditTreatment(new TreatmentModel
                    {
                        Id = model.Id,
                        Title = model.Title,
                        Disease = model.Disease,
                        Description = model.Description,
                        IsActive = model.IsActive,
                    });
                    if (res != 0)
                    {
                        Session["Success"] = "Successfully Added The Record";
                        return RedirectToAction("Treatment");
                    }
                }
                Session["Error"] = "An Error has occured";
                return View(model);
            }
            catch (Exception)
            {
                Session["Error"] = "An Error has occured";
                return View(model);
                throw;
            }
        }

        public JsonResult ChangeTreatmentStatus(int id)
        {
            bool Result = false;
            bool ChangeStatus = new TreatmentBLL { }.ChangeStatus(id);
            if (ChangeStatus)
            {
                Result = true;
            }
            return Json(Result);
        }
        /*************************************Treatment end********************************************************************/

        /*************************************************************Contact**************************************************************/
        public ActionResult Contact()
        {
            ContactModel model = new ContactModel();

            //model.HomeList = new HomeBLL { }.HomeList;
            model.ContactList = new ContactBLL { }.ContactList();
            return View(model);
        }

        public ActionResult AddEditContact(int id = 0)
        {
            ContactModel model = new ContactModel();
            if (id != 0)
            {
                ContactModel ContactModel = new ContactBLL { }.GetContactById(id);
                if (ContactModel != null)
                {
                    model.Id = ContactModel.Id;
                    model.Address = ContactModel.Address;
                    model.ContactPerson_1 = ContactModel.ContactPerson_1;
                    model.ContactPerson_2 = ContactModel.ContactPerson_2;

                    model.MailFrom = ContactModel.MailFrom;
                    model.MailTo = ContactModel.MailTo;
                    model.SmtpClient = ContactModel.SmtpClient;
                    model.Port = ContactModel.Port;
                    model.smtp_Email = ContactModel.smtp_Email;
                    model.Password = ContactModel.Password;
                    model.IsActive = Convert.ToBoolean(ContactModel.IsActive);

                }
            }
            return View(model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult AddEditContact(ContactModel model)
        {
            try
            {
                int _UserId = Convert.ToInt32(Session["AdminUserId"]);
                if (ModelState.IsValid)
                {
                    int res = new ContactBLL { }.AddEditContact(new ContactModel
                    {
                        Id = model.Id,
                        Address = model.Address,
                        ContactPerson_1 = model.ContactPerson_1,
                        ContactPerson_2 = model.ContactPerson_2,
                        MailFrom = model.MailFrom,
                        MailTo = model.MailTo,
                        SmtpClient = model.SmtpClient,
                        Port = model.Port,
                        smtp_Email = model.smtp_Email,
                        Password = model.Password,
                        IsActive = model.IsActive
                    });
                    if (res != 0)
                    {
                        Session["Success"] = "Successfully Added The Record";
                        return RedirectToAction("Contact");
                    }
                }
                Session["Error"] = "An Error has occured";
                return View(model);
            }
            catch (Exception)
            {
                Session["Error"] = "An Error has occured";
                return View(model);
                throw;
            }
        }

        public JsonResult ChangeContactStatus(int id)
        {
            bool Result = false;
            bool ChangeStatus = new ContactBLL { }.ChangeStatus(id);
            if (ChangeStatus)
            {
                Result = true;
            }
            return Json(Result);
        }

        /*************************************************************end Contact**************************************************************/

        /*************************************************************Cost ComparisionContent**************************************************************/
        public ActionResult CostContent()
        {
            CostComparisionContentModel model = new CostComparisionContentModel();

            //model.HomeList = new HomeBLL { }.HomeList;
            model.CostComparisionContentList = new CostComparisionContentBLL { }.CostComparisionContentList();
            return View(model);
        }

        public ActionResult AddEditCostContent(int id = 0)
        {
            CostComparisionContentModel model = new CostComparisionContentModel();
            if (id != 0)
            {
                CostComparisionContentModel CostContentModel = new CostComparisionContentBLL { }.GetCostComparisionContentById(id);
                if (CostContentModel != null)
                {
                    model.Id = CostContentModel.Id;
                    model.Title = CostContentModel.Title;
                    model.Description = CostContentModel.Description;
                    model.ChartTitle = CostContentModel.ChartTitle;
                    model.Disclaimer = CostContentModel.Disclaimer;
                    model.IsActive = Convert.ToBoolean(CostContentModel.IsActive);

                }
            }
            return View(model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult AddEditCostContent(CostComparisionContentModel model)
        {
            try
            {
                int _UserId = Convert.ToInt32(Session["AdminUserId"]);
                if (ModelState.IsValid)
                {
                    int res = new CostComparisionContentBLL { }.AddEditCostComparisionContent(new CostComparisionContentModel
                    {
                        Id = model.Id,
                        Title = model.Title,
                        Description = model.Description,
                        ChartTitle = model.ChartTitle,
                        Disclaimer=model.Disclaimer,
                        IsActive = model.IsActive,
                    });
                    if (res != 0)
                    {
                        Session["Success"] = "Successfully Added The Record";
                        return RedirectToAction("CostContent");
                    }
                }
                Session["Error"] = "An Error has occured";
                return View(model);
            }
            catch (Exception)
            {
                Session["Error"] = "An Error has occured";
                return View(model);
                throw;
            }
        }

        public JsonResult ChangeCostContentStatus(int id)
        {
            bool Result = false;
            bool ChangeStatus = new CostComparisionContentBLL { }.ChangeStatus(id);
            if (ChangeStatus)
            {
                Result = true;
            }
            return Json(Result);
        }
        /***************************************Cost ComparisionContent** end********************************************************************/

        /*************************************************************Cost Comparision Chart**************************************************************/
        public ActionResult CostChart()
        {
            CostComparisionChartModel model = new CostComparisionChartModel();

            //model.HomeList = new HomeBLL { }.HomeList;
            model.CostComparisionChartList = new CostComparisionChartBLL { }.CostComparisionChartList();
            return View(model);
        }

        public ActionResult AddEditCostChart(int id = 0)
        {
            CostComparisionChartModel model = new CostComparisionChartModel();
            if (id != 0)
            {
                CostComparisionChartModel CostModel = new CostComparisionChartBLL { }.GetCostComparisionChartById(id);
                if (CostModel != null)
                {
                    model.Id = CostModel.Id;
                    model.Procedures = CostModel.Procedures;
                    model.US = CostModel.US;
                    model.UK = CostModel.UK;
                    model.Bangkok = CostModel.Bangkok;
                    model.India = CostModel.India;
                    model.Singapore = CostModel.Singapore;
                    model.IsActive = Convert.ToBoolean(CostModel.IsActive);

                }
            }
            return View(model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult AddEditCostChart(CostComparisionChartModel model)
        {
            try
            {
                int _UserId = Convert.ToInt32(Session["AdminUserId"]);
                if (ModelState.IsValid)
                {
                    int res = new CostComparisionChartBLL { }.AddEditCostChart(new CostComparisionChartModel
                    {
                        Id = model.Id,
                        Procedures = model.Procedures,
                        US = model.US,
                        UK = model.UK,
                        Bangkok = model.Bangkok,
                        India=model.India,
                        Singapore=model.Singapore,
                        IsActive = model.IsActive,
                    });
                    if (res != 0)
                    {
                        Session["Success"] = "Successfully Added The Record";
                        return RedirectToAction("CostChart");
                    }
                }
                Session["Error"] = "An Error has occured";
                return View(model);
            }
            catch (Exception)
            {
                Session["Error"] = "An Error has occured";
                return View(model);
                throw;
            }
        }

        public JsonResult ChangeCostChartStatus(int id)
        {
            bool Result = false;
            bool ChangeStatus = new CostComparisionChartBLL { }.ChangeStatus(id);
            if (ChangeStatus)
            {
                Result = true;
            }
            return Json(Result);
        }
        /***************************************Cost ComparisionChart** end********************************************************************/

        /*************************************************************LatestNews**************************************************************/
        public ActionResult LatestNews()
        {
            LatestNewsModel model = new LatestNewsModel();

            //model.HomeList = new HomeBLL { }.HomeList;
            model.latestNewsList = new latestNewsBLL { }.latestNewsList();
            return View(model);
        }

        public ActionResult AddEditlatestNews(int id = 0)
        {
            LatestNewsModel model = new LatestNewsModel();
            if (id != 0)
            {
                LatestNewsModel newModel = new latestNewsBLL { }.GetLatestNewsById(id);
                if (newModel != null)
                {
                    model.Id = newModel.Id;
                    model.Image = newModel.Image;
                    model.Description = newModel.Description;
                    model.IsActive = Convert.ToBoolean(newModel.IsActive);

                }
            }
            return View(model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult AddEditlatestNews(LatestNewsModel model, List<HttpPostedFileBase> file)
        {
            try
            {
                int _UserId = Convert.ToInt32(Session["AdminUserId"]);
                string strFileName = "";
                string path = "";
                Random rnd = new Random();
                if (ModelState.IsValid)
                {
                    int res = 0;

                    foreach (var item in file)
                    {
                        if (item != null)
                        {
                            strFileName = "NewsImg_" + rnd.Next(100, 100000000) + "." + item.FileName.Split('.')[1].ToString();
                            path = Server.MapPath("~/Areas/Admin/img/" + strFileName);

                            res = new latestNewsBLL { }.AddEditlatestNews(new LatestNewsModel
                            {
                                Id = model.Id,
                                Image = strFileName,
                                Description = model.Description,
                                IsActive = model.IsActive,
                            });
                            if (res != 0)
                            {
                                item.SaveAs(path);
                            }
                        }
                        else
                        {
                            res = new latestNewsBLL { }.AddEditlatestNews(new LatestNewsModel
                            {
                                Id = model.Id,
                                Image = strFileName,
                                Description = model.Description,
                                IsActive = model.IsActive,
                            });
                        }
                    }

                    if (res != 0)
                    {
                        Session["Success"] = "Successfully Added The Record";
                        return RedirectToAction("LatestNews");
                    }
                }
                Session["Error"] = "An Error has occured";
                return View(model);
            }
            catch (Exception)
            {
                Session["Error"] = "An Error has occured";
                return View(model);
                throw;
            }
        }

        public JsonResult ChangeLatestNewsStatus(int id)
        {
            bool Result = false;
            bool ChangeStatus = new latestNewsBLL { }.ChangeStatus(id);
            if (ChangeStatus)
            {
                Result = true;
            }
            return Json(Result);
        }
        /*************************************LatestNews end********************************************************************/


        /*************************************************************Testimonial**************************************************************/
        public ActionResult Testimonial()
        {
            TestimonialModel model = new TestimonialModel();

            //model.HomeList = new HomeBLL { }.HomeList;
            model.TestimonialList = new TestimonialBLL { }.TestimonialList();
            return View(model);
        }

        public ActionResult AddEditTestimonial(int id = 0)
        {
            TestimonialModel model = new TestimonialModel();
            if (id != 0)
            {
                TestimonialModel newModel = new TestimonialBLL { }.GetTestimonialById(id);
                if (newModel != null)
                {
                    model.Id = newModel.Id;
                    model.Image = newModel.Image;
                    model.Description = newModel.Description;
                    model.IsActive = Convert.ToBoolean(newModel.IsActive);

                }
            }
            return View(model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult AddEditTestimonial(TestimonialModel model, List<HttpPostedFileBase> file)
        {
            try
            {
                int _UserId = Convert.ToInt32(Session["AdminUserId"]);
                string strFileName = "";
                string path = "";
                Random rnd = new Random();
                if (ModelState.IsValid)
                {
                    int res = 0;

                    foreach (var item in file)
                    {
                        if (item != null)
                        {
                            strFileName = "TestimonialImg_" + rnd.Next(100, 100000000) + "." + item.FileName.Split('.')[1].ToString();
                            path = Server.MapPath("~/Areas/Admin/img/" + strFileName);

                            res = new TestimonialBLL { }.AddEditTestimonial(new TestimonialModel
                            {
                                Id = model.Id,
                                Image = strFileName,
                                Description = model.Description,
                                IsActive = model.IsActive,
                            });
                            if (res != 0)
                            {
                                item.SaveAs(path);
                            }
                        }
                        else
                        {
                            res = new TestimonialBLL { }.AddEditTestimonial(new TestimonialModel
                            {
                                Id = model.Id,
                                Image = strFileName,
                                Description = model.Description,
                                IsActive = model.IsActive,
                            });
                        }
                    }

                    if (res != 0)
                    {
                        Session["Success"] = "Successfully Added The Record";
                        return RedirectToAction("Testimonial");
                    }
                }
                Session["Error"] = "An Error has occured";
                return View(model);
            }
            catch (Exception)
            {
                Session["Error"] = "An Error has occured";
                return View(model);
                throw;
            }
        }

        public JsonResult ChangeTestimonialStatus(int id)
        {
            bool Result = false;
            bool ChangeStatus = new TestimonialBLL { }.ChangeStatus(id);
            if (ChangeStatus)
            {
                Result = true;
            }
            return Json(Result);
        }
        /*************************************Testimonial end********************************************************************/
    }
}

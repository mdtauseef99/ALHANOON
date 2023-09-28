using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonUtility;

namespace Alhanoon.Dal
{
   
   public class IndexDAL
    {
       AlhanoonEntities objdb = new AlhanoonEntities();
       public List<BannerModel> GetAllBanner()
       {
           try
           {
               List<BannerModel> obj = new List<BannerModel>();
               obj = objdb.Banners.Where(x => x.IsActive == true).Select(x => new BannerModel
               {
                   BannerId = x.BannerId,
                   BannerName = x.BannerName,
                   IsActive = x.IsActive
               }).OrderBy(x => x.BannerId).ToList();
               return obj;

           }
           catch (Exception)
           {
               return null;
               throw;
           }
       }
       public List<ServicesModel> GetAllServices()
       {
           try
           {
               List<ServicesModel> obj = new List<ServicesModel>();
               obj = objdb.Services.Where(x => x.IsActive == true).Select(x => new ServicesModel
               {
                   Id  = x.Id,
                   Title = x.Title,
                   //Icon=x.Icon,
                   Description=x.Description,
                   IsActive = x.IsActive
               }).OrderBy(x => x.Id).ToList();
               return obj;

           }
           catch (Exception)
           {
               return null;
               throw;
           }
       }
       public List<DoctorModel> GetAllDoctor()
       {
           try
           {
               List<DoctorModel> obj = new List<DoctorModel>();
               obj = objdb.Doctors.Where(x => x.IsActive == true).Select(x => new DoctorModel
               {
                   DoctorId = x.DoctorId,
                   DoctorName = x.DoctorName,
                   Designation = x.Designation,
                   DepartmentId=x.DepartmentId,
                   Photo=x.Photo,
                   IsActive = x.IsActive
               }).OrderBy(x => x.DoctorId).ToList();
               return obj;

           }
           catch (Exception)
           {
               return null;
               throw;
           }
       }
       public List<HospitalModel> GetAllHospital()
       {
           try
           {
               List<HospitalModel> obj = new List<HospitalModel>();
               obj = objdb.Hospitals.Where(x => x.IsActive == true).Select(x => new HospitalModel
               {
                   Id = x.Id,
                   Image = x.Image,
                   IsActive = x.IsActive
               }).OrderBy(x => x.Id).ToList();
               return obj;

           }
           catch (Exception)
           {
               return null;
               throw;
           }
       }

       public List<TreatmentModel> GetAllTreatment()
       {
           try
           {
               List<TreatmentModel> obj = new List<TreatmentModel>();
               obj = objdb.Treatments.Where(x => x.IsActive == true).Select(x => new TreatmentModel
               {
                   Id = x.Id,
                   Title = x.Title,
                   IsActive = x.IsActive
               }).OrderBy(x => x.Id).ToList();
               return obj;

           }
           catch (Exception)
           {
               return null;
               throw;
           }
       }
       public List<LatestNewsModel> GetAllLatestNews()
       {
           try
           {
               List<LatestNewsModel> obj = new List<LatestNewsModel>();
               obj = objdb.LatestNews.Where(x => x.IsActive == true).Select(x => new LatestNewsModel
               {
                   Id = x.Id,
                   Image = x.Image,
                   Description =x.Description,
                   IsActive = x.IsActive
               }).OrderBy(x => x.Id).ToList();
                 //}).OrderByDescending(x => x.Id).ToList();
               return obj;

           }
           catch (Exception)
           {
               return null;
               throw;
           }
       }
    }
}

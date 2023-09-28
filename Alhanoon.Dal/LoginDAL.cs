using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonUtility;

namespace Alhanoon.Dal
{
   public class LoginDAL
    { 
       AlhanoonEntities objdb = new AlhanoonEntities();
       public AdministrationModel AdminLogin(AdministrationModel objmodel)
       {
           try
           {
               return objdb.Administrators.Where(x => x.EmailId == objmodel.EmailId & x.Password == objmodel.Password)
                           .Select(x => new AdministrationModel
                           {
                               AdminId = x.AdminId,
                               EmailId = x.EmailId,
                           }).SingleOrDefault();
           }
           catch (Exception)
           {
               return null;
               throw;
           }
       }
       public int ChangesPassword(AdministrationModel model)
       {
           try
           {

               Administrator objuser = objdb.Administrators.Find(model.AdminId);
               {
                   objuser.AdminId = model.AdminId;
                   objuser.Password = model.Password;
               };
               objdb.SaveChanges();
               return objuser.AdminId;

           }
           catch (Exception)
           {
               return 0;
               throw;
           }
       }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonUtility;
using Alhanoon.Dal;

namespace Alhanoon.Bll
{
   public class LoginBLL
    {
       LoginDAL objLogin = new LoginDAL();

       public AdministrationModel AdminLogin(AdministrationModel model)
        {
            return objLogin.AdminLogin(model);
        }
       public int ChangesPassword(AdministrationModel model)
       {
           try
           {

               return objLogin.ChangesPassword(model);

           }
           catch (Exception)
           {
               return 0;
               throw;
           }
       }
    }
}

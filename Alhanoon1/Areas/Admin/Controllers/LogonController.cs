using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommonUtility;
using Alhanoon.Bll;

namespace Alhanoon1.Areas.Admin.Controllers
{
    [AllowAnonymous]
    public class LogonController : Controller
    {
        //
        // GET: /Admin/Logon/

        public ActionResult Index(string returnurl = "")
        {
            LogonModel model = new LogonModel
            {
                Returnurl = returnurl,
            };

            return View(model);
        }

        public ActionResult Login(LogonModel objlogon)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    LoginBLL objLoginBll = new LoginBLL();
                    AdministrationModel objUser = objLoginBll.AdminLogin(new AdministrationModel
                    {
                        EmailId = objlogon.EmailId,
                        Password = DataEncryption.Encrypt(objlogon.Password.Trim(), "passKey")
                    });
                    if (objUser != null)
                    {
                        Session["AdminUserId"] = objUser.AdminId;
                        Session["UserName"] = objUser.EmailId;
                        Session.Timeout = 60;
                        if (objlogon.Returnurl != null)
                        {
                            return Redirect(objlogon.Returnurl);
                        }
                        return RedirectToAction("Index", "MasterData");
                    }
                }
                Session["Error"] = "Invalid Email or Password.";
                return View("Index", objlogon);
            }
            catch (Exception)
            {
                Session["Error"] = "Invalid Email or Password.";
                return View("Index", objlogon);
                throw;
            }
        }
        public ActionResult Logout()
        {
            try
            {
                Session["AdminUserId"] = string.Empty;
                Session.Abandon();

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
                throw;
            }
        }

        public ActionResult ChangePassword()
        {
            return View();
        }
         [HttpPost]
        public ActionResult ChangePassword(AdminWebModel model)
        {
            try
            {
                int userid = Convert.ToInt32(Session["AdminUserId"]);
                string pwd = "";
                if (model.ConfirmPassword == null && model.NewPassword == null)
                {
                    pwd = model.Password;
                }
                else
                {
                    pwd = model.ConfirmPassword;
                }
                if (model != null)
                {
                    Session["PasswordChange"] = "Passwords Change SuccessFully";
                    int res = new LoginBLL { }.ChangesPassword(new AdministrationModel
                    {
                        Password = DataEncryption.Encrypt(pwd, "passKey"),
                        AdminId = userid,
                       
                    });

                }

                return View("ChangePassword");

            }
            catch (Exception)
            {
                
                throw;
            }
        }

    }
}

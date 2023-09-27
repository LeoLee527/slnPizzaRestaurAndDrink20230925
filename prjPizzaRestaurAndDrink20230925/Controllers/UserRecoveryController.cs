using Dblayer;
using prjPizzaRestaurAndDrink20230925.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prjPizzaRestaurAndDrink20230925.Controllers
{
    public class UserRecoveryController : Controller
    {
        private PizzaRestaurantAndDrinkDbEntities Db = new PizzaRestaurantAndDrinkDbEntities();

        // GET: PasswordRecovery
        public ActionResult AccountRecovery()
        {
            var accountRecoveryMV = new AccountRecoveryMV();
            return View(accountRecoveryMV);
        }

        [HttpPost]
        public ActionResult AccountRecovery(AccountRecoveryMV accountRecoveryMV)
        {
            using (var transaction = Db.Database.BeginTransaction())
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        var user = Db.UserTables.Where(u => u.UserName.Trim() == accountRecoveryMV.UserName || u.EmailAddress == accountRecoveryMV.UserName.Trim()).FirstOrDefault();
                        if (user != null)
                        {
                            string code = DateTime.Now.ToString("yyyyMMddHHmmssmm") + accountRecoveryMV.UserName;
                            var accountrecoverydetails = new UserPasswordRecoveryTable();
                            accountrecoverydetails.UserID = user.UserID;
                            accountrecoverydetails.OldPassword = user.Password;
                            accountrecoverydetails.RecoveryCode = code;
                            accountrecoverydetails.RecoveryCodeExpiryDateTime = DateTime.Now.AddDays(1);
                            accountrecoverydetails.RecoveryStatus = true;
                            Db.UserPasswordRecoveryTables.Add(accountrecoverydetails);
                            Db.SaveChanges();

                            var callbackUrl = Url.Action("ResetPassword", "User", new { recoverycode = code }, protocol: Request.Url.Scheme);
                            // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");
                            string body = string.Empty;
                            using (StreamReader reader = new StreamReader(Server.MapPath("~/MailTemplates/ForgotPasswordConfirmation.html")))
                            {
                                body = reader.ReadToEnd();
                            }
                            body = body.Replace("{ConfirmationLink}", callbackUrl);
                            body = body.Replace("{UserName}", user.EmailAddress);
                            bool IsSendEmail = HelperClass.EmailClass.Send(user.EmailAddress, "Reset Password", body, true);
                            if (IsSendEmail)
                            {
                                transaction.Commit();
                                ModelState.AddModelError(string.Empty, "Recovery Link Sent on your email address(" + user.EmailAddress + ")");
                            }
                            else
                            {
                                transaction.Rollback();
                                ModelState.AddModelError(string.Empty, "Some Issue is Occure! Please Try Again later.");
                            }
                        }
                        else
                        {
                            transaction.Rollback();
                            ModelState.AddModelError("UserName", "Not Found!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    ModelState.AddModelError(string.Empty, "Some Issue is Occure! Please Try Again later.");
                }
            }
            return View(accountRecoveryMV);
        }
    }
}
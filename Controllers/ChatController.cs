using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PirateChatSite.Models;
using WebMatrix.WebData;

namespace PirateChatSite.Controllers
{
    public class ChatController : Controller
    {
        private UsersContext db = new UsersContext();

        //
        // GET: /Chat/

        public ActionResult Index()
        {
            if (!WebSecurity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", new { returnUrl = "/chat" });
            }
            UserProfile user = db.UserProfiles.First(u => u.UserId == WebSecurity.CurrentUserId);

            if (user.Following.Count != 0)
            {
                return View(user);
            }
            else // no users, send them to add contacts
            {
                return RedirectToAction("AddContacts", "Account");
            }
        }

        // 
        // Get: /Chat/ContactsList
        public ActionResult ContactsList()
        {
            UserProfile user = db.UserProfiles.First(u => u.UserId == WebSecurity.CurrentUserId);

            ContactsListViewModel contactsList = new ContactsListViewModel(user);

            return Json(contactsList, JsonRequestBehavior.AllowGet);
        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
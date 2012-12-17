using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKinver.Models;

namespace MVCKinver.Controllers
{
    public class ContactController : Controller
    {

        private KinverEntities db = new KinverEntities();
        //
        // GET: /Contact/

        public ActionResult Index()
        {
            return PartialView();
        }

        //
        // POST: /Contact/
        [HttpPost]
        [ChildActionOnly]
        public ActionResult Index(ContactInfo ContactInfo) {
            if (ModelState.IsValid)
            {
                ViewBag.SubmitMessage = "<i class=\"icon-ok\"></i> 感谢您的垂询，我们会尽快与您联系！";
                db.ContactInfoes.Add(ContactInfo);
                db.SaveChanges();
                return PartialView();
            }
            else 
            {
                return PartialView();
            }
        }


    }
}

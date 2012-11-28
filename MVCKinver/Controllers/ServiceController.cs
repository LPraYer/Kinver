using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKinver.Models;

namespace MVCKinver.Controllers
{
    public class ServiceController : Controller
    {
        KinverEntities storeDB = new KinverEntities();
        //
        // GET: /Service/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET:/Service/Detail
        public ActionResult Details(int id)
        {
            var serviceModel = storeDB.Services.Find(id);
            return View(serviceModel);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCKinver.Controllers
{
    public class ErrorController : Controller
    {
        //
        // GET: /Error/
        public ActionResult Index()
        {
            return RedirectToAction("Index","Home");
        }

        // 404
        // GET: /Error/NotFound
        public ActionResult NotFound()
        {
            return View();
        }

        // 404之外的错误页面
        // GET: /Error/HttpError
        public ActionResult HttpError()
        {
            return View("Error");
        }
    }
}

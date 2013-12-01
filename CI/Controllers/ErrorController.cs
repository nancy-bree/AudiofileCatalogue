using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CI.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Http404(string aspxerrorpath)
        {
            ViewData["error_path"] = aspxerrorpath;
            return View();
        }

        public ActionResult Http403()
        {
            return View();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HaveYouSeenMe.Controllers
{
    public class PetController : Controller
    {
        //
        // GET: /Pet/

        public ActionResult Index()
        {
            return View();
        }

        /*public ActionResult Display()
        {

            var name = (string)RouteData.Values["id"];

            var model = PetManagement.GetByName(name);

            if (model == null)

                return RedirectToAction("NotFound");

            return View(model);

        }
        */

        public ActionResult NotFound()
        {

            return View();

        }



    }
}

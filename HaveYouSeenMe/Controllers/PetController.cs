using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HaveYouSeenMe.Models;
using HaveYouSeenMe.Models.Business;
using System.IO;

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
        public ActionResult PictureUpload()
        {
            return View();
        }

        [HttpPost] 
        [ValidateAntiForgeryToken] 
        public ActionResult PictureUpload(PictureModel model) 
        {    
            if (model.PictureFile.ContentLength > 0)    
            {        
                var fileName = Path.GetFileName(model.PictureFile.FileName);        
                var filePath = Server.MapPath(“/Content/Uploads”);        
                string savedFileName = Path.Combine(filePath, fileName);        
                model.PictureFile.SaveAs(savedFileName);        
                PetManagement.CreateThumbnail(fileName, filePath, 100, 100, true);    
            }
    
            return View(model); 
        } 


        public ActionResult ShowError()
        {
            ViewData["ErrorCode"] = 12345;
            ViewData["ErrorDescription"] = "Something bad happened";
            ViewData["ErrorDate"] = DateTime.Now;
            ViewData["Exception"] = new Exception();

            return View();
        }

        public ActionResult NotFound()
        {

            return View();

        }

        public FileResult DownloadPetPicture()
        {
            var name = (string)RouteData.Values["id"];
            var picture = "/Content/Uploads/" + name + ".jpg";
            var contentType = "image/jpg";
            // var fileName = name + ".jpg";
            return File(picture, contentType);
        }

        public ActionResult NotFoundError() 
        {
            return HttpNotFound("Nothing here...");
        }
    }
}

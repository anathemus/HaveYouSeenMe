﻿using System;
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

    }
}
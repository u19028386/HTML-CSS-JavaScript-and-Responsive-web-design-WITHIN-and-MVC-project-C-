﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase Files) //INSIDE HOME
        {
            // Verify that the user selected a file
            // Not null and has a length

                if (Files != null && Files.ContentLength > 0)
            {

                // get file name
                var fileName = Path.GetFileName(Files.FileName);

                if (Request["ntype"] == "nDocument")
                {
                    // storing the file inside ~/App_Data/Documents folder
                    var path = Path.Combine(Server.MapPath("~/App_Data/Documents"), fileName);
                    Files.SaveAs(path);

                }

                if (Request["ntype"] == "nImage")
                {
                    // storing the file inside ~/App_Data/Images folder
                    var path = Path.Combine(Server.MapPath("~/App_Data/Images"), fileName);
                    Files.SaveAs(path);

                }

                if (Request["ntype"] == "nVideo")
                {
                    // storing the file inside ~/App_Data/Videos folder
                    var path = Path.Combine(Server.MapPath("~/App_Data/Videos"), fileName);
                    Files.SaveAs(path);

                }
            }
            // redirect back to the index action to show the form once again

            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            return View();
        }

    }
}
/* Name: Pushpa Dhakal, Course: C# .NET
Code Louisville @ Bellarmine University, Mondays 6:00PM to 8:00PM 
Spring 2020
Instructor: Steve England
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.SqlServer;

namespace CollegeListOfAmerica.Controllers
{
    //This inherits controller to HomeController
    public class HomeController : Controller
    {
        //GET: Home
        public ActionResult Index()
        {
            //It redirects to the index page.
            return RedirectToAction("Index", "CollegeList");
        }

        public ActionResult Practice(string x)
        {
            var idk = x;
            return View(idk);
        }
    }
}


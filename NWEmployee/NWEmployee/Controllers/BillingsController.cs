using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NWEmployee.Controllers
{
    public class BillingsController : Controller
    {
        // GET: Billings
        public ActionResult Index()
        {
            return View();
        }
    }
}
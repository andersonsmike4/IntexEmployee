using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NWCustomer.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        // GET: Dashboard
        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult WorkOrders()
        {
            return View();
        }

        public ActionResult NewOrder()
        {
            return View();
        }

        public ActionResult Summary()
        {
            return View();
        }

        public ActionResult Details(string type)
        {
            ViewBag.Type = type;
            return View();
        }
    }
}
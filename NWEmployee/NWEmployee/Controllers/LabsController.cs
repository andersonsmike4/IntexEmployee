using NWEmployee.DAL;
using NWEmployee.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NWEmployee.Controllers
{
    public class LabsController : Controller
    {
        NorthwestContext db = new NorthwestContext();

        // GET: Labs
        public ActionResult Index()
        {
            return View();
        }

        // GET: Labs
        public ActionResult WorkOrders()
        {
            ViewBag.type = "WO";
            Stack<WorkOrders> workOrdersList = new Stack<WorkOrders>();
            IEnumerable<int> list = db.Database.SqlQuery<int>("SELECT workOrderID FROM WorkOrders").ToList();
            foreach(var item in list)
            {
                WorkOrders workOrder = new WorkOrders();
                workOrder.workOrderID = item;
                var custName = db.Database.SqlQuery<string>("SELECT custName FROM Customers INNER JOIN CustomerAccount ON Customers.custID = CustomerAccount.custID INNER JOIN[Invoices] ON CustomerAccount.accID = [Invoices].accID INNER JOIN WorkOrders ON[Invoices].workOrderID = WorkOrders.workOrderID WHERE WorkOrders.workOrderID =" + item).FirstOrDefault();
                workOrder.customerName = custName;
                workOrdersList.Push(workOrder);
            }
            ViewBag.workOrderList = workOrdersList;
            return View();
        }

        // GET: Labs
        public ActionResult WorkOrdersCom(int workOrderID)
        {
            ViewBag.type = "CO";
            Stack<Compounds> compounds = new Stack<Compounds>();
            IEnumerable<int> list = db.Database.SqlQuery<int>("SELECT LTNum FROM Compounds WHERE workOrderID = " + workOrderID).ToList();
            foreach (var item in list)
            {
                Compounds compound = new Compounds();
                compound.LTNum = item;
                var comName = db.Database.SqlQuery<string>("SELECT compoundName FROM Compounds INNER JOIN CompoundsFinite ON Compounds.compoundFinID = CompoundsFinite.compoundFinID WHERE LTNum = " + item).FirstOrDefault();
                compound.compoundName = comName;
                compounds.Push(compound);
            }
            ViewBag.compounds = compounds;
            ViewBag.workOrderID = workOrderID;
            return View("WorkOrders");
        }

        // GET: Labs
        public ActionResult WorkOrdersSam(int workOrderID, int LTNum)
        {
            ViewBag.type = "SA";
            Stack samples = new Stack();
            IEnumerable<int> list = db.Database.SqlQuery<int>("SELECT [sampleID(LT + Sequence)] FROM Samples WHERE LTNum = " + LTNum).ToList();
            foreach (var item in list)
            {
                samples.Push(item);
            }
            ViewBag.samples = samples;
            ViewBag.LT = LTNum;
            ViewBag.workOrderID = workOrderID;
            return View("WorkOrders");
        }

        public ActionResult WorkOrdersTest()
        {
            return View("WorkOrders");
        }
    }
}
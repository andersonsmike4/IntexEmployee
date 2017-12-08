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
    [Authorize]
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
            Stack<Samples> samples = new Stack<Samples>();
            IEnumerable<int> list = db.Database.SqlQuery<int>("SELECT sampleID FROM Samples WHERE LTNum = " + LTNum).ToList();
            foreach (var item in list)
            {
                Samples sample = new Samples();
                var assayName = db.Database.SqlQuery<string>("SELECT name FROM Samples INNER JOIN Assays ON Samples.assayID = Assays.assayID WHERE sampleID = " + item).FirstOrDefault();
                sample.sampleID = item;
                sample.assayName = assayName;
                samples.Push(sample);
            }
            ViewBag.samples = samples;
            ViewBag.LTNum = LTNum;
            ViewBag.workOrderID = workOrderID;
            return View("WorkOrders");
        }

        public ActionResult WorkOrdersTest(int workOrderID, int LTNum, int sampleID)
        {
            ViewBag.type = "TE";
            
            List<Tests> tests = new List<Tests>();
            IEnumerable<int> list = db.Database.SqlQuery<int>("SELECT SerialTestID FROM testTube INNER JOIN Serialized_Tests ON testTube.serialID = Serialized_Tests.SerialTestID WHERE sampleID = " + sampleID).ToList();

            foreach(var serialTestID in list)
            {
                Tests test = new Tests();
                var testName = db.Database.SqlQuery<string>("SELECT Tests.testName FROM Serialized_Tests INNER JOIN Tests ON Serialized_Tests.testID = Tests.testID WHERE SerialTestID = " + serialTestID).FirstOrDefault();
                test.testTubeID = serialTestID;
                test.testName = testName;
                tests.Add(test);
            }
            ViewBag.tests = tests;
            ViewBag.workOrderID = workOrderID;
            ViewBag.LTNum = LTNum;
            ViewBag.sampleID = sampleID;
            return View("WorkOrders");
        }
    }
}
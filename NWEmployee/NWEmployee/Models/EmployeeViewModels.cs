using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NWEmployee.Models
{
    public class WorkOrders
    {
        public int workOrderID;
        public string customerName;
    }

    public class Compounds
    {
        public int LTNum;
        public string compoundName;
    }

    public class Samples
    {
        public int sampleID;
        public string assayName;
    }

    public class Tests
    {
        public int testTubeID;
        public string testName;
    }
}
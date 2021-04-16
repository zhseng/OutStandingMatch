using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OutStandingMatch;

namespace OutStandingTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<Bill> data = new List<Bill>();
            OutStandingCalc calc = new OutStandingCalc();

            data.Add(new Bill { CustomerId = 1, BillAmount = 100 });
            data.Add(new Bill { CustomerId = 1, BillAmount = 200 });
            data.Add(new Bill { CustomerId = 2, BillAmount = 300 });
            data.Add(new Bill { CustomerId = 2, BillAmount = 100 });
            data.Add(new Bill { CustomerId = 1, BillAmount = 200 });

            Assert.AreEqual(calc.GetPossibleCustomerIdsForOutstandingAmount(data, 400).Count(), 1);
        }


        [TestMethod]
        public void TestMethod2()
        {
            List<Bill> data = new List<Bill>();
            OutStandingCalc calc = new OutStandingCalc();

            data.Add(new Bill { CustomerId = 1, BillAmount = 100 });
            data.Add(new Bill { CustomerId = 1, BillAmount = 200 });
            data.Add(new Bill { CustomerId = 2, BillAmount = 300 });
            data.Add(new Bill { CustomerId = 2, BillAmount = 100 });
            data.Add(new Bill { CustomerId = 1, BillAmount = 200 });

            Assert.AreEqual(calc.GetPossibleCustomerIdsForOutstandingAmount(data, 500).Count(), 1);
        }

        [TestMethod]
        public void TestMethod3()
        {
            List<Bill> data = new List<Bill>();
            OutStandingCalc calc = new OutStandingCalc();

            data.Add(new Bill { CustomerId = 1, BillAmount = 100 });
            data.Add(new Bill { CustomerId = 2, BillAmount = 200 });
            data.Add(new Bill { CustomerId = 3, BillAmount = 300 });
            data.Add(new Bill { CustomerId = 4, BillAmount = 100 });
            data.Add(new Bill { CustomerId = 5, BillAmount = 200 });

            Assert.AreEqual(calc.GetPossibleCustomerIdsForOutstandingAmount(data, 200).Count(), 2);
        }

        [TestMethod]
        public void TestMethod4()
        {
            List<Bill> data = new List<Bill>();
            OutStandingCalc calc = new OutStandingCalc();

            data.Add(new Bill { CustomerId = 1, BillAmount = 100 });
            data.Add(new Bill { CustomerId = 1, BillAmount = 100 });
            data.Add(new Bill { CustomerId = 2, BillAmount = 150 });
            data.Add(new Bill { CustomerId = 2, BillAmount = 50 });
            data.Add(new Bill { CustomerId = 3, BillAmount = 200 });

            Assert.AreEqual(calc.GetPossibleCustomerIdsForOutstandingAmount(data, 200).Count(), 3);
        }
    }
}

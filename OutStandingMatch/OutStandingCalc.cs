using System;
using System.Collections.Generic;
using System.Linq;

namespace OutStandingMatch
{
    public class OutStandingCalc
    {
        public IEnumerable<int> GetPossibleCustomerIdsForOutstandingAmount(List<Bill> outstandingBills, decimal amountToMatch)
        {
            List<int> result = new List<int>();

            // Possible individual bill match
            foreach (var rowBill in outstandingBills)
            {
                if(rowBill.BillAmount - rowBill.PaidAmount == amountToMatch && !result.Contains(rowBill.CustomerId))
                {
                    result.Add(rowBill.CustomerId);
                }
            }

            // Possible total bill collection
            var groupby = outstandingBills.GroupBy(a => a.CustomerId)
                .Select(b =>
                new {
                    CustomerId = b.Key,
                    OutStanding = b.Sum(c => c.BillAmount - c.PaidAmount)
                });

            foreach (var rowGroup in groupby)
            {
                if (amountToMatch == rowGroup.OutStanding && !result.Contains(rowGroup.CustomerId))
                    result.Add(rowGroup.CustomerId);
            }

            return result;
        }
    }

    public class Bill
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public DateTime BillDate { get; set; }

        public decimal BillAmount { get; set; }

        public decimal PaidAmount { get; set; }

        public DateTime? PaidDate { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    public class InVoiceSummary
    {
        private int numberOfRides;
        private double totalFare;
        private double averageFare;

        public InVoiceSummary(int numberOfRides, double totalFare)
        {
            this.numberOfRides = numberOfRides;
            this.totalFare = totalFare;
            this.averageFare = this.totalFare / this.numberOfRides;
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }
}

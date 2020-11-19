using CabInvoiceGenerator;
using NUnit.Framework;

namespace CabInvoiceGeneratorTest
{
    public class Tests
    {
        InVoiceGenerator inVoiceGenerator = null;

        /// <summary>
        /// Test Case UC1
        /// Givens the distance and time should return total fare.
        /// </summary>
        [Test]
        public void GivenDistanceAndTimeShouldReturnTotalFare()
        {
            /// Creating Instance of InvoiceGenerator For Normal Ride.
            inVoiceGenerator = new InVoiceGenerator(RideType.NORMAL);
            double distance = 2.0;
            int time = 5;
            /// Calculating Fare
            double fare = inVoiceGenerator.CalculateFare(distance, time);
            double excepted = 25;
            /// Assert
            Assert.AreEqual(excepted, fare);
        }

    }
}
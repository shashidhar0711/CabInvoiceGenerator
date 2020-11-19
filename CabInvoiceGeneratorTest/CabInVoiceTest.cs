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
            /// Arrange
            /// Creating Instance of InvoiceGenerator For Normal Ride.
            inVoiceGenerator = new InVoiceGenerator(RideType.NORMAL);
            double distance = 2.0;
            int time = 5;

            /// Act
            /// Calculating Fare
            double fare = inVoiceGenerator.CalculateFare(distance, time);
            double excepted = 25;

            /// Assert
            Assert.AreEqual(excepted, fare);
        }

        /// <summary>
        /// Test Case UC2
        /// Givens the multiple rides should return in voice summary.
        /// </summary>
        [Test]
        public void GivenMultipleRidesShouldReturnInVoiceSummary()
        {
            /// Arrange
            /// Creating Instance of InvoiceGenerator For Normal Ride
            inVoiceGenerator = new InVoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };

            /// Act
            /// Calculating Multiple Rides Total Fare
            InVoiceSummary summary = inVoiceGenerator.MultipleCalculateFare(rides);
            InVoiceSummary expectedSummary = new InVoiceSummary(2, 30.0);

            /// Assert
            Assert.AreEqual(expectedSummary, summary);
        }
    }
}
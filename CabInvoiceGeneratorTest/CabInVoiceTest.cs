using CabInvoiceGenerator;
using NUnit.Framework;

namespace CabInvoiceGeneratorTest
{
    public class Tests
    {
        InVoiceGenerator inVoiceGenerator = null;

        /// <summary>
        /// Givens the distance and time should return total fare.
        /// </summary>
        [Test]
        public void GivenDistanceAndTime_ItShouldReturnTotalFare()
        {
            /// Creating Instance of InvoiceGenerator For Normal Ride
            inVoiceGenerator = new InVoiceGenerator(RideType.NORMAL);
            double distance = 2.0;
            int time = 5;
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
        public void GivenMultipleRides_ItShouldReturnInVoiceSummary()
        {
            /// Creating Instance of InvoiceGenerator For Normal Ride
            /// Arrange
            inVoiceGenerator = new InVoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(1.0, 1) };

            /// Calculating Multiple Rides Total Fare
            /// Act
            InVoiceSummary summary = inVoiceGenerator.MultipleCalculateFare(rides);
            InVoiceSummary expectedSummary = new InVoiceSummary(2, 30.0);

            /// Assert
            Assert.AreEqual(expectedSummary, summary);

        }

        /// <summary>
        /// Test case UC3
        /// Givens the multiple rides should return in voice summary with average.
        /// </summary>
        [Test]
        public void GivenMultipleRides_ItShouldReturnInvoiceSummary_WithAverage()
        {
            /// Arrange
            /// Creating Instance of InvoiceGenerator For Normal Ride
            inVoiceGenerator = new InVoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(1.0, 1) };

            /// Act
            /// Calcualting Average Fare
            InVoiceSummary inVoiceSummary = inVoiceGenerator.CalculateAvgFare(rides);
            InVoiceSummary expectedInvoiceSummary = new InVoiceSummary(2, 30.0, 15.0);

            /// Assert
            Assert.AreEqual(expectedInvoiceSummary, inVoiceSummary);
        }

        /// <summary>
        /// Test case UC4
        /// Givens user id it should return in voice summary.
        /// </summary>
        [Test]
        public void GivenUserId_ItShouldReturnInvoiceSummary()
        {
            /// Arrange
            /// initialising the object of the invoice generator class
            inVoiceGenerator = new InVoiceGenerator(RideType.NORMAL);

            /// Creating the reference of the ride repository
            RideRepository repository = new RideRepository();
            string userID = "Shashi";
            Ride[] rides = { new Ride(2.0, 5), new Ride(1.0, 1) };
            /// Adding the Ride in to repository
            repository.AddRide(userID, rides);
            /// Getting the user id
            Ride[] rideData = repository.GetRides(userID);

            /// Act
            InVoiceSummary inVoiceSummary = inVoiceGenerator.CalculateAvgFare(rideData);
            InVoiceSummary expectedInvoiceSummary = new InVoiceSummary(2, 30.0, 15.0);

            /// Assert
            Assert.AreEqual(expectedInvoiceSummary, inVoiceSummary);
        }
    }
}
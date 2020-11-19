using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    public class InVoiceGenerator
    {
        /// variables
        RideType rideType;
        private RideRepository rideRepository;

        /// Constants
        private readonly double MINIMUM_COST_PER_KM;
        private readonly int COST_PER_TIME;
        private readonly double MINIMUM_FARE;

        /// <summary>
        /// Initializes a new instance of the <see cref="InVoiceGenerator"/> class.
        /// </summary>
        /// <param name="rideType">Type of the ride.</param>
        /// <exception cref="CabInVoiceException">Invalid ride type</exception>
        public InVoiceGenerator(RideType rideType)
        {
            this.rideType = rideType;
            this.rideRepository = new RideRepository();

            try
            {
                if(rideType.Equals(RideType.PREMIUM))
                {
                    this.MINIMUM_COST_PER_KM = 15;
                    this.COST_PER_TIME = 2;
                    this.MINIMUM_FARE = 20;
                }

                if (rideType.Equals(RideType.NORMAL))
                {
                    this.MINIMUM_COST_PER_KM = 10;
                    this.COST_PER_TIME = 1;
                    this.MINIMUM_FARE = 5;
                }
            }
            catch(CabInVoiceException)
            {
                throw new CabInVoiceException(CabInVoiceException.ExceptionType.INVALID_RIDE_TYPE, "Invalid ride type");
            }
        }

        /// <summary>
        /// Calculates the fare.
        /// </summary>
        /// <param name="distance">The distance.</param>
        /// <param name="time">The time.</param>
        /// <returns></returns>
        /// <exception cref="CabInVoiceException">
        /// Invalid ride type
        /// or
        /// Invalid distance
        /// or
        /// Invalid time
        /// </exception>
        public double CalculateFare(double distance, int time)
        {
            double totalFare = 0;
            try
            {
                /// Calculating Total Fare
                totalFare = distance * MINIMUM_COST_PER_KM + time * COST_PER_TIME;
            }
            catch(CabInVoiceException)
            {
                if(rideType.Equals(null))
                {
                    throw new CabInVoiceException(CabInVoiceException.ExceptionType.INVALID_RIDE_TYPE, "Invalid ride type");
                }

                if(distance <= 0)
                {
                    throw new CabInVoiceException(CabInVoiceException.ExceptionType.INVALID_DISTANCE, "Invalid distance");
                }
                if(time < 0)
                {
                    throw new CabInVoiceException(CabInVoiceException.ExceptionType.INVLAID_TIME, "Invalid time");
                }
            }
            return Math.Max(totalFare, MINIMUM_FARE);
        }

        /// <summary>
        /// Multiples the calculate fare.
        /// </summary>
        /// <param name="rides">The rides.</param>
        /// <returns></returns>
        /// <exception cref="CabInvoiceGenerator.CabInVoiceException">Rides Are Null</exception>
        public InVoiceSummary MultipleCalculateFare(Ride[] rides)
        {
            double totalFare = 0;
            try
            {
                /// Calculating Total Fare For All Rides 
                foreach (Ride ride in rides)
                {
                    totalFare += this.CalculateFare(ride.distance, ride.time);
                }
            }
            catch (CabInVoiceException)
            {
                if (rides == null)
                {
                    throw new CabInVoiceException(CabInVoiceException.ExceptionType.NULL_RIDES, "Rides Are Null");
                }
            }
            return new InVoiceSummary(rides.Length, totalFare);
        }
    }
}

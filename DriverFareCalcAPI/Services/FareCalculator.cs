using DriverFareCalcAPI.IServices;
using DriverFareCalcAPI.Models;

namespace DriverFareCalcAPI.Services
{
    public class FareCalculator : IFareCalculator
    {
        private readonly IFareBandProvider _fareBands;

        public FareCalculator(IFareBandProvider fareBands)
        {
            _fareBands = fareBands;
        }

        public double CalculateFare(double distance)
        {
            double fare = 0;
            double previousLimit = 0;
            var bands = _fareBands.GetBands()?.ToList() ?? new List<FareBand>();

            foreach (var band in bands)
            {
                double currentLimit = band.DistanceLimit ?? double.MaxValue;

                if (distance <= previousLimit)
                    return fare;

                double milesInBand = Math.Min(distance, currentLimit) - previousLimit;
                fare += milesInBand * band.RatePerMile;
                previousLimit = currentLimit;
            }

            return fare;
        }
    }
}


using DriverFareCalcAPI.IServices;
using DriverFareCalcAPI.Models;

namespace DriverFareCalcAPI.Services
{
    public class FareBandProvider : IFareBandProvider
    {
        public IEnumerable<FareBand> GetBands()
        {
            return new List<FareBand>
                {
                    new FareBand { DistanceLimit = 1, RatePerMile = 10 },
                    new FareBand { DistanceLimit = 6, RatePerMile = 2 },
                    new FareBand { DistanceLimit = 16, RatePerMile = 3 },
                    new FareBand { DistanceLimit = null, RatePerMile = 1 }
                };
        }
    }
}


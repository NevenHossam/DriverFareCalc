using DriverFareCalcAPI.Models;

namespace DriverFareCalcAPI.IServices
{
    public interface IFareBandProvider
    {
        IEnumerable<FareBand> GetBands();
    }
}


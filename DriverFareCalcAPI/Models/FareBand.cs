namespace DriverFareCalcAPI.Models
{
    public class FareBand
    {
        public double? DistanceLimit { get; set; }  // e.g., 1, 6, 16, or null for no limit
        public double RatePerMile { get; set; }     // GBP per mile
    }
}


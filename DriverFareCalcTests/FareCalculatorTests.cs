using DriverFareCalcAPI.Services;
using DriverFareCalcAPI.IServices;

namespace DriverFareCalcAPI.Tests
{
    public class FareCalculatorTests
    {
        private IFareCalculator CreateCalculator()
        {
            return new FareCalculator(new FareBandProvider());
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 10)]
        [InlineData(2, 10 + 2)]
        [InlineData(3, 10 + (2 * 2))]
        [InlineData(6, 10 + (5 * 2))]
        [InlineData(12, 10 + (5 * 2) + (6 * 3))] // 38
        [InlineData(18, 10 + (5 * 2) + (10 * 3) + 2)] // 56
        [InlineData(100, 10 + 10 + 30 + (84 * 1))] // 134
        public void CalculateFare_ShouldReturnExpectedResult(double distance, double expectedFare)
        {
            var calculator = CreateCalculator();
            var actualFare = calculator.CalculateFare(distance);
            Assert.Equal(expectedFare, actualFare, precision: 2);
        }
    }
}

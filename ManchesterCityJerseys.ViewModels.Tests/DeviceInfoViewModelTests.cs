using FluentAssertions;

namespace ManchesterCityJerseys.ViewModels.Tests
{
    public class DeviceInfoViewModelTests
    {
        [Fact]
        public void Constructor_ShouldThrowArgumentNullException_WhenDeviceInfoServiceIsNull()
        {
            // Act
            Action act = () => new DeviceInfoViewModel(null);

            // Assert
            act.Should().Throw<ArgumentNullException>().WithMessage("*deviceInfoService*");
        }
    }
}

using FluentAssertions;
using ManchesterCityJerseys.Core.Interfaces;
using ManchesterCityJerseys.Core.Models;
using Moq;

namespace ManchesterCityJerseys.ViewModels.Tests
{
    public class JerseyListViewModelTests
    {
        private readonly Mock<IJerseyService> _jerseyServiceMock;
        private readonly Mock<IDeviceInfoService> _deviceInfoServiceMock;
        private readonly Mock<INavigationService> _navigationServiceMock;
        private readonly JerseyListViewModel _viewModel;

        public JerseyListViewModelTests()
        {
            _jerseyServiceMock = new Mock<IJerseyService>();
            _deviceInfoServiceMock = new Mock<IDeviceInfoService>();
            _navigationServiceMock = new Mock<INavigationService>();

            _deviceInfoServiceMock.Setup(x => x.GetDeviceModel()).Returns("Test Device");

            _viewModel = new JerseyListViewModel(
                _jerseyServiceMock.Object,
                _navigationServiceMock.Object);
        }

        [Theory]
        [InlineData(null, "navigationService", "jerseyService")]
        [InlineData("jerseyService", null, "navigationService")]
        public void Constructor_ShouldThrowArgumentNullException_WhenAnyDependencyIsNull(
            string jerseyService, string navigationService, string expectedParam)
        {
            // Arrange
            var jerseyServiceInstance = jerseyService == null ? null : _jerseyServiceMock.Object;
            var navigationServiceInstance = navigationService == null ? null : _navigationServiceMock.Object;

            // Act
            Action act = () => new JerseyListViewModel(jerseyServiceInstance, navigationServiceInstance);

            // Assert
            act.Should().Throw<ArgumentNullException>()
               .And.ParamName.Should().Be(expectedParam);
        }

        [Fact]
        public async Task LoadJerseysAsync_ShouldLoadJerseys()
        {
            // Arrange
            var jerseys = new List<Jersey>
            {
                new Jersey { Id = 1, Name = "Home Jersey 2023", Year = "2023", Price = 79.99M },
                new Jersey { Id = 2, Name = "Away Jersey 2023", Year = "2023", Price = 74.99M }
            };
            _jerseyServiceMock.Setup(x => x.GetJerseysAsync()).ReturnsAsync(jerseys);

            // Act
            await _viewModel.LoadJerseysCommand.ExecuteAsync(null);

            // Assert
            _viewModel.Jerseys.Should().HaveCount(2);
            _viewModel.Jerseys[0].Item.Name.Should().Be("Home Jersey 2023");
            _viewModel.Jerseys[1].Item.Name.Should().Be("Away Jersey 2023");
        }

        [Fact]
        public async Task OnJerseySelected_ShouldNavigateToDetailPage()
        {
            // Arrange
            var jerseys = new List<Jersey>
            {
                new Jersey { Id = 1, Name = "Home Jersey 2023", Year = "2023", Price = 79.99M },
                new Jersey { Id = 2, Name = "Away Jersey 2023", Year = "2023", Price = 74.99M }
            };
            _jerseyServiceMock.Setup(x => x.GetJerseysAsync()).ReturnsAsync(jerseys);

            // Act
            await _viewModel.LoadJerseysCommand.ExecuteAsync(null);

            _viewModel.Jerseys[0].SelectCommand.Execute(null);

            // Assert
            _navigationServiceMock.Verify(x => x.NavigateToAsync($"JerseyDetailPage?selectedJerseyId={_viewModel.Jerseys[0].Item.Id}"), Times.Once);
        }

        [Fact]
        public async Task LoadJerseysAsync_ShouldAddError_WhenJerseysAreNullOrEmpty()
        {
            // Arrange
            _jerseyServiceMock
                .Setup(s => s.GetJerseysAsync())
                .ReturnsAsync((List<Jersey>)null);

            // Act
            await _viewModel.LoadJerseysCommand.ExecuteAsync(null);

            // Assert
            Assert.Contains("No jerseys available.", _viewModel.Errors);
        }

        [Fact]
        public async Task LoadJerseysAsync_ShouldAddError_WhenExceptionOccurs()
        {
            // Arrange
            _jerseyServiceMock
                .Setup(s => s.GetJerseysAsync())
                .ThrowsAsync(new Exception("Service unavailable"));

            // Act
            await _viewModel.LoadJerseysCommand.ExecuteAsync(null);

            // Assert
            Assert.Contains("Failed to load jerseys: Service unavailable", _viewModel.Errors);
        }
    }
}

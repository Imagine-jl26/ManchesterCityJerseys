using FluentAssertions;
using ManchesterCityJerseys.Core.Interfaces;
using ManchesterCityJerseys.Core.Models;
using Moq;

namespace ManchesterCityJerseys.ViewModels.Tests
{
    public class JerseyDetailViewModelTests
    {
        private readonly Mock<IJerseyService> _jerseyServiceMock;
        private readonly JerseyDetailViewModel _viewModel;

        public JerseyDetailViewModelTests()
        {
            _jerseyServiceMock = new Mock<IJerseyService>();
            _viewModel = new JerseyDetailViewModel(_jerseyServiceMock.Object);
        }

        [Fact]
        public void Constructor_ShouldThrowArgumentNullException_WhenJerseyServiceIsNull()
        {
            // Act
            Action act = () => new JerseyDetailViewModel(null);

            // Assert
            act.Should().Throw<ArgumentNullException>()
               .WithMessage("*jerseyService*");
        }

        [Fact]
        public async Task InitializeAsync_ShouldLoadJersey_WhenValidIdProvided()
        {
            // Arrange
            var testJersey = new Jersey { Id = 1, Name = "Test Jersey", Year = "2024", Price = 79.99M };
            _jerseyServiceMock.Setup(x => x.GetJerseyByIdAsync(1)).ReturnsAsync(testJersey);

            // Act
            await _viewModel.InitializeAsync(1);

            // Assert
            _viewModel.SelectedJersey.Should().NotBeNull();
            _viewModel.SelectedJersey.Should().BeEquivalentTo(testJersey);
        }

        [Fact]
        public async Task InitializeAsync_ShouldSetEmptyJersey_WhenInvalidIdProvided()
        {
            // Arrange
            _jerseyServiceMock.Setup(x => x.GetJerseyByIdAsync(It.IsAny<int>())).ReturnsAsync((Jersey)null);

            // Act
            await _viewModel.InitializeAsync(999);

            // Assert
            _viewModel.SelectedJersey.Should().BeNull();
        }

        [Fact]
        public async Task InitializeAsync_ShouldAddError_WhenJerseyNotFound()
        {
            // Arrange
            _jerseyServiceMock
                .Setup(s => s.GetJerseyByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((Jersey)null);

            // Act
            await _viewModel.InitializeAsync(1);

            // Assert
            Assert.Contains("Jersey not found.", _viewModel.Errors);
        }

        [Fact]
        public async Task InitializeAsync_ShouldAddError_WhenExceptionOccurs()
        {
            // Arrange
            _jerseyServiceMock
                .Setup(s => s.GetJerseyByIdAsync(It.IsAny<int>()))
                .ThrowsAsync(new Exception("Network failure"));

            // Act
            await _viewModel.InitializeAsync(1);

            // Assert
            Assert.Contains("Failed to load jersey: Network failure", _viewModel.Errors);
        }
    }
}

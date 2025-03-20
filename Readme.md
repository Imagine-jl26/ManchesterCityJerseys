# Manchester City Jerseys - .NET MAUI App

## 📌 Overview
This is a .NET MAUI application that showcases a collection of Manchester City jerseys. The app follows best practices such as MVVM architecture, dependency injection, and unit testing to provide a structured and scalable codebase.

## 🚀 Features
- 📋 **Jersey List Page:** Displays a collection of Manchester City jerseys.
- 🔍 **Jersey Detail Page:** Shows detailed information about a selected jersey.
- 📱 **Device Info Page:** Fetches and displays device model information using Dependency Injection.
- 🏗 **MVVM Architecture:** Ensures maintainability and separation of concerns.
- 🔌 **Dependency Injection:** Implements services via interfaces for testability and flexibility.
- ✅ **Unit Testing:** Provides test coverage for ViewModels and services.

## 🏗 Project Structure

### 📂 `Core`
- `Models/Jersey.cs` - Represents the data model for jerseys.
- `Interfaces/IDeviceInfoService.cs` - Interface for fetching device information.
- `Interfaces/IJerseyService.cs` - Interface for fetching jersey data.
- `Interfaces/INavigationService.cs` - Interface for navigation.

### 📂 `Services`
- `JerseyService.cs` - Provides jersey data (simulated API data source).

### 📂 `ViewModels`
- `JerseyListViewModel.cs` - Manages jersey list logic.
- `JerseyDetailViewModel.cs` - Handles the jersey detail page logic.
- `DeviceInfoViewModel.cs` - Fetches device model information.

### 📂 `Views`
- `JerseyListPage.xaml` - Displays the list of jerseys.
- `JerseyDetailPage.xaml` - Shows details of a selected jersey.
- `DeviceInfoPage.xaml` - Displays device info.

### 📂 `Tests`
- `JerseyListViewModelTests.cs` - Unit tests for `JerseyListViewModel`.
- `JerseyDetailViewModelTests.cs` - Unit tests for `JerseyDetailViewModel`.

## 🔧 Installation & Setup
1. **Clone the Repository:**
   ```sh
   git clone https://github.com/Imagine-jl26/ManchesterCityJerseys.git
   cd ManchesterCityJerseys
   ```

2. **Open in Visual Studio:**
   - Ensure you have the latest .NET MAUI workload installed.
   - Open the solution file in Visual Studio 2022.

3. **Run the Application:**
   - Select an emulator or a physical device.
   - Press `F5` or click on `Run`.

## 🧪 Running Tests
To execute unit tests, run the following command in the test project directory:
```sh
dotnet test
```

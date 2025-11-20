# UC-010: Windows-Based GitHub Actions Pipeline Development

[![Build Status](https://github.com/signanthealth-poc/day4-poc-demo-1/workflows/Windows%20CI%2FCD%20Pipeline/badge.svg)](https://github.com/signanthealth-poc/day4-poc-demo-1/actions)
[![.NET](https://img.shields.io/badge/.NET-8.0-blue.svg)](https://dotnet.microsoft.com/download/dotnet/8.0)
[![License](https://img.shields.io/badge/license-MIT-green.svg)](LICENSE)

> **Complete demonstration project for Windows-based GitHub Actions pipeline development featuring .NET 8.0 Web API, multi-framework testing, and production-ready CI/CD automation.**

## 🎯 **Project Overview**

This repository contains a **fool-proof demonstration** designed for a 30-minute presentation showcasing Windows-based GitHub Actions pipeline development. The project includes:

- ✅ **Complete .NET 8.0 Web API** with layered architecture
- ✅ **Multi-framework testing** (MSTest, NUnit, xUnit) - All 20 tests passing
- ✅ **GitHub Actions CI/CD pipeline** with Windows matrix builds
- ✅ **PowerShell build automation** with timing metrics
- ✅ **Production-ready features** including Swagger documentation
- ✅ **Comprehensive demo playbook** for presentations

## 🏗️ **Architecture**

```
WeatherApiDemo/
├── src/
│   ├── WeatherApi/           # Main Web API application
│   ├── WeatherApi.Core/      # Business logic and models
│   └── WeatherApi.Data/      # Data access layer
├── tests/
│   ├── WeatherApi.MSTests/   # Microsoft Test Framework
│   ├── WeatherApi.NUnitTests/# NUnit Framework
│   └── WeatherApi.XUnitTests/# xUnit Framework
├── .github/workflows/        # GitHub Actions CI/CD
├── build/                    # PowerShell build scripts
└── docs/                     # Demo playbook and documentation
```

## 🚀 **Quick Start**

### Prerequisites
- .NET 8.0 SDK
- PowerShell 5.1 or later
- Git
- Visual Studio Code (recommended)

### Local Development

1. **Clone the repository**
   ```powershell
   git clone https://github.com/signanthealth-poc/day4-poc-demo-1.git
   cd day4-poc-demo-1
   ```

2. **Build and test locally**
   ```powershell
   .\build\build.ps1 -RunTests
   ```

3. **Run the API**
   ```powershell
   dotnet run --project src/WeatherApi
   ```

4. **Access Swagger UI**
   - Navigate to: `https://localhost:5001/swagger`

### Demo Verification
Run the complete demo verification:
```powershell
.\demo-verification.ps1
```

## 🧪 **Testing Strategy**

This project demonstrates **multi-framework testing** with identical test coverage across three popular .NET testing frameworks:

| Framework | Tests | Status |
|-----------|-------|--------|
| **MSTest** | 6 tests | ✅ All passing |
| **NUnit** | 7 tests | ✅ All passing |
| **xUnit** | 7 tests | ✅ All passing |
| **Total** | **20 tests** | ✅ **100% success** |

### Test Coverage
- ✅ Temperature conversion (Celsius ↔ Fahrenheit)
- ✅ Object initialization and defaults
- ✅ Business logic validation
- ✅ Service layer functionality

## 🔄 **CI/CD Pipeline**

### GitHub Actions Features
- **Windows Matrix Builds**: Tests across `windows-latest`, `windows-2022`, `windows-2019`
- **NuGet Caching**: Optimized build times with dependency caching
- **Multi-Framework Testing**: Automated testing across all frameworks
- **Artifact Management**: Build artifacts stored for deployment
- **PowerShell Integration**: Native Windows tooling

### Build Pipeline Stages
1. **Restore** - NuGet package restoration with caching
2. **Build** - Compile solution in Release configuration
3. **Test** - Execute all test frameworks in parallel
4. **Package** - Create deployment artifacts
5. **Deploy** - (Ready for deployment automation)

## 📊 **Performance Metrics**

Current build performance (local):
- **Restore Time**: ~1.1 seconds
- **Build Time**: ~1.4 seconds  
- **Test Time**: ~6.4 seconds
- **Total Pipeline**: ~8.9 seconds

## 🛠️ **Development Tools**

### PowerShell Build Script
The `build/build.ps1` script provides comprehensive build automation:

```powershell
# Basic build
.\build\build.ps1

# Build with tests
.\build\build.ps1 -RunTests

# Clean build with packaging
.\build\build.ps1 -Clean -Package

# Debug configuration
.\build\build.ps1 -Configuration Debug -RunTests
```

### Available Parameters
- `-Configuration`: `Debug` or `Release` (default: `Release`)
- `-RunTests`: Execute all test projects
- `-Package`: Create deployment packages
- `-Clean`: Clean previous builds
- `-OutputPath`: Specify custom output directory

## 📚 **API Documentation**

### Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| `GET` | `/weatherforecast` | Get 5-day weather forecast |
| `GET` | `/weatherforecast/{days}` | Get forecast for specific number of days |

### Sample Response
```json
[
  {
    "date": "2025-11-21",
    "temperatureC": 22,
    "temperatureF": 71,
    "summary": "Mild",
    "windSpeed": 5.2,
    "humidity": 65,
    "pressure": 1013.25
  }
]
```

## 🎤 **Demo Presentation**

### 30-Minute Presentation Structure
The complete demo playbook is available at [`docs/DEMO_PLAYBOOK.md`](docs/DEMO_PLAYBOOK.md) and includes:

1. **Introduction** (5 minutes)
   - Windows GitHub Actions overview
   - Project architecture walkthrough

2. **Live Demonstration** (20 minutes)
   - Local build execution
   - GitHub Actions pipeline walkthrough
   - Multi-framework testing showcase
   - PowerShell automation features

3. **Q&A and Wrap-up** (5 minutes)
   - Best practices discussion
   - Troubleshooting common issues

### Key Demonstration Points
- ✅ **Windows-native tooling** (PowerShell, .NET, Windows runners)
- ✅ **Matrix build strategy** across Windows versions
- ✅ **Caching optimization** for faster builds
- ✅ **Multi-framework testing** approach
- ✅ **Production-ready pipeline** configuration

## 🔧 **Troubleshooting**

### Common Issues

**Build Failures**
```powershell
# Clean and rebuild
.\build\build.ps1 -Clean
dotnet clean WeatherApiDemo.sln
dotnet restore WeatherApiDemo.sln
```

**Test Failures**
```powershell
# Run tests individually
dotnet test tests/WeatherApi.MSTests/WeatherApi.MSTests.csproj -v normal
dotnet test tests/WeatherApi.NUnitTests/WeatherApi.NUnitTests.csproj -v normal
dotnet test tests/WeatherApi.XUnitTests/WeatherApi.XUnitTests.csproj -v normal
```

**NuGet Package Issues**
```powershell
# Clear NuGet cache
dotnet nuget locals all --clear
dotnet restore WeatherApiDemo.sln --force
```

## 🤝 **Contributing**

This is a demonstration project designed for presentation purposes. However, contributions to improve the demo experience are welcome:

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/improvement`)
3. Commit your changes (`git commit -am 'Add demo improvement'`)
4. Push to the branch (`git push origin feature/improvement`)
5. Create a Pull Request

## 📄 **License**

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 🏷️ **Tags**

`#github-actions` `#windows` `#dotnet` `#ci-cd` `#powershell` `#testing` `#web-api` `#demo` `#presentation` `#automation`

---

## 📞 **Support**

For questions about this demonstration project:
- 📧 **Email**: [support@signanthealth.com](mailto:support@signanthealth.com)
- 🐛 **Issues**: [GitHub Issues](https://github.com/signanthealth-poc/day4-poc-demo-1/issues)
- 📖 **Documentation**: [Demo Playbook](docs/DEMO_PLAYBOOK.md)

---

**Built with ❤️ for the Signant Health POC team**
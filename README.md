# Windows GitHub Actions Pipeline Demo

## Overview
This project demonstrates a comprehensive CI/CD pipeline for Windows applications using GitHub Actions, featuring matrix builds, caching strategies, and multiple test frameworks.

## Project Structure
```
├── src/
│   ├── WeatherApi/              # Main .NET 8.0 Web API
│   ├── WeatherApi.Core/         # Business logic library
│   └── WeatherApi.Data/         # Data access layer
├── tests/
│   ├── WeatherApi.MSTests/      # MSTest unit tests
│   ├── WeatherApi.NUnitTests/   # NUnit unit tests
│   └── WeatherApi.XUnitTests/   # xUnit unit tests
├── .github/workflows/           # GitHub Actions workflows
├── build/                       # Build scripts and configurations
└── docs/                        # Documentation and demo materials
```

## Demo Features

### 🚀 CI/CD Pipeline Components
- **Multi-Framework Testing**: MSTest, NUnit, and xUnit
- **Matrix Builds**: Windows 2019, 2022, and latest
- **Dependency Caching**: NuGet packages and build outputs
- **Artifact Management**: Build outputs, test results, and packages
- **Performance Optimization**: Parallel execution and incremental builds

### 🛠️ Build Tools Integration
- **MSBuild**: Traditional .NET Framework support
- **dotnet CLI**: Modern .NET development
- **Visual Studio tooling**: Enterprise-grade build capabilities

### 📊 Quality Gates
- Code coverage reporting
- Static code analysis
- Security vulnerability scanning
- Performance benchmarking

## Quick Start

### Prerequisites
- .NET 8.0 SDK
- Visual Studio 2022 or VS Code
- Git

### Running Locally
```bash
# Restore dependencies
dotnet restore

# Build solution
dotnet build

# Run tests
dotnet test

# Run API
dotnet run --project src/WeatherApi
```

### Demo Execution
See [Demo Playbook](docs/DEMO_PLAYBOOK.md) for step-by-step presentation guide.

## Success Metrics
- ✅ Complete Windows pipeline operational
- ✅ Artifacts generated successfully
- ✅ All tests passing across frameworks
- ✅ Optimized build times with caching
- ✅ Matrix builds for multiple Windows versions

## Performance Optimizations
- **Dependency Caching**: ~60% build time reduction
- **Matrix Parallelization**: Concurrent Windows version testing
- **Incremental Builds**: Only rebuild changed components
- **Artifact Reuse**: Share outputs between workflow jobs

---

*This demo showcases enterprise-grade CI/CD practices for Windows environments using GitHub Actions.*
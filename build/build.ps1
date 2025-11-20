# Windows GitHub Actions Pipeline Build Script
# This script demonstrates various build scenarios for the demo

param(
    [Parameter(Mandatory=$false)]
    [ValidateSet("Debug", "Release")]
    [string]$Configuration = "Release",
    
    [Parameter(Mandatory=$false)]
    [switch]$RunTests,
    
    [Parameter(Mandatory=$false)]
    [switch]$Package,
    
    [Parameter(Mandatory=$false)]
    [switch]$Clean,
    
    [Parameter(Mandatory=$false)]
    [string]$OutputPath = ".\publish"
)

$ErrorActionPreference = "Stop"
$SolutionPath = ".\WeatherApiDemo.sln"

Write-Host "Starting Windows Build Pipeline Demo" -ForegroundColor Green
Write-Host "Configuration: $Configuration" -ForegroundColor Yellow
Write-Host "Solution: $SolutionPath" -ForegroundColor Yellow

# Clean previous builds
if ($Clean) {
    Write-Host "Cleaning previous builds..." -ForegroundColor Blue
    if (Test-Path "bin") { Remove-Item -Recurse -Force "bin" }
    if (Test-Path "obj") { Remove-Item -Recurse -Force "obj" }
    if (Test-Path $OutputPath) { Remove-Item -Recurse -Force $OutputPath }
    dotnet clean $SolutionPath
}

# Restore dependencies
Write-Host "Restoring NuGet packages..." -ForegroundColor Blue
$restoreTime = Measure-Command {
    dotnet restore $SolutionPath --verbosity minimal
}
Write-Host "Restore completed in $($restoreTime.TotalSeconds.ToString("F2")) seconds" -ForegroundColor Green

# Build solution
Write-Host "Building solution..." -ForegroundColor Blue
$buildTime = Measure-Command {
    dotnet build $SolutionPath --configuration $Configuration --no-restore --verbosity minimal
}
Write-Host "Build completed in $($buildTime.TotalSeconds.ToString("F2")) seconds" -ForegroundColor Green

# Run tests if requested
if ($RunTests) {
    Write-Host "Running tests..." -ForegroundColor Blue
    
    $testProjects = @(
        "tests\WeatherApi.MSTests\WeatherApi.MSTests.csproj",
        "tests\WeatherApi.NUnitTests\WeatherApi.NUnitTests.csproj",
        "tests\WeatherApi.XUnitTests\WeatherApi.XUnitTests.csproj"
    )
    
    $totalTestTime = Measure-Command {
        foreach ($testProject in $testProjects) {
            Write-Host "  Running tests in $testProject..." -ForegroundColor Cyan
            dotnet test $testProject --configuration $Configuration --no-build --verbosity normal
        }
    }
    Write-Host "All tests completed in $($totalTestTime.TotalSeconds.ToString("F2")) seconds" -ForegroundColor Green
}

# Package application if requested
if ($Package) {
    Write-Host "Publishing application..." -ForegroundColor Blue
    $publishTime = Measure-Command {
        dotnet publish "src\WeatherApi\WeatherApi.csproj" --configuration $Configuration --no-build --output $OutputPath
    }
    Write-Host "Publish completed in $($publishTime.TotalSeconds.ToString("F2")) seconds" -ForegroundColor Green
    Write-Host "Output location: $OutputPath" -ForegroundColor Yellow
}

# Display summary
Write-Host "`nBuild Summary:" -ForegroundColor Green
Write-Host "  Restore Time: $($restoreTime.TotalSeconds.ToString("F2"))s" -ForegroundColor White
Write-Host "  Build Time: $($buildTime.TotalSeconds.ToString("F2"))s" -ForegroundColor White
if ($RunTests) {
    Write-Host "  Test Time: $($totalTestTime.TotalSeconds.ToString("F2"))s" -ForegroundColor White
}
if ($Package) {
    Write-Host "  Publish Time: $($publishTime.TotalSeconds.ToString("F2"))s" -ForegroundColor White
}

$totalTime = $restoreTime.Add($buildTime)
if ($RunTests) { $totalTime = $totalTime.Add($totalTestTime) }
if ($Package) { $totalTime = $totalTime.Add($publishTime) }

Write-Host "  Total Time: $($totalTime.TotalSeconds.ToString("F2"))s" -ForegroundColor Green
Write-Host "Build pipeline completed successfully!" -ForegroundColor Green
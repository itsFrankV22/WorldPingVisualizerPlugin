# Development

## Prequisites

### .NET 5 and CLI
To make development easier, this project uses [Paket](https://fsprojects.github.io/Paket/) as a dependency manager on top of NuGet. At the time of writing, TShock doesn't officially support NuGet packages yet, so the project acquires TShock dependencies over HTTPS. This project assumes you have the .NET 5 SDK and the dotnet CLI

### .NET 4.7.2 Targetting Pack
The project targets .NET Framework 4.7.2. So .NET Framework 4.7.2 is required to compile this project via Visual Studio

## Setup Dependencies
1. Restore dotnet tools(run `dotnet tool restore`)
2. Restore dependencies(run `dotnet paket restore`)

## Compile w/Visual Studio
1. Open `WorldPingVisualizer.sln`
2. Build solution

## Compile w/dotnet CLI
1. Navigate to project root directory
2. Run `dotnet build`

## Get Compiled Files
1. Navigate to `src/WorldPingVisualizer/bin/{BUILD_CONFIGURATION}/` where `{BUILD_CONFIGURATION}` is either Debug or Release
2. Do stuff with files
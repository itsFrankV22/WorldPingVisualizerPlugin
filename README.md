# World Ping Visualizer
World Ping Visualizer is a TShock plugin that visualizes map pings

![GitHub license](https://img.shields.io/github/license/Arthri/WorldPingVisualizer?style=flat-square) ![GitHub release (latest SemVer)](https://img.shields.io/github/v/release/Arthri/WorldPingVisualizer?sort=semver&style=flat-square) ![GitHub release (latest SemVer including pre-releases)](https://img.shields.io/github/v/release/Arthri/WorldPingVisualizer?include_prereleases&sort=semver&style=flat-square)

## Features
- Shows CombatText at ping locations
- Shows Particles at ping locations
- Supports TShock `/reload`

## Screenshots
![Example 1](../HEAD/docs/assets/Usage-1.gif)

## Installation
1. Grab the [latest](https://github.com/Arthri/WorldPingVisualizer/relases/latest) release
2. Put the zip in `ServerPlugins` folder
3. Unzip the zip

## Usage
1. Open full map
2. Double click somewhere to ping that location

The ping location should be lit up by visualizations depending on your configuration

## Development

### Prequisites
- .NET 5 SDK or above
- .NET Framework 4.7.2 targetting pack

### Setup Dependencies
1. Restore dotnet tools(run `dotnet tool restore`)
2. Restore dependencies(run `dotnet paket restore`)

### Compile w/Visual Studio
1. Open `WorldPingVisualizer.sln`
2. Build solution

### Compile w/dotnet CLI
1. Navigate to project root directory
2. Run `dotnet build`

### Get Compiled Files
1. Navigate to `src/WorldPingVisualizer/bin/{BUILD_CONFIGURATION}/` where `{BUILD_CONFIGURATION}` is either Debug or Release
2. Do stuff with files

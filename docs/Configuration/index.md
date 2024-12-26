# Configuration
World Ping Visualizer allows you to configure a number of options, such as how often pings are visualized, or how the visualizations look

## Configuration Path
By default, the plugin save path is `{Working Directory}/config/WorldPingVisualizer/`

## Configuration Options

### `metadata`
This is used by [LrndefLib](https://github.com/Arthri/LrndefLib). Please do not touch this unless you know what you are doing

### `particles`

#### `enabled`
Set to true to enable particles at ping locations

#### `particlesIntervalMilliseconds`
The interval(in milliseconds) to broadcast particles

Examples:

- `1000` for 1 second
- `1500` for 1.5 seconds
- `2000` for 2 seconds
- `36000` for 36 seconds

#### `particleType`
The type of particles to broadcast. More on particle types [here](particle-types.md)

### `combatText`

#### `enabled`
Set to true to enable combat text at ping locations

#### `combatTextIntervalMilliseconds`
The interval(in milliseconds) to broadcast combat text

Examples:

- `1000` for 1 second
- `1500` for 1.5 seconds
- `2000` for 2 seconds
- `36000` for 36 seconds

#### `combatTextContents`
The contents of the combat text broadcasted

Examples:

- `PONG!`
- `Ping Location`

#### `combatTextColor`
The color of the combat text broadcasted, in RGB decimal format.

Examples:

- `16711680` for pure red or #FF0000
- `65280` for pure green or #00FF00
- `255` for pure blue or #0000FF

!!! tip

    You can use a hex to decimal converter to get the decimal values. Alternatively Programmer calculators come built in with hex to decimal

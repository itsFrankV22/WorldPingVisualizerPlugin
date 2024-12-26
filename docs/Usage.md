# Usage

## via Terraria
1. Open full map(press ++m++ or ++"Full Map"++ key)
2. Double click somewhere to create a ping

The ping will be registered and visualized. Anyone near it will see the visualizations

!!! note

    Pings have a default life time of 15 seconds. At the time of writing, this is unchangeable, both in the vanilla client and the plugin

## via API

### Registering a Ping
```csharp
using Terraria.Map;
using WorldVisualizerPlugin;

var ping = new PingMapLayer.Ping(position);
WorldPingVisualizer.Instance.Pings.Add(ping);
```

The above will register a ping that will expire approximately 15 seconds from now.

### Showing Particles at a Ping
```csharp
using WorldVisualizerPlugin;
using WorldVisualizerPlugin.Extensions;

var type = /* */;
var ping = WorldPingVisualizer.Instance.Pings...; // Do LINQ stuff or give index to list
ping.ShowParticles(type);
```

`type` must be one of [Particle Types](/Configuration/particle-types.md)

### Showing Combat Text at a Ping
```csharp
using WorldVisualizerPlugin;
using WorldVisualizerPlugin.Extensions;

var text = "PONG!";
var color = 0xFFFF00u;
var ping = WorldPingVisualizer.Instance.Pings...; // Do LINQ stuff or give index to list
ping.ShowCombatText(NetworkText.FromLiteral(text), color);
```

- `text` can be any message. If you have experience with `NetworkText`, you can also use other types like `FromFormattable` and `FromKey`
- `color` must be a uint representing the packed value of a Color in ARGB format.

    !!! Tip

        Use the hexadecimal notation, e.g.:

        - `0xFFFF00` for `#FFFF00` or yellow
        - `0xFF00FF` for `#FF00FF` or magenta

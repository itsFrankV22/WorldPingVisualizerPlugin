# World Ping Visualizer
World Ping Visualizer es un plugin de TShock que visualiza los pings en el mapa.

> [!NOTE]
> If you speak English visit this to read in [English](README.md)

> [!NOTE]
> Repositorio original: https://github.com/Arthri/WorldPingVisualizer/tree/master
/
> Este ha sido actualizado por mí ya que el otro no funcionaba.

## Características
- Muestra CombatText en las ubicaciones de los pings.
- Muestra partículas en las ubicaciones de los pings.
- Soporta el comando `/reload` de TShock.

## Capturas de Pantalla
![Ejemplo 1](../HEAD/docs/assets/Usage-1.gif)

## Instalación
1. Descarga la [última](https://github.com/itsFrankV22/WorldPingVisualizerPlugin/releases) versión.
2. Coloca el archivo `.dll` en la carpeta `ServerPlugins`.

## Uso
1. Abre el mapa completo.
2. Haz doble clic en algún lugar para hacer ping en esa ubicación.

La ubicación del ping debería iluminarse con las visualizaciones dependiendo de tu configuración.

## Desarrollo

### Prerrequisitos
- .NET 5 SDK o superior.
- Paquete de destino de .NET Framework 4.7.2.

### Configuración de Dependencias
1. Restaura las herramientas de dotnet (ejecuta `dotnet tool restore`).
2. Restaura las dependencias (ejecuta `dotnet paket restore`).

### Compilar con Visual Studio
1. Abre `WorldPingVisualizer.sln`.
2. Compila la solución.

### Compilar con la CLI de dotnet
1. Navega al directorio raíz del proyecto.
2. Ejecuta `dotnet build`.

### Obtener Archivos Compilados
1. Navega a `src/WorldPingVisualizer/bin/{BUILD_CONFIGURATION}/` donde `{BUILD_CONFIGURATION}` es Debug o Release.
2. Haz lo que necesites con los archivos.

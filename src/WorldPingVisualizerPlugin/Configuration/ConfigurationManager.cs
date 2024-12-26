using Newtonsoft.Json;
using System.IO;

namespace MapPingParticle.Configuration
{
    public class ConfigurationManager
    {
        /// <summary>
        /// Gets a value indicating whether or not the configs has loaded.
        /// </summary>
        public bool Loaded { get; private set; }

        /// <summary>
        /// Gets or sets an object representing visualizer settings.
        /// </summary>
        public VisualizerSettings VisualizerSettings { get; set; }

        /// <summary>
        /// Initializes a new instance of <see cref="ConfigurationManager"/>.
        /// </summary>
        internal ConfigurationManager()
        {
            VisualizerSettings = new VisualizerSettings();
        }

        /// <summary>
        /// Loads the configs.
        /// </summary>
        public void Load()
        {
            Reload();
            Loaded = true;
        }

        /// <summary>
        /// Reloads the configs.
        /// </summary>
        public void Reload()
        {
            if (!Directory.Exists(PathsConfiguration.SavePath))
            {
                Directory.CreateDirectory(PathsConfiguration.SavePath);
            }

            var visualizerConfigPath = PathsConfiguration.VisualizerConfigPath;
            if (!File.Exists(visualizerConfigPath))
            {
                VisualizerSettings = new VisualizerSettings
                {
                    Version = VisualizerSettings.CurrentVersion,
                    Metadata = new SettingsMetadata
                    {
                        Version = SettingsMetadata.CurrentMetadataVersion
                    }
                };

                SaveConfig(visualizerConfigPath);
            }
            else
            {
                LoadConfig(visualizerConfigPath);
            }
        }

        private void SaveConfig(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
            using (StreamWriter sw = new StreamWriter(fs))
            using (JsonTextWriter writer = new JsonTextWriter(sw))
            {
                TransformWriter(writer);
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(writer, VisualizerSettings);
            }
        }

        private void LoadConfig(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (StreamReader sr = new StreamReader(fs))
            using (JsonTextReader reader = new JsonTextReader(sr))
            {
                JsonSerializer serializer = new JsonSerializer();
                VisualizerSettings = serializer.Deserialize<VisualizerSettings>(reader);
            }

            bool incompleteSettings = VisualizerSettings == null ||
                                      VisualizerSettings.Version != VisualizerSettings.CurrentVersion ||
                                      VisualizerSettings.Metadata == null ||
                                      VisualizerSettings.Metadata.Version != SettingsMetadata.CurrentMetadataVersion;

            if (incompleteSettings)
            {
                VisualizerSettings = new VisualizerSettings
                {
                    Version = VisualizerSettings.CurrentVersion,
                    Metadata = new SettingsMetadata
                    {
                        Version = SettingsMetadata.CurrentMetadataVersion
                    }
                };

                SaveConfig(path);
            }
        }

        private void TransformWriter(JsonTextWriter writer)
        {
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 4;
        }
    }
}

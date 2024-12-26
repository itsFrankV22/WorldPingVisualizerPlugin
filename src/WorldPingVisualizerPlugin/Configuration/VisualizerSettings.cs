using Newtonsoft.Json;
using Terraria.GameContent.Drawing;

namespace MapPingParticle.Configuration
{
    /// <summary>
    /// Represents the settings used to visualize pings.
    /// </summary>
    public class VisualizerSettings
    {
        /// <summary>
        /// Represents the current version of <see cref="VisualizerSettings"/>.
        /// </summary>
        public static readonly int CurrentVersion = 1;

        /// <summary>
        /// Represents the settings used to visualize pings via particles.
        /// </summary>
        public class ParticleSettings
        {
            /// <summary>
            /// Gets or sets if particles are enabled.
            /// </summary>
            [JsonProperty("enabled")]
            public bool Enabled { get; set; } = true;

            /// <summary>
            /// Gets or sets the interval to show particles at pings.
            /// </summary>
            [JsonProperty("particlesIntervalMilliseconds")]
            public int ParticlesIntervalMilliseconds { get; set; } = 700;

            /// <summary>
            /// Gets or sets the particle type to be used.
            /// </summary>
            [JsonProperty("particleType")]
            public ParticleOrchestraType ParticleType { get; set; } = ParticleOrchestraType.StellarTune;
        }

        /// <summary>
        /// Represents the settings used to visualize pings via combat text.
        /// </summary>
        public class CombatTextSettings
        {
            /// <summary>
            /// Gets or sets if combat text is enabled.
            /// </summary>
            [JsonProperty("enabled")]
            public bool Enabled { get; set; }

            /// <summary>
            /// Gets or sets the interval to show combat text at pings.
            /// </summary>
            [JsonProperty("combatTextIntervalMilliseconds")]
            public int CombatTextIntervalMilliseconds { get; set; } = 700;

            /// <summary>
            /// Gets or sets the contents of the combat text.
            /// </summary>
            [JsonProperty("combatTextContents")]
            public string CombatTextContents { get; set; } = "PING!";

            /// <summary>
            /// Gets or sets the color of the combat text.
            /// </summary>
            [JsonProperty("combatTextColor")]
            public uint CombatTextColor { get; set; } = 0xFFFF00;
        }

        /// <summary>
        /// Gets or sets the particle settings.
        /// </summary>
        [JsonProperty("particles")]
        public ParticleSettings Particles { get; set; } = new ParticleSettings();

        /// <summary>
        /// Gets or sets the combat text settings.
        /// </summary>
        [JsonProperty("combatText")]
        public CombatTextSettings CombatText { get; set; } = new CombatTextSettings();

        /// <summary>
        /// Gets or sets the version of the settings.
        /// </summary>
        [JsonProperty("version")]
        public int Version { get; set; } = CurrentVersion;

        /// <summary>
        /// Gets or sets the metadata of the settings.
        /// </summary>
        [JsonProperty("metadata")]
        public SettingsMetadata Metadata { get; set; } = new SettingsMetadata();
    }

    public class SettingsMetadata
    {
        public static readonly int CurrentMetadataVersion = 1;

        /// <summary>
        /// Gets or sets the version of the metadata.
        /// </summary>
        [JsonProperty("version")]
        public int Version { get; set; } = CurrentMetadataVersion;
    }
}

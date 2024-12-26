using Terraria;
using Terraria.GameContent.Drawing;
using Terraria.GameContent.NetModules;
using Terraria.Localization;
using Terraria.Net;
using static Terraria.Map.PingMapLayer;

namespace MapPingParticle.Extensions
{
    /// <summary>
    /// Provides extension methods to the <see cref="Ping"/> class.
    /// </summary>
    public static class PingExtensions
    {
        /// <summary>
        /// Show &lt;<paramref name="particleType"/>&gt; particles at <see cref="Ping.Position"/>.
        /// </summary>
        /// <param name="ping">The ping.</param>
        /// <param name="particleType">The particle type to show.</param>
        public static void ShowParticles(this Ping ping, ParticleOrchestraType particleType)
        {
            // Convert to pixel position
            var position = ping.Position * 16;

            var settings = new ParticleOrchestraSettings()
            {
                // 255 is the server player's index
                // We don't track ping creators, for now
                IndexOfPlayerWhoInvokedThis = 255,

                PositionInWorld = position
            };

            // Create the packet
            var packet = NetParticlesModule.Serialize(
                particleType,
                settings);

            // Broadcast it
            NetManager.Instance.Broadcast(packet);
        }

        /// <summary>
        /// Show <paramref name="text"/> as <see cref="CombatText"/> at <see cref="Ping.Position"/>.
        /// </summary>
        /// <param name="ping">The ping.</param>
        /// <param name="text">The text to show.</param>
        /// <param name="color">The color of the text in ARGB format.</param>
        public static void ShowCombatText(this Ping ping, NetworkText text, uint color)
        {
            // Convert the specified color into ABGR format
            // SendData internally uses Color for serialization
            // Color takes in packedValues in the ABGR format
            var abgrColor =
                (color & 0xFF00FF00)
              | ((color & 0x00FF0000) >> 16)
              | ((color & 0x000000FF) << 16);

            // Convert to pixel position
            var position = ping.Position * 16;

            // Broadcast combat text
            NetMessage.SendData(
                msgType: (int)PacketTypes.CreateCombatTextExtended,
                text: text,
                number: (int)abgrColor,
                number2: position.X,
                number3: position.Y);
        }
    }
}

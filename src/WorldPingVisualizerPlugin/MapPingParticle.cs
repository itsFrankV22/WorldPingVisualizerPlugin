using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Terraria;
using Terraria.GameContent.NetModules;
using Terraria.Localization;
using Terraria.Map;
using Terraria.Net;
using TerrariaApi.Server;
using TShockAPI.Hooks;
using MapPingParticle.Configuration;
using MapPingParticle.Extensions;

namespace MapPingParticle
{
    [ApiVersion(2, 1)]
    public class MapPingParticle : TerrariaPlugin
    {
        #region Plugin Information

        /// <inheritdoc />
        public override string Name => typeof(MapPingParticle).Assembly.GetCustomAttribute<AssemblyTitleAttribute>().Title;

        /// <inheritdoc />
        public override string Description => typeof(MapPingParticle).Assembly.GetCustomAttribute<AssemblyDescriptionAttribute>().Description;

        /// <inheritdoc />
        public override Version Version => typeof(MapPingParticle).Assembly.GetName().Version;

        /// <inheritdoc />
        public override string Author => typeof(MapPingParticle).Assembly.GetCustomAttribute<AssemblyCompanyAttribute>().Company;

        #endregion

        public static MapPingParticle Instance { get; private set; }

        /// <summary>
        /// Gets the object that represents this plugin's configuration manager.
        /// </summary>
        private ConfigurationManager _configManager;

        /// <inheritdoc cref="ConfigurationManager.VisualizerConfigFile"/>
        public VisualizerSettings VisualizerSettings
        {
            get => _configManager.VisualizerSettings;
            set => _configManager.VisualizerSettings = value;
        }

        #region Last- Times

        /// <summary>
        /// Gets a <see cref="DateTime"/> indicating the last time ping expiration was checked.
        /// </summary>
        public DateTime LastExpiredCheckTime { get; private set; }

        /// <summary>
        /// Gets a <see cref="DateTime"/> indicating the last time particles were broadcasted at pings.
        /// </summary>
        public DateTime LastParticlesTime { get; private set; }

        /// <summary>
        /// Gets a <see cref="DateTime"/> indicating the last time CombatText was broadcasted at pings.
        /// </summary>
        public DateTime LastCombatTextTime { get; private set; }

        #endregion

        /// <summary>
        /// Gets a list of active pings.
        /// </summary>
        public List<PingMapLayer.Ping> Pings { get; } = new List<PingMapLayer.Ping>();

        public MapPingParticle(Main game) : base(game)
        {
            Instance = this;
        }

        /// <inheritdoc />
        public override void Initialize()
        {
            _configManager = new ConfigurationManager();
            _configManager.Load();

            GeneralHooks.ReloadEvent += ConfigReload;

            ServerApi.Hooks.NetGetData.Register(this, OnGetData);
            ServerApi.Hooks.GamePostUpdate.Register(this, OnGamePostUpdate);
        }

        /// <inheritdoc />
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ServerApi.Hooks.NetGetData.Deregister(this, OnGetData);
                ServerApi.Hooks.GamePostUpdate.Deregister(this, OnGamePostUpdate);
            }

            base.Dispose(disposing);
        }

        #region Hooks

        private void OnGetData(GetDataEventArgs e)
        {
            using (var stream = new MemoryStream(e.Msg.readBuffer, e.Index, e.Length))
            {
                if (e.MsgID == PacketTypes.LoadNetModule)
                {
                    using (var reader = new BinaryReader(stream))
                    {
                        var id = reader.ReadUInt16();
                        var module = NetManager.Instance._modules[id];
                        if (module.GetType() == typeof(NetPingModule))
                        {
                            var position = reader.ReadVector2();
                            var ping = new PingMapLayer.Ping(position);
                            Pings.Add(ping);
                        }
                    }
                }
            }
        }

        private void OnGamePostUpdate(EventArgs e)
        {
            if (Pings.Count > 0)
            {
                var now = DateTime.Now;

                var timePassedExpiration = (now - LastExpiredCheckTime).TotalSeconds;
                if (timePassedExpiration > 1)
                {
                    // Reverse for loop to delete times
                    // Using a normal for loop to clear items shifts the indexes
                    // And will lead to Index Out of Range Exception
                    for (int i = Pings.Count; i-- > 0;)
                    {
                        var ping = Pings[i];
                        var pingLifetime = (now - ping.Time).TotalSeconds;
                        if (pingLifetime > PingMapLayer.PING_DURATION_IN_SECONDS)
                        {
                            Pings.RemoveAt(i);
                        }
                    }
                }

                var visualizerSettings = VisualizerSettings;

                var particleSettings = visualizerSettings.Particles;
                if (particleSettings.Enabled)
                {
                    var particlesInterval = particleSettings.ParticlesIntervalMilliseconds;
                    var timePassedParticles = (now - LastParticlesTime).TotalMilliseconds;
                    if (timePassedParticles > particlesInterval)
                    {
                        foreach (var ping in Pings)
                        {
                            var particleType = particleSettings.ParticleType;

                            ping.ShowParticles(particleType);
                        }

                        LastParticlesTime = now;
                    }
                }

                var combatTextSettings = visualizerSettings.CombatText;
                if (combatTextSettings.Enabled)
                {
                    var combatTextInterval = combatTextSettings.CombatTextIntervalMilliseconds;
                    var timePassedCombatText = (now - LastCombatTextTime).TotalMilliseconds;
                    if (timePassedCombatText > combatTextInterval)
                    {
                        foreach (var ping in Pings)
                        {
                            var combatTextContents = combatTextSettings.CombatTextContents;
                            var networkText = NetworkText.FromLiteral(combatTextContents);
                            var argbColor = combatTextSettings.CombatTextColor;

                            ping.ShowCombatText(networkText, argbColor);
                        }

                        LastCombatTextTime = now;
                    }
                }
            }
        }

        #endregion

        #region TShock Hooks

        private void ConfigReload(ReloadEventArgs e)
        {
            _configManager.Reload();
        }

        #endregion
    }
}

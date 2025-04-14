namespace SL_Dev_Tools
{
    using Exiled.API.Enums;
    using Exiled.API.Features;
    using Exiled.API.Features.Core.UserSettings;
    using System;
    using SL_Dev_Tools.Enums;
    
    public class MainPlugin : Plugin<Config, Translations>
    {
        /// <summary>
        /// Gets or sets the <see cref="MainPlugin"/> singleton.
        /// </summary>
        public static MainPlugin Singleton { get; set; }

        /// <summary>
        /// Gets the <see cref="Config"/> singleton.
        /// </summary>
        public static Config Configs => Singleton?.Config;

        /// <summary>
        /// Gets the <see cref="Translations"/> singleton.
        /// </summary>
        public static Translations Translations => Singleton?.Translation;

        /// <inheritdoc/>
        public override string Name => "DevTools";

        /// <inheritdoc/>
        public override string Author => "ketamine0389, Grogert Gaming";

        /// <inheritdoc/>
        public override PluginPriority Priority => PluginPriority.Low;

        /// <inheritdoc/>
        public override Version Version => new(1, 0, 0);

        /// <inheritdoc/>
        public override Version RequiredExiledVersion => new(9, 5, 1);

        public static MainPlugin Instance;
        public static EventHandlers Handlers;

        public override void OnEnabled()
        {
            Instance = this;
            Handlers = new();

            // make this better later, i feel lazy rn - JFK 04/11/2025 @ 11:04 EST
            if (Config.EnabledModules.TryGetValue(ModuleType.Positions, out ModuleType value))
                SettingBase.Register(new SettingBase[]
                {
                    new HeaderSetting("Dev Tools"),
                    new KeybindSetting(Config.PositionsKeybindId, "Log Positions", default, hintDescription: "Logs details about position to client and server console."),
                });

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Instance = null;
            Handlers = null;

            base.OnDisabled();
        }
    }
}

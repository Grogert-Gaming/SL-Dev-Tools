// EXILED Project Template
// Version 2
// https://github.com/ketamine0389


namespace SL_Dev_Tools
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using Exiled.API.Interfaces;
    using SL_Dev_Tools.Enums;

    public class Config : IConfig
    {
        [Description("Whether the plugin is enabled or disabled.")]
        public bool IsEnabled { get; set; } = true;

        [Description("Which modules are enabled.")]
        public HashSet<ModuleType> EnabledModules { get; set; } = new()
        {
            ModuleType.Positions
        };

        [Description("UID of the positions setting.")]
        public int PositionsKeybindId { get; set; } = 200;

        [Description("Whether the debug mode is enabled or disabled.")]
        public bool Debug { get; set; } = true;
    }
}

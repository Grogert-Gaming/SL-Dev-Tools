namespace SL_Dev_Tools
{
    using Exiled.API.Features;
    using UserSettings.ServerSpecific;
    using SL_Dev_Tools.Modules;

    public class EventHandlers
    {
        public EventHandlers()
        {
            RegisterEvents();
        }

        ~EventHandlers()
        {
            UnregisterEvents();
        }

        public void RegisterEvents()
        {
            ServerSpecificSettingsSync.ServerOnSettingValueReceived += OnSettingValueReceived;
        }

        public void UnregisterEvents()
        {
            ServerSpecificSettingsSync.ServerOnSettingValueReceived -= OnSettingValueReceived;
        }

        public void OnSettingValueReceived(ReferenceHub hub, ServerSpecificSettingBase settingBase)
        {
            if(!Player.TryGet(hub, out Player plr)) return;
            if (!(settingBase is SSKeybindSetting keybindSetting && keybindSetting.SyncIsPressed)) return;

            switch (keybindSetting.SettingId)
            {
                case 200:
                    Positions.GetPos(plr);
                    break;
            }
        }
    }
}

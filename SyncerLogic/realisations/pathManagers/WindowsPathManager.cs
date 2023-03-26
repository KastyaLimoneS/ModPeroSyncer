using SyncerLogic.abstractions;

namespace SyncerLogic.realisations.pathManagers;

internal class WindowsPathManager: AbstractPathManager
{
    public override string ModsPath => "C:/Users/"+ Environment.UserName +"/AppData/Roaming/.minecraft/mods/";
    public override string CachePath => "C:/Users/"+ Environment.UserName +"/AppData/Roaming/.minecraft/ModSync/Cache/";
    public override string SettingsPath => "C:/Users/"+ Environment.UserName +"/AppData/Roaming/.minecraft/ModSync/Settings/";
}

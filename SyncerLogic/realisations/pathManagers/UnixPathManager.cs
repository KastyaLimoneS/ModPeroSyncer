using SyncerLogic.abstractions;

namespace SyncerLogic.realisations.pathManagers;

internal class UnixPathManager: AbstractPathManager
{
    public override string ModsPath => "/home/" + Environment.UserName + "/.minecraft/mods/";
    public override string CachePath => "/home/" + Environment.UserName + "/.minecraft/ModSync/Cache/";
    public override string SettingsPath => "/home/" + Environment.UserName + "/.minecraft/ModSync/Settings/";
}

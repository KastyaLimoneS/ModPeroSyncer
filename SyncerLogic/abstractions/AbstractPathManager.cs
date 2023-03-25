using SyncerLogic.realisations.pathManagers;

namespace SyncerLogic.abstractions;

internal abstract class AbstractPathManager
{
    public static AbstractPathManager Instance {get; private set;}
    public abstract String CachePath{get;}
    public abstract String ModsPath{get;}
    public abstract String SettingsPath{get;}
    public static void SelectPlatform(String platform)
    {
        if (platform == "custom")
        {
            Instance = new CustomPathManager();
            return;
        }
        if (platform == "Unix")
        {
            Instance = new UnixPathManager();
            return;
        }
        throw new NotImplementedException();
    }
}

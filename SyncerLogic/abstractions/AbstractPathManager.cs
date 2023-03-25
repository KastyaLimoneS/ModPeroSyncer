namespace SyncerLogic.abstractions;

internal abstract class AbstractPathManager
{
    public static AbstractPathManager Instance {get; private set;}
    public abstract String CachePath{get;}
    public abstract String ModsPath{get;}
    public abstract String SettingsPath{get;}
    public static void SelectPlatform(String platform)
    {
        throw new NotImplementedException();
    }
}

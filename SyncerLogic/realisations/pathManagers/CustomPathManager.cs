using SyncerLogic.abstractions;
using SyncerLogic.main;

namespace SyncerLogic.realisations.pathManagers;

internal class CustomPathManager : AbstractPathManager
{
    public override String ModsPath => PlaceholderSettings.ModsPath;
    public override String CachePath => PlaceholderSettings.CachePath;
    public override String SettingsPath => PlaceholderSettings.SettingsPath;
}

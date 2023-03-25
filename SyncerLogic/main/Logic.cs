using SyncerLogic.abstractions;
using SyncerLogic.dto;

namespace SyncerLogic.main;

public class Logic
{
    public Logic()
    {
        PackManager.Init();
    }

    public IEnumerable<int> UpdateMods(String packName, String storagePlatform)
    {
        var pathManager = AbstractPathManager.Instance;

        var adress = PackManager.GetRepoAdress(packName);
        if (adress == null) {/*do something bad*/}

        var repo = RepoFactory.CreateRepo(adress, storagePlatform);
        var cache = RepoFactory.CreateRepo(pathManager.CachePath, "local");
        var mods = RepoFactory.CreateRepo(pathManager.ModsPath, "local");
        yield return 0;

        var toUpdate = RepoMatchingResult.CompareRepos(repo, mods, RepoMatchingResult.CompareMode.BOTH);
        var toDownload = RepoMatchingResult.CompareRepos(repo, cache, RepoMatchingResult.CompareMode.LOADING_ONLY);
        yield return 1;

        repo.UpdateTo(pathManager.CachePath, toDownload);
        yield return 2;

        cache.UpdateTo(pathManager.ModsPath, toUpdate);
        yield return 3;
    }

    public void AddPack(String name, String adress)
    {
        PackManager.CreatePack(name, adress);
    }

    public String[] GetPackNames() => PackManager.GetPackNames();
}

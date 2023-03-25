using SyncerLogic.abstractions;
using SyncerLogic.yandexStuff;
using SyncerLogic.dto;

namespace SyncerLogic.main;

public class Logic
{
    public Logic(String platform)
    {
        AbstractPathManager.SelectPlatform(platform);
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

    public void test1()
    {
        var a = RepoFactory.CreateRepo("/home/kastya/.minecraft/mods/", "local");
        Console.WriteLine(a.Files.Length);
        var b = RepoFactory.CreateRepo("/home/kastya/.minecraft/testMods/", "local");
        Console.WriteLine(b.Files.Length);
        a.UpdateTo("/home/kastya/.minecraft/testMods/", RepoMatchingResult.CompareRepos(a, b, RepoMatchingResult.CompareMode.LOADING_ONLY));
        Console.WriteLine(b.Files.Length);
    }

    public void test2()
    {
        Console.WriteLine("=============test2=============");
        foreach (var file in LilYandexAPI.GetFilesInFolder("https://disk.yandex.ru/d/WlkuoRC8dYU-dg"))
        {
            Console.WriteLine(file.Name);
            file.DownloadTo(AbstractPathManager.Instance.ModsPath);
        }
        Console.WriteLine("===============================");
    }

    public String[] GetPackNames() => PackManager.GetPackNames();
}

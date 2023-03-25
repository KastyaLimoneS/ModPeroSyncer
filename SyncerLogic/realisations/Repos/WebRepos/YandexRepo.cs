using SyncerLogic.abstractions;
using SyncerLogic.yandexStuff;
using SyncerLogic.dto;

namespace SyncerLogic.realisations.Repos.WebRepos;

internal class YandexRepo: AbstractRepo
{

    LilYandexAPI.YandexFile[] _files;

    public YandexRepo(String adress): base(adress)
    {}
    public override string[] Files => LoadFiles();
    public override void UpdateTo(string destPath_, RepoMatchingResult stuffToUpdate)
    {
        foreach (var file in stuffToUpdate.ToDelete)
            File.Delete(destPath_+file);
        foreach (var __fl in _files.Where(fl => stuffToUpdate.ToLoad.Contains(fl.Name)))
            __fl.DownloadTo(destPath_);
    }
    private string[] LoadFiles()
    {
        _files = LilYandexAPI.GetFilesInFolder(_adress).ToArray();
        return _files.Select(fl => fl.Name).ToArray();
    }
}

using SyncerLogic.abstractions;
using SyncerLogic.dto;

namespace SyncerLogic.realisations.Repos;

internal class LocalRepo: AbstractRepo
{
    public override String[] Files => FindFiles();

    public LocalRepo(String adress): base(adress)
    {}

    public override void UpdateTo(string destPath_, RepoMatchingResult stuffToUpdate)
    {
        foreach (var file in stuffToUpdate.ToDelete)
            File.Delete(destPath_+file);
        foreach (var file in stuffToUpdate.ToLoad)
            File.Copy(_adress+file, destPath_+file);
    }
    private String[] FindFiles() 
    {
        var result = Directory.EnumerateFiles(_adress).Select(pth => pth.Split("/").Last()) .ToArray();
        return result;
    }
}

using SyncerLogic.dto;

namespace SyncerLogic.abstractions;

internal abstract class AbstractRepo
{
    protected readonly String _adress;

    public AbstractRepo(String adress)
    {
        _adress = adress;
    }
    public abstract String[] Files {get;}
    public abstract void UpdateTo(String destPath_, RepoMatchingResult stuffToUpdate);
}

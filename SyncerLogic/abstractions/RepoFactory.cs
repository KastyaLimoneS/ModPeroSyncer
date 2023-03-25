using SyncerLogic.realisations.Repos;

namespace SyncerLogic.abstractions;

internal static class RepoFactory
{
    public static AbstractRepo CreateRepo(String adress, String storage)
    {
        if (storage == "local")
            return new LocalRepo(adress);
        throw new NotImplementedException();
    }
}

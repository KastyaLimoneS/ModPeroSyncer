using SyncerLogic.realisations.Repos;
using SyncerLogic.realisations.Repos.WebRepos;

namespace SyncerLogic.abstractions;

internal static class RepoFactory
{
    public static AbstractRepo CreateRepo(String adress, String storage)
    {
        if (storage == "local")
            return new LocalRepo(adress);
        if (storage == "yandex")
            return new YandexRepo(adress);
        throw new NotImplementedException();
    }
}

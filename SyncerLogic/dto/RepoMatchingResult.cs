using SyncerLogic.abstractions;

namespace SyncerLogic.dto;

internal record RepoMatchingResult(String[] ToDelete, String[] ToLoad)
{
    public static RepoMatchingResult CompareRepos(AbstractRepo pattern, AbstractRepo given, CompareMode mode)
    {
        var toAdd = new List<String>();
        var toDelete = new List<String>();
        if (mode == CompareMode.LOADING_ONLY || mode == CompareMode.BOTH)
            foreach(var file in pattern.Files)
                if (!given.Files.Contains(file)) toAdd.Add(file);
        if (mode == CompareMode.DELETION_ONLY || mode == CompareMode.BOTH)
            foreach(var file in given.Files)
                if (!pattern.Files.Contains(file)) toDelete.Add(file);
        return new RepoMatchingResult(toDelete.ToArray(), toAdd.ToArray());
    }

    public enum CompareMode
    {
        DELETION_ONLY,
        LOADING_ONLY,
        BOTH
    }
}

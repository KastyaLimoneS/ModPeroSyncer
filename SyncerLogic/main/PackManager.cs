using System.Text.Json.Nodes;
using System.IO;
using SyncerLogic.abstractions;

namespace SyncerLogic.main;

internal static class PackManager
{
    private static JsonNode _root;
    private static String _path;

    public static void Init()
    {
        _path = AbstractPathManager.Instance.SettingsPath+"packs.json";
        var file = File.OpenText(_path);
        _root = JsonNode.Parse(file.ReadToEnd());
    }
    public static String? GetRepoAdress(String packName) => _root[packName].GetValue<String>();
    public static void CreatePack(String name, String adress)
    {
        _root[name] = adress;
        _root["packs"] = _root["packs"].GetValue<String>()+"|"+name;
        var newJson = _root.ToJsonString();
        using (StreamWriter writer = new StreamWriter(_path))
            writer.Write(newJson);
    }

    public static String[] GetPackNames() => _root["packs"].GetValue<String>().Split("|");
}

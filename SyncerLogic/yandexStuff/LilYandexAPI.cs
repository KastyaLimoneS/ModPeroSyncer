using System.Text.Json;
using System.Net;
using SyncerLogic.utils;

namespace SyncerLogic.yandexStuff;

internal static class LilYandexAPI
{
    public static JsonDocument GetPublicResourceMatadata(String link)
    {
        var objStream = WebRequest.Create("https://cloud-api.yandex.net/v1/disk/public/resources?public_key=" + link).GetResponse().GetResponseStream();
        var objReader = new LinqStreamReader(objStream);
        return JsonDocument.Parse(objReader.Aggregate((a, b) => a+'\n'+b));
    }

    public static IEnumerable<YandexFile> GetFilesInFolder(String link)
    {
        var doc = GetPublicResourceMatadata(link);
        var enumerable = doc.RootElement.GetProperty("_embedded").GetProperty("items").EnumerateArray();
        foreach (var item in enumerable)
            yield return new YandexFile(item.GetProperty("name").GetString(), item.GetProperty("file").GetString());
    }

    public record YandexFile(String Name, String DownloadLink)
    {
        public void DownloadTo(String path)
        {
            var client = new WebClient();
            client.DownloadFile(DownloadLink, path+Name);
        }
    }
}

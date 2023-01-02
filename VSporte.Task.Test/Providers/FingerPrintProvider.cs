using System.IO;
using Newtonsoft.Json;
using VSporte.Task.Solution.Models;

namespace VSporte.Task.Test.Providers;

public class FingerprintProvider
{
    public Fingerprint Get() => new()
    {
        Clubs = ReadFromFile<ClubItem>("clubs"),
        Players = ReadFromFile<PlayerItem>("players"),
        PlayerClubs = ReadFromFile<PlayerClubItem>("player_clubs"),
    };

    private static T[] ReadFromFile<T>(string name)
    {
        var text = File.ReadAllText($"Source/{name}.json");
        return JsonConvert.DeserializeObject<T[]>(text);
    }
}
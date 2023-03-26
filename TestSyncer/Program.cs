using SyncerLogic.main;

Console.WriteLine(Environment.OSVersion.Platform.ToString());
var logic = new Logic(Environment.OSVersion.Platform.ToString());

int a = 0;

while (true) {
    String[] command = Console.ReadLine().Split(" ");
    if (command[0] == "list") {
        Console.WriteLine("Your Packs:");
        foreach(var pack in logic.GetPackNames()) Console.WriteLine("|-"+pack);
    }
    if (command[0] == "add") {
        logic.AddPack(command[1], command[2]);
        Console.WriteLine($"Pack \"{command[1]}\" was added with repo \"{command[2]}\"");
    }
    if (command[0] == "update") {
        Console.WriteLine();
        foreach(var stage in logic.UpdateMods(command[1], command[2]))
            {Console.Write("###"); a+=stage;}
        Console.WriteLine("\n Your mods are updated");
    }
    if (command[0] == "exit")
        break;
}
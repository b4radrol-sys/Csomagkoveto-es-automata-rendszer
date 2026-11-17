using System.IO;

if (!File.Exists("csomagok.csv"))
{
    File.WriteAllText("csomagok.csv", "");
}
if (!File.Exists("automatak.csv"))
{
    File.WriteAllText("automatak.csv", "");
}

Console.WriteLine("==============================================");
Console.WriteLine($"Csomagautomata rendszer | {DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss")}");
Console.WriteLine("==============================================");

Console.WriteLine("1. Ügyfél műveletek");
Console.WriteLine("2. Futár műveletek");
int bejovo = int.Parse(Console.ReadLine());
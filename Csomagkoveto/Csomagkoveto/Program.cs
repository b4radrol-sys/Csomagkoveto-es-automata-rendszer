using System.IO;

if (!File.Exists("csomagok.csv"))
{
    File.WriteAllText("csomagok.csv", "");
}
if (!File.Exists("automatak.csv"))
{
    File.WriteAllText("automatak.csv", "");
}

string muveletvalasztas()
{
    string x = Console.ReadLine();
    while (x != "1" && x != "2" && x != "3" )
    {
        Console.WriteLine("Helytelen bemenet! Helyes bemenetek: Ügyfél műveletek -> 1 ; Futár műveletek -> 2 ; Mentés és kilépés -> 3");
        x = Console.ReadLine();
    }
    return x;
}

void kilepes()
{
    Environment.Exit(0);
}


Console.WriteLine("==============================================");
Console.WriteLine($"Csomagautomata rendszer | {DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss")}");
Console.WriteLine("==============================================");

Console.WriteLine("1. Ügyfél műveletek");
Console.WriteLine("2. Futár műveletek");
Console.WriteLine("3. Kilépés");



while (true)
{
    Console.WriteLine("Válasszon a műveletek közül egy szám beírásával: ");
    
    string valasztas = muveletvalasztas();
    if (valasztas == "0")
    {
        kilepes();
    }
    
    
}
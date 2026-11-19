using System.IO;

if (!File.Exists("csomagok.csv"))
{
    File.WriteAllText("csomagok.csv", "");
}

bool checkNev(string nev)
{

    foreach (char karakter in nev)
    {

        if (char.IsDigit(karakter))
        {
            return false;
        }

    }

    return true;
}

bool checkMeret(string meret)
{
    meret = meret.ToLower();
    if (meret == "s" || meret == "m" || meret == "l")
    {
        return true;
    }

    return false;
}

string muveletValasztas()
{
    string x = Console.ReadLine();
    while (x != "1" && x != "2" && x != "0" )
    {
        Console.WriteLine("Helytelen bemenet! Helyes bemenetek: 0. Kilépés | 1. Ügyfél műveletek | 2. Futár műveletek");
        x = Console.ReadLine();
    }
    return x;
}

string ugyfelMuveletValasztas()
{
    Console.WriteLine("1. Új csomag feladása\n2. Csomag átvétele\n3. Csomagkövetés");
    string x = Console.ReadLine();
    while (x != "1" && x != "2" && x != "3")
    {
        Console.WriteLine("Helytelen bemenet! Helyes bemenetek: 1. Új csomag feladása | 2. Csomag átvétele | 3. Csomagkövetés");
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

while (true)
{
    Console.WriteLine("0. Kilépés");
    Console.WriteLine("1. Ügyfél műveletek");
    Console.WriteLine("2. Futár műveletek");
    Console.WriteLine("Válasszon a műveletek közül egy szám beírásával: ");
    
    string valasztas = muveletValasztas();
    if (valasztas == "0")
    {
        kilepes();
    }else if (valasztas == "1")
    {
        // ugyfelDolgok
        string muvelet = ugyfelMuveletValasztas();
        if (muvelet == "1")
        {
            Console.Write("Címzett neve: ");
            string cimzett = Console.ReadLine();
            while (checkNev(cimzett) == false)
            {
                Console.Write("Helytelen bemenet! Címzett neve: ");
                cimzett = Console.ReadLine();
            }

            Console.Write("Csomag mérete (S/M/L): ");
            string csomagMeret = Console.ReadLine();
            while (checkMeret(csomagMeret) == false)
            {
                Console.Write("Helytelen bemenet! Csomag mérete (S/M/L): ");
                csomagMeret = Console.ReadLine();
            }

            string feladasiIdo = DateTime.Now;
        }

    }
    
    
}
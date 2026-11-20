using System.IO;

if (!File.Exists("csomagok.csv"))
{
    File.WriteAllText("csomagok.csv", "");
}

List<Csomag> csomagok = new();

foreach (string sor in File.ReadLines("csomagok.csv"))
{
    if (string.IsNullOrWhiteSpace(sor)) continue;

    string[] mezok = sor.Split(';');
    if (mezok.Length != 6 || !DateTime.TryParse(mezok[4], out DateTime ido))
    {
        Console.WriteLine($"Hibás sor: {sor}");
        continue;
    }

    csomagok.Add(new Csomag(mezok[0], mezok[1], mezok[2], mezok[3], ido, mezok[5]));
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

    if (string.IsNullOrWhiteSpace(nev) || nev.Contains(';')) return false;

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

string ujCsomagAzonosito()
{
    string azonosito;
    do
    {
        char betu1 = (char)Random.Shared.Next('A', 'Z' + 1);
        char betu2 = (char)Random.Shared.Next('A', 'Z' + 1);
        int szam = Random.Shared.Next(0, 100);

        azonosito = $"{betu1}{betu2}-{szam:D2}";
    } while (csomagok.Any(c => c.CsomagAzonosito == azonosito));

    return azonosito;
}

string ujNyitokod()
{
    return Random.Shared.Next(0, 100000).ToString("D5");
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

            DateTime feladasiIdo = DateTime.Now;

            string csomagAzonosito = ujCsomagAzonosito();

            string nyitokod = ujNyitokod();

            Csomag uj = new(cimzett, csomagMeret.ToUpper(), "Feladva", nyitokod, feladasiIdo, csomagAzonosito);

            csomagok.Add(uj);

            File.AppendAllText("csomagok.csv", uj.ToCsvSor() + Environment.NewLine);

            Console.WriteLine($"{feladasiIdo} Csomag sikeresen feladva!");
            Console.WriteLine($"Követési szám: {uj.CsomagAzonosito}");
        }

    }   
    
    
}
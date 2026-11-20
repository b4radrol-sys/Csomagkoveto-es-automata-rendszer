public class Csomag
{
    public string Cimzett { get; }
    public string Meret { get; }
    public string Statusz { get; private set; }
    private string Nyitokod { get; }
    public DateTime FeladasIdo { get; }
    public string CsomagAzonosito { get; }

    public Csomag(string cimzett, string meret, string statusz, string nyitokod, DateTime feladasIdo, string csomagAzonosito)
    {
        Cimzett = cimzett;
        Meret = meret;
        Statusz = statusz;
        Nyitokod = nyitokod;
        FeladasIdo = feladasIdo;
        CsomagAzonosito = csomagAzonosito;
    }

    public bool NyitokodEllenorzes(string kod)
    {
        return Nyitokod == kod;
    }

    public void StatuszFrissit(string ujStatusz)
    {
        Statusz = ujStatusz;
    }

    // Egy sor a csv fájlba: cimzett;meret;statusz;nyitokod;feladasIdo;csomagAzonosito
    public string ToCsvSor()
    {
        string ido = FeladasIdo.ToString("yyyy-MM-dd HH:mm:ss");
        return $"{Cimzett};{Meret};{Statusz};{Nyitokod};{ido};{CsomagAzonosito}";
    }
}
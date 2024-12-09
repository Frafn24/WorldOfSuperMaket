using System.Linq;

namespace WorldOfSuperMaket.Readers;

public class Translate
{
    // Variable
    private string filename = @"C:\\Users\\frede\\RiderProjects\\WorldOfSuperMaket\\Data";

    // Singleton-instans
    public static Translate Instance { get; } = new Translate();
    // Dictionary der gemmer oversættelser
    private Dictionary<string, string> ActiveTranslations = new Dictionary<string, string>();

    // constructor som sikrer vi kun har denne ene instans
    private Translate() { }

    // Indlæser oversættelserne
    public void SetLanguage(string language)
    {
        // .Skip(1) skipper den første linje
        // .Select(ParseCsvLine) parser de forskellige parametre, så det er læsbart
        // .ToList() konverterer det til en liste
        var translations = File.ReadAllLines(getPlaceMent("Language.csv")).Skip(1).Select(ParseCsvLine).ToList();

        // Tømmer dictionary når vi skifter sprog, så der ikke sker fejl.
        ActiveTranslations.Clear();

        // tjekker hvilket sporg der ønskes, og vælger det i csv filen.
        foreach (var translation in translations)
        {
            if (language.ToLower() == "danish")
            {
                ActiveTranslations[translation.Key] = translation.Danish;
            }
            else if (language.ToLower() == "english")
            {
                ActiveTranslations[translation.Key] = translation.English;
            }
            else
            {
                throw new Exception("Language not supported. Either pick danish or english.");
            }
        }
        //lol
    }

    public string GetTranslation(string key)
    {
        // Tjekker om key'en findes i vores dictionary "ActiveTranslations"
        if (ActiveTranslations.ContainsKey(key))
        {
            return ActiveTranslations[key];
        }
        else
        {
            return $"Missing translation for {key}";
        }
    }

    // En metode der kan sikrer sig, at den rigtige sti bliver kaldt uanset
    // operativsystem. 
    // Måske vi skal gøre det på samme måde som de andre CSV-filer?
    public string getPlaceMent(string filename)
    {
        string update = "";
        string placement = Path.GetFullPath(filename);
        //string xmlFile = HostingEnvironment.MapPath("filename");
        if (placement.Contains(@"\\data\\net8.0\"))
        {
            update = placement.Replace(@"bin\Debug", "data");
        }
        else if (placement.Contains(@"bin\Debug\net8.0"))
        {
            update = placement.Replace(@"bin\Debug\net8.0", "data");
        }
        else if (placement.Contains(@"bin/Debug/net8.0"))
        {
            update = placement.Replace(@"bin/Debug/net8.0", "Data/Language.csv");
        }
        else { update = placement; }
        return update;
    }
    //string GetPlacement(string Filename) => Path.Combine(filename, Filename);

    // Deler filen op efter hvor der er et komma. 
    // Den gør det muligt for os at lave metoden "TranslationData" og
    // Constructoren "TranslationData".
    TranslationData ParseCsvLine(string line)
    {
        var parts = line.Split(',');
        return new TranslationData(parts[0], parts[1], parts[2]);
    }



    // Metode der instansierer vores variable, og laver en constructor. 
    public class TranslationData
    {
        public string Key { get; set; }
        public string Danish { get; set; }
        public string English { get; set; }

        public TranslationData(string key, string danish, string english)
        {
            Key = key;
            Danish = danish;
            English = english;
        }
    }
}

// Eksempel på implementering i koden:

/*
Hvis vi kigger på inventoryCommand har vi en Console.WriteLine
som printer "Vis varer i dit inventory." Hvis vi gerne vil have den
til, at kunne oversætte sig selv baseret på det valgte sprog, kan
vi skrive det på følgende måde:

Console.WriteLine(translator.GetTranslation("key: show_items_in_inv"), command);

I dette tilfælde behøver vi faktisk ikke skrive "command" til sidst, fordi der er
ikke noget, som brugeren selv kan have skrevet ind. Hvis vi kigger på en anden 
Console.WriteLine"Woopsie, jeg forstår ikke {command}"
ville command kunne hente kommandoen fra csv-filen

Grunden til vi kan gøre det er fordi, vi starter med at istantisere:

private Translate translator;
*/
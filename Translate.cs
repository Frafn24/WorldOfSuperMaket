namespace WorldOfSuperMaket;

internal class Translate
{
    // Variable
    private string filename = "/Users/frederikthygesen/Downloads";
    private Dictionary<string, string> ActiveTranslations = new Dictionary<string, string>();

    public void SetLanguage(string language)
    {
        var translations = File.ReadAllLines(GetPlacement("Translation.csv")).Skip(1).Select(ParseCsvLine).ToList();

        ActiveTranslations.Clear();
        // tjekker hvilket sporg der ønskes, og vælger det i csv filen.
        foreach (var translation in translations)
        {
            if (language.ToLower() == "danish")
            {
                ActiveTranslations[translation.Key] = translation.danish;
            }
            else if (language.ToLower() == "english")
            {
                ActiveTranslations[translation.Key] = translation.english;
            }
            else
            {
                throw new Exception("Language not supported. Either pick danish or english.");
            }
        }

        string GetTranslations(string key)
        {
            if (!ActiveTranslations.ContainsKey(key))
            {
                return ActiveTranslations[key];
            }
            else
            {
                return $"Missing translation for {key}";
            }
        }

        string GetPlacement(string Filename) => Path.Combine(filename, Filename);

        TranslationData ParseCsvLine(string line)
        {
            var parts = line.Split(',');
            return new TranslationData(parts[0], parts[1], parts[2]);
        }
    }

    public class TranslationData
    {
        public string Key { get; set; }
        public string danish { get; set; }
        public string english { get; set; }

        public TranslationData(string key, string danish, string english)
        {
            Key = key;
            danish = danish;
            english = english;
        }
    }
}
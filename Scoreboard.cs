namespace WorldOfSuperMaket;

internal class ScoreBoard
{
    
    private string filename = "/Users/frederikthygesen/Downloads";

    public void LoadScores()
    {
        List<Data> lines = File.ReadAllLines(GetPlacement("Scoreboard.csv")).Skip(1).Select(x => ParseCsvLine(x)).ToList();
        //string[] lines = File.ReadAllLines(FilePath);
        foreach (var line in lines)
        {
            Console.WriteLine($"Player: {line.Username}, Food Score: {line.FoodScore}, Environment Score: {line.EnvironmentScore}");
        }  
    }
      


    private Data ParseCsvLine(string csvLine)
    {
        string[] lines = csvLine.Split(';');
        string username = Convert.ToString(lines[0]);
        double foodScore = double.Parse(lines[1]);
        double environmentScore = double.Parse(lines[2]);

        return new Data(username, foodScore, environmentScore);
    }

    public string GetPlacement(string FilePath)
    {
        string placement = Path.GetFullPath(FilePath);
        var update = placement.Replace(@"bin\Debug\", "data");
        return update;
    }
}

public class Data
{
    public string Username { get; }
    public double FoodScore { get; }
    public double EnvironmentScore { get; }

    public Data(string username, double foodScore, double environmentScore)
    {
        Username = username;
        FoodScore = foodScore;
        EnvironmentScore = environmentScore;
    }
}
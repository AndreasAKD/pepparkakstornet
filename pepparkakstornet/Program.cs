
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Team
{
    public string Name { get; set; }
    public int Height1 { get; set; }
    public int DesignScore { get; set; }
    public int Hits { get; set; }
    public int Height2 { get; set; }
    public int Del1Score { get; set; }
    public int Del2Score { get; set; }
    public int TotalScore { get; set; }
}

class Program
{
    // Expects each line in the file to be:
    // TeamName;Height1;DesignScore;Hits;Height2
    // Example: Lag X;48;150;4;40
    static void Main(string[] args)
    {
        Console.WriteLine("PEPPARKAKSTORNET - RESULTATGENERATOR\n");
        string file = "scores.txt"; if (!File.Exists(file))
        {
            Console.WriteLine($"Filen '{file}' hittades inte. Skapa en textfil där varje rad är:\nTeamNamn;Höjd1;Designpoäng;Träffar;Höjd2\nExempel: Lag X;48;150;4;40");
            return;
        }

        var teams = new List<Team>();
        foreach (var line in File.ReadAllLines(file))
        {
            if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#")) continue;
            var parts = line.Split(',');
            if (parts.Length < 5)
            {
                //Console.WriteLine($"Felaktig rad: {line}");
                continue;
            }
            try
            {
                var team = new Team
                {
                    Name = parts[0].Trim(),
                    Height1 = int.Parse(parts[1]),
                    DesignScore = int.Parse(parts[2]),
                    Hits = int.Parse(parts[3]),
                    Height2 = int.Parse(parts[4])
                };
                // Del 1
                int heightScore = team.Height1;
                if (team.Height1 > 50) heightScore += 50;
                team.Del1Score = heightScore + team.DesignScore;
                // Del 2
                int duelScore = team.Hits * 20 + team.Height2;
                if (team.Height2 > 50) duelScore += 50;
                team.Del2Score = duelScore;
                team.TotalScore = team.Del1Score + team.Del2Score;
                teams.Add(team);
            }
            catch
            {
                Console.WriteLine($"Fel vid tolkning av rad: {line}");
            }
        }

        if (teams.Count == 0)
        {
            Console.WriteLine("Inga giltiga lag hittades i filen.");
            return;
        }

        Console.WriteLine("\nSlutresultat (sorterat på totalpoäng):");
        var sorted = teams.OrderByDescending(t => t.TotalScore).ToList();
        var winner = sorted.First();

        // Print winner with color and ASCII banner at the top
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("***************************************");
        Console.WriteLine($"***  VINNARE: {winner.Name} med {winner.TotalScore} poäng!  ***");
        Console.WriteLine("***************************************");
        Console.ResetColor();

        Console.WriteLine("\nSlutresultat (sorterat på totalpoäng):");

        foreach (var t in sorted)
        {
            // Del 1 breakdown
            int heightBonus1 = t.Height1 > 50 ? 50 : 0;
            Console.WriteLine($"\n{t.Name}:");
            Console.WriteLine($"  Del 1 (Byggmoment):");
            Console.WriteLine($"    Höjd: {t.Height1} cm = {t.Height1}p{(heightBonus1 > 0 ? $" + {heightBonus1}p bonus" : "")}");
            Console.WriteLine($"    Designpoäng: {t.DesignScore}p");
            Console.WriteLine($"    Summa Del 1: {t.Del1Score}p");

            // Del 2 breakdown
            int heightBonus2 = t.Height2 > 50 ? 50 : 0;
            int hitPoints = t.Hits * 20;
            Console.WriteLine($"  Del 2 (Duellmoment):");
            Console.WriteLine($"    Träffar: {t.Hits} st = {hitPoints}p");
            Console.WriteLine($"    Kvarvarande höjd: {t.Height2} cm = {t.Height2}p{(heightBonus2 > 0 ? $" + {heightBonus2}p bonus" : "")}");
            Console.WriteLine($"    Summa Del 2: {t.Del2Score}p");

            // Total
            Console.WriteLine($"  Totalt: {t.TotalScore}p");

        }

        // Print winner with color and ASCII banner at the top
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("***************************************");
        Console.WriteLine($"***  VINNARE: {winner.Name} med {winner.TotalScore} poäng!  ***");
        Console.WriteLine("***************************************");
        Console.ResetColor();

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Ej sorterad Lista efter vinnare utan bara lag 1 ...8");
        foreach (var t in teams)
        {
            Console.WriteLine($"{t.Name}: Del 1 = {t.Del1Score}p, Del 2 = {t.Del2Score}p, Totalt = {t.TotalScore}p");
        }
    }
}

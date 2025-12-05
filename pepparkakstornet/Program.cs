using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

class Team
{
    public string Name { get; set; } = string.Empty;
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

    static void Main(string[] args)
    {
        int bonusThreshold = 50; // Minimum height for bonus
        int bonusValue = 50;     // Bonus points

        Console.WriteLine("KLANKRIGET - RESULTATGENERATOR\n");
        string file = "scores.txt";
        if (!File.Exists(file))
        {
            Console.WriteLine($"Filen '{file}' hittades inte. Skapa en textfil där varje rad är:\nTeamNamn,Höjd1,Designpoäng,Träffar,Höjd2\nExempel: Lag X,48,150,4,40");
            return;
        }

        var teams = new List<Team>();
        foreach (var rawLine in File.ReadLines(file))
        {
            var line = rawLine.Trim();
            if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#", StringComparison.Ordinal)) continue;

            var parts = line.Split(',', StringSplitOptions.TrimEntries);
            if (parts.Length < 5)
            {
                continue;
            }

            if (!int.TryParse(parts[1], out var height1)
                || !int.TryParse(parts[2], out var designScore)
                || !int.TryParse(parts[3], out var hits)
                || !int.TryParse(parts[4], out var height2))
            {
                continue;
            }

            var team = new Team
            {
                Name = parts[0].Trim(),
                Height1 = height1,  
                DesignScore = designScore,
                Hits = hits,
                Height2 = height2
            };

            // Del 1
            int heightScore = team.Height1;
            if (team.Height1 > bonusThreshold) heightScore += bonusValue;
            team.Del1Score = heightScore + team.DesignScore;

            // Del 2
            int duelScore = team.Hits * 20 + team.Height2;
            if (team.Height2 > bonusThreshold) duelScore += bonusValue;
            team.Del2Score = duelScore;

            team.TotalScore = team.Del1Score + team.Del2Score;
            teams.Add(team);
        }

        if (teams.Count == 0)
        {
            Console.WriteLine("Inga giltiga lag hittades i filen.");
            return;
        }

        var sorted = teams.OrderByDescending(t => t.TotalScore).ToList();
        var winner = sorted.First();

        // Fun suspense animation before showing the winner
        Console.WriteLine();
        Console.Write("Vinnaren räknas ut");
        for (int i = 0; i < 20; i++)
        {
            Console.Write(".");
            Thread.Sleep(400);
        }

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();

        while (!Console.KeyAvailable)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("***************************************");
            Console.WriteLine($"***  VINNARE: {winner.Name} med {winner.TotalScore} poäng!  ***");
            Console.WriteLine("***************************************");
            Console.ResetColor();
            Thread.Sleep(250);
            Console.SetCursorPosition(0, Console.CursorTop - 3);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("***************************************");
            Console.WriteLine($"***  VINNARE: {winner.Name} med {winner.TotalScore} poäng!  ***");
            Console.WriteLine("***************************************");
            Console.ResetColor();
            Thread.Sleep(250);
            Console.SetCursorPosition(0, Console.CursorTop - 3);
        }
        Console.ReadKey(true); // Clear the key press
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("***************************************");
        Console.WriteLine($"***  VINNARE: {winner.Name} med {winner.TotalScore} poäng!  ***");
        Console.WriteLine("***************************************");
        Console.ResetColor();

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("\nSlutresultat (sorterat på totalpoäng):");
        foreach (var t in sorted)
        {
            int heightBonus1 = t.Height1 > bonusThreshold ? bonusValue : 0;
            Console.WriteLine($"\n{t.Name}:");
            Console.WriteLine($"  Del 1 (Byggmoment):");
            Console.WriteLine($"    Höjd: {t.Height1} cm = {t.Height1}p{(heightBonus1 > 0 ? $" + {heightBonus1}p bonus" : "")}");
            Console.WriteLine($"    Designpoäng: {t.DesignScore}p");
            Console.WriteLine($"    Summa Del 1: {t.Del1Score}p");

            int heightBonus2 = t.Height2 > bonusThreshold ? bonusValue : 0;
            int hitPoints = t.Hits * 20;
            Console.WriteLine($"  Del 2 (Duellmoment):");
            Console.WriteLine($"    Träffar: {t.Hits} st = {hitPoints}p");
            Console.WriteLine($"    Kvarvarande höjd: {t.Height2} cm = {t.Height2}p{(heightBonus2 > 0 ? $" + {heightBonus2}p bonus" : "")}");
            Console.WriteLine($"    Summa Del 2: {t.Del2Score}p");

            Console.WriteLine($"  Totalt: {t.TotalScore}p");
        }
    }
}
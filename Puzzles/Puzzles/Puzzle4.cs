namespace AoC2020.Puzzles;

public class Puzzle4 : PuzzleBase<IEnumerable<IEnumerable<string>>, int, int>
{
    protected override string Filename => "Input/puzzle-input-03.txt";
    protected override string PuzzleTitle => "--- Day 4: Passport Processing ---";

    private static bool ValidPassport(IEnumerable<string> data, int part = 1)
    {
        var passportData = new Dictionary<string, string>();
        var requiredData = new[] { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };
        
        foreach (var line in data)
        {
            if (string.IsNullOrEmpty(line)) continue;
            
            var fields = line.Split(' ');
            foreach (var field in fields)
            {
                var kvpair = field.Split(':');
                passportData[kvpair[0]] = kvpair[1];
            }
        }

        var keysPresent = requiredData.All(key => passportData.ContainsKey(key)); 
        
        if (part == 1)
        {
            return keysPresent;
        }
        
        return keysPresent && ValidPassportValues(passportData);
    }

    private static bool IsHex(string s)
    {
        return s.All(IsHexChar);
    }

    private static bool IsHexChar(char c)
    {
        return (c >= '0' && c <= '9') || (c >= 'a' && c <= 'f');
    }
    
    private static bool ValidPassportValues(Dictionary<string, string> passportData)
    {
        var byr = int.Parse(passportData["byr"]);
        if (!(passportData["byr"].Length == 4 && byr >= 1920 && byr <= 2002)) return false;
        
        var iyr = int.Parse(passportData["iyr"]);
        if (!(passportData["iyr"].Length == 4 && iyr >= 2010 && iyr <= 2020)) return false;
        
        var eyr = int.Parse(passportData["eyr"]);
        if (!(passportData["eyr"].Length == 4 && eyr >= 2020 && eyr <= 2030)) return false;

        var hgt = int.Parse(passportData["hgt"][..^2]);
        var hgtUnit = passportData["hgt"][^2..];
        if (hgtUnit != "cm" && hgtUnit != "in") return false;
        if (hgtUnit == "cm" && !(hgt >= 150 && hgt <= 193)) return false;
        if (hgtUnit == "in" && !(hgt >= 59 && hgt <= 76)) return false;

        var hcl = passportData["hcl"];
        if (hcl.Length != 7) return false;
        if (hcl[0] != '#') return false;
        if (!IsHex(hcl[1..])) return false;

        var colors = new[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
        if (!colors.Contains(passportData["ecl"])) return false;
        
        var pid = passportData["pid"];
        return pid.Length == 9 && int.TryParse(pid, out _);
    }
    
    public override int PartOne(IEnumerable<IEnumerable<string>> input)
    {
        return input.Count(data => ValidPassport(data));
    }
    
    public override int PartTwo(IEnumerable<IEnumerable<string>> input)
    {
        return input.Count(data => ValidPassport(data, part:2));
    }
    
    public override IEnumerable<IEnumerable<string>> Preprocess(IPuzzleInput input, int part = 1)
    {
        var index = 0;
        return input.GetAllLines().
            GroupBy(x => !string.IsNullOrEmpty(x) ? index : index++);
    }
}
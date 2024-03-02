using System.Text.RegularExpressions;
using CitationParser.Data.Model;

namespace CitationParser.Services.Parser;

static public class DepositedManuscriptParser
{
    public static List<University> GetUniversity(string citation)
    {
        String universityString = "";
        universityString = citation.Split(';')[1].Split(". -")[0];

        if (universityString.Contains("http"))
        {
            return null;
        }

        if (universityString.IndexOf('/') == 1)
        {
            universityString = universityString.Split('/')[2];
        }
        
        if (universityString.Contains("//"))
        {
            universityString = universityString.Split("//")[0];
        }
        
        var universities = universityString.Split(',');
        var universitiesList = new List<University>();

        for (int i = 0; i < universities.Length; i++)
        {
            universitiesList.Add(new University() {Name = universities[i].Trim()});
        }

        return universitiesList;
    }

    public static string GetTitleOfSource(string citation)
    {
        String sourceString = "";
        sourceString = citation.Split(';')[1].Split(". -")[0];

        if (sourceString.Contains("http"))
        {
            return null;
        }

        if (sourceString.IndexOf('/') == 1)
        {
            return sourceString.Split('/')[1].Trim();
        }
        
        if (sourceString.Contains("//"))
        {
            return sourceString.Split("//")[1].Trim();
        }

        return null;
    }

    public static City GetCity(string citation)
    {
        return new City() { Name = citation.Split(". - ")[1].Split(',')[0] };
    }
    
    public static string GetYear(string citation)
    {
        return citation.Split(". - ")[1].Split(',')[1].Trim();
    }
    
    public static string GetPages(string citation)
    {
        var pages = citation.Split(". - ")[2].Split(',');

        for (int i = 0; i < pages.Length; i++)
        {
            if (Regex.IsMatch(pages[i], @"^\s?\d+\sc"))
            {
                return pages[i].Trim();
            }
        }

        return null;
    }
    
    public static string GetInformation(string citation)
    {
        var information = citation.Split(". - ");
        return information[information.Length-1].Trim();
    }
}
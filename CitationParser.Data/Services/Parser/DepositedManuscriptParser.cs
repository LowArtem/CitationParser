using System.Text.RegularExpressions;
using CitationParser.Data.Model;

namespace CitationParser.Services.Parser;

static public class DepositedManuscriptParser
{
    public static List<Company> GetCompany(string citation)
    {
        String companyString = "";
        companyString = citation.Split(';')[1].Split(". -")[0];

        if (companyString.Contains("http"))
        {
            return new List<Company>();
        }

        if (companyString.IndexOf('/') == 1)
        {
            companyString = companyString.Split('/')[2];
        }
        
        if (companyString.Contains("//"))
        {
            companyString = companyString.Split("//")[0];
        }
        
        var universities = companyString.Split(',');
        var universitiesList = new List<Company>();

        for (int i = 0; i < universities.Length; i++)
        {
            universitiesList.Add(new Company() {Name = universities[i].Trim()});
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
                Regex.Replace(pages[i], @"[^0-9]", "");
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
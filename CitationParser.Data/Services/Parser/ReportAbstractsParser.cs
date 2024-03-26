using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using CitationParser.Data.Model;
using MoreLinq;
using MoreLinq.Extensions;

namespace CitationParser.Data.Services.Parser;

[SuppressMessage("ReSharper", "CommentTypo")]
public class ReportAbstractsParser
{
    public static string GetTitleOfSource(string citation)
    {
        return citation.Split(" // ")[1].Split(" / ")[0].Trim();
    }

    public static List<Editor> GetEditors(string citation)
    {
        try
        {
            var editorString = citation.Split(" // ")[1]
                .Split(" / ")[1]
                .Split(';')[0].Trim();

            var answer = new List<Editor>();

            if (editorString.Contains("ред"))
            {
                var regex = new Regex(@"\[.*?\]");
                var regex2 = new Regex(@"\(.*?\)");
                editorString = regex.Replace(editorString, "");
                editorString = regex2.Replace(editorString, "");

                if (editorString.Contains("под ред."))
                    editorString = editorString.Split(".", 2)[1].Trim();
                else
                    editorString = editorString.Split(":")[1].Trim();

                var editors = editorString
                    .Split(", ");

                answer.AddRange(editors.Select(e => new Editor { Name = e.Trim(' ', '.', ',') }));
            }

            return answer;
        }
        catch (Exception e)
        {
            return new List<Editor>();
        }
    }

    public static List<Company> GetCompanies(string citation)
    {
        try
        {
            citation = citation.Replace("—", "-");
            citation = citation.Replace("–", "-");
            citation = citation.Replace("−", "-");
            citation = citation.Replace("-", "-");

            var companies = GetEditors(citation).Count != 0
                ? citation.Split(" ; ")[1].Split(" - ")[0].Split(", ")
                : citation.Split(" // ")[1].Split("/")[1].Split(". -")[0].Split(", ");

            return companies.Select(c => new Company { Name = c.Trim(' ', '.', ',') }).ToList();
        }
        catch (Exception e)
        {
            return new List<Company>();
        }
    }

    public static List<City> GetCity(string citation)
    {
        citation = citation.Replace("—", "-");
        citation = citation.Replace("–", "-");
        citation = citation.Replace("−", "-");
        citation = citation.Replace("-", "-");

        var cities = citation.Split(". - ")[1].Split(", ")[0].Split(";");
        
        return cities.Select(c => new City { Name = c.Trim(' ', '.', ',') }).ToList();
    }
    
    public static string? GetYear(string citation)
    {
        citation = citation.Replace("—", "-");
        citation = citation.Replace("–", "-");
        citation = citation.Replace("−", "-");
        citation = citation.Replace("-", "-");

        return citation.Split(". - ")[1].Split(", ")[1].Trim();
    }

    public static string GetUrl(string citation)
    {
        citation = citation.Replace("—", "-");
        citation = citation.Replace("–", "-");
        citation = citation.Replace("−", "-");
        citation = citation.Replace("-", "-");

        var splitCitation = citation.Split(". - ");

        foreach (var str in splitCitation)
        {
            if (str.Contains("URL"))
                return str.Trim();
        }

        return null;
    }

    public static string GetPages(string citation)
    {
        citation = citation.Replace("—", "-");
        citation = citation.Replace("–", "-");
        citation = citation.Replace("−", "-");
        citation = citation.Replace("-", "-");

        var splitCitation = citation.Split(". - ");

        foreach (var str in splitCitation)
        {
            if (Regex.IsMatch(str.Trim(), @"^[СPРC]\.\s?\d+"))
                return str.Split(".")[1].Trim();
        }

        return null;
    }
    
    public static string GetVolume(string citation)
    {
        citation = citation.Replace("—", "-");
        citation = citation.Replace("–", "-");
        citation = citation.Replace("−", "-");
        citation = citation.Replace("-", "-");

        var splitCitation = citation.Split(". - ");

        foreach (var str in splitCitation)
        {
            if (Regex.IsMatch(str.Trim(), @"^(Vol|Т|Ч)\.\s?\w+"))
                return str.Split(",")[0].Trim();
        }

        return null;
    }
    
    public static string GetNumber(string citation)
    {
        citation = citation.Replace("—", "-");
        citation = citation.Replace("–", "-");
        citation = citation.Replace("−", "-");
        citation = citation.Replace("-", "-");

        var splitCitation = citation.Split(". - ");

        foreach (var str in splitCitation)
        {
            if (Regex.IsMatch(str.Trim(), @"[№N]\s?\d+$"))
            {
                var numberStr = str.Split(",");
                return numberStr[numberStr.Length - 1].Trim();
            }
        }

        return null;
    }
    
    public static string GetLanguage(string citation)
    {
        citation = citation.Replace("—", "-");
        citation = citation.Replace("–", "-");
        citation = citation.Replace("−", "-");
        citation = citation.Replace("-", "-");

        var splitCitation = citation.Split(". - ");

        if (Regex.IsMatch(splitCitation[splitCitation.Length - 1].Trim(), @"^\w+\.$"))
            return splitCitation[splitCitation.Length - 1].Trim();

        return null;
    }
}
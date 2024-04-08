using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using CitationParser.Data.Model;
using MoreLinq;
using MoreLinq.Extensions;

namespace CitationParser.Data.Services.Parser;

[SuppressMessage("ReSharper", "CommentTypo")]
public static class MagazineArticleParser
{
    public static string GetTitleOfSource(string citation)
    {
        citation = citation.Replace("—", "-");
        citation = citation.Replace("–", "-");
        citation = citation.Replace("−", "-");
        citation = citation.Replace("-", "-");
        
        return citation.Split(" // ")[1].Split(". - ")[0].Trim();
    }

    public static string GetPublicationYear(string citation)
    {
        citation = citation.Replace("—", "-");
        citation = citation.Replace("–", "-");
        citation = citation.Replace("−", "-");
        citation = citation.Replace("-", "-");
        
        return citation.Split(" // ")[1].Split(" - ")[1].Split('.')[0].Trim();
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
            if (Regex.IsMatch(str.Trim(), @"(№|N|issue|No)\.?\s?\w+$"))
            {
                var numberStr = str.Split(",");
                return numberStr[numberStr.Length - 1].Trim();
            }
        }

        return null;
    }
    
    public static List<Company> GetCompanies(string citation)
    {
        try
        {
            citation = citation.Replace("—", "-");
            citation = citation.Replace("–", "-");
            citation = citation.Replace("−", "-");
            citation = citation.Replace("-", "-");

            var companies = citation.Split("//")[1].Split(". - ")[2].Split(";")[1].Split(",");

            return companies.Select(c => new Company { Name = c.Trim(' ', '.', ',') }).ToList();
        }
        catch (Exception e)
        {
            return new List<Company>();
        }
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
            {
                var numberStr = str;
                if(str.Contains(":"))
                    numberStr = numberStr.Split(":")[0];
                var strList = numberStr.Split(",");
                return strList[0].Trim();
            }
        }

        return null;
    }

    public static List<Editor> GetEditors(string citation)
    {
        var number = citation.Split(" // ")[1];
        number = number.Replace("—", "-");
        number = number.Replace("–", "-");
        number = number.Replace("−", "-");
        number = number.Replace("-", "-");

        number = number.Split(". - ")[2].Trim();

        if (number.Contains("ed. by "))
        {
            return number
                .Split("ed. by ")[1].Trim()
                .Split(",")
                .Select(s => new Editor()
                {
                    Name = s
                        .Split(";")[0]
                        .Replace(":", "")
                        .TrimEnd('.')
                        .Trim()
                })
                .ToList();
        }

        if (number.Contains("/ eds."))
        {
            return number
                .Split("/ eds.")[1].Trim()
                .Split(",")
                .Select(s => new Editor()
                {
                    Name = s
                        .Split(";")[0]
                        .Replace(":", "")
                        .Replace("[et al.]", "")
                        .TrimEnd('.')
                        .Trim()
                })
                .ToList();
        }

        return new List<Editor>();
    }

    public static string GetPageNumbers(string citation)
    {
        var pages = citation.Split(" // ")[1];
        pages = pages.Replace("—", "-");
        pages = pages.Replace("–", "-");
        pages = pages.Replace("−", "-");
        pages = pages.Replace("-", "-");

        var splitCitation = pages.Split(". - ");
        
        foreach (var str in splitCitation)
        {
            if (Regex.IsMatch(str.Trim(), @"^[СPРC]\.\s?\d+"))
                return str.Split(".")[1].Trim();
        }
        
        return null;
    }
    
    public static string GetCountOfPages(string citation)
    {
        var pages = citation.Split(" // ")[1];
        pages = pages.Replace("—", "-");
        pages = pages.Replace("–", "-");
        pages = pages.Replace("−", "-");
        pages = pages.Replace("-", "-");

        var splitCitation = pages.Split(". - ");
        
        foreach (var str in splitCitation)
        {
            if (Regex.IsMatch(str.Trim(), @"^\d+\s?[сcpр]\.?"))
            {
                return Regex.Replace(str, @"[^0-9]", "").Trim();

            }
        }
        
        return null;
    }

    public static string? GetDoi(string citation)
    {
        var doi = citation.Split(" // ")[1];
        doi = doi.Replace("—", "-");
        doi = doi.Replace("–", "-");
        doi = doi.Replace("–", "-");
        doi = doi.Replace("−", "-");
        doi = doi.Replace("-", "-");

        return doi.Contains("DOI:")
            ? doi.Split("DOI:")[1].Split(". - ")[0].Trim().TrimEnd('.')
            : null;
    }

    public static string? GetUrl(string citation)
    {
        return citation.Contains("URL")
            ? citation.Split("URL")[1].Trim().TrimStart(':').Trim().TrimEnd('.')
            : null;
    }

    public static string? GetArticleNumber(string citation)
    {
        citation = citation.Replace("—", "-");
        citation = citation.Replace("–", "-");
        citation = citation.Replace("−", "-");
        citation = citation.Replace("-", "-");

        var splitCitation = citation.Split(". - ");

        foreach (var str in splitCitation)
        {
            if (Regex.IsMatch(str.Trim(), @"Article\s?\d*"))
            {
                return str.Trim();
            }
        }

        return null;
    }
    
    public static List<Editor> GetEditorsFromRussianMagazine(string citation)
    {
        var number = citation.Replace("—", "-");
        number = number.Replace("–", "-");
        number = number.Replace("−", "-");
        number = number.Replace("-", "-");

        var list = number.Split(". - ");

        if (list[2].Contains(" ред. "))
        {
            list = list[2].Split("/");
            
        }
        else
        {
            list = list[0].Split("/");
        }
        
        number = list[list.Length - 1];
        if (!number.Contains(" ред. "))
        {
            return new List<Editor>();
        }

        number = Regex.Replace(number, @"[Пп]од(\s(науч|общ)\.)?\sред\.", "");
        list = number.Split(",");
        var result = new List<Editor>();
        foreach (string editor in list)
        {
            if (editor.Split(" и ").Length > 1)
            {
                foreach (var ed in editor.Split(" и "))
                    result.Add(new Editor(){Name = ed.Trim()});
            }
            else
                result.Add(new Editor(){Name = editor.Trim()});
        }

        return result;
    }
    
    public static List<City> GetCities(string citation)
    {
        citation = citation.Replace("—", "-");
        citation = citation.Replace("–", "-");
        citation = citation.Replace("−", "-");
        citation = citation.Replace("-", "-");

        var cities = citation.Split(". - ")[1].Split(", ")[0].Split(":");

        if (!Regex.IsMatch(cities[0], @"^\s*\d+\s*$"))
        {
            cities = cities[0].Split(";");
            return cities.Select(c => new City { Name = c.Trim(' ', '.', ',') }).ToList();
        }

        return new List<City>();
    }
    
    public static string? GetPublishingHouse(string citation)
    {
        var publishingHouseString = citation.Replace('–', '-').Split(". -");

        if (publishingHouseString.Length > 1 && publishingHouseString[1].Contains("изд."))
        {
            publishingHouseString = publishingHouseString[2].Split(':');
        }
        else if (publishingHouseString.Length > 1)
        {
            publishingHouseString = publishingHouseString[1].Split(':');
        }
        else
        {
            return null;
        }
        
        if (publishingHouseString.Length > 1)
        {
            publishingHouseString = publishingHouseString[publishingHouseString.Length - 1].Split(',');

            return publishingHouseString[0].Trim().Replace("[", string.Empty).Replace("]", string.Empty);
        }

        return null;
    }
}
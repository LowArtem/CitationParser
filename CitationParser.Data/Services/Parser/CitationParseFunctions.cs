using CitationParser.Data.Model;
using MoreLinq;

namespace CitationParser.Data.Services.Parser;

/// <summary>
/// Общие функции парсинга
/// </summary>
public static class CitationParseFunctions
{
    public static string GetName(string citation)
    {
        var name = citation.Split("/ ")[0].Trim();
        return name
            .Replace(": Депонированная рукопись", "")
            .Replace(": тез. докл.", "");
    }

    public static List<Author> GetAuthors(string citation, bool isComma = false)
    {
        string authorCitation = citation.Replace('–', '-');
        var authors = new List<string>();

        authors = isComma
            ? authorCitation.Split("/ ")[1].Trim().Split(". -")[0].Split(";")[0].Split(", ").ToList()
            : authorCitation.Split("/ ")[1].Trim().Split(". -")[0].Split(" // ")[0].Split(", ").ToList();

        return authors.Select(a => new Author(a.Replace("/", "").Trim())).ToList();
    }
    
    public static string? GetUrl(string citation)
    {
        return citation.Contains("URL")
            ? citation.Split("URL")[1].Trim().TrimStart(':').Trim().TrimEnd('.')
            : null;
    }
}
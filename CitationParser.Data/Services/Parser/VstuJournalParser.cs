using System.Diagnostics.CodeAnalysis;

namespace CitationParser.Data.Services.Parser;

[SuppressMessage("ReSharper", "CommentTypo")]
public static class VstuJournalParser
{
    public static string GetSourceName(string citation)
    {
        return citation.Split(" // ")[1].Split(" - ")[0].Trim();
    }

    public static string GetPublicationYear(string citation)
    {
        var result = citation.Split(" // ")[1].Split(" - ")[1].Split('.')[0].Split(','); // Волгоград, 2015

        if (result.Length > 1)
            return result[1].Trim();

        return result[0].Trim();
    }

    public static string GetNumber(string citation)
    {
        return citation.Split(" // ")[1].Split(" - ")[2].Trim();
    }

    public static string GetPageNumbers(string citation)
    {
        return citation
            .Split(" // ")[1]
            .Split(" - ")[3]
            .Trim()
            .Split(' ')[1]
            .Trim()
            .Replace(".", "");
    }

    public static string? GetDoi(string citation)
    {
        try
        {
            return citation.Split(" // ")[1]
                .Split(" - ")[4]
                .Replace("DOI:", "")
                .Trim()
                .TrimEnd('.');
        }
        catch (IndexOutOfRangeException)
        {
            return null;
        }
    }
}
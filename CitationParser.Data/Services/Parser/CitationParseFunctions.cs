using System.Text.RegularExpressions;
using CitationParser.Data.Model;

namespace CitationParser.Services.Parser;

public static class CitationParseFunctions
{
    public static string GetName(string citation)
    {
        return citation.Split("/ ")[0].Trim();
    }
    
    
}
﻿namespace CitationParser.Data.Services.Parser;

public static class CitationParseFunctions
{
    public static string GetName(string citation)
    {
        return citation.Split("/ ")[0].Trim();
    }
}
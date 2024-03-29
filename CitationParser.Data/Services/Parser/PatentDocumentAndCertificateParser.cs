﻿using System.Diagnostics.CodeAnalysis;
using CitationParser.Data.Model;

namespace CitationParser.Data.Services.Parser;

[SuppressMessage("ReSharper", "CommentTypo")]
public static class PatentDocumentAndCertificateParser
{
    public static List<Company> GetCompanies(string citation)
    {
        var companyNames = citation
            .Split(";")[1]
            .Split("-")[0]
            .TrimEnd('.')
            .Split(", ");

        return companyNames.Select(n => new Company { Name = n.Trim().TrimEnd('.') }).ToList();
    }

    public static string GetYear(string citation)
    {
        return citation.Split(". - ")[1].Trim().Replace(".", "");
    }
}
using System.Diagnostics.CodeAnalysis;
using CitationParser.Data.Model;

namespace CitationParser.Data.Services.Parser;

[SuppressMessage("ReSharper", "CommentTypo")]
public static class PatentDocumentAndCertificateParser
{
    public static List<Company> GetCompanies(string citation)
    {
        var companyNames = citation
            .Split(";")[1]
            .Split(". -");

        if (!companyNames[0].Contains("Правообладатель:") &&
            !companyNames[0].Contains("правообладатель:") &&
            !companyNames[0].Contains("правообладатели"))
        {
            companyNames = companyNames[0].TrimEnd('.').Split(", ");

            return companyNames.Select(n => new Company { Name = n.Trim().TrimEnd('.') }).ToList();
        }

        return new List<Company>();
    }
    
    public static string GetRightHolder(string citation)
    {
        var rightHolder = citation
            .Split(";")[1]
            .Split(". -");

        if (rightHolder[0].Contains("Правообладатель:") || 
            rightHolder[0].Contains("правообладатель:"))
        {
            return rightHolder[0].TrimEnd('.').Split(":")[1].Trim(' ', '.');
        }
        else if (rightHolder[0].Contains("правообладатели"))
        {
            return rightHolder[0].Replace("правообладатели", "").Trim(' ', '.');
        }

        return null;
    }

    public static string GetYear(string citation)
    {
        return citation.Split(". - ")[1].Trim().Replace(".", "");
    }
}
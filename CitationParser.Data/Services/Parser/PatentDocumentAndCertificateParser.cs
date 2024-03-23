using System.Diagnostics.CodeAnalysis;
using CitationParser.Data.Model;

namespace CitationParser.Data.Services.Parser;

[SuppressMessage("ReSharper", "CommentTypo")]
public static class PatentDocumentAndCertificateParser
{
    /*
     * Пат. 2654045 Российская Федерация, МПК B01J20/16, B01J20/22, C02F3/34 Композиция для
     * биологической очистки грунта, нефтешламов, жидких отходов и сточных вод от органических соединений и
     * нефтепродуктов / С.В. Кудашев, В.Ф. Желтобрюхов, Н.В. Грачева, А.В. Лысенко, О.О. Тужиков,
     * С.Н. Недешева, Е.В. Москвичева; ВолгГТУ. - 2018
     */

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
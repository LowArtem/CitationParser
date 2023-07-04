﻿using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using CitationParser.Data.Model;

namespace CitationParser.Data.Services.Parser;

[SuppressMessage("ReSharper", "CommentTypo")]
public static class ForeignMagazineArticleParser
{
    /*
     * Content of Secondary Education in the Russian Empire in the second half of the 19th century
     * (the Example of Ust-Medveditsky Women's Secondary School of the Don Cossack Host)
     * (Содержание гимназического образования в Российской империи второй половины XIX века
     * (на примере Усть-Медведицкой женской гимназии области Войска Донского)) / А.А. Соловьев,
     * А.В. Захаров, Н.Л. Виноградова, Л.С. Соловьева // Bylye Gody (Былые годы) : электрон.
     * журнал. - 2022. - Vol. 17, issue 1. – P. 378-385. –
     * DOI: 10.13187/bg.2022.1.378. – URL: https://bg.cherkasgu.press/journals_n/1646150680.pdf
     *
     *
     * 
     * Peculiar properties of the electron beam dynamics simulation by particle-particle methods
     * taking into account delay effects / С.А. Аликов, А.Г. Шеин // ITM Web of
     * Conferences. - 2019. - Vol. 30 : 29th International Crimean Conference «Microwave & Telecommunication
     * Technology» (CriMiCo’2019) (Sevastopol, Russia, September 8-14, 2019) / ed. by P.
     * Yermolov. – 9 p. – DOI: https://doi.org/10.1051/itmconf/20193009005.
     *
     *
     * 
     * Learning problem generator for introductory programming courses / А.А. Прокудин, О.А. Сычев,
     * М. Денисов // Software Impacts. - 2023. - Vol. 17 (September). – Article
     * 100519. – 4 p. – DOI: https://doi.org/10.1016/j.simpa.2023.100519. – URL:
     * https://www.sciencedirect.com/science/article/pii/S2665963823000568?via%3Dihub.
     */

    public static string GetTitleOfSource(string citation)
    {
        return citation.Split(" // ")[1].Split(" - ")[0].Trim();
    }

    public static string GetPublicationYear(string citation)
    {
        return citation.Split(" // ")[1].Split(" - ")[1].Split('.')[0].Trim();
    }

    public static string GetNumber(string citation)
    {
        var number = citation.Split(" // ")[1];
        number = number.Replace("—", "-");
        number = number.Replace("–", "-");
        number = number.Replace("−", "-");
        number = number.Replace("-", "-");

        number = number.Split(". - ")[2].Trim();

        return number.Contains("/ ed")
            ? number.Split("/ ed")[0].Trim()
            : number;
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

    public static string GetPages(string citation)
    {
        var pages = citation.Split(" // ")[1];
        pages = pages.Replace("—", "-");
        pages = pages.Replace("–", "-");
        pages = pages.Replace("−", "-");
        pages = pages.Replace("-", "-");

        pages = pages.Split(". - ")[3];
        pages = Regex.Replace(pages, "[^0-9-]", "");

        return pages.Trim();
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
}
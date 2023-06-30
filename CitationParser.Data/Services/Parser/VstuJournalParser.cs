using System.Diagnostics.CodeAnalysis;

namespace CitationParser.Data.Services.Parser;

[SuppressMessage("ReSharper", "CommentTypo")]
public static class VstuJournalParser
{
    /*
     * Оценка интенсивности развития турбулизации в тепломассообменных насадочных контактных устройствах
     * для селективной очистки газовых выбросов и испарительного охлаждения промышленной оборотной
     * воды / Н.А. Меренцов, А.Б. Голованчиков, В.А. Балашов, В.Н. Лебедев, А.В. Персидский // Вестник Волгоградского
     * государственного архитектурно-строительного университета. Серия: Строительство и
     * архитектура. - 2020. - Вып. 2 (79). - C. 245-254. - DOI: 10.35211/1990-5297-2023-2-273-19-21.
     */

    public static string GetSourceName(string citation)
    {
        return citation.Split(" // ")[1].Split(" - ")[0].Trim();
    }

    public static string GetPublicationYear(string citation)
    {
        return citation.Split(" // ")[1].Split(" - ")[1].Split('.')[0].Trim();
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
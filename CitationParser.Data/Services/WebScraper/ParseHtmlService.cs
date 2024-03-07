using System.Text.RegularExpressions;

namespace CitationParser.Data.Services.WebScraper;

/// <summary>
/// Распарсить HTML списка публикаций
/// </summary>
public class ParseHtmlService
{
    /// <summary>
    /// Получить список публикаций
    /// </summary>
    /// <returns></returns>
    public List<string> GetPublications(string html)
    {
        var publicationString = html.Split("id=\"LIST\"")[1].Split("</div>")[0];
        
        publicationString = publicationString
            .Remove(0, publicationString.IndexOf('>')); // Получаем список тегов p
        
        publicationString = new Regex(@"<b>.*</b>")
                .Replace(publicationString, "")   // выпиливаем все теги b с содержимым (в них просто дублируется автор)
                .Replace("</p>", "");   // убираем все закрывающие теги p

        var publicationList = publicationString.Split("<p>"); // получаем список непосредственно публикаций
        
        return publicationList.ToList();
    }
}
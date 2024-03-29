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
        var publicationString = html.Split("ID=\"LIST\"")[1].Split("</DIV>")[0];
        
        publicationString = publicationString
            .Remove(0, publicationString.IndexOf('>') + 1); // Получаем список тегов p

        publicationString = publicationString.Trim('\n', '\r', ' ');

        if (!publicationString.Contains("<p>")) // если в списке нет статей, возвращаем пустой лист
            return new List<string>();

        publicationString = new Regex(@"<p>.*<b>.*</b>") // выпиливаем: все открывающие теги p с номерами, 
            .Replace(publicationString, "") // все теги b с содержимым (в них просто дублируется автор),
            .TrimEnd('<', '/', 'p', '>'); // последний закрывающий тег p

        var publicationList = publicationString.Split("</p>"); // получаем список непосредственно публикаций
        
        return publicationList.ToList();
    }
}
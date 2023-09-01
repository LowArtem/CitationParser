using System.Text.RegularExpressions;
using CitationParser.Data.Model;

namespace CitationParser.Services.Parser;

public class StudyGuideWithStampParser
{
    public static List<Editor> GetEditor(string citation)
    {
        var editorString = citation.Replace('–', '-').Split(". -")[0].Split('/');

        if (editorString.Length > 1)
        {
            editorString = editorString[1].Split(';');
        }

        if (editorString.Length > 1 && editorString[1].Contains("ред"))
        {
            var editors = Regex.Matches(editorString[1], @"\w*\s?[ЁА-Я]{1}\.(\s?[ЁА-Я]{1}\.)?\s?\w*,?");

            List<Editor> editorsList = new List<Editor>();
            for (int i = 0; i < editors.Count; i++)
            {
                editorsList.Add(new Editor() { Name = editors[i].ToString().Replace(",", string.Empty).Trim()});
            }
            return editorsList;

        }

        return null;
    }
}
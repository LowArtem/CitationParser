using System.Text.RegularExpressions;
using CitationParser.Data.Model;

namespace CitationParser.Services.Parser;

public class StudyGuideParser
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
                editorsList.Add(new Editor() { Name = editors[i].ToString().Replace(",", string.Empty).Trim() });
            }

            return editorsList;

        }

        return null;
    }

    public static List<University> GetUniversity(string citation)
    {
        var universityString = citation.Replace('–', '-').Split(". -")[0].Split('/');

        universityString = universityString[universityString.Length - 1].Split(';');

        if (!universityString[universityString.Length - 1].Contains("ред."))
        {
            universityString = universityString[universityString.Length - 1].Split(',');

            List<University> universitiesList = new List<University>();

            for (int i = 0; i < universityString.Length; i++)
            {
                universitiesList.Add(new University() { Name = universityString[i].Trim().Replace("[", string.Empty).Replace("]", string.Empty) });
            }

            return universitiesList;
        }

        return null;

    }
}
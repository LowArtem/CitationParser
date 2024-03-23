using System.Text.RegularExpressions;
using CitationParser.Data.Model;

namespace CitationParser.Services.Parser;

public class ArticleFromRussianCollectionParser
{
    public static ScientificCollection GetTitleScientificCollection(string citation)
    {
        var scientificCollection = citation.Replace('–', '-').Split("//")[1].Split(". -")[0];

        return new ScientificCollection() {Title = scientificCollection.Split('/')[0].Trim() };
    }
    
    public static List<Editor> GetEditorScientificCollection(string citation)
    {
        var editorString = citation.Replace('–', '-').Split("//")[1].Split(". -")[0].Split('/');

        if (editorString[editorString.Length - 1].Contains("ред"))
        {
            var editors = Regex.Matches(editorString[editorString.Length - 1], @"[ЁА-Я]{1}\.(\s[ЁА-Я]{1}\.)?\s\w+,?");

            List<Editor> editorsList = new List<Editor>();
            for (int i = 0; i < editors.Count; i++)
            {
                editorsList.Add(new Editor() { Name = editors[i].ToString().Replace(",", string.Empty) });
            }
            return editorsList;

        }

        return new List<Editor>();
    }
    
    public static List<Company> GetCompanyScientificCollection(string citation)
    {
        var companyString = citation.Replace('–', '-').Split("//")[1].Split(". -")[0].Split('/');

        companyString = companyString[companyString.Length - 1].Split(';');
        
        companyString = companyString[companyString.Length - 1].Split(',');
        
        List<Company> universitiesList = new List<Company>();

        for (int i = 0; i < companyString.Length; i++)
        {
            universitiesList.Add(new Company() { Name = companyString[i].Trim() });
        }
        
        return universitiesList;

    }
    
    public static List<City> GetCitiesScientificCollection(string citation)
    {
        List < City > cities = new List<City>();

        var citiesString = citation.Replace('–', '-').Split("//")[1].Split(". -")[1].Split(',');

        if (citiesString.Length > 1)
        {
            citiesString = citiesString[0].Split(';');

            for (int i = 0; i < citiesString.Length; i++)
            {
                cities.Add(new City()
                {
                    Name = citiesString[i].Trim()
                });
            }
        }

        return cities;
    }

    public static string GetYearScientificCollection(string citation)
    {
        var citiesString = citation.Replace('–', '-').Split("//")[1].Split(". -");

        citiesString = citiesString[1].Split(',');
        return citiesString[citiesString.Length - 1].Trim();
    }

    public static string GetPagesNumbersScientificCollection(string citation)
    {
        var pagesString = citation.Replace('–', '-').Split("//")[1].Split(". -");

        for (int i = 0; i < pagesString.Length; i++)
        {
            if (Regex.IsMatch(pagesString[i].Trim(), @"^(C|С)\.\s?\d+-?\d?"))
            {
                return pagesString[i].Trim();
            }
        }

        return null;
    }
    
    public static string GetVolumeNumbersScientificCollection(string citation)
    {
        var pagesString = citation.Replace('–', '-').Split("//")[1].Split(". -");

        for (int i = 0; i < pagesString.Length; i++)
        {
            if (Regex.IsMatch(pagesString[i].Trim(), @"^(T|Т)\.\s?[A-Z]+"))
            {
                return pagesString[i].Trim();
            }
        }

        return null;
    }
    
    public static string GetCountPagesScientificCollection(string citation)
    {
        var pagesString = citation.Replace('–', '-').Split("//")[1].Split(". -");

        for (int i = 0; i < pagesString.Length; i++)
        {
            if (Regex.IsMatch(pagesString[i].Trim(), @"^\d+\s(c|с)"))
            {
                return pagesString[i].Trim();
            }
        }

        return null;
    }
    
    public static string GetDOIScientificCollection(string citation)
    {
        var DOIString = citation.Replace('–', '-').Split(". -");

        for (int i = 0; i < DOIString.Length; i++)
        {
            if (DOIString[i].Contains("DOI:"))
            {
                return DOIString[i].Trim();
            }
        }

        return null;
    }
    
    public static string GetURLScientificCollection(string citation)
    {
        var URLString = citation.Replace('–', '-').Split(". -");

        for (int i = 0; i < URLString.Length; i++)
        {
            if (URLString[i].Contains("URL:")  || URLString[i].Contains("Режим доступа"))
            {
                return URLString[i].Trim();
            }
        }

        return null;
    }
    
    public static string GetArticleNumberScientificCollection(string citation)
    {
        var articleNumberString = citation.Replace('–', '-').Split(". -");

        for (int i = 0; i < articleNumberString.Length; i++)
        {
            if (articleNumberString[i].Contains("Вып.")  || articleNumberString[i].Contains("Статья"))
            {
                return articleNumberString[i].Trim();
            }
        }

        return null;
    }
    
    public static string GetDataStorageScientificCollection(string citation)
    {
        var dataStorageString = citation.Replace('–', '-').Split(". -");

        for (int i = 0; i < dataStorageString.Length; i++)
        {
            if (dataStorageString[i].Contains("диск"))
            {
                return dataStorageString[i].Trim();
            }
        }

        return null;
    }
}
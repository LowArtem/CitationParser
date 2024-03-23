using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using CitationParser.Data.Model;
using MoreLinq;
using MoreLinq.Extensions;

namespace CitationParser.Services.Parser;

static public class ArticleFromForeignCollection
{
    public static ScientificCollection GetTitleScientificCollection(string citation)
    {
        var scientificCollection = citation.Replace('–', '-').Split("//")[1].Split(". -")[0];

        return new ScientificCollection() {Title = scientificCollection.Split('/')[0].Trim() };
    }
    
    public static List<Editor> GetEditorScientificCollection(string citation)
    {
        var editorString = citation.Replace('–', '-').Split("//")[1].Split(". -")[0].Split('/');
        editorString = editorString[editorString.Length - 1].Split(';');
        
        if (editorString[0].Substring(0, 3) == " ed")
        {
            var editors = Regex.Matches(editorString[0], @"[A-ZЁА-Я]{1}\.(\s[A-ZЁА-Я]{1}\.)?\s\w+,?");

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

        var citiesString = citation.Replace('–', '-').Split("//")[1].Split(". -")[1].Split(':');

        if (citiesString.Length > 1)
        {
            citiesString = citiesString[0].Split(';');
            
            for (int i = 0; i < citiesString.Length; i++)
            {
                if (citiesString[i].Contains('('))
                {
                    cities.Add(new City()
                    {
                        Name = citiesString[i].Split('(')[0].Trim().Replace("[", string.Empty),
                        Country = citiesString[i].Split('(')[1].Trim().Replace(")", string.Empty)
                    });
                }
                else
                {
                    cities.Add(new City()
                    {
                        Country = citiesString[i].Trim().Replace("[", string.Empty)
                    });
                }
            }
        }
        else if (!citiesString[0].Split(',')[0].Trim().Contains(' '))
        {
            cities.Add(new City() {Name = citiesString[0].Split(',')[0].Trim().Replace("[", string.Empty).Replace("]", string.Empty)});
        }

        return cities;
    }

    public static string GetYearScientificCollection(string citation)
    {
        var citiesString = citation.Replace('–', '-').Split("//")[1].Split(". -")[1].Split(':');

        citiesString = citiesString[citiesString.Length - 1].Split(',');
        return citiesString[citiesString.Length - 1].Trim();
    }
    
    public static string GetPublishingHouseScientificCollection(string citation)
    {
        var publishingHouseString = citation.Replace('–', '-').Split("//")[1].Split(". -")[1].Split(':');

        publishingHouseString = publishingHouseString[publishingHouseString.Length - 1].Split(',');

        if (!int.TryParse(publishingHouseString[0].Trim(), out int n))
        {
            return publishingHouseString[0].Trim().Replace("[", string.Empty).Replace("]", string.Empty);
        }

        return null;
    }
    
    public static string GetPagesNumbersScientificCollection(string citation)
    {
        var pagesString = citation.Replace('–', '-').Split("//")[1].Split(". -");

        for (int i = 0; i < pagesString.Length; i++)
        {
            if (Regex.IsMatch(pagesString[i].Trim(), @"^(P|С)\.\s?\d+-?\d?"))
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
            if (Regex.IsMatch(pagesString[i].Trim(), @"^\d+\s(p|с)"))
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
            if (URLString[i].Contains("URL:"))
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
            if (articleNumberString[i].Contains("Article"))
            {
                return articleNumberString[i].Trim();
            }
        }

        return null;
    }
}
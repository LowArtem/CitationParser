using System.Text.RegularExpressions;
using CitationParser.Data.Model;
using MoreLinq;

namespace CitationParser.Services.Parser;

public class OtherPublicationsParser
{
    public static string GetTitleSource(string citation)
    {
        var scientificCollection = citation.Replace('–', '-').Split("//")[1].Split(". -")[0];

        return scientificCollection.Split('/')[0].Trim();
    }
    
    public static string GetYear(string citation)
    {
        var citiesString = citation.Replace('–', '-').Split(". -");

        if (!citiesString[1].Contains("Введ."))
        {
            citiesString = citiesString[1].Split(',');
        }
        else
        {
            citiesString = citiesString[2].Split(',');
        }
        
        return citiesString[citiesString.Length - 1].Trim().Replace("[", string.Empty).Replace("]", string.Empty);
        
    }
    
    public static List<City> GetCities(string citation)
    {
        List < City > cities = new List<City>();

        var citiesString = citation.Replace('–', '-').Split(". -");

        if (citiesString[1].Contains("Введ."))
        {
            citiesString = citiesString[2].Split(',');
        }
        else
        {
            citiesString = citiesString[1].Split(',');
        }

        if (citiesString.Length > 1)
        {
            citiesString = citiesString[0].Split(';');

            for (int i = 0; i < citiesString.Length; i++)
            {
                cities.Add(new City()
                {
                    Name = citiesString[i].Split(':')[0].Split('(')[0].Trim().Replace("[", string.Empty).Replace("]", string.Empty),
                });

                if (citiesString[i].Split('(').Length > 1)
                {
                    cities[cities.Count - 1].Country = citiesString[i].Split(':')[0].Split('(')[1].Trim().Replace(")", string.Empty);
                }
            }
        }

        return cities;
    }
    
    public static string GetPublishingHouse(string citation)
    {
        var publishingHouseString = citation.Replace('–', '-').Split(". -")[1].Split(':');

        publishingHouseString = publishingHouseString[publishingHouseString.Length - 1].Split(',');

        if (!int.TryParse(publishingHouseString[0].Trim(), out int n))
        {
            return publishingHouseString[0].Trim().Replace("[", string.Empty).Replace("]", string.Empty);
        }

        return null;
    }

    public static string GetPagesNumbers(string citation)
    {
        var pagesString = citation.Replace('–', '-').Split("//")[1].Split(". -");

        for (int i = 0; i < pagesString.Length; i++)
        {
            if (Regex.IsMatch(pagesString[i].Split(';')[0].Trim(), @"^(P|С)\.\s?\d+-?\d?"))
            {
                return pagesString[i].Split(';')[0].Trim();
            }
        }

        return null;
    }
    
    public static string GetCountPages(string citation)
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
    
    public static string GetURL(string citation)
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
    
    public static string GetNumber(string citation)
    {
        var articleNumberString = citation.Replace('–', '-').Split(". -");

        for (int i = 0; i < articleNumberString.Length; i++)
        {
            if (articleNumberString[i].Contains("№") || articleNumberString[i].Contains("Paper No"))
            {
                return articleNumberString[i].Trim();
            }
        }

        return null;
    }

    public static List<University> GetUniversity(string citation)
    {
        var universityString = citation.Replace('–', '-').Split("//");
        
        if (universityString.Length > 1)
        {
            universityString = universityString[1].Split(". -")[0].Split('/');
        }
        else
        {
            universityString = universityString[0].Split(". -")[0].Split('/');
        }

        universityString = universityString[universityString.Length - 1].Split(';');
        
        universityString = universityString[universityString.Length - 1].Split(',');
        
        List<University> universitiesList = new List<University>();

        for (int i = 0; i < universityString.Length; i++)
        {
            if (!universityString[i].Contains("сост.:"))
            {
                universitiesList.Add(new University() { Name = universityString[i].Trim() });
            }
        }
        
        return universitiesList;

    }
    
    public static string GetDateIntroduction(string citation)
    {
        var citiesString = citation.Replace('–', '-').Split(". -");

        if (citiesString[1].Contains("Введ."))
        {
            return citiesString[1].Trim();
        }

        return null;
    }
}
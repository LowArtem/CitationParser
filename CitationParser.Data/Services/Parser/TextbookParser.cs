using System.Text.RegularExpressions;
using CitationParser.Data.Model;

namespace CitationParser.Services.Parser;

public class TextbookParser
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

        return new List<Editor>();
    }
    
    public static List<Company> GetCompany(string citation)
    {
        var companyString = citation.Replace('–', '-').Split(". -")[0].Split('/');

        if (!companyString[^1].Contains(';'))
            return new List<Company>();
        
        companyString = companyString[1].Split(';');

        if (!companyString[companyString.Length - 1].Contains("ред."))
        {
            companyString = companyString[companyString.Length - 1].Split(',');

            List<Company> universitiesList = new List<Company>();

            for (int i = 0; i < companyString.Length; i++)
            {
                universitiesList.Add(new Company() { Name = companyString[i].Trim().Replace("[", string.Empty).Replace("]", string.Empty) });
            }

            return universitiesList;
        }

        return new List<Company>();

    }
    
    public static List<City> GetCities(string citation)
    {
        List < City > cities = new List<City>();

        var citiesString = citation.Replace('–', '-').Split(". -");

        if (citiesString.Length > 1 && (citiesString[1].Contains("изд.") || citiesString[1].Contains("диск")))
        {
            citiesString = citiesString[2].Split(',');
        }
        else if (citiesString.Length > 1)
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
    
    public static string GetYear(string citation)
    {
        var yearString = citation.Replace('–', '-').Split(". -");

        if (yearString.Length > 1 && !(yearString[1].Contains("изд.") || yearString[1].Contains("диск") || yearString[1].Contains("Изд.")))
        {
            yearString = yearString[1].Split(',');
        }
        else if (yearString.Length > 1)
        {
            yearString = yearString[2].Split(',');
        }
        else
        {
            return null;
        }
        
        return yearString[yearString.Length - 1].Trim().Replace("[", string.Empty).Replace("]", string.Empty);
    }
    
    public static string GetCountPages(string citation)
    {
        var pagesString = citation.Replace('–', '-').Split(". -");

        for (int i = 0; i < pagesString.Length; i++)
        {
            if (Regex.IsMatch(pagesString[i].Trim(), @"^\d+\s(c|с)"))
            {
                return Regex.Replace(pagesString[i], @"[^0-9]", "").Trim();
            }
        }

        return null;
    }
    
    public static string GetInformationAboutPublication(string citation)
    {
        var complexNumberString = citation.Replace('–', '-').Split(". -");

        for (int i = 0; i < complexNumberString.Length; i++)
        {
            
            if (complexNumberString[i].Contains("изд") || complexNumberString[i].Contains("Изд"))
            {
                if (complexNumberString[i].Contains("диск"))
                {
                    var dataStorageAndPublication = complexNumberString[i].Split(";");

                    if (dataStorageAndPublication[0].Contains("изд") || complexNumberString[i].Contains("Изд"))
                    {
                        return dataStorageAndPublication[0].Trim().Replace("[", string.Empty).Replace("]", string.Empty);
                    }
                    
                    return dataStorageAndPublication[1].Trim().Replace("[", string.Empty).Replace("]", string.Empty);
                }
                
                return complexNumberString[i].Trim();
            }
        }

        return null;
    }
    
    public static string GetVolumeNumbers(string citation)
    {
        var volumeString = citation.Replace('–', '-').Split(". -");

        for (int i = 0; i < volumeString.Length; i++)
        {
            if (Regex.IsMatch(volumeString[i].Trim(), @"^Ч\.\s?\d+"))
            {
                return volumeString[i].Trim();
            }
        }

        return null;
    }
}
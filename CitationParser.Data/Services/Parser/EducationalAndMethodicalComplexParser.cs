using System.Text.RegularExpressions;
using CitationParser.Data.Model;

namespace CitationParser.Services.Parser;

public class EducationalAndMethodicalComplexParser
{
    public static List<Company> GetCompany(string citation)
    {
        var companyString = citation.Replace('–', '-').Split(". -")[0].Split('/');

        companyString = companyString[companyString.Length - 1].Split(';');

        if (companyString.Length > 1)
        {
            companyString = companyString[companyString.Length - 1].Split(',');


            List<Company> universitiesList = new List<Company>();

            for (int i = 0; i < companyString.Length; i++)
            {
                universitiesList.Add(new Company() { Name = companyString[i].Trim() });
            }

            return universitiesList;
        }

        return new List<Company>();

    }
    
    public static List<City> GetCities(string citation)
    {
        List < City > cities = new List<City>();

        var citiesString = citation.Replace('–', '-').Split(". -");

        if (citiesString.Length > 1 && citiesString[1].Contains("изд."))
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
        var citiesString = citation.Replace('–', '-').Split(". -");

        if (citiesString.Length > 1 && !citiesString[1].Contains("изд."))
        {
            citiesString = citiesString[1].Split(',');
        }
        else if (citiesString.Length > 1)
        {
            citiesString = citiesString[2].Split(',');
        }
        else
        {
            return null;
        }
        
        return citiesString[citiesString.Length - 1].Trim().Replace("[", string.Empty).Replace("]", string.Empty);
        
    }
    
    public static string GetPublishingHouse(string citation)
    {
        var publishingHouseString = citation.Replace('–', '-').Split(". -");

        if (publishingHouseString.Length > 1 && publishingHouseString[1].Contains("изд."))
        {
            publishingHouseString = publishingHouseString[2].Split(':');
        }
        else if (publishingHouseString.Length > 1)
        {
            publishingHouseString = publishingHouseString[1].Split(':');
        }
        else
        {
            return null;
        }
        
        if (publishingHouseString.Length > 1)
        {
            publishingHouseString = publishingHouseString[publishingHouseString.Length - 1].Split(',');

            return publishingHouseString[0].Trim().Replace("[", string.Empty).Replace("]", string.Empty);
        }

        return null;
    }
    
    public static string GetDataStorage(string citation)
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
    
    public static string GetComplexNumber(string citation)
    {
        var complexNumberString = citation.Replace('–', '-').Split(". -");

        for (int i = 0; i < complexNumberString.Length; i++)
        {
            if (complexNumberString[i].Contains("№ ГР"))
            {
                return complexNumberString[i].Trim();
            }
        }

        return null;
    }
    
    public static string GetInformationAboutPublication(string citation)
    {
        var complexNumberString = citation.Replace('–', '-').Split(". -");

        for (int i = 0; i < complexNumberString.Length; i++)
        {
            if (complexNumberString[i].Contains("изд."))
            {
                return complexNumberString[i].Trim();
            }
        }

        return null;
    }
    
    public static string GetCountPages(string citation)
    {
        var pagesString = citation.Replace('–', '-').Split(". -");

        for (int i = 0; i < pagesString.Length; i++)
        {
            if (Regex.IsMatch(pagesString[i].Trim(), @"^\d+\s(c|с)"))
            {
                Regex.Replace(pagesString[i], @"[^0-9]", "");
                return pagesString[i].Trim();
            }
        }

        return null;
    }
    
    public static string GetRegistrationNumber(string citation)
    {
        var registrationNumberString = citation.Replace('–', '-').Split(". -");

        if (registrationNumberString.Length > 1 && !registrationNumberString[registrationNumberString.Length -1].Contains("["))
        {
            return registrationNumberString[registrationNumberString.Length - 1].Split('/')[0].Split("от")[0]
                .Replace("Рег. свид.", String.Empty).Trim();
        }

        return null;
    }
    
    public static string GetDateOfRegistration(string citation)
    {
        var dateOfRegistrationString = citation.Replace('–', '-').Split(". -");

        if (dateOfRegistrationString.Length > 1 && !dateOfRegistrationString[dateOfRegistrationString.Length -1].Contains("["))
        {
            return dateOfRegistrationString[dateOfRegistrationString.Length - 1].Split('/')[0].Split("от")[1].Trim();
        }

        return null;
    }
    
    public static string GetPlaceOfRegistration(string citation)
    {
        var placeOfRegistrationString = citation.Replace('–', '-').Split(". -");

        if (placeOfRegistrationString.Length > 1 && !placeOfRegistrationString[placeOfRegistrationString.Length -1].Contains("["))
        {
            return placeOfRegistrationString[placeOfRegistrationString.Length - 1].Split('/')[1].Trim();
        }

        return null;
    }
    
    public static string GetInformation(string citation)
    {
        var informationString = citation.Replace('–', '-').Split(". -");

        if (informationString.Length > 1 && informationString[informationString.Length -1].Contains("["))
        {
            return informationString[informationString.Length - 1].Trim();
        }

        return null;
    }
}
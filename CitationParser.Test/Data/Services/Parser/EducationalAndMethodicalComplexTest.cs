using CitationParser.Data.Model;
using CitationParser.Services.Parser;

namespace CitationParser.Test.Data.Services.Parser;

public class EducationalAndMethodicalComplexTest
{
    [Fact]
    public void GetUniversities_SimpleTest()
    {
        var citation = "Детали машин и основы конструирования [Электронный ресурс] : электрон. учеб.-метод. комплекс / М.М. Матлин, С.Ю. Кислов, И.М. Шандыбина ; ВолгГТУ. – Волгоград, 2011. – 1 электрон. опт. диск (CD-ROM). – № ГР 0321100012. – Рег. свид. № 21083 от 13 января 2011 г. / ФГУП НТЦ «Информрегистр»";

        List<Company> universities = new List<Company>();
        universities.Add(new Company(){Name = "ВолгГТУ"});

        var result = EducationalAndMethodicalComplexParser.GetCompany(citation);

        Assert.Equal(universities.Count, result.Count);
        for (int i = 0; i < universities.Count; i++)
        {
            Assert.Equal(universities[i].Name, result[i].Name);
        }
    }
    
    [Fact]
    public void GetUniversities_TwoCompanyTest()
    {
        var citation = "Профессиональная межкультурная коммуникация: английский язык : учебно-методический комплекс (Рек. УМО по образованию в области лингвистики в качестве УМК) / Т.Н. Астафурова ; ФГБОУ ВПО «Волгоградский гос. ун-т», Ин-т дополнительного образования. – 3-е изд., доп. – Волгоград : Изд-во ВолГУ, 2011. – 200 с. – [Усл.-печ. л. 11,6 ; тираж 100]";

        List<Company> universities = new List<Company>();
        universities.Add(new Company(){Name = "ФГБОУ ВПО «Волгоградский гос. ун-т»"});
        universities.Add(new Company(){Name = "Ин-т дополнительного образования"});
        
        var result = EducationalAndMethodicalComplexParser.GetCompany(citation);

        Assert.Equal(universities.Count, result.Count);
        for (int i = 0; i < universities.Count; i++)
        {
            Assert.Equal(universities[i].Name, result[i].Name);
        }
    }
    
    [Fact]
    public void GetCities_SimpleTest()
    {
        var citation = "Детали машин и основы конструирования [Электронный ресурс] : электрон. учеб.-метод. комплекс / М.М. Матлин, С.Ю. Кислов, И.М. Шандыбина ; ВолгГТУ. – Волгоград, 2011. – 1 электрон. опт. диск (CD-ROM). – № ГР 0321100012. – Рег. свид. № 21083 от 13 января 2011 г. / ФГУП НТЦ «Информрегистр»";

        List<City> cities = new List<City>();
        cities.Add(new City() {Name = "Волгоград"});

        var result = EducationalAndMethodicalComplexParser.GetCities(citation);

        Assert.Equal(cities.Count, result.Count);
        for (int i = 0; i < cities.Count; i++)
        {
            Assert.Equal(cities[i].Name, result[i].Name);
            Assert.Equal(cities[i].Country, result[i].Country);
        }
    }
    
    [Fact]
    public void GetCities_NullTest()
    {
        var citation = "Оценка влияния дорожных условий на пропускную способность городских дорог в зимнее время / Ф.В. Волченко ";

        List<City> cities = new List<City>();

        var result = EducationalAndMethodicalComplexParser.GetCities(citation);

        Assert.Equal(cities.Count, result.Count);
        for (int i = 0; i < cities.Count; i++)
        {
            Assert.Equal(cities[i].Name, result[i].Name);
            Assert.Equal(cities[i].Country, result[i].Country);
        }
    }

    [Fact]
    public void GetCities_CityIsNotContainedAfterFirstDotAndHyphenTest()
    {
        var citation = " Профессиональная межкультурная коммуникация: английский язык : учебно-методический комплекс (Рек. УМО по образованию в области лингвистики в качестве УМК) / Т.Н. Астафурова ; ФГБОУ ВПО «Волгоградский гос. ун-т», Ин-т дополнительного образования. – 3-е изд., доп. – Волгоград : Изд-во ВолГУ, 2011. – 200 с. – [Усл.-печ. л. 11,6 ; тираж 100]";

        List<City> cities = new List<City>();
        cities.Add(new City(){Name = "Волгоград"});

        var result = EducationalAndMethodicalComplexParser.GetCities(citation);

        Assert.Equal(cities.Count, result.Count);
        for (int i = 0; i < cities.Count; i++)
        {
            Assert.Equal(cities[i].Name, result[i].Name);
            Assert.Equal(cities[i].Country, result[i].Country);
        }
    }
    
    [Fact]
    public void GetYear_SimpleTest()
    {
        var citation = "Детали машин и основы конструирования [Электронный ресурс] : электрон. учеб.-метод. комплекс / М.М. Матлин, С.Ю. Кислов, И.М. Шандыбина ; ВолгГТУ. – Волгоград, 2011. – 1 электрон. опт. диск (CD-ROM). – № ГР 0321100012. – Рег. свид. № 21083 от 13 января 2011 г. / ФГУП НТЦ «Информрегистр»";

        var expected = "2011";

        var result = EducationalAndMethodicalComplexParser.GetYear(citation);
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetYear_NullTest()
    {
        var citation = "Оценка влияния дорожных условий на пропускную способность городских дорог в зимнее время / Ф.В. Волченко ";

        string expected = null;

        var result = EducationalAndMethodicalComplexParser.GetYear(citation);
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetYear_YearIsNotContainedAfterFirstDotAndHyphenTest()
    {
        var citation = "Профессиональная межкультурная коммуникация: английский язык : учебно-методический комплекс (Рек. УМО по образованию в области лингвистики в качестве УМК) / Т.Н. Астафурова ; ФГБОУ ВПО «Волгоградский гос. ун-т», Ин-т дополнительного образования. – 3-е изд., доп. – Волгоград : Изд-во ВолГУ, 2011. – 200 с. – [Усл.-печ. л. 11,6 ; тираж 100]";

        var expected = "2011";

        var result = EducationalAndMethodicalComplexParser.GetYear(citation);
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetPublishingHouse_SimpleTest()
    {
        var citation = "Профессиональная межкультурная коммуникация: английский язык : учебно-методический комплекс (Рек. УМО по образованию в области лингвистики в качестве УМК) / Т.Н. Астафурова ; ФГБОУ ВПО «Волгоградский гос. ун-т», Ин-т дополнительного образования. – 3-е изд., доп. – Волгоград : Изд-во ВолГУ, 2011. – 200 с. – [Усл.-печ. л. 11,6 ; тираж 100]";

        var expected = "Изд-во ВолГУ";

        var result = EducationalAndMethodicalComplexParser.GetPublishingHouse(citation);
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetPublishingHouse_NullTest()
    {
        var citation = "Оценка влияния дорожных условий на пропускную способность городских дорог в зимнее время / Ф.В. Волченко ";

        string expected = null;

        var result = EducationalAndMethodicalComplexParser.GetPublishingHouse(citation);
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetDataStorage_SimpleTest()
    {
        var citation = "Детали машин и основы конструирования [Электронный ресурс] : электрон. учеб.-метод. комплекс / М.М. Матлин, С.Ю. Кислов, И.М. Шандыбина ; ВолгГТУ. – Волгоград, 2011. – 1 электрон. опт. диск (CD-ROM). – № ГР 0321100012. – Рег. свид. № 21083 от 13 января 2011 г. / ФГУП НТЦ «Информрегистр»";

        var expected = "1 электрон. опт. диск (CD-ROM)";

        var result = EducationalAndMethodicalComplexParser.GetDataStorage(citation);
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetComplexNumber_SimpleTest()
    {
        var citation = " Детали машин и основы конструирования [Электронный ресурс] : электрон. учеб.-метод. комплекс / М.М. Матлин, С.Ю. Кислов, И.М. Шандыбина ; ВолгГТУ. – Волгоград, 2011. – 1 электрон. опт. диск (CD-ROM). – № ГР 0321100012. – Рег. свид. № 21083 от 13 января 2011 г. / ФГУП НТЦ «Информрегистр»";

        var expected = "№ ГР 0321100012";

        var result = EducationalAndMethodicalComplexParser.GetComplexNumber(citation);
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetInformationAboutPublication_SimpleTest()
    {
        var citation = "Профессиональная межкультурная коммуникация: английский язык : учебно-методический комплекс (Рек. УМО по образованию в области лингвистики в качестве УМК) / Т.Н. Астафурова ; ФГБОУ ВПО «Волгоградский гос. ун-т», Ин-т дополнительного образования. – 3-е изд., доп. – Волгоград : Изд-во ВолГУ, 2011. – 200 с. – [Усл.-печ. л. 11,6 ; тираж 100]";

        var expected = "3-е изд., доп";

        var result = EducationalAndMethodicalComplexParser.GetInformationAboutPublication(citation);
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetCountPages_SimpleTest()
    {
        var citation = "Профессиональная межкультурная коммуникация: английский язык : учебно-методический комплекс (Рек. УМО по образованию в области лингвистики в качестве УМК) / Т.Н. Астафурова ; ФГБОУ ВПО «Волгоградский гос. ун-т», Ин-т дополнительного образования. – 3-е изд., доп. – Волгоград : Изд-во ВолГУ, 2011. – 200 с. – [Усл.-печ. л. 11,6 ; тираж 100]";

        var expected = "200 с";

        var result = EducationalAndMethodicalComplexParser.GetCountPages(citation);
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetRegistrationNumber_SimpleTest()
    {
        var citation = " Детали машин и основы конструирования [Электронный ресурс] : электрон. учеб.-метод. комплекс / М.М. Матлин, С.Ю. Кислов, И.М. Шандыбина ; ВолгГТУ. – Волгоград, 2011. – 1 электрон. опт. диск (CD-ROM). – № ГР 0321100012. – Рег. свид. № 21083 от 13 января 2011 г. / ФГУП НТЦ «Информрегистр»";

        var expected = "№ 21083";

        var result = EducationalAndMethodicalComplexParser.GetRegistrationNumber(citation);
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetDateOfRegistration_SimpleTest()
    {
        var citation = " Детали машин и основы конструирования [Электронный ресурс] : электрон. учеб.-метод. комплекс / М.М. Матлин, С.Ю. Кислов, И.М. Шандыбина ; ВолгГТУ. – Волгоград, 2011. – 1 электрон. опт. диск (CD-ROM). – № ГР 0321100012. – Рег. свид. № 21083 от 13 января 2011 г. / ФГУП НТЦ «Информрегистр»";

        var expected = "13 января 2011 г.";

        var result = EducationalAndMethodicalComplexParser.GetDateOfRegistration(citation);
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetPlaceOfRegistration_SimpleTest()
    {
        var citation = " Детали машин и основы конструирования [Электронный ресурс] : электрон. учеб.-метод. комплекс / М.М. Матлин, С.Ю. Кислов, И.М. Шандыбина ; ВолгГТУ. – Волгоград, 2011. – 1 электрон. опт. диск (CD-ROM). – № ГР 0321100012. – Рег. свид. № 21083 от 13 января 2011 г. / ФГУП НТЦ «Информрегистр»";

        var expected = "ФГУП НТЦ «Информрегистр»";

        var result = EducationalAndMethodicalComplexParser.GetPlaceOfRegistration(citation);
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetInformation_SimpleTest()
    {
        var citation = "Профессиональная межкультурная коммуникация: английский язык : учебно-методический комплекс (Рек. УМО по образованию в области лингвистики в качестве УМК) / Т.Н. Астафурова ; ФГБОУ ВПО «Волгоградский гос. ун-т», Ин-т дополнительного образования. – 3-е изд., доп. – Волгоград : Изд-во ВолГУ, 2011. – 200 с. – [Усл.-печ. л. 11,6 ; тираж 100]";

        var expected = "[Усл.-печ. л. 11,6 ; тираж 100]";

        var result = EducationalAndMethodicalComplexParser.GetInformation(citation);
        
        Assert.Equal(expected, result);
    }
}
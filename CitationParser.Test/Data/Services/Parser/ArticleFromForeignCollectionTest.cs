using CitationParser.Data.Model;
using CitationParser.Services.Parser;

namespace CitationParser.Test.Data.Services.Parser;

public class ArticleFromForeignCollectionTest
{
    [Fact]
    public void GetTitleScientificCollection_SimpleTest()
    {
        var citation = "Development of creating computer programs method for multivariate optimization of functional meat product recipes / А.С. Мирошник, М.И. Сложенкина, И.Ф. Горлов, Д.А. Мосолова, A.L. Ishevskyi // IOP Conference Series: Earth and Environmental Science. Vol. 548 : III International Scientific Conference: AGRITECH-III-2020: Agribusiness, Environmental Engineering and Biotechnologies (Krasnoyarsk, Russia, 18-20 June 2020). Conference «Innovative Development of Agrarian-and-Food Technologies» (Volgograd, Russia) / Krasnoyarsk Regional Union of Scientific and Engineering Associations, Krasnoyarsk Science and Technology City Hall, Volgograd State Technical University, Volga region research Institute of manufacture and processing of meat-and-milk production [et al.]. – [IOP Publishing], 2020. – 6 p. – URL : https://iopscience.iop.org/article/10.1088/1755-1315/548/8/082081/pdf";

        var expected = "IOP Conference Series: Earth and Environmental Science. Vol. 548 : III International Scientific Conference: AGRITECH-III-2020: Agribusiness, Environmental Engineering and Biotechnologies (Krasnoyarsk, Russia, 18-20 June 2020). Conference «Innovative Development of Agrarian-and-Food Technologies» (Volgograd, Russia)";

        var result = ArticleFromForeignCollection.GetTitleScientificCollection(citation).Title;
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetYear_SimpleTest()
    {
        var citation = "Development of creating computer programs method for multivariate optimization of functional meat product recipes / А.С. Мирошник, М.И. Сложенкина, И.Ф. Горлов, Д.А. Мосолова, A.L. Ishevskyi // IOP Conference Series: Earth and Environmental Science. Vol. 548 : III International Scientific Conference: AGRITECH-III-2020: Agribusiness, Environmental Engineering and Biotechnologies (Krasnoyarsk, Russia, 18-20 June 2020). Conference «Innovative Development of Agrarian-and-Food Technologies» (Volgograd, Russia) / Krasnoyarsk Regional Union of Scientific and Engineering Associations, Krasnoyarsk Science and Technology City Hall, Volgograd State Technical University, Volga region research Institute of manufacture and processing of meat-and-milk production [et al.]. – [IOP Publishing], 2020. – 6 p. – URL : https://iopscience.iop.org/article/10.1088/1755-1315/548/8/082081/pdf";

        var expected = "2020";

        var result = ArticleFromForeignCollection.GetYearScientificCollection(citation);
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetPages_SimpleTest()
    {
        var citation = " An Expert System for the Priorities Formation in Sustainable Development Fundamental Research / А.В. Зубков, I.B. Mamai, С.В. Проничкин, А.В. Холстов // Software Engineering Application in Systems Design : Proceedings of 6th Computational Methods in Systems and Software (CoMeSySo 2022) Conference (October 2022). Vol. 1 / eds.: Radek Silhavy [et al.]. – Cham (Switzerland) : Springer Nature Switzerland AG, 2023. – P. 831-839. – DOI: https://doi.org/10.1007/978-3-031-21435-6_73. – (Book ser.: Lecture Notes in Networks and Systems (LNNS) ; vol. 596).";

        var expected = "831-839";

        var result = ArticleFromForeignCollection.GetPagesNumbersScientificCollection(citation);
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetPages_RussianTest()
    {
        var citation = "Источники по истории российской антивоенной мысли второй половины XIX – начала XX вв.: многообразие форм и смыслов / Н.Ю. Николаев // Актуальные проблемы источниковедения : материалы VII Междунар. науч.-практ. конф. (г. Витебск, 27–29 апреля 2023 г.). В 2 т. Т. 2 / редкол.: А. Н. Дулов, М. Ф. Румянцева (отв. ред.) [и др.] ; Витебский гос. университет им. П. М. Машерова. – Витебск, 2023. – С. 103-105";

        var expected = "103-105";

        var result = ArticleFromForeignCollection.GetPagesNumbersScientificCollection(citation);
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetPages_OnePageTest()
    {
        var citation = "Interpreting Traces: Studying Misconceptions of Control Flow Statements / Е. Фомичев, Е.Д. Беришева, А.М. Дворянкин, О.А. Сычев // SIGCSE 2023 : Proceedings of the 54th ACM Technical Symposium on Computer Science Education (Toronto, ON, Canada, 15-18 March 2023) / Association for Computing Machinery (ACM). – [USA], 2023. – Vol. 2. – P. 1361. - DOI: https://doi.org/10.1145/3545947.3576305";

        var expected = "1361";

        var result = ArticleFromForeignCollection.GetPagesNumbersScientificCollection(citation);
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetCountPages_SimpleTest()
    {
        var citation = "Development of creating computer programs method for multivariate optimization of functional meat product recipes / А.С. Мирошник, М.И. Сложенкина, И.Ф. Горлов, Д.А. Мосолова, A.L. Ishevskyi // IOP Conference Series: Earth and Environmental Science. Vol. 548 : III International Scientific Conference: AGRITECH-III-2020: Agribusiness, Environmental Engineering and Biotechnologies (Krasnoyarsk, Russia, 18-20 June 2020). Conference «Innovative Development of Agrarian-and-Food Technologies» (Volgograd, Russia) / Krasnoyarsk Regional Union of Scientific and Engineering Associations, Krasnoyarsk Science and Technology City Hall, Volgograd State Technical University, Volga region research Institute of manufacture and processing of meat-and-milk production [et al.]. – [IOP Publishing], 2020. – 6 p. – URL : https://iopscience.iop.org/article/10.1088/1755-1315/548/8/082081/pdf";

        var expected = "6";

        var result = ArticleFromForeignCollection.GetCountPagesScientificCollection(citation);
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetPublishingHouse_SimpleTest()
    {
        var citation = "Development of creating computer programs method for multivariate optimization of functional meat product recipes / А.С. Мирошник, М.И. Сложенкина, И.Ф. Горлов, Д.А. Мосолова, A.L. Ishevskyi // IOP Conference Series: Earth and Environmental Science. Vol. 548 : III International Scientific Conference: AGRITECH-III-2020: Agribusiness, Environmental Engineering and Biotechnologies (Krasnoyarsk, Russia, 18-20 June 2020). Conference «Innovative Development of Agrarian-and-Food Technologies» (Volgograd, Russia) / Krasnoyarsk Regional Union of Scientific and Engineering Associations, Krasnoyarsk Science and Technology City Hall, Volgograd State Technical Company, Volga region research Institute of manufacture and processing of meat-and-milk production [et al.]. – [IOP Publishing], 2020. – 6 p. – URL : https://iopscience.iop.org/article/10.1088/1755-1315/548/8/082081/pdf";

        var expected = "IOP Publishing";

        var result = ArticleFromForeignCollection.GetPublishingHouseScientificCollection(citation);
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetPublishingHouse_cityIsSpecifiedTest()
    {
        var citation = "Accuracy assessment of the mechatronic unit control system with flexible links / М.Ю. Ветлицын, Ю.А. Ветлицын, Г.Ю. Прокудин, Н.Г. Шаронов // AIP Conference Proceedings. Vol. 2697, issue 1 : Proceedings of 33rd International Conference of Young Scientists and Students «Topical Problems of Mechanical Engineering» (ToPME 2021) (Moscow, Russia, 30 November – 2 December 2021) / eds.: M. Prozhega [et al.] ; Blagonravov Mechanical Engineering Research Institute of the Russian Academy of Sciences (IMASH RAN). – [USA : AIP Publishing], 2023. – Article 070010. – 6 p. – DOI: https://doi.org/10.1063/5.0111991.";

        var expected = "AIP Publishing";

        var result = ArticleFromForeignCollection.GetPublishingHouseScientificCollection(citation);
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetDOI_SimpleTest()
    {
        var citation = "Accuracy assessment of the mechatronic unit control system with flexible links / М.Ю. Ветлицын, Ю.А. Ветлицын, Г.Ю. Прокудин, Н.Г. Шаронов // AIP Conference Proceedings. Vol. 2697, issue 1 : Proceedings of 33rd International Conference of Young Scientists and Students «Topical Problems of Mechanical Engineering» (ToPME 2021) (Moscow, Russia, 30 November – 2 December 2021) / eds.: M. Prozhega [et al.] ; Blagonravov Mechanical Engineering Research Institute of the Russian Academy of Sciences (IMASH RAN). – [USA : AIP Publishing], 2023. – Article 070010. – 6 p. – DOI: https://doi.org/10.1063/5.0111991.";

        var expected = "DOI: https://doi.org/10.1063/5.0111991.";

        var result = ArticleFromForeignCollection.GetDOIScientificCollection(citation);
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetURL_SimpleTest()
    {
        var citation = "Analysis of Existing Diagnostic Methods for the Linear Insulator Risk-Based Maintenance / О.О. Ахмедова, Д. Титов, К.В. Волхов // 2023 International Conference on Industrial Engineering, Applications and Manufacturing (ICIEAM) (Sochi, Russian Federation,15-19 May 2023) : Proceedings / Moscow Polytechnic University, Kazan State Power Engineering University. – [Publisher: IEEE (Institute of Electrical and Electronics Engineers)], 2023. – P. 52-57. – DOI: 10.1109/ICIEAM57311.2023.10139251. – URL: https://ieeexplore.ieee.org/document/10139251";

        var expected = "URL: https://ieeexplore.ieee.org/document/10139251";

        var result = ArticleFromForeignCollection.GetURLScientificCollection(citation);
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetUniversities_SimpleTest()
    {
        var citation = "Analysis of Existing Diagnostic Methods for the Linear Insulator Risk-Based Maintenance / О.О. Ахмедова, Д. Титов, К.В. Волхов // 2023 International Conference on Industrial Engineering, Applications and Manufacturing (ICIEAM) (Sochi, Russian Federation,15-19 May 2023) : Proceedings / Moscow Polytechnic University, Kazan State Power Engineering University. – [Publisher: IEEE (Institute of Electrical and Electronics Engineers)], 2023. – P. 52-57. – DOI: 10.1109/ICIEAM57311.2023.10139251. – URL: https://ieeexplore.ieee.org/document/10139251";

        List<Company> universities = new List<Company>();
        universities.Add(new Company(){Name = "Moscow Polytechnic University"});
        universities.Add(new Company(){Name = "Kazan State Power Engineering University"});

        var result = ArticleFromForeignCollection.GetCompanyScientificCollection(citation);

        Assert.Equal(universities.Count, result.Count);
        for (int i = 0; i < universities.Count; i++)
        {
            Assert.Equal(universities[i].Name, result[i].Name);
        }
    }
    
    [Fact]
    public void GetUniversities_NullTest()
    {
        var citation = "Competitive funding for research in developing countries: Institutional context / С.В. Проничкин, В.Л. Розалиев, I.B. Mamai // AIP Conference Proceedings. Vol. 2467 : 2nd International Conference on Advances in Materials, Systems and Technologies (CAMSTech 2021) (Krasnoyarsk, Russia, 29-31 July 2021) : proceedings / eds.: I. Kovalev [et al.]. – AIP Publishing, 2022. – Article 040016. – DOI: 10.1063/5.0092501. – URL: https://aip.scitation.org/doi/pdf/10.1063/5.0092501.";

        var result = ArticleFromForeignCollection.GetCompanyScientificCollection(citation);

        Assert.Empty(result);
    }
    
    [Fact]
    public void GetCities_SimpleTest()
    {
        var citation = "Marginal Effects Models of Scientific and Technological Fields’ Integration in Heterogeneous Systems / В.Л. Розалиев, С.В. Проничкин, А.Р. Донская, О.К. Касымов, Аг.С. Кузнецова // Data Science and Algorithms in Systems : Proceedings of 6th Computational Methods in Systems and Software (CoMeSySo 2022) Conference (October 2022). Vol. 2 / eds.: Radek Silhavy [et al.]. – Cham (Switzerland) : Springer Nature Switzerland AG, 2023. – P. 926-932. – DOI: https://doi.org/10.1007/978-3-031-21438-7_79. – (Book ser.: Lecture Notes in Networks and Systems (LNNS) ; vol. 597)";

        List<City> cities = new List<City>();
        cities.Add(new City() {Name = "Cham", Country = "Switzerland"});

        var result = ArticleFromForeignCollection.GetCitiesScientificCollection(citation);

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
        var citation = "Investigation of the Accumulation Process of Municipal Solid Waste in Trade Facilities of the Stationary Retail Network / Н.В. Мензелинцева, О.С. Власова, Н.Ю. Карапузова, О.В. Жиркова, И.М. Статюха // AIP Conference Proceedings. Vol. 2700 : IV International Scientific Conference on Advanced Technologies in Aerospace, Mechanical and Automation Engineering (MIST: Aerospace-IV 2021) (10–11 December 2021, Krasnoyarsk, Russian Federation) : proceedings / eds.: I. Kovalev, A. Voroshilova. – AIP Publishing, 2023. – Article 050022. – 9 p. - DOI: https://doi.org/10.1063/5.0126402. – URL: https://aip.scitation.org/doi/10.1063/5.0126402.";

        List<City> cities = new List<City>();

        var result = ArticleFromForeignCollection.GetCitiesScientificCollection(citation);

        Assert.Equal(cities.Count, result.Count);
        for (int i = 0; i < cities.Count; i++)
        {
            Assert.Equal(cities[i].Name, result[i].Name);
            Assert.Equal(cities[i].Country, result[i].Country);
        }
    }
    
    [Fact]
    public void GetCities_NullWithoutPublishingTest()
    {
        var citation = "Ontology-based method of electronic learning resources retrieval and integration / М.Б. Кульцова, А.В. Аникин, И.Г. Жукова // IISA 2015 – 6th International Conference on Information, Intelligence, Systems and Applications (Corfu, Greece, 6 July 2015 – 8 July 2015) : Conference Proceeding / Ionian University, Institute of Electrical and Electronics Engineers (IEEE) [Piscataway, USA]. – 2015. – Art. no. 7388112.";

        List<City> cities = new List<City>();

        var result = ArticleFromForeignCollection.GetCitiesScientificCollection(citation);

        Assert.Equal(cities.Count, result.Count);
        for (int i = 0; i < cities.Count; i++)
        {
            Assert.Equal(cities[i].Name, result[i].Name);
            Assert.Equal(cities[i].Country, result[i].Country);
        }
    }
    
    [Fact]
    public void GetCities_CountryOnlyTest()
    {
        var citation = "Источники по истории российской антивоенной мысли второй половины XIX – начала XX вв.: многообразие форм и смыслов / Н.Ю. Николаев // Актуальные проблемы источниковедения : материалы VII Междунар. науч.-практ. конф. (г. Витебск, 27–29 апреля 2023 г.). В 2 т. Т. 2 / редкол.: А. Н. Дулов, М. Ф. Румянцева (отв. ред.) [и др.] ; Витебский гос. университет им. П. М. Машерова. – Витебск, 2023. – С. 103-105";

        List<City> cities = new List<City>();
        cities.Add(new City(){Name = "Витебск"});

        var result = ArticleFromForeignCollection.GetCitiesScientificCollection(citation);

        Assert.Equal(cities.Count, result.Count);
        for (int i = 0; i < cities.Count; i++)
        {
            Assert.Equal(cities[i].Name, result[i].Name);
            Assert.Equal(cities[i].Country, result[i].Country);
        }
    }
    
    [Fact]
    public void GetCities_TwoCitiesTest()
    {
        var citation = "Best Practices for Inclusiveness by Top Universities and Their Openness to Persons with Disabilities in the More Developed Countries / Е.С. Акопова, Д.О. Забазнова, И.А. Тарасова, М.А. Болокова // Social Mobility, Social Inequality, and the Role of Higher Education / eds.: E. G. Popkova [et al.]. – Leiden (Netherlands) ; Boston (USA) : Brill, 2023. – Chapter 11. – P. 169-179. – DOI: https://doi.org/10.1163/9789004540019_013. – URL: https://brill.com/display/book/9789004540019/BP000014.xml. – (Book ser.: Studies in Critical Social Sciences ; vol. 254) ";

        List<City> cities = new List<City>();
        cities.Add(new City(){Name = "Leiden", Country = "Netherlands"});
        cities.Add(new City() {Name = "Boston", Country = "USA"});

        var result = ArticleFromForeignCollection.GetCitiesScientificCollection(citation);

        Assert.Equal(cities.Count, result.Count);
        for (int i = 0; i < cities.Count; i++)
        {
            Assert.Equal(cities[i].Name, result[i].Name);
            Assert.Equal(cities[i].Country, result[i].Country);
        }
    }
    
    [Fact]
    public void GetEditor_SimpleTest()
    {
        var citation = "Best Practices for Inclusiveness by Top Universities and Their Openness to Persons with Disabilities in the More Developed Countries / Е.С. Акопова, Д.О. Забазнова, И.А. Тарасова, М.А. Болокова // Social Mobility, Social Inequality, and the Role of Higher Education / eds.: E. G. Popkova [et al.]. – Leiden (Netherlands) ; Boston (USA) : Brill, 2023. – Chapter 11. – P. 169-179. – DOI: https://doi.org/10.1163/9789004540019_013. – URL: https://brill.com/display/book/9789004540019/BP000014.xml. – (Book ser.: Studies in Critical Social Sciences ; vol. 254) ";

        List<Editor> editors = new List<Editor>();
        editors.Add(new Editor(){Name = "E. G. Popkova"});

        var result = ArticleFromForeignCollection.GetEditorScientificCollection(citation);

        Assert.Equal(editors.Count, result.Count);
        for (int i = 0; i < editors.Count; i++)
        {
            Assert.Equal(editors[i].Name, result[i].Name);
        }
    }
    
    [Fact]
    public void GetEditor_PublicationsContainsCompanyTest()
    {
        var citation = "Studying the Process of Honing with Preliminary Cryogenic Treatment of Products from Low-Carbon Steels / Нкеуа Д.А. Ивон, О.А. Курсин, А.А. Жданов, М.Ю. Полянчикова, А. Соловьев // Proceedings of the 8th International Conference on Industrial Engineering. ICIE 2022 (May 16-20, 2022 ; virtual conference) / eds.: A. A. Radionov, V. R. Gasiyarov ; Moscow Polytechnic University, Tula State University, Volgograd State Technical University. – Cham (Switzerland) : Springer Nature Switzerland AG, 2023. – P. 944-954. – DOI: https://doi.org/10.1007/978-3-031-14125-6_92. – (Book ser. Lecture Notes in Mechanical Engineering – LNME).";

        List<Editor> editors = new List<Editor>();
        editors.Add(new Editor(){Name = "A. A. Radionov"});
        editors.Add(new Editor(){Name = "V. R. Gasiyarov"});

        var result = ArticleFromForeignCollection.GetEditorScientificCollection(citation);

        Assert.Equal(editors.Count, result.Count);
        for (int i = 0; i < editors.Count; i++)
        {
            Assert.Equal(editors[i].Name, result[i].Name);
        }
    }
    
    [Fact]
    public void GetArticleNumber_SimpleTest()
    {
        var citation = "Structure and phase composition of aluminide coating formed on nickel-based alloy / А.И. Богданов, В.Г. Шморгун, В.П. Кулевич, Р.Д. Евчиц // AIP Conference Proceedings. Vol. 2697, issue 1 : Proceedings of 33rd International Conference of Young Scientists and Students «Topical Problems of Mechanical Engineering» (ToPME 2021) (Moscow, Russia, 30 November – 2 December 2021) / eds.: M. Prozhega [et al.] ; Blagonravov Mechanical Engineering Research Institute of the Russian Academy of Sciences (IMASH RAN). – [USA : AIP Publishing], 2023. – Article 020001. – 5 p. – DOI: https://doi.org/10.1063/5.0111923";

        var expected = "Article 020001";

        var result = ArticleFromForeignCollection.GetArticleNumberScientificCollection(citation);
        
        Assert.Equal(expected, result);
    }
}
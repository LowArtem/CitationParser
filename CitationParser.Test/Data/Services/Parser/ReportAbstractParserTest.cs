using System.Text.RegularExpressions;
using CitationParser.Data.Services.Parser;

namespace CitationParser.Test.Data.Services.Parser;

public class ReportAbstractParserTest
{
    [Fact]
    public void GetEditors_SimpleTest()
    {
        const string citation = """
                                Синтез и свойства 1,3-дизамещенных мочевин и их биоизостерических аналогов, содержащих полициклические
                                фрагменты – ингибиторов растворимой эпоксидгидролазы (sEH) / В.В. Бурмистров, Г.М. Бутов // Сборник
                                тезисов докладов Восьмой Междисциплинарной конференции «Молекулярные и Биологические аспекты Химии,
                                Фармацевтики и Фармакологии» (МОБИ-ХимФарма2023) (г. Санкт-Петербург, 24-27 апреля 2023 г.) / под ред. К. В.
                                Кудрявцева, Е. М. Паниной ; Российский национальный исследовательский медицинский университет им. Н. И.
                                Пирогова, Российский гос. педагогический университет им. А. И. Герцена, Бюро медицинской и фармацевтической
                                информации «РИХТ». - Москва, 2023. - C. 22
                                """;

        var editors = ReportAbstractsParser.GetEditors(citation);
        var editorsString = editors
            .Select(x => Regex.Replace(x.Name, @"[\n\r\t]", " "))
            .Select(x => Regex.Replace(x, "  ", " "))
            .ToList();

        var expected = new List<string>() { "К. В. Кудрявцева", "Е. М. Паниной" };

        Assert.True(expected.SequenceEqual(editorsString));
    }

    [Fact]
    public void GetCompany_WithEditorsTest()
    {
        const string citation = """
                                Синтез и свойства 1,3-дизамещенных мочевин и их биоизостерических аналогов, содержащих полициклические
                                фрагменты – ингибиторов растворимой эпоксидгидролазы (sEH) / В.В. Бурмистров, Г.М. Бутов // Сборник
                                тезисов докладов Восьмой Междисциплинарной конференции «Молекулярные и Биологические аспекты Химии,
                                Фармацевтики и Фармакологии» (МОБИ-ХимФарма2023) (г. Санкт-Петербург, 24-27 апреля 2023 г.) / под ред. К. В.
                                Кудрявцева, Е. М. Паниной ; Российский национальный исследовательский медицинский университет им. Н. И.
                                Пирогова, Российский гос. педагогический университет им. А. И. Герцена, Бюро медицинской и фармацевтической
                                информации «РИХТ». - Москва, 2023. - C. 22
                                """;

        var expected = new List<string>
        {
            "Российский национальный исследовательский медицинский университет им. Н. И. Пирогова",
            "Российский гос. педагогический университет им. А. И. Герцена",
            "Бюро медицинской и фармацевтической информации «РИХТ»"
        };

        var companies = ReportAbstractsParser.GetCompanies(citation);
        var companiesString = companies?.Select(x => Regex.Replace(x.Name, @"[\n\r\t]", " "))
            .Select(x => Regex.Replace(x, "  ", " "))
            .ToList();

        Assert.True(expected.SequenceEqual(companiesString ?? new List<string>()));
    }

    [Fact]
    public void GetCompany_WithoutEditorsTest()
    {
        const string citation = """
                                Приложение для анализа видеофайлов для оценки поведения грызунов (крыс и мышей) в лабиринтах,
                                используемых в лабораторных исследованиях : [описание плаката] / С.В. Кравченко, Ю.А. Орлова, А.В. Алексеев,
                                И.Л. Гринин, Д.С. Матюшечкин // Параллельные вычислительные технологии – XV : международная конференция
                                ПаВТ'2021 (г. Волгоград, 30 марта – 1 апреля 2021 г.) : короткие статьи и описания
                                плакатов / РАН, Суперкомпьютерный консорциум университетов России, РФФИ. - Челябинск, 2021. - C. 282. – URL :http://omega.sp.susu.ru/pavt2021/proceedings.pdf.
                                """;

        var expected = new List<string>
        {
            "РАН",
            "Суперкомпьютерный консорциум университетов России",
            "РФФИ"
        };

        var companies = ReportAbstractsParser.GetCompanies(citation);
        var companiesString = companies?
            .Select(x => Regex.Replace(x.Name, @"[\n\r\t]", " "))
            .Select(x => Regex.Replace(x, "  ", " "))
            .ToList();

        Assert.Equal(expected.ToHashSet(), companiesString?.ToHashSet() ?? new HashSet<string>());
    }

    [Fact]
    public void GetCompany_NullTest()
    {
        const string citation = """
                                Резонансная двухфотонная спектроскопия колебательных состояний молекул при четырёхволновом смешении
                                частот / В.С. Должиков, Ю.С. Должиков, А.А. Макаров, В.Г. Мовшев, Е.А. Рябов // Тезисы докладов
                                XII всесоюзной конференции по когерентной и нелинейной оптике (Москва, 26-29 авг. 1985 г.). Ч. II : Секции
                                X-XIX. - М., 1985. - C. 496-497.
                                """;

        var companies = ReportAbstractsParser.GetCompanies(citation);
        Assert.True(companies.Count == 0);
    }
    
    [Fact]
    public void GetCity_SimpleTest()
    {
        const string citation = """
                                Синтез и свойства 1,3-дизамещенных мочевин и их биоизостерических аналогов, содержащих полициклические
                                фрагменты – ингибиторов растворимой эпоксидгидролазы (sEH) / В.В. Бурмистров, Г.М. Бутов // Сборник
                                тезисов докладов Восьмой Междисциплинарной конференции «Молекулярные и Биологические аспекты Химии,
                                Фармацевтики и Фармакологии» (МОБИ-ХимФарма2023) (г. Санкт-Петербург, 24-27 апреля 2023 г.) / под ред. К. В.
                                Кудрявцева, Е. М. Паниной ; Российский национальный исследовательский медицинский университет им. Н. И.
                                Пирогова, Российский гос. педагогический университет им. А. И. Герцена, Бюро медицинской и фармацевтической
                                информации «РИХТ». - Москва, 2023. - C. 22
                                """;

        var cities = ReportAbstractsParser.GetCity(citation);
        var citiesString = cities
            .Select(x => Regex.Replace(x.Name, @"[\n\r\t]", " "))
            .Select(x => Regex.Replace(x, "  ", " "))
            .ToList();

        var expected = new List<string>() { "Москва" };

        Assert.True(expected.SequenceEqual(citiesString));
    }
    
    [Fact]
    public void GetCity_MultiplyTest()
    {
        const string citation = """
                                Влияние режимов теплообработки на фазоформирование и размеры наночастиц BiFeO(3), 
                                синтезированных золь-гель методом / Ньян Тхи Лыу, А.Г. Шеин // ВНКСФ–25. Двадцать пятая 
                                Всероссийская научная конференция студентов-физиков и молодых учёных (Республика Крым, 19-26 
                                апреля 2019 г.) : материалы (сб. тез.) конф. Информационный бюллетень / под общ. ред. А. 
                                Арапова ; Ассоциация студентов-физиков и молодых учёных России, Крымский федеральный ун-т им. 
                                В. И. Вернадского, Физико-технический ин-т КФУ, Крымская астрофизическая обсерватория РАН, Ин-т 
                                электрофизики УрО РАН, Южный федеральный ун-т. - Екатеринбург ; Ростов-на-Дону ; Севастополь, 
                                2019. - C. 143.
                                """;

        var cities = ReportAbstractsParser.GetCity(citation);
        var citiesString = cities
            .Select(x => Regex.Replace(x.Name, @"[\n\r\t]", " "))
            .Select(x => Regex.Replace(x, "  ", " "))
            .ToList();

        var expected = new List<string>() { "Екатеринбург", "Ростов-на-Дону", "Севастополь" };

        Assert.True(expected.SequenceEqual(citiesString));
    }
    
    [Fact]
    public void GetYear_SimpleTest()
    {
        const string citation = """
                                Синтез и свойства 1,3-дизамещенных мочевин и их биоизостерических аналогов, содержащих полициклические
                                фрагменты – ингибиторов растворимой эпоксидгидролазы (sEH) / В.В. Бурмистров, Г.М. Бутов // Сборник
                                тезисов докладов Восьмой Междисциплинарной конференции «Молекулярные и Биологические аспекты Химии,
                                Фармацевтики и Фармакологии» (МОБИ-ХимФарма2023) (г. Санкт-Петербург, 24-27 апреля 2023 г.) / под ред. К. В.
                                Кудрявцева, Е. М. Паниной ; Российский национальный исследовательский медицинский университет им. Н. И.
                                Пирогова, Российский гос. педагогический университет им. А. И. Герцена, Бюро медицинской и фармацевтической
                                информации «РИХТ». - Москва, 2023. - C. 22
                                """;

        var year = ReportAbstractsParser.GetYear(citation);

        var expected = "2023";

        Assert.Equal(expected, year);
    }
    
    [Fact]
    public void GetURL_SimpleTest()
    {
        const string citation = """
                                 Последствия санкций для российских банков / А.А. Сложеникина, К.А. Шабалкина, Ю.Г. Оноприенко // XXVIII Межвузовская научно–практическая конференция молодых ученых и студентов г. Волжского (г. Волжский, 29 мая – 2 июня 2023 г.) : материалы конф. / отв. за вып.: Г. М. Бутов ; ВПИ (филиал) ФГБОУ ВО ВолгГТУ [и др.]. - Волжский, 2023. - C. 341-342. – URL: https://volpi.ru/science/science_conference.
                                """;

        var url = ReportAbstractsParser.GetUrl(citation);

        var expected = "URL: https://volpi.ru/science/science_conference.";

        Assert.Equal(expected, url);
    }
    
    [Fact]
    public void GetURL_NullTest()
    {
        const string citation = """
                                Синтез и свойства 1,3-дизамещенных мочевин и их биоизостерических аналогов, содержащих полициклические
                                фрагменты – ингибиторов растворимой эпоксидгидролазы (sEH) / В.В. Бурмистров, Г.М. Бутов // Сборник
                                тезисов докладов Восьмой Междисциплинарной конференции «Молекулярные и Биологические аспекты Химии,
                                Фармацевтики и Фармакологии» (МОБИ-ХимФарма2023) (г. Санкт-Петербург, 24-27 апреля 2023 г.) / под ред. К. В.
                                Кудрявцева, Е. М. Паниной ; Российский национальный исследовательский медицинский университет им. Н. И.
                                Пирогова, Российский гос. педагогический университет им. А. И. Герцена, Бюро медицинской и фармацевтической
                                информации «РИХТ». - Москва, 2023. - C. 22
                                """;

        var url = ReportAbstractsParser.GetUrl(citation);

        Assert.Null(url);
    }
    
    [Fact]
    public void GetPages_SimpleTest()
    {
        const string citation = """
                                 Последствия санкций для российских банков / А.А. Сложеникина, К.А. Шабалкина, Ю.Г. Оноприенко // XXVIII Межвузовская научно–практическая конференция молодых ученых и студентов г. Волжского (г. Волжский, 29 мая – 2 июня 2023 г.) : материалы конф. / отв. за вып.: Г. М. Бутов ; ВПИ (филиал) ФГБОУ ВО ВолгГТУ [и др.]. - Волжский, 2023. - C. 341-342. – URL: https://volpi.ru/science/science_conference.
                                """;

        var pages = ReportAbstractsParser.GetPages(citation);

        var expected = "C. 341-342";

        Assert.Equal(expected, pages);
    }
    
    [Fact]
    public void GetPages_OnePageTest()
    {
        const string citation = """
                                Подход к расчету экологического следа городских жителей / К.С. Айрапетян, А.С. Маковкин // Конкурс научно-исследовательских работ студентов Волгоградского государственного технического университета (г. Волгоград, 24-28 апреля 2023 г.) : тез. докл. / редкол.: С. В. Кузьмин (отв. ред.) [и др.] ; ВолгГТУ, Отдел координации научных исследований молодых ученых УНиИ, Общество молодых ученых. - Волгоград, 2023. - C. 467.
                                """;

        var pages = ReportAbstractsParser.GetPages(citation);

        var expected = "C. 467.";

        Assert.Equal(expected, pages);
    }
    
    [Fact]
    public void GetPages_EnglishTest()
    {
        const string citation = """
                                 VAR-method based AI-system for predicting financial risk in realeconomy of Russia in conditions of modern digital transformation / Н.И. Ломакин, M. Safonova, M. Maramygin, А.В. Катаев, Yu. Sigidov, N. Maliy // III International Scientific and Practical Conference «Digital Economy and Finances» (St. Petersburg, March 19-20, 2020) : Book of Abstracts / St. Petersburg University of Management Technologies and Economics [et al.]. - Saint Petersburg, 2020. - P. 37-38.
                                """;

        var pages = ReportAbstractsParser.GetPages(citation);

        var expected = "P. 37-38.";

        Assert.Equal(expected, pages);
    }
}
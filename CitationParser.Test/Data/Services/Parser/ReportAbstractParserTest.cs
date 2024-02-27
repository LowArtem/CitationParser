﻿using System.Text.RegularExpressions;
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
}
using CitationParser.Data.Model;
using CitationParser.Data.Services.Parser;

namespace CitationParser.Test.Data.Services.Parser;

public class PatentDocumentAndCertificateParserTest
{
    [Fact]
    public void GetUniversities_SimpleTest()
    {
        const string citation1 =
            "Пат. 2396900 РФ, МПК A 61 B 5/05, A 61 B 17/60. Аппарат для оценки степени восстановления костной ткани / А.С. Баринов, А. Воробьев, Ю.П. Муха, С.А. Русаков, М.М. Гольдреер, А.С. Пономарев, Р.В. Литовкин; ООО \"Центр антропометрической (ортопедической) косметологии и коррекции\" , ГОУ ВПО ВолгГТУ. - 2010.";

        const string citation2 =
            "Свид. о гос. регистрации программы для ЭВМ № 2019613591 от 19 марта 2019 г. Российская Федерация. «Умная» система управления финансовым риском на основе реального опциона по модели Кокса–Росса–Рубинштейна / Н.И. Ломакин, С.П. Сазонов, О.О. Дроботова, Г.И. Лукьянов, О.Н. Максимова, А.В. Петрухин, О.А. Голодова, А.В. Шохнех, К.В. Фадеева, Е.Е. Харламова; ВолгГТУ. - 2019.";

        var expected1 = new List<Company>()
        {
            new() { Name = "ООО \"Центр антропометрической (ортопедической) косметологии и коррекции\"" },
            new() { Name = "ГОУ ВПО ВолгГТУ" }
        };

        var expected2 = new List<Company>()
        {
            new() { Name = "ВолгГТУ" }
        };

        var result1 = PatentDocumentAndCertificateParser.GetCompanies(citation1);
        var result2 = PatentDocumentAndCertificateParser.GetCompanies(citation2);

        Assert.Equal(expected1.Select(e => e.Name), result1.Select(r => r.Name));
        Assert.Equal(expected2.Select(e => e.Name), result2.Select(r => r.Name));
    }
    
    [Fact]
    public void GetUniversities_WithRightHolderTest()
    {
        const string citation1 =
            "Свид. о гос. регистрации программы для ЭВМ № 2018619882 от 14 сентября 2018 г. Российская Федерация. Расчёт устойчивости стержневых систем по методу конечных элементов в форме классического смешанного метода / А.В. Игнатьев; Правообладатель: Игнатьев Александр Владимирович. - 2018";
        
        var result1 = PatentDocumentAndCertificateParser.GetCompanies(citation1);

        Assert.Empty(result1);
    }
    
    [Fact]
    public void GetRightHolder_SimpleTest()
    {
        const string citation1 =
            "Свид. о гос. регистрации программы для ЭВМ № 2019611906 от 6 февраля 2019 г. Российская Федерация. Веб-сервис для перевода пиктограммных сообщений в связный текст на русском языке / Д.С. Матюшечкин; правообладатель: Матюшечкин Дмитрий Сергеевич. - 2019.";

        const string citation2 =
            "Свид. о гос. регистрации программы для ЭВМ № 2021611490 от 28.01.2021 Российская Федерация. B2Doc: Стенокардия - сервер / Ю.А. Орлова, А.В. Зубков, Н.Д. Сибирный, Я.Е. Каменнов, А.Р. Донская, Аг.С. Кузнецова, А.П. Кулевич, Е.А. Шурлаева, М.Ю. Фролов, Ю.М. Лопатин, А.И. Каборгина; правообладатель: ФГБОУ ВО \"ВолгГТУ\". - 2021.";

        var expected1 = "Матюшечкин Дмитрий Сергеевич";

        var expected2 = "ФГБОУ ВО \"ВолгГТУ\"";

        var result1 = PatentDocumentAndCertificateParser.GetRightHolder(citation1);
        var result2 = PatentDocumentAndCertificateParser.GetRightHolder(citation2);

        Assert.Equal(expected1, result1);
        Assert.Equal(expected2, result2);
    }
    
    [Fact]
    public void GetUniversities_WithCopyrightHolderTest()
    {
        const string citation1 =
            "Свид. о гос. регистрации программы для ЭВМ № 2021667237 от 27.10.2021 Российская Федерация. Панель управления лицензиями продуктов с возможностью просмотра статистики / Ю.А. Орлова, А.В. Зубков, Е.С. Тарапатина, В.А. Литвиненко, И.А. Самоходкина, А.Р. Донская; ФГБОУ ВО ВолгГТУ. - 2021.";
        
        var result1 = PatentDocumentAndCertificateParser.GetRightHolder(citation1);

        Assert.Null(result1);
    }

    [Fact]
    public void GetYear_SimpleTest()
    {
        const string citation1 =
            "Пат. 2396900 РФ, МПК A 61 B 5/05, A 61 B 17/60. Аппарат для оценки степени восстановления костной ткани / А.С. Баринов, А. Воробьев, Ю.П. Муха, С.А. Русаков, М.М. Гольдреер, А.С. Пономарев, Р.В. Литовкин; ООО \"Центр антропометрической (ортопедической) косметологии и коррекции\" , ГОУ ВПО ВолгГТУ. - 2010.";

        const string citation2 =
            "Свид. о гос. регистрации программы для ЭВМ № 2019613591 от 19 марта 2019 г. Российская Федерация. «Умная» система управления финансовым риском на основе реального опциона по модели Кокса–Росса–Рубинштейна / Н.И. Ломакин, С.П. Сазонов, О.О. Дроботова, Г.И. Лукьянов, О.Н. Максимова, А.В. Петрухин, О.А. Голодова, А.В. Шохнех, К.В. Фадеева, Е.Е. Харламова; ВолгГТУ. - 2019.";

        const string expected1 = "2010";
        const string expected2 = "2019";

        var result1 = PatentDocumentAndCertificateParser.GetYear(citation1);
        var result2 = PatentDocumentAndCertificateParser.GetYear(citation2);

        Assert.Equal(expected1, result1);
        Assert.Equal(expected2, result2);
    }
}
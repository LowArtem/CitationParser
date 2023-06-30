using CitationParser.Data.Model;
using CitationParser.Data.Services.Parser;

namespace CitationParser.Test.Data.Services.Parser;

public class PatentDocumentAndCertificateParserTest
{
    [Fact]
    public void GetUniversities_SimpleTest()
    {
        const string citation1 = "Пат. 2396900 РФ, МПК A 61 B 5/05, A 61 B 17/60. Аппарат для оценки степени восстановления костной ткани / А.С. Баринов, А. Воробьев, Ю.П. Муха, С.А. Русаков, М.М. Гольдреер, А.С. Пономарев, Р.В. Литовкин; ООО \"Центр антропометрической (ортопедической) косметологии и коррекции\" , ГОУ ВПО ВолгГТУ. - 2010.";

        const string citation2 =
            "Свид. о гос. регистрации программы для ЭВМ № 2019613591 от 19 марта 2019 г. Российская Федерация. «Умная» система управления финансовым риском на основе реального опциона по модели Кокса–Росса–Рубинштейна / Н.И. Ломакин, С.П. Сазонов, О.О. Дроботова, Г.И. Лукьянов, О.Н. Максимова, А.В. Петрухин, О.А. Голодова, А.В. Шохнех, К.В. Фадеева, Е.Е. Харламова; ВолгГТУ. - 2019.";
        
        var expected1 = new List<University>()
        {
            new University() { Name = "ООО \"Центр антропометрической (ортопедической) косметологии и коррекции\"" },
            new University() { Name = "ГОУ ВПО ВолгГТУ" },
        };

        var expected2 = new List<University>()
        {
            new University() { Name = "ВолгГТУ" }
        };
        
        var result1 = PatentDocumentAndCertificateParser.GetUniversities(citation1);
        var result2 = PatentDocumentAndCertificateParser.GetUniversities(citation2);
        
        Assert.Equal(expected1.Select(e => e.Name), result1.Select(r => r.Name));
        Assert.Equal(expected2.Select(e => e.Name), result2.Select(r => r.Name));
    }

    [Fact]
    public void GetYear_SimpleTest()
    {
        const string citation1 = "Пат. 2396900 РФ, МПК A 61 B 5/05, A 61 B 17/60. Аппарат для оценки степени восстановления костной ткани / А.С. Баринов, А. Воробьев, Ю.П. Муха, С.А. Русаков, М.М. Гольдреер, А.С. Пономарев, Р.В. Литовкин; ООО \"Центр антропометрической (ортопедической) косметологии и коррекции\" , ГОУ ВПО ВолгГТУ. - 2010.";

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
using CitationParser.Data.Model;
using CitationParser.Data.Services.Parser;

namespace CitationParser.Test.Data.Services.Parser;

public class CitationParseFunctionsTest
{
    [Fact]
    public void GetName_SimpleTest()
    {
        var citation =
            "Пат. 2788145 Российская Федерация, МПК C08G 79/04, C09K 21/12, C09K 21/14 Применение олигоэфиракрилата ((((1-(4-(2-(4-(3-(4-(2-(4-(2-((((1-(аллилокси))-3-хлорпропан-2-ил)окси)((1-хлор-3-(метакрилоилокси)пропан-2-ил)окси)фосфато)окси)-3-хлорпропокси)фенил)пропан-2-ил)фенокси)-2-гидроксипропокси)фенил)пропан-2-ил)фенокси)-3-хлорпропан-2-ил)окси)фосфатдиил)бис(окси))бис(3-хлорпропан-2,1-диил)бис(2-метилакрилата) в качестве олигомера для получения термо- и теплостойких полимеров с пониженной горючестью / Б.А. Буравов, Е.С. Бочкарев, Н.Х. Гричишкина, О.О. Тужиков, О.И. Тужиков, В.Г. Кочетков, Н.В. Сидоренко, С.В. Борисов, А. Аль-Хамзави, С.М. Соломахин; ФГБОУ ВО ВолгГТУ. - 2022";

        var expected =
            "Пат. 2788145 Российская Федерация, МПК C08G 79/04, C09K 21/12, C09K 21/14 Применение олигоэфиракрилата ((((1-(4-(2-(4-(3-(4-(2-(4-(2-((((1-(аллилокси))-3-хлорпропан-2-ил)окси)((1-хлор-3-(метакрилоилокси)пропан-2-ил)окси)фосфато)окси)-3-хлорпропокси)фенил)пропан-2-ил)фенокси)-2-гидроксипропокси)фенил)пропан-2-ил)фенокси)-3-хлорпропан-2-ил)окси)фосфатдиил)бис(окси))бис(3-хлорпропан-2,1-диил)бис(2-метилакрилата) в качестве олигомера для получения термо- и теплостойких полимеров с пониженной горючестью";

        var result = CitationParseFunctions.GetName(citation);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetAuthors_SimpleTest()
    {
        var citation1 =
            @"Восстановление ударной вязкости подвергнутой сварочному нагреву стали 01Х17М2ФБ за счет термоциклической обработки: Депонированная рукопись/ И.И. Жукова, Н.А. Бубнов, А.И. Гришина, А.В. Назаров, В.А. Куликов; Волгогр. гос. пед. ун-т. - Волгоград, 1995. - 8 c. - Деп. в Депонированная рукопись 1995-05-29, № 1512.";

        var citation2 =
            @"Content of Secondary Education in the Russian Empire in the second half of the 19th century (the Example of Ust-Medveditsky Women's Secondary School of the Don Cossack Host) (Содержание гимназического образования в Российской империи второй половины XIX века (на примере Усть-Медведицкой женской гимназии области Войска Донского)) / А.А. Соловьев, А.В. Захаров, Н.Л. Виноградова, Л.С. Соловьева // Bylye Gody (Былые годы) : электрон. журнал. - 2022. - Vol. 17, issue 1. – P. 378-385. – DOI: 10.13187/bg.2022.1.378. – URL: https://bg.cherkasgu.press/journals_n/1646150680.pdf";

        var expected1 = new List<Author>()
        {
            new("И.И. Жукова"),
            new("Н.А. Бубнов"),
            new("А.И. Гришина"),
            new("А.В. Назаров"),
            new("В.А. Куликов")
        };

        var expected2 = new List<Author>()
        {
            new("А.А. Соловьев"),
            new("А.В. Захаров"),
            new("Н.Л. Виноградова"),
            new("Л.С. Соловьева")
        };

        var result1 = CitationParseFunctions.GetAuthors(citation1, true);
        var result2 = CitationParseFunctions.GetAuthors(citation2);

        Assert.Equal(expected1.Select(e => e.Name), result1.Select(r => r.Name));
        Assert.Equal(expected2.Select(e => e.Name), result2.Select(r => r.Name));
    }
    
        [Fact]
    public void GetUrl_SimpleTest()
    {
        const string citation1 =
            "Content of Secondary Education in the Russian Empire in the second half of the 19th century (the Example of Ust-Medveditsky Women's Secondary School of the Don Cossack Host) (Содержание гимназического образования в Российской империи второй половины XIX века (на примере Усть-Медведицкой женской гимназии области Войска Донского)) / А.А. Соловьев, А.В. Захаров, Н.Л. Виноградова, Л.С. Соловьева // Bylye Gody (Былые годы) : электрон. журнал. - 2022. - Vol. 17, issue 1. – P. 378-385. – DOI: 10.13187/bg.2022.1.378. – URL: https://bg.cherkasgu.press/journals_n/1646150680.pdf";

        const string citation2 =
            "Peculiar properties of the electron beam dynamics simulation by particle-particle methods taking into account delay effects / С.А. Аликов, А.Г. Шеин // ITM Web of Conferences. - 2019. - Vol. 30 : 29th International Crimean Conference «Microwave & Telecommunication Technology» (CriMiCo’2019) (Sevastopol, Russia, September 8-14, 2019) / ed. by P. Yermolov. – 9 p. – DOI: https://doi.org/10.1051/itmconf/20193009005.";

        const string citation3 =
            "Моделирование связанных процессов формирования остаточных напряжений в металлическом сплаве с учетом трансформации структуры при импульсном термосиловом поверхностном упрочнении (Modeling of the coupled processes of residual stress formation in a metallic alloy taking into account structure transformation due to pulse thermo-force surface hardening) / В.П. Багмутов, Д.С. Денисевич, И.Н. Захаров, М.Д. Романенко, В.В. Баринов // Вычислительная механика сплошных сред (Computational Continuum Mechanics). - 2022. - Т. 15, № 4. - C. 449-465. - DOI: 10.7242/1999-6691/2022.15.4.35. – URL: https://journal.permsc.ru/index.php/ccm/article/view/CCMv15n4a7/2008";

        const string expected1 = "https://bg.cherkasgu.press/journals_n/1646150680.pdf";
        const string expected2 = "https://journal.permsc.ru/index.php/ccm/article/view/CCMv15n4a7/2008";

        var result1 = CitationParseFunctions.GetUrl(citation1);
        var result2 = CitationParseFunctions.GetUrl(citation2);
        var result3 = CitationParseFunctions.GetUrl(citation3);

        Assert.Equal(expected1, result1);
        Assert.Null(result2);
        Assert.Equal(expected2, result3);
    }
}
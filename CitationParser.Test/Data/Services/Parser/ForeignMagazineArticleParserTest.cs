using CitationParser.Data.Model;
using CitationParser.Data.Services.Parser;

namespace CitationParser.Test.Data.Services.Parser;

public class ForeignMagazineArticleParserTest
{
    [Fact]
    public void GetNumber_SimpleTest()
    {
        const string citation1 =
            "Content of Secondary Education in the Russian Empire in the second half of the 19th century (the Example of Ust-Medveditsky Women's Secondary School of the Don Cossack Host) (Содержание гимназического образования в Российской империи второй половины XIX века (на примере Усть-Медведицкой женской гимназии области Войска Донского)) / А.А. Соловьев, А.В. Захаров, Н.Л. Виноградова, Л.С. Соловьева // Bylye Gody (Былые годы) : электрон. журнал. - 2022. - Vol. 17, issue 1. – P. 378-385. – DOI: 10.13187/bg.2022.1.378. – URL: https://bg.cherkasgu.press/journals_n/1646150680.pdf";

        const string citation2 =
            "Peculiar properties of the electron beam dynamics simulation by particle-particle methods taking into account delay effects / С.А. Аликов, А.Г. Шеин // ITM Web of Conferences. - 2019. - Vol. 30 : 29th International Crimean Conference «Microwave & Telecommunication Technology» (CriMiCo’2019) (Sevastopol, Russia, September 8-14, 2019) / ed. by P. Yermolov. – 9 p. – DOI: https://doi.org/10.1051/itmconf/20193009005.";

        const string citation3 =
            "Моделирование связанных процессов формирования остаточных напряжений в металлическом сплаве с учетом трансформации структуры при импульсном термосиловом поверхностном упрочнении (Modeling of the coupled processes of residual stress formation in a metallic alloy taking into account structure transformation due to pulse thermo-force surface hardening) / В.П. Багмутов, Д.С. Денисевич, И.Н. Захаров, М.Д. Романенко, В.В. Баринов // Вычислительная механика сплошных сред (Computational Continuum Mechanics). - 2022. - Т. 15, № 4. - C. 449-465. - DOI: 10.7242/1999-6691/2022.15.4.35. – URL: https://journal.permsc.ru/index.php/ccm/article/view/CCMv15n4a7/2008";
        
        const string expected1 = "Vol. 17, issue 1";
        const string expected2 =
            "Vol. 30 : 29th International Crimean Conference «Microwave & Telecommunication Technology» (CriMiCo’2019) (Sevastopol, Russia, September 8-14, 2019)";
        const string expected3 = "Т. 15, № 4";

        var result1 = ForeignMagazineArticleParser.GetNumber(citation1);
        var result2 = ForeignMagazineArticleParser.GetNumber(citation2);
        var result3 = ForeignMagazineArticleParser.GetNumber(citation3);

        Assert.Equal(expected1, result1);
        Assert.Equal(expected2, result2);
        Assert.Equal(expected3, result3);
    }

    [Fact]
    public void GetEditors_SimpleTest()
    {
        const string citation1 =
            "Content of Secondary Education in the Russian Empire in the second half of the 19th century (the Example of Ust-Medveditsky Women's Secondary School of the Don Cossack Host) (Содержание гимназического образования в Российской империи второй половины XIX века (на примере Усть-Медведицкой женской гимназии области Войска Донского)) / А.А. Соловьев, А.В. Захаров, Н.Л. Виноградова, Л.С. Соловьева // Bylye Gody (Былые годы) : электрон. журнал. - 2022. - Vol. 17, issue 1. – P. 378-385. – DOI: 10.13187/bg.2022.1.378. – URL: https://bg.cherkasgu.press/journals_n/1646150680.pdf";

        const string citation2 =
            "Peculiar properties of the electron beam dynamics simulation by particle-particle methods taking into account delay effects / С.А. Аликов, А.Г. Шеин // ITM Web of Conferences. - 2019. - Vol. 30 : 29th International Crimean Conference «Microwave & Telecommunication Technology» (CriMiCo’2019) (Sevastopol, Russia, September 8-14, 2019) / ed. by P. Yermolov. – 9 p. – DOI: https://doi.org/10.1051/itmconf/20193009005.";

        const string citation3 =
            "Physical Principles for Forming the Microgeometry of the Surface Layer in the Steel Edge Cutting Machining / А.С. Сергеев, Ж.С. Тихонова, Т.В. Уварова // Materials Science Forum. - 2019. - Vol. 973 : IX Int. Sci. and Techn. Conf. on Engineering – Innovation Technol. in Eng.: From Design to Production of Competitive Products (Volgograd, Sept. 2017) : Proc. / eds. A. Suslov, V. Lysak, Ju. Chigirinskiy [et al.] ; Volgograd St. Techn. Univ. - C. P. 69-74";

        var expected2 = new List<Editor>()
        {
            new()
            {
                Name = "P. Yermolov"
            }
        };

        var expected3 = new List<Editor>()
        {
            new()
            {
                Name = "A. Suslov"
            },
            new()
            {
                Name = "V. Lysak"
            },
            new()
            {
                Name = "Ju. Chigirinskiy"
            }
        };

        var result1 = ForeignMagazineArticleParser.GetEditors(citation1);
        var result2 = ForeignMagazineArticleParser.GetEditors(citation2);
        var result3 = ForeignMagazineArticleParser.GetEditors(citation3);

        Assert.Empty(result1);
        Assert.Equal(expected2.Select(e => e.Name), result2.Select(r => r.Name));
        Assert.Equal(expected3.Select(e => e.Name), result3.Select(r => r.Name));
    }

    [Fact]
    public void GetPages_SimpleTest()
    {
        const string citation1 =
            "Content of Secondary Education in the Russian Empire in the second half of the 19th century (the Example of Ust-Medveditsky Women's Secondary School of the Don Cossack Host) (Содержание гимназического образования в Российской империи второй половины XIX века (на примере Усть-Медведицкой женской гимназии области Войска Донского)) / А.А. Соловьев, А.В. Захаров, Н.Л. Виноградова, Л.С. Соловьева // Bylye Gody (Былые годы) : электрон. журнал. - 2022. - Vol. 17, issue 1. – P. 378-385. – DOI: 10.13187/bg.2022.1.378. – URL: https://bg.cherkasgu.press/journals_n/1646150680.pdf";

        const string citation2 =
            "Peculiar properties of the electron beam dynamics simulation by particle-particle methods taking into account delay effects / С.А. Аликов, А.Г. Шеин // ITM Web of Conferences. - 2019. - Vol. 30 : 29th International Crimean Conference «Microwave & Telecommunication Technology» (CriMiCo’2019) (Sevastopol, Russia, September 8-14, 2019) / ed. by P. Yermolov. – 9 p. – DOI: https://doi.org/10.1051/itmconf/20193009005.";

        const string citation3 =
            "Robust sampling-sourced numerical retrieval algorithm for optical energy loss function based on log–log mesh optimization and local monotonicity / И.И. Маглеванный, В.А. Смоляр // Nuclear Instruments and Methods in Physics Research Section B: Beam Interactions with Materials and Atoms. - 2016. - Vol. 367 (January). - C. 26-36.";

        const string citation4 =
            "Моделирование связанных процессов формирования остаточных напряжений в металлическом сплаве с учетом трансформации структуры при импульсном термосиловом поверхностном упрочнении (Modeling of the coupled processes of residual stress formation in a metallic alloy taking into account structure transformation due to pulse thermo-force surface hardening) / В.П. Багмутов, Д.С. Денисевич, И.Н. Захаров, М.Д. Романенко, В.В. Баринов // Вычислительная механика сплошных сред (Computational Continuum Mechanics). - 2022. - Т. 15, № 4. - C. 449-465. - DOI: 10.7242/1999-6691/2022.15.4.35. – URL: https://journal.permsc.ru/index.php/ccm/article/view/CCMv15n4a7/2008";
        
        const string expected1 = "378-385";
        const string expected2 = "9";
        const string expected3 = "26-36";
        const string expected4 = "449-465";

        var result1 = ForeignMagazineArticleParser.GetPages(citation1);
        var result2 = ForeignMagazineArticleParser.GetPages(citation2);
        var result3 = ForeignMagazineArticleParser.GetPages(citation3);
        var result4 = ForeignMagazineArticleParser.GetPages(citation4);

        Assert.Equal(expected1, result1);
        Assert.Equal(expected2, result2);
        Assert.Equal(expected3, result3);
        Assert.Equal(expected4, result4);
    }

    [Fact]
    public void GetDoi_SimpleTest()
    {
        const string citation1 =
            "Content of Secondary Education in the Russian Empire in the second half of the 19th century (the Example of Ust-Medveditsky Women's Secondary School of the Don Cossack Host) (Содержание гимназического образования в Российской империи второй половины XIX века (на примере Усть-Медведицкой женской гимназии области Войска Донского)) / А.А. Соловьев, А.В. Захаров, Н.Л. Виноградова, Л.С. Соловьева // Bylye Gody (Былые годы) : электрон. журнал. - 2022. - Vol. 17, issue 1. – P. 378-385. – DOI: 10.13187/bg.2022.1.378. – URL: https://bg.cherkasgu.press/journals_n/1646150680.pdf";

        const string citation2 =
            "Peculiar properties of the electron beam dynamics simulation by particle-particle methods taking into account delay effects / С.А. Аликов, А.Г. Шеин // ITM Web of Conferences. - 2019. - Vol. 30 : 29th International Crimean Conference «Microwave & Telecommunication Technology» (CriMiCo’2019) (Sevastopol, Russia, September 8-14, 2019) / ed. by P. Yermolov. – 9 p. – DOI: https://doi.org/10.1051/itmconf/20193009005.";

        const string citation3 =
            "Robust sampling-sourced numerical retrieval algorithm for optical energy loss function based on log–log mesh optimization and local monotonicity / И.И. Маглеванный, В.А. Смоляр // Nuclear Instruments and Methods in Physics Research Section B: Beam Interactions with Materials and Atoms. - 2016. - Vol. 367 (January). - C. 26-36.";

        const string citation4 =
            "Моделирование связанных процессов формирования остаточных напряжений в металлическом сплаве с учетом трансформации структуры при импульсном термосиловом поверхностном упрочнении (Modeling of the coupled processes of residual stress formation in a metallic alloy taking into account structure transformation due to pulse thermo-force surface hardening) / В.П. Багмутов, Д.С. Денисевич, И.Н. Захаров, М.Д. Романенко, В.В. Баринов // Вычислительная механика сплошных сред (Computational Continuum Mechanics). - 2022. - Т. 15, № 4. - C. 449-465. - DOI: 10.7242/1999-6691/2022.15.4.35. – URL: https://journal.permsc.ru/index.php/ccm/article/view/CCMv15n4a7/2008";
        
        const string expected1 = "10.13187/bg.2022.1.378";
        const string expected2 = "https://doi.org/10.1051/itmconf/20193009005";
        const string expected3 = "10.7242/1999-6691/2022.15.4.35";

        var result1 = ForeignMagazineArticleParser.GetDoi(citation1);
        var result2 = ForeignMagazineArticleParser.GetDoi(citation2);
        var result3 = ForeignMagazineArticleParser.GetDoi(citation3);
        var result4 = ForeignMagazineArticleParser.GetDoi(citation4);

        Assert.Equal(expected1, result1);
        Assert.Equal(expected2, result2);
        Assert.Null(result3);
        Assert.Equal(expected3, result4);
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

        var result1 = ForeignMagazineArticleParser.GetUrl(citation1);
        var result2 = ForeignMagazineArticleParser.GetUrl(citation2);
        var result3 = ForeignMagazineArticleParser.GetUrl(citation3);

        Assert.Equal(expected1, result1);
        Assert.Null(result2);
        Assert.Equal(expected2, result3);
    }
}
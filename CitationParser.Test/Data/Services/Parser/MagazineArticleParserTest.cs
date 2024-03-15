using CitationParser.Data.Model;
using CitationParser.Data.Services.Parser;

namespace CitationParser.Test.Data.Services.Parser;

public class MagazineArticleParserTest
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
        
        const string expected1 = "issue 1";
        const string expected3 = "№ 4";

        var result1 = MagazineArticleParser.GetNumber(citation1);
        var result2 = MagazineArticleParser.GetNumber(citation2);
        var result3 = MagazineArticleParser.GetNumber(citation3);

        Assert.Equal(expected1, result1);
        Assert.Null(result2);
        Assert.Equal(expected3, result3);
    }

    [Fact]
    public void GetNumber_WordTest()
    {
        const string citation =
            "Disclosure of the export potential of high-tech enterprises in the context of industry 4.0 through quality management / Я.Т. Нозиров, Л.И. Кукаева, Хуссейн Б.А. Абдул, В.С. Устенко // Proceedings on Engineering Sciences. - 2023. - Vol. 5, N S2. - C. P. 295-310. - URL: https://pesjournal.net/paper.php?id=441.";

        const string expected = "N S2";

        var result = MagazineArticleParser.GetNumber(citation);

        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetNumber_RussianTest()
    {
        const string citation =
            "Figurative narratives of environmental security = Образные нарративы экологической безопасности / И.В. Скрынникова, Т.Н. Астафурова // Science Journal of Volgograd State University. Linguistics (Вестник Волгоградского государственного университета. Серия 2: Языкознание). - 2023. - Т. 22, № 4. - C. 158-166.";

        const string expected = "№ 4";

        var result = MagazineArticleParser.GetNumber(citation);

        Assert.Equal(expected, result);
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

        var result1 = MagazineArticleParser.GetEditors(citation1);
        var result2 = MagazineArticleParser.GetEditors(citation2);
        var result3 = MagazineArticleParser.GetEditors(citation3);

        Assert.Empty(result1);
        Assert.Equal(expected2.Select(e => e.Name), result2.Select(r => r.Name));
        Assert.Equal(expected3.Select(e => e.Name), result3.Select(r => r.Name));
    }

    [Fact]
    public void GetPageNumbers_SimpleTest()
    {
        const string citation1 =
            "Content of Secondary Education in the Russian Empire in the second half of the 19th century (the Example of Ust-Medveditsky Women's Secondary School of the Don Cossack Host) (Содержание гимназического образования в Российской империи второй половины XIX века (на примере Усть-Медведицкой женской гимназии области Войска Донского)) / А.А. Соловьев, А.В. Захаров, Н.Л. Виноградова, Л.С. Соловьева // Bylye Gody (Былые годы) : электрон. журнал. - 2022. - Vol. 17, issue 1. – P. 378-385. – DOI: 10.13187/bg.2022.1.378. – URL: https://bg.cherkasgu.press/journals_n/1646150680.pdf";

        const string citation4 =
            "Моделирование связанных процессов формирования остаточных напряжений в металлическом сплаве с учетом трансформации структуры при импульсном термосиловом поверхностном упрочнении (Modeling of the coupled processes of residual stress formation in a metallic alloy taking into account structure transformation due to pulse thermo-force surface hardening) / В.П. Багмутов, Д.С. Денисевич, И.Н. Захаров, М.Д. Романенко, В.В. Баринов // Вычислительная механика сплошных сред (Computational Continuum Mechanics). - 2022. - Т. 15, № 4. - C. 449-465. - DOI: 10.7242/1999-6691/2022.15.4.35. – URL: https://journal.permsc.ru/index.php/ccm/article/view/CCMv15n4a7/2008";
        
        const string expected1 = "P. 378-385";
        const string expected4 = "C. 449-465";

        var result1 = MagazineArticleParser.GetPageNumbers(citation1);
        var result4 = MagazineArticleParser.GetPageNumbers(citation4);

        Assert.Equal(expected1, result1);
        Assert.Equal(expected4, result4);
    }
    
    [Fact]
    public void GetPageNumbers_RussianTest()
    {
        const string citation =
            "Влияние кристаллической структуры вещества на дифференциальное сечение упругого рассеяния и принципа неразличимости частиц на тормозную способность / В.А. Смоляр, А.В. Еремин, В.В. Еремин, А.С. Бураков // Электромагнитные волны и электронные системы. - 2014. - Т. 19, № 3. - C. 66-72.";
        
        const string expected = "C. 66-72.";

        var result = MagazineArticleParser.GetPageNumbers(citation);

        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetCountOfPages_SimpleTest()
    {
        const string citation2 =
            "Peculiar properties of the electron beam dynamics simulation by particle-particle methods taking into account delay effects / С.А. Аликов, А.Г. Шеин // ITM Web of Conferences. - 2019. - Vol. 30 : 29th International Crimean Conference «Microwave & Telecommunication Technology» (CriMiCo’2019) (Sevastopol, Russia, September 8-14, 2019) / ed. by P. Yermolov. – 9 p. – DOI: https://doi.org/10.1051/itmconf/20193009005.";

        const string citation3 =
            "Learning problem generator for introductory programming courses / А.А. Прокудин, О.А. Сычев, М. Денисов // Software Impacts. - 2023. - Vol. 17 (September). – Article100519. – 4 p. – DOI: https://doi.org/10.1016/j.simpa.2023.100519. – URL:https://www.sciencedirect.com/science/article/pii/S2665963823000568?via%3Dihub.";
        
        const string expected2 = "9 p";
        const string expected3 = "4 p";

        var result2 = MagazineArticleParser.GetCountOfPages(citation2);
        var result3 = MagazineArticleParser.GetCountOfPages(citation3);

        Assert.Equal(expected2, result2);
        Assert.Equal(expected3, result3);
    }
    
    [Fact]
    public void GetCountOfPages_RussianTest()
    {
        const string citation =
            "Исследование класса давления запирания регуляторов РЕД / Т.В. Ефремова, М.С. Злыгин // Инженерный вестник Дона. - 2023. - № 1. - 8 с. - URL: http://www.ivdon.ru/ru/magazine/archive/n1y2023/8149.";
        
        const string expected = "8 с";

        var result = MagazineArticleParser.GetCountOfPages(citation);

        Assert.Equal(expected, result);
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

        var result1 = MagazineArticleParser.GetDoi(citation1);
        var result2 = MagazineArticleParser.GetDoi(citation2);
        var result3 = MagazineArticleParser.GetDoi(citation3);
        var result4 = MagazineArticleParser.GetDoi(citation4);

        Assert.Equal(expected1, result1);
        Assert.Equal(expected2, result2);
        Assert.Null(result3);
        Assert.Equal(expected3, result4);
    }
    
    [Fact]
    public void GetDoi_RussianTest()
    {
        const string citation =
            "Исследование износостойкости оправок при прошивке заготовок из стали 20Х13 / А.А. Корсаков, Д.В. Михалкин, А.В. Красиков, А.С. Алещенко, Ю.В. Гамин, А.И. Банников, Я.А. Чемаева, Е.Ю. Михалкина // Прокатное производство. Приложение к журналу \"Технология металлов\". - 2023. - № 21. - C. 1-8. - DOI: 10.31044/1684-2499-2023-0-21-1-8.";

        const string expected = "10.31044/1684-2499-2023-0-21-1-8";

        var result = MagazineArticleParser.GetDoi(citation);

        Assert.Equal(expected, result);
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

        var result1 = MagazineArticleParser.GetUrl(citation1);
        var result2 = MagazineArticleParser.GetUrl(citation2);
        var result3 = MagazineArticleParser.GetUrl(citation3);

        Assert.Equal(expected1, result1);
        Assert.Null(result2);
        Assert.Equal(expected2, result3);
    }
    
    [Fact]
    public void GetUrl_RussianTest()
    {
        const string citation =
            "Исследование класса давления запирания регуляторов РЕД / Т.В. Ефремова, М.С. Злыгин // Инженерный вестник Дона. - 2023. - № 1. - 8 с. - URL: http://www.ivdon.ru/ru/magazine/archive/n1y2023/8149.";

        const string expected = "http://www.ivdon.ru/ru/magazine/archive/n1y2023/8149";

        var result = MagazineArticleParser.GetUrl(citation);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetVolume_SimpleTest()
    {
        const string citation =
            "Disclosure of the export potential of high-tech enterprises in the context of industry 4.0 through quality management / Я.Т. Нозиров, Л.И. Кукаева, Хуссейн Б.А. Абдул, В.С. Устенко // Proceedings on Engineering Sciences. - 2023. - Vol. 5, N S2. - C. P. 295-310. - URL: https://pesjournal.net/paper.php?id=441.";

        const string expected = "Vol. 5";

        var result = MagazineArticleParser.GetVolume(citation);

        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetVolume_WithTitleTest()
    {
        const string citation =
            "Peculiar properties of the electron beam dynamics simulation by particle-particle methods taking into account delay effects / С.А. Аликов, А.Г. Шеин // ITM Web of Conferences. - 2019. - Vol. 30 : 29th International Crimean Conference «Microwave & Telecommunication Technology» (CriMiCo’2019) (Sevastopol, Russia, September 8-14, 2019) / ed. by P. Yermolov. – 9 p. – DOI: https://doi.org/10.1051/itmconf/20193009005.";

        const string expected = "Vol. 30";

        var result = MagazineArticleParser.GetVolume(citation);

        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetVolume_RussianTest()
    {
        const string citation =
            "Исследование кальцийсодержащих соединений в качестве катализаторов этерификации глицерина высшими карбоновыми кислотами (Study of calcium-containing compounds as catalysts for the esterification of glycerol with higher carboxylic acids) / Ю.Л. Зотов, Д.М. Заправдина, Е.В. Шишкин, Ю.В. Попов // Тонкие химические технологии / Tonkie Khimicheskie Tekhnologii. - 2023. - Т. 18, № 3. - C. 175-186. - DOI: 10.32362/2410-6593-2023-18-3-175-186.";

        const string expected = "Т. 18";

        var result = MagazineArticleParser.GetVolume(citation);

        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetArticleNumber_SimpleTest()
    {
        const string citation =
            " Investigation of thermal processes in the gap during explosion welding / С.В. Хаустов, V.V. Pai, В.И. Лысак, С.В. Кузьмин // International Journal of Heat and Mass Transfer. - 2023. - Vol. 209. - Article 124166. - 8 p. - DOI: https://doi.org/10.1016/j.ijheatmasstransfer.2023.124166. - URL: https://www.sciencedirect.com/science/article/abs/pii/S0017931023003198.";

        const string expected = "Article 124166";

        var result = MagazineArticleParser.GetArticleNumber(citation);

        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetArticleNumber_RussianTest()
    {
        const string citation =
            "The sky visibility at shading by trees / С.В. Корниенко, Е.А. Дикарева // Construction of Unique Buildings and Structures. - 2022. - № 4 (102). - Article 10203. - Doi: 10.4123/CUBS.102.3.";

        const string expected = "Article 10203";

        var result = MagazineArticleParser.GetArticleNumber(citation);

        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetTitleOfSource_SimpleTest()
    {
        const string citation =
            " Investigation of thermal processes in the gap during explosion welding / С.В. Хаустов, V.V. Pai, В.И. Лысак, С.В. Кузьмин // International Journal of Heat and Mass Transfer. - 2023. - Vol. 209. - Article 124166. - 8 p. - DOI: https://doi.org/10.1016/j.ijheatmasstransfer.2023.124166. - URL: https://www.sciencedirect.com/science/article/abs/pii/S0017931023003198.";

        const string expected = "International Journal of Heat and Mass Transfer";

        var result = MagazineArticleParser.GetTitleOfSource(citation);

        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetTitleOfSource_RussianTest()
    {
        const string citation =
            "Обоснование мероприятий по модернизации транспортной системы на основе обследования пассажиропотоков / С.В. Волченко // Вестник Волгоградского государственного архитектурно-строительного университета. Сер.: Строительство и архитектура. – Волгоград : Изд-во ВолгГАСУ, 2008. – Вып. 12 (31). - С. 54-57. - 2008.";

        const string expected = "Вестник Волгоградского государственного архитектурно-строительного университета. Сер.: Строительство и архитектура";

        var result = MagazineArticleParser.GetTitleOfSource(citation);

        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetCompanies_SimpleTest()
    {
        const string citation =
            "Contactless Evaluation of the Microgeometry of the Machined Surface / Ю.Л. Чигиринский, А.П. Гонтарь // Materials Science Forum. - 2019. - Vol. 973 : IX Int. Sci. and Techn. Conf. on Engineering – Innovation Technol. in Eng.: From Design to Production of Competitive Products (Volgograd, Sept. 2017) : Proc. / eds. A. Suslov, V. Lysak, Ju. Chigirinskiy [et al.] ; Volgograd St. Techn. Univ. - C. P. 206-211.";

        var expected = "Volgograd St. Techn. Univ";

        var result = MagazineArticleParser.GetCompanies(citation);

        Assert.Single(result);
        Assert.Equal(expected, result[0].Name);
    }

    [Fact]
    public void GetEditorsFromRussian_SimpleTest()
    {
        var citation = "Влияние комплекса антропогенных факторов на состояние водных объектов (на примере оз. Придорожное) / М.В. Решетникова, М.В. Бурдина // Научно-методический электронный журнал \"Концепт\". Современные научные исследования. - 2014. - Т20, Выпуск 2 / Под ред. П.М. Горева и В.В. Утемова. - C. 3286-3290.";

        var expected1 = "П.М. Горева";
        var expected2 = "В.В. Утемова";
        var actual = MagazineArticleParser.GetEditorsFromRussianMagazine(citation);

        Assert.Equal(2, actual.Count);
        Assert.Equal(expected1, actual[0].Name);
        Assert.Equal(expected2, actual[1].Name);
    }
    
    [Fact]
    public void GetEditorsFromRussian_CommaTest()
    {
        var citation = "Рецензия на книгу «Корпоративная социальная ответственность: управленческий аспект» / под общ. ред. д.э.н., проф. И.Ю. Беляевой, д.э.н., проф. М.А. Эскиндарова. – М. : Кнорус, 2008 / И.Е. Бельских, Л.С. Шаховская // Финансы и кредит. - 2009. - № 4. - C. 80-82.";

        var expected1 = "д.э.н.";
        var expected2 = "проф. И.Ю. Беляевой";
        var expected3 = "д.э.н.";
        var expected4 = "проф. М.А. Эскиндарова";

        var actual = MagazineArticleParser.GetEditorsFromRussianMagazine(citation);

        Assert.Equal(4, actual.Count);
        Assert.Equal(expected1, actual[0].Name);
        Assert.Equal(expected2, actual[1].Name);
        Assert.Equal(expected3, actual[2].Name);
        Assert.Equal(expected4, actual[3].Name);
    }

    [Fact]
    public void GetCities_SimpleTest()
    {
        var citation = "Обоснование мероприятий по модернизации транспортной системы на основе обследования пассажиропотоков / С.В. Волченко // Вестник Волгоградского государственного архитектурно-строительного университета. Сер.: Строительство и архитектура. – Волгоград : Изд-во ВолгГАСУ, 2008. – Вып. 12 (31). - С. 54-57. - 2008.";

        var expected = "Волгоград";

        var actual = MagazineArticleParser.GetCities(citation);

        Assert.Single(actual);
        Assert.Equal(expected, actual[0].Name);
    }
    
    [Fact]
    public void GetPublishingHouse_SimpleTest()
    {
        var citation = "Обоснование мероприятий по модернизации транспортной системы на основе обследования пассажиропотоков / С.В. Волченко // Вестник Волгоградского государственного архитектурно-строительного университета. Сер.: Строительство и архитектура. – Волгоград : Изд-во ВолгГАСУ, 2008. – Вып. 12 (31). - С. 54-57. - 2008.";

        var expected = "Изд-во ВолгГАСУ";

        var actual = MagazineArticleParser.GetPublishingHouse(citation);

        Assert.Equal(expected, actual);
    }
}
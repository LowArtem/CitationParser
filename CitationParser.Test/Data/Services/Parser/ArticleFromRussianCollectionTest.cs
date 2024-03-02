using CitationParser.Data.Model;
using CitationParser.Services.Parser;

namespace CitationParser.Test.Data.Services.Parser;

public class ArticleFromRussianCollectionTest
{
    [Fact]
    public void GetTitleScientificCollection_SimpleTest()
    {
        var citation = " Автоматизация технологического процесса плавки металла на базе средств автоматизации российского производства / В.Д. Санников, Л.И. Медведева // Технические науки: проблемы и решения : сб. ст. по материалам LXIX междунар. науч.-практ. конф. (февраль 2023 г.) / ООО «Интернаука». - Москва, 2023. - № 2 (64). - C. 23-29. – URL: https://www.internauka.org/conf/tech/lxix";

        var expected = "Технические науки: проблемы и решения : сб. ст. по материалам LXIX междунар. науч.-практ. конф. (февраль 2023 г.)";

        var result = ArticleFromRussianCollectionParser.GetTitleScientificCollection(citation).Title;
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetEditor_SimpleTest()
    {
        var citation = "BIG DATA в цифровом прогнозировании устойчивости банковского сектора РФ / Э.О. Федоровская, И.А. Калмыкова, Н.И. Ломакин // Стратегия и тактика управления предприятием в переходной экономике : сб. материалов XXIII ежегодного открытого конкурса науч.-исслед. работ студентов и молодых ученых в обл. экономики и управления «Зеленый росток» с итоговым этапом в форме Всерос. (нац.) науч. конф. (г. Волгоград, апрель 2023 г.) / под ред. Г. С. Мерзликиной ; ВолгГТУ. - Волгоград, 2023. - Вып. 46. - C. 143-144.";

        List<Editor> editors = new List<Editor>();
        editors.Add(new Editor(){Name = "Г. С. Мерзликиной"});

        var result = ArticleFromRussianCollectionParser.GetEditorScientificCollection(citation);

        Assert.Equal(editors.Count, result.Count);
        for (int i = 0; i < editors.Count; i++)
        {
            Assert.Equal(editors[i].Name, result[i].Name);
        }
    }
    
    [Fact]
    public void GetEditor_PublicationsContainsUniversityTest()
    {
        var citation = "Анализ проблемных кредитов в банковском секторе / Е.И. Семина, И.А. Чеховская // Менеджмент и финансы производственных систем : сб. науч.-практ. ст. Всерос. (национальной) науч.-практ. конф. (г. Волгоград, 12 декабря 2022 г.) / отв. ред.: И. А. Езангина, И. А. Чеховская ; редкол.: С. П. Сазонов [и др.] ; Волгоградский гос. технический университет, Волгоградский институт управления – филиал РАНХиГС при Президенте РФ, Волгоградский филиал РЭУ им. Плеханова [и др.]. - Курск, 2023. - C. 209-214";

        List<Editor> editors = new List<Editor>();
        editors.Add(new Editor(){Name = "И. А. Езангина"});
        editors.Add(new Editor(){Name = "И. А. Чеховская"});
        editors.Add(new Editor(){Name = "С. П. Сазонов"});

        var result = ArticleFromRussianCollectionParser.GetEditorScientificCollection(citation);

        Assert.Equal(editors.Count, result.Count);
        for (int i = 0; i < editors.Count; i++)
        {
            Assert.Equal(editors[i].Name, result[i].Name);
        }
    }
    
    [Fact]
    public void GetUniversities_SimpleTest()
    {
        var citation = "ESG и энергоэффективность в FinTech-отраслях: нужны ли новые подходы? / О.М. Коробейникова, Л.И. Стефанович // Энергетика и цифровизация: теория и практика трансформации : материалы II Междунар. науч.-практ. конф. (г. Волгоград, 25 ноября 2022 г.) / под общ. ред. Р. Ю. Скокова ; Волгоградский ЦНТИ – филиал ФГБУ «Российское энергетическое агентство» Министерства энергетики РФ. - Волгоград, 2023. - C. 84-90";

        List<University> universities = new List<University>();
        universities.Add(new University(){Name = "Волгоградский ЦНТИ - филиал ФГБУ «Российское энергетическое агентство» Министерства энергетики РФ"});

        var result = ArticleFromRussianCollectionParser.GetUniversityScientificCollection(citation);

        Assert.Equal(universities.Count, result.Count);
        for (int i = 0; i < universities.Count; i++)
        {
            Assert.Equal(universities[i].Name, result[i].Name);
        }
    }
    
    [Fact]
    public void GetUniversities_TwoUniversitiesTest()
    {
        var citation = " Актуальность вариантного проектирования в технологии информационного моделирования архитектурно-строительных объектов / М.Ф. Шарипов // Развитие городского строительства и хозяйства в трудах молодых ученых : сб. тр. науч.-практ. конф., 25-28 апреля 2023 г., Волгоград / М-во науки и высш. образования Рос. Федерации, Волгогр. гос. техн. ун-т. - Волгоград, 2023. - C. 26-34. - 1 электрон.-опт. диск (CD-R)";

        List<University> universities = new List<University>();
        universities.Add(new University(){Name = "М-во науки и высш. образования Рос. Федерации"});
        universities.Add(new University(){Name = "Волгогр. гос. техн. ун-т"});

        var result = ArticleFromRussianCollectionParser.GetUniversityScientificCollection(citation);

        Assert.Equal(universities.Count, result.Count);
        for (int i = 0; i < universities.Count; i++)
        {
            Assert.Equal(universities[i].Name, result[i].Name);
        }
    }
    
    [Fact]
    public void GetCities_SimpleTest()
    {
        var citation = "Укрепление подвижных песков в засушливых районах России / Р.Н. Буглаев // Молодежь и научно-технический прогресс в дорожной отрасли Юга России = Youth and scientific-and-technical progress in roadfield of south of Russia : материалы XII междунар. науч.-техн. конф. студентов, аспирантов и молодых ученых, 23-25 мая 2018 г, Волгоград / ВолгГТУ. - Волгоград, 2018. - C. 111-115";

        List<City> cities = new List<City>();
        cities.Add(new City() {Name = "Волгоград"});

        var result = ArticleFromRussianCollectionParser.GetCitiesScientificCollection(citation);

        Assert.Equal(cities.Count, result.Count);
        for (int i = 0; i < cities.Count; i++)
        {
            Assert.Equal(cities[i].Name, result[i].Name);
        }
    }
    
    [Fact]
    public void GetYear_SimpleTest()
    {
        var citation = "Анализ проблемных кредитов в банковском секторе / Е.И. Семина, И.А. Чеховская // Менеджмент и финансы производственных систем : сб. науч.-практ. ст. Всерос. (национальной) науч.-практ. конф. (г. Волгоград, 12 декабря 2022 г.) / отв. ред.: И. А. Езангина, И. А. Чеховская ; редкол.: С. П. Сазонов [и др.] ; Волгоградский гос. технический университет, Волгоградский институт управления – филиал РАНХиГС при Президенте РФ, Волгоградский филиал РЭУ им. Плеханова [и др.]. - Курск, 2023. - C. 209-214";

        var expected = "2023";

        var result = ArticleFromRussianCollectionParser.GetYearScientificCollection(citation);
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetPages_SimpleTest()
    {
        var citation = "ESG и энергоэффективность в FinTech-отраслях: нужны ли новые подходы? / О.М. Коробейникова, Л.И. Стефанович // Энергетика и цифровизация: теория и практика трансформации : материалы II Междунар. науч.-практ. конф. (г. Волгоград, 25 ноября 2022 г.) / под общ. ред. Р. Ю. Скокова ; Волгоградский ЦНТИ – филиал ФГБУ «Российское энергетическое агентство» Министерства энергетики РФ. - Волгоград, 2023. - C. 84-90";

        var expected = "C. 84-90";

        var result = ArticleFromRussianCollectionParser.GetPagesNumbersScientificCollection(citation);
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetCountPages_SimpleTest()
    {
        var citation = "Исследование тенденций развития рынка производителей кондитерской продукции / Э.А. Дербишева // Экономист будущего: меняем мир : сб. ст. Всерос. науч.-практ. конф. молодых ученых с междунар. участием (г. Кемерово, 30 марта 2023 г.) / под общ. ред. Ю. С. Якуниной, Е. Е. Жернова ; Кузбасский гос. технический университет им. Т. Ф. Горбачева. - Кемерово, 2023. - Статья 0208. – 3 с. – URL: https://science.kuzstu.ru/wp-content/Events/Conference/Econom/2023/EF_2023/pages/Articles/0208.pdf";

        var expected = "3 с";

        var result = ArticleFromRussianCollectionParser.GetCountPagesScientificCollection(citation);
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetURL_SimpleTest()
    {
        var citation = "Исследование тенденций развития рынка производителей кондитерской продукции / Э.А. Дербишева // Экономист будущего: меняем мир : сб. ст. Всерос. науч.-практ. конф. молодых ученых с междунар. участием (г. Кемерово, 30 марта 2023 г.) / под общ. ред. Ю. С. Якуниной, Е. Е. Жернова ; Кузбасский гос. технический университет им. Т. Ф. Горбачева. - Кемерово, 2023. - Статья 0208. – 3 с. – URL: https://science.kuzstu.ru/wp-content/Events/Conference/Econom/2023/EF_2023/pages/Articles/0208.pdf";

        var expected = "URL: https://science.kuzstu.ru/wp-content/Events/Conference/Econom/2023/EF_2023/pages/Articles/0208.pdf";

        var result = ArticleFromRussianCollectionParser.GetURLScientificCollection(citation);
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetDOI_SimpleTest()
    {
        var citation = "Новая индустриализация России посредством новых способов привлечения инвестиций / А.А. Ардизинба, Вад.В. Новиков, В.В. Новиков, Л.С. Шаховская // Экономика и право : монография / Чувашский государственный институт культуры и искусств. - Чебоксары, 2023. - Гл. 1. – С. 17-31. – DOI: 10.31483/r-107261. – URL: https://phsreda.com/e-publications/e-publication-10501.pdf";

        var expected = "DOI: 10.31483/r-107261";

        var result = ArticleFromRussianCollectionParser.GetDOIScientificCollection(citation);
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetVolume_SimpleTest()
    {
        var citation = "Анализ влияния различных социальноэкономических факторов на развитие агропромышленного комплекса в современных условиях России / А.Ф. Рогачев, А.Б. Симонов, Е.М. Попов, Е.Б. Масленков // Научное обоснование стратегии цифрового развития АПК и сельских территорий : материалы Национальной науч.-практ. конф. (г. Волгоград, 9 ноября 2022 г.) / редкол.: В. А. Цепляев (гл. ред.) [и др.] ; ФГБОУ ВО Волгоградский ГАУ. - Волгоград, 2023. - Т. I. - C. 319-326. – URL: https://volgau.com/Portals/0/23/230523/mat_nnpk_09112022_t1.pdf?ver=CyYuk9E0QfIYtddVX64T0g%3d%3d";

        var expected = "Т. I";

        var result = ArticleFromRussianCollectionParser.GetVolumeNumbersScientificCollection(citation);
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetArticleNumber_SimpleTest()
    {
        var citation = "Анализ функционирования страхового рынка РФ: современное состояние и перспективы развития / Е.И. Морозова // Экономист будущего: меняем мир : сб. ст. Всерос. науч.-практ. конф. молодых ученых с междунар. участием (г. Кемерово, 30 марта 2023 г.) / под общ. ред. Ю. С. Якуниной, Е. Е. Жернова ; Кузбасский гос. технический университет им. Т. Ф. Горбачева. - Кемерово, 2023. - Статья 0220. – 5 с. – URL: https://science.kuzstu.ru/wp-content/Events/Conference/Econom/2023/EF_2023/pages/Articles/0220.pdf";

        var expected = "Статья 0220";

        var result = ArticleFromRussianCollectionParser.GetArticleNumberScientificCollection(citation);
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetDataStorage_SimpleTest()
    {
        var citation = "Архитектурно-планировочная организация территории детских лагерей отдыха / Я.Д. Новокщенова, Аннагулы Хатамов // Развитие городского строительства и хозяйства в трудах молодых ученых : сб. тр. науч.-практ. конф., 25-28 апреля 2023 г., Волгоград / М-во науки и высш. образования Рос. Федерации, Волгогр. гос. техн. ун-т. - Волгоград, 2023. - C. 131-133. - 1 электрон.-опт. диск (CD-R).";

        var expected = "1 электрон.-опт. диск (CD-R).";

        var result = ArticleFromRussianCollectionParser.GetDataStorageScientificCollection(citation);
        
        Assert.Equal(expected, result);
    }
}
using CitationParser.Data.Model;
using CitationParser.Services.Parser;

namespace CitationParser.Test.Data.Services.Parser;

public class OtherPublicationsParserTest
{
    [Fact]
    public void GetTitleSource_SimpleTest()
    {
        var citation = "Вячеслав Дербишер. Стихи («Всё меньше ветеранов я встречаю»...) / В.Е. Дербишер // Георгиевская лента : 75 лет Победы. Книга десятая / Российский союз писателей. – Москва, 2020. – С. 18-29";

        var expected = "Георгиевская лента : 75 лет Победы. Книга десятая";

        var result = OtherPublicationsParser.GetTitleSource(citation);
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetTitleSource_NotRightSlashTest()
    {
        var citation = "«За боль и быль несбывшейся судьбы...» / Ю.В. Артюхович // Отчий край. – 2021. – № 1 (109). – С. 176-181";

        var expected = "Отчий край";

        var result = OtherPublicationsParser.GetTitleSource(citation);
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetYear_SimpleTest()
    {
        var citation = "Документальное обеспечение стрительства : справочное пособие / В.Н. Кабанов . - Москва : ООО \"Проспект\", 2021. - 144 с";

        var expected = "2021";

        var result = OtherPublicationsParser.GetYear(citation);
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetYear_SquareBracketsTest()
    {
        var citation = "Трактор-легенда. 70 лет ДТ-54 / В.В. Косенко, В.В. Шаров, Ю.С. Ценч // www.techstory.ru. Сайт о механических экскаваторах, старой строительной, авто- и железнодорожной технике. Сайт об истории отечественной дорожной и строительной техники. Раздел «Тематические статьи». История отечественного тракторостроения. – [2019]. – URL : http://www.techstory.ru/fin/85_dt54_2019.htm";

        var expected = "2019";

        var result = OtherPublicationsParser.GetYear(citation);
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetCities_SimpleTest()
    {
        var citation = "Вячеслав Дербишер. Стихи («Всё меньше ветеранов я встречаю»...) / В.Е. Дербишер // Георгиевская лента : 75 лет Победы. Книга десятая / Российский союз писателей. – Москва, 2020. – С. 18-29";
        
        List<City> cities = new List<City>();
        cities.Add(new City() {Name = "Москва"});

        var result = OtherPublicationsParser.GetCities(citation);

        Assert.Equal(cities.Count, result.Count);
        for (int i = 0; i < cities.Count; i++)
        {
            Assert.Equal(cities[i].Name, result[i].Name);
        }
    }
    
    [Fact]
    public void GetCities_EnglishTest()
    {
        var citation = "Blockchain and the institutional complexity: post-institutionalism vs. neoinstitutionalism / Д.П. Фролов // MPRA: Munich Personal RePEc Archive : [on-line publications] / Munich University Library. – Munich (Germany), 2019. – Paper No. 95963 (posted 13 September, 2019). – 18 p. – URL : https://mpra.ub.uni-muenchen.de/95963/1/MPRA_paper_95963.pdf";
        
        List<City> cities = new List<City>();
        cities.Add(new City() {Name = "Munich", Country = "Germany"});

        var result = OtherPublicationsParser.GetCities(citation);

        Assert.Equal(cities.Count, result.Count);
        for (int i = 0; i < cities.Count; i++)
        {
            Assert.Equal(cities[i].Name, result[i].Name);
            Assert.Equal(cities[i].Country, result[i].Country);
        }
    }
    
    [Fact]
    public void GetPublishingHouse_SimpleTest()
    {
        var citation = "Добрые стихи. Стихи для детей / Ю.В. Артюхович ; художник: Е. Г. Новикова ; худож. редактор: А. Ю. Шурыгина ; [Комитет культуры Волгоградской обл.]. – Волгоград : ГБУ культуры «Издатель», 2020. – 27 с";

        var expected = "ГБУ культуры «Издатель»";

        var result = OtherPublicationsParser.GetPublishingHouse(citation);
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetPages_SimpleTest()
    {
        var citation = "Женская территория / Ю.В. Артюхович // IV международная литературная премия «Перископ-2020» : литературный конкурс. – Волгоград, 2021. – С. 275-289. – URL: http://periscope-volga.ru/news/itogi_iv_mezhdunarodnoj_literaturnoj_premii_periskop_2020/2020-12-08-183";

        var expected = "275-289";

        var result = OtherPublicationsParser.GetPagesNumbers(citation);
        
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetPages_OnePageTest()
    {
        var citation = "Применение кинетического метода расчёта многокомпонентной изотермической абсорбции / Н.Г. Неумоина, А.В. Белов // Научное обозрение. Технические науки : [обзор статей, опубликованных в журнале «Современные проблемы науки и образования» по техническим наукам в 2013 году] / РАЕ. – 2014. – № 2. – С. 76 ; парал.: рус., англ.";

        var expected = "76";

        var result = OtherPublicationsParser.GetPagesNumbers(citation);

        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetCountPages_SimpleTest()
    {
        var citation = "Факторы влияющие на обработку титановых сплавов с опережающим пластическим деформированием [Электронный ресурс] : доклад / И.Н. Козачухненко, Д.В. Крайнев, Н.Г. Сахнов // Практическое значение современных научных исследований ‘2017 : междунар. науч.-практ. Интернет-конф. (13-20 июня 2017 г.). Секция «Технические науки», подсекция «Машиноведение и машиностроение» / Научно-издательский проект «Scientific World» (SWorld). – [Одесса], 2017. – 6 с. – Режим доступа : http://www.sworld.education/index.php/ru/technical-sciences-ua217/machines-and-mechanical-engineering-ua217/29285-ua217-028";

        var expected = "6";

        var result = OtherPublicationsParser.GetCountPages(citation);
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetCountPages_EnglishTest()
    {
        var citation = "Blockchain and the institutional complexity: post-institutionalism vs. neoinstitutionalism / Д.П. Фролов // MPRA: Munich Personal RePEc Archive : [on-line publications] / Munich University Library. – Munich (Germany), 2019. – Paper No. 95963 (posted 13 September, 2019). – 18 p. – URL : https://mpra.ub.uni-muenchen.de/95963/1/MPRA_paper_95963.pdf";

        var expected = "18";

        var result = OtherPublicationsParser.GetCountPages(citation);
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetURL_SimpleTest()
    {
        var citation = "Женская территория / Ю.В. Артюхович // IV международная литературная премия «Перископ-2020» : литературный конкурс. – Волгоград, 2021. – С. 275-289. – URL: http://periscope-volga.ru/news/itogi_iv_mezhdunarodnoj_literaturnoj_premii_periskop_2020/2020-12-08-183";

        var expected = "URL: http://periscope-volga.ru/news/itogi_iv_mezhdunarodnoj_literaturnoj_premii_periskop_2020/2020-12-08-183";

        var result = OtherPublicationsParser.GetURL(citation);
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetNumber_SimpleTest()
    {
        var citation = " Blockchain and the institutional complexity: post-institutionalism vs. neoinstitutionalism / Д.П. Фролов // MPRA: Munich Personal RePEc Archive : [on-line publications] / Munich University Library. – Munich (Germany), 2019. – Paper No. 95963 (posted 13 September, 2019). – 18 p. – URL : https://mpra.ub.uni-muenchen.de/95963/1/MPRA_paper_95963.pdf";

        var expected = "Paper No. 95963 (posted 13 September, 2019)";

        var result = OtherPublicationsParser.GetNumber(citation);
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetNumber_SecondTest()
    {
        var citation = "«За боль и быль несбывшейся судьбы...» / Ю.В. Артюхович // Отчий край. – 2021. – № 1 (109). – С. 176-181";

        var expected = "№ 1 (109)";

        var result = OtherPublicationsParser.GetNumber(citation);
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetUniversities_SimpleTest()
    {
        var citation = "Blockchain and the institutional complexity: post-institutionalism vs. neoinstitutionalism / Д.П. Фролов // MPRA: Munich Personal RePEc Archive : [on-line publications] / Munich University Library. – Munich (Germany), 2019. – Paper No. 95963 (posted 13 September, 2019). – 18 p. – URL : https://mpra.ub.uni-muenchen.de/95963/1/MPRA_paper_95963.pdf";

        List<Company> universities = new List<Company>();
        universities.Add(new Company(){Name = "Munich University Library"});

        var result = OtherPublicationsParser.GetCompany(citation);

        Assert.Equal(universities.Count, result.Count);
        for (int i = 0; i < universities.Count; i++)
        {
            Assert.Equal(universities[i].Name, result[i].Name);
        }
    }

    [Fact]
    public void GetDateIntroduction_SimpleTest()
    {
        var citation =
            "Проектирование земляного полотна автомобильных дорог в сложных геологических, гидрологических и климатических условиях горной части республики Дагестан : СТО.25106343.01-2014.РМД : рег. метод. док. / С.В. Алексиков, А.И. Лескин, Д.И. Гофман ; Агентство по трансп. и дорож. хоз-ву респ. Дагестан. - Введ. 03 апреля 2015 г. - Махачкала, 2015. - 86 с. - (Стандарт организации)";
        
        var expected = "Введ. 03 апреля 2015 г";

        var result = OtherPublicationsParser.GetDateIntroduction(citation);
        
        Assert.Equal(expected, result);
    }
}
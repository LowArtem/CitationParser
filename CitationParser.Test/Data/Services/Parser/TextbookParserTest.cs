using CitationParser.Data.Model;
using CitationParser.Services.Parser;

namespace CitationParser.Test.Data.Services.Parser;

public class TextbookParserTest
{
    [Fact]
    public void GetEditor_SimpleTest()
    {
        var citation = "Надёжность и диагностика сложных систем: учебник . Рек. УМО по университетскому политехническому образованию / В.М. Труханов, А.Г. Тарнаев; под ред. В. М. Труханова. - Москва, 2016. - 174 с.";

        List<Editor> editors = new List<Editor>();
        editors.Add(new Editor(){Name = "В. М. Труханова"});

        var result = TextbookParser.GetEditor(citation);
        
        Assert.Equal(editors.Count, result.Count);
        for (int i = 0; i < editors.Count; i++)
        {
            Assert.Equal(editors[i].Name, result[i].Name);
        }
    }
    
    [Fact]
    public void GetEditor_NullTest()
    {
        var citation = "Митрофанова, И.А. Налоги и налогообложение: учебник / И.А. Митрофанова, А.Б. Тлисов, И.В. Митрофанова. - Москва ; Берлин, 2017. - 280 с.";

        var result = TextbookParser.GetEditor(citation);
        
        Assert.Null(result);
    }
    
    [Fact]
    public void GetEditor_PublicationsContainsCompanyTest()
    {
        var citation = " История оружия. Очерки развития артиллерии: учебник . Доп. УМО вузов РФ по университетскому политехническому образованию / О.Г. Агошков, А.Ю. Александров, В.В. Ветров, В.А. Власов, В.А. Девяткин, Н.В. Ежов, В.Ф. Захаренко, В.Г. Кучеров, Н.А. Макаровец, Г.М. Споршев, Н.Е. Стариков, Л.А. Устинов, Н.В. Федотова, С.Е. Червонцев, В.Г. Черный; под ред. В.Г. Кучерова ; ВолгГТУ. - Волгоград, 2015. - 271 с.";
        
        List<Editor> editors = new List<Editor>();
        editors.Add(new Editor(){Name = "В.Г. Кучерова"});
        
        var result = TextbookParser.GetEditor(citation);

        Assert.Equal(editors.Count, result.Count);
        for (int i = 0; i < editors.Count; i++)
        {
            Assert.Equal(editors[i].Name, result[i].Name);
        }
    }
    
    [Fact]
    public void GetEditor_MultipleEditorsTest()
    {
        var citation = "Проектирование спецмашин. Часть 1, книга 1. Артиллерийские стволы: учебник . Доп. Научно-методическим советом по специальности 17.05.02 «Стрелково-пушечное, артиллерийское и ракетное оружие» / О.Г. Агошков, А.Ю. Александров, С.А. Алексеев, Ю.Б. Брызгалов, И.Е. Волкова, В.А. Девяткин, А.С. Зайцев, И.В. Ковшов, В.Г. Кучеров, В.В. Стешов, Н.В. Федотова, С.Е. Червонцев; под ред. Г.И. Закаменных, В.Г. Кучерова, С.Е. Червонцева ; ВолгГТУ. - Волгоград, 2017. - 395 с";

        List<Editor> editors = new List<Editor>();
        editors.Add(new Editor(){Name = "Г.И. Закаменных"});
        editors.Add(new Editor(){Name = "В.Г. Кучерова"});
        editors.Add(new Editor(){Name = "С.Е. Червонцева"});



        var result = TextbookParser.GetEditor(citation);

        Assert.Equal(editors.Count, result.Count);
        for (int i = 0; i < editors.Count; i++)
        {
            Assert.Equal(editors[i].Name, result[i].Name);
        }
        
    }
    
    [Fact]
    public void GetUniversities_SimpleTest()
    {
        var citation = " История оружия. Очерки развития артиллерии: учебник . Доп. УМО вузов РФ по университетскому политехническому образованию / О.Г. Агошков, А.Ю. Александров, В.В. Ветров, В.А. Власов, В.А. Девяткин, Н.В. Ежов, В.Ф. Захаренко, В.Г. Кучеров, Н.А. Макаровец, Г.М. Споршев, Н.Е. Стариков, Л.А. Устинов, Н.В. Федотова, С.Е. Червонцев, В.Г. Черный; под ред. В.Г. Кучерова ; ВолгГТУ. - Волгоград, 2015. - 271 с.";

        List<Company> universities = new List<Company>();
        universities.Add(new Company(){Name = "ВолгГТУ"});

        var result = TextbookParser.GetCompany(citation);

        Assert.Equal(universities.Count, result.Count);
        for (int i = 0; i < universities.Count; i++)
        {
            Assert.Equal(universities[i].Name, result[i].Name);
        }
    }
    
    [Fact]
    public void GetCities_SimpleTest()
    {
        var citation = "Рынок ценных бумаг: учебник . В 3 ч. Ч. 2 (гл. 11-17). Рек. УМО по образованию в области финансов, учёта и мировой экономики / А.И. Гончаров, М.В. Гончарова. - Волгоград, 2012. - 223 с.";

        List<City> cities = new List<City>();
        cities.Add(new City() {Name = "Волгоград"});

        var result = TextbookParser.GetCities(citation);

        Assert.Equal(cities.Count, result.Count);
        for (int i = 0; i < cities.Count; i++)
        {
            Assert.Equal(cities[i].Name, result[i].Name);
        }
    }
    
    [Fact]
    public void GetCities_MultipleCitiesTest()
    {
        var citation = "Эксплуатация машин в строительстве. Ч. III. Производственная эксплуатация машин: учебник . Допущено Федеральным УМО по укрупнённой группе специальностей и направлений подготовки «Техника и технологии наземного транспорта» / В.М. Рогожкин, Н.А. Ушаков. - 2-е изд., перераб. и доп. - Волгоград ; Старый Оскол, 2019. - 248 с.";

        List<City> cities = new List<City>();
        cities.Add(new City() {Name = "Волгоград"});
        cities.Add(new City() {Name = "Старый Оскол"});

        var result = TextbookParser.GetCities(citation);

        Assert.Equal(cities.Count, result.Count);
        for (int i = 0; i < cities.Count; i++)
        {
            Assert.Equal(cities[i].Name, result[i].Name);
        }
    }
    
    [Fact]
    public void GetYear_SimpleTest()
    {
        var citation = "Автоматика и автоматизация рабочих и производственных процессов при эксплуатации транспортных средств: учебник . Доп. УМО вузов РФ по образованию в области транспортных машин и транспортно-технологических комплексов / А.А. Ревин, К.В. Чернышов, В.Г. Дыгало; под ред. А. А. Ревина. - Волгоград, 2015. - 387 с.";

        var expected = "2015";

        var result = TextbookParser.GetYear(citation);
        
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetYear_YearIsNotContainedAfterFirstDotAndHyphenTest()
    {
        var citation = "Эксплуатация машин в строительстве: учебник . Доп. Федеральным УМО по укрупнённой группе специальностей и направлений подготовки 23.00.00 «Техника и технологии наземного транспорта» / В.М. Рогожкин, Н.Н. Гребенникова. - Изд. второе, доп. и испр. - Москва, 2018. - 628 с.";

        var expected = "2018";

        var result = TextbookParser.GetYear(citation);
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetCountPages_SimpleTest()
    {
        var citation = "Финансы: учебник / Р.Р. Мавлютов; Волгогр. гос. техн. ун-т. - Волгоград, 2019. - 269 с.";

        var expected = "269 с.";

        var result = TextbookParser.GetCountPages(citation);
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetCountPages_NullTest()
    {
        var citation = "Финансы, денежное обращение и ипотека: учебник / Р.Р. Мавлютов; Волгогр. гос. техн. ун-т. - Волгоград, 2020 с.";
        
        var result = TextbookParser.GetCountPages(citation);
        
        Assert.Null(result);
    }
    
    [Fact]
    public void GetInformationAboutPublication_SimpleTest()
    {
        var citation = "Финансы, денежное обращение и кредит: учебник . Рекомендовано ФГБУ «ФИРО» в качестве учебника для использования в образовательном процессе образовательных организаций, реализующих программы СПО по специальностям «Экономика и бухгалтерский учет (по отраслям)», «Финансы (по отраслям)» / Л.В. Перекрестова, Н.М. Романенко, С.П. Сазонов. - 15-е изд., перераб. и доп. - Москва, 2020. - 320 с.";

        var expected = "15-е изд., перераб. и доп";

        var result = TextbookParser.GetInformationAboutPublication(citation);
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetVolume_SimpleTest()
    {
        var citation = "Проектирование и строительство морских нефтегазовых сооружений: учебник . Рек. УМО РАЕ / В.А. Перфилов, В.В. Габова, И.А. Томарева, У.В. Канавец; ВолгГТУ. - Волгоград, 2017. - Ч. 1. - 226 с.";

        var expected = "Ч. 1";

        var result = TextbookParser.GetVolumeNumbers(citation);
        
        Assert.Equal(expected, result);
    }
}
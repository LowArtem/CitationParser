using CitationParser.Data.Model;
using CitationParser.Services.Parser;

namespace CitationParser.Test.Data.Services.Parser;

public class StudyGuideWithStampParserTest
{
    [Fact]
    public void GetEditor_SimpleTest()
    {
        var citation = "Экспертиза дорожно-транспортных происшествий в примерах и задачах: учеб. пособ.(гриф) . Доп. ФУМО по укруп. гр. спец-тей и напр. подготовки 23.00.00 «Техника и технологии наземного транспорта» в кач. учеб. пособ. для обуч. по направл. подготовки: 23.03.01 «Технология транспортных процессов», «бакалавриат», 23.03.03 «Эксплуатация транспортно-технологических машин и комплексов», «бакалавриат», 23.04.01 «Технология транспортных процессов», «магистратура», 23.04.03 «Эксплуатация транспортно-технологических машин и комплексов», «магистратура» / Ю.Я. Комаров, С.В. Ганзин, Р.А. Жирков, Н.К. Клепик, Д.Ю. Комаров; под общ. ред. Ю. Я. Комарова. - 2-е изд., перераб. и доп. - Москва, 2022. - 312 с";

        List<Editor> editors = new List<Editor>();
        editors.Add(new Editor(){Name = "Ю. Я. Комарова"});

        var result = StudyGuideWithStampParser.GetEditor(citation);
        
        Assert.Equal(editors.Count, result.Count);
        for (int i = 0; i < editors.Count; i++)
        {
            Assert.Equal(editors[i].Name, result[i].Name);
        }
    }
    
    [Fact]
    public void GetEditor_NullTest()
    {
        var citation = "Инженерное благоустройство городских территорий: учеб. пособ.(гриф) / Н.В. Иванова, Г.В. Безугомоннов; Волгогр. гос. техн. ун-т. - Волгоград, 2023. - 110 с.";

        var result = StudyGuideWithStampParser.GetEditor(citation);
        
        Assert.Empty(result);
    }
    
    [Fact]
    public void GetEditor_PublicationsContainsCompanyTest()
    {
        var citation = "Озеленение и благоустройство придомовых территорий многоквартирного дома. Технико-экономическое обоснование проектных решений и разработка сметной документации: учеб. пособ.(гриф) / О.В. Максимчук, Н.В. Иванова, А.С. Соловьева; под ред. Максимчук О.В.; Волгогр. гос. техн. ун-т. - Волгоград, 2021. - 146 с";

        List<Editor> editors = new List<Editor>();
        editors.Add(new Editor(){Name = "Максимчук О.В."});

        var result = StudyGuideWithStampParser.GetEditor(citation);

        Assert.Equal(editors.Count, result.Count);
        for (int i = 0; i < editors.Count; i++)
        {
            Assert.Equal(editors[i].Name, result[i].Name);
        }
    }
    
    [Fact]
    public void GetEditor_MultipleEditorsTest()
    {
        var citation = "Основы рекламы: прикладные задачи и методы их решения: учеб. пособ.(гриф) . Рек. Минобрнауки (ФГОС 3+) / Е.Г. Попкова, Д.П. Фролов, В.И. Тинякова, Н.С. Полусмакова, О.Ф. Серова, В.В. Антоненко, Ю.И. Дубова, Д.В. Богданов; под ред. Д. П. Фролова, Е. Г. Попковой. - Москва, 2016. - 194 с";

        List<Editor> editors = new List<Editor>();
        editors.Add(new Editor(){Name = "Д. П. Фролова"});
        editors.Add(new Editor(){Name = "Е. Г. Попковой"});


        var result = StudyGuideWithStampParser.GetEditor(citation);

        Assert.Equal(editors.Count, result.Count);
        for (int i = 0; i < editors.Count; i++)
        {
            Assert.Equal(editors[i].Name, result[i].Name);
        }
    }
    
    [Fact]
    public void GetUniversities_SimpleTest()
    {
        var citation = "Организация расчётов с бюджетом и внебюджетными фондами: учеб. пособ.(гриф) . Доп. УМО Совета директоров профессиональных образовательных организаций Волгоградской области / Г.А. Машенцева, З.А. Костина; КТИ (филиал) ВолгГТУ. - Волгоград, 2016. - 103 с.";

        List<Company> universities = new List<Company>();
        universities.Add(new Company(){Name = "КТИ (филиал) ВолгГТУ"});

        var result = StudyGuideWithStampParser.GetCompany(citation);

        Assert.Equal(universities.Count, result.Count);
        for (int i = 0; i < universities.Count; i++)
        {
            Assert.Equal(universities[i].Name, result[i].Name);
        }
    }
    
    [Fact]
    public void GetUniversities_SquareBracketsTest()
    {
        var citation = "Металлорежущие станки. Лабораторный практикум: учеб. пособ.(гриф) . Доп. УМО вузов по образованию в области автоматизированного машиностроения (УМО АМ) / Н.И. Никифоров, Я.Н. Отений, А.М. Лаврентьев, А.Г. Схиртладзе; [ВолгГТУ]. - Волгоград ; Старый Оскол, 2018. - 175 с";

        List<Company> universities = new List<Company>();
        universities.Add(new Company(){Name = "ВолгГТУ"});

        var result = StudyGuideWithStampParser.GetCompany(citation);

        Assert.Equal(universities.Count, result.Count);
        for (int i = 0; i < universities.Count; i++)
        {
            Assert.Equal(universities[i].Name, result[i].Name);
        }
    }
    
    [Fact]
    public void GetCities_SimpleTest()
    {
        var citation = "Инженерное благоустройство городских территорий: учеб. пособ.(гриф) / Н.В. Иванова, Г.В. Безугомоннов; Волгогр. гос. техн. ун-т. - Волгоград, 2023. - 110 с";

        List<City> cities = new List<City>();
        cities.Add(new City() {Name = "Волгоград"});

        var result = StudyGuideWithStampParser.GetCities(citation);

        Assert.Equal(cities.Count, result.Count);
        for (int i = 0; i < cities.Count; i++)
        {
            Assert.Equal(cities[i].Name, result[i].Name);
        }
    }
    
    [Fact]
    public void GetCities_MultipleCitiesTest()
    {
        var citation = " Металлорежущие станки. Лабораторный практикум: учеб. пособ.(гриф) . Доп. УМО вузов по образованию в области автоматизированного машиностроения (УМО АМ) / Н.И. Никифоров, Я.Н. Отений, А.М. Лаврентьев, А.Г. Схиртладзе; [ВолгГТУ]. - Волгоград ; Старый Оскол, 2018. - 175 с";

        List<City> cities = new List<City>();
        cities.Add(new City() {Name = "Волгоград"});
        cities.Add(new City() {Name = "Старый Оскол"});

        var result = StudyGuideWithStampParser.GetCities(citation);

        Assert.Equal(cities.Count, result.Count);
        for (int i = 0; i < cities.Count; i++)
        {
            Assert.Equal(cities[i].Name, result[i].Name);
        }
    }
    
    [Fact]
    public void GetCities_MultipleCitiesAndPublishingHouseTest()
    {
        var citation = "Металлорежущие станки. Лабораторный практикум: учеб. пособ.(гриф) . Допущено УМО вузов по образованию в области автоматизированного машиностроения (УМО АМ) для студентов вузов, обучающихся по направлению «Конструкторско-технологическое обеспечение машиностроительных производств» / Н.И. Никифоров, Я.Н. Отений, А.М. Лаврентьев, А.Г. Схиртладзе. - Волгоград : ВолгГТУ ; Старый Оскол : ТНТ, 2021. - 176 с";

        List<City> cities = new List<City>();
        cities.Add(new City() {Name = "Волгоград"});
        cities.Add(new City() {Name = "Старый Оскол"});

        var result = StudyGuideWithStampParser.GetCities(citation);

        Assert.Equal(cities.Count, result.Count);
        for (int i = 0; i < cities.Count; i++)
        {
            Assert.Equal(cities[i].Name, result[i].Name);
        }
    }
    
    [Fact]
    public void GetYear_SimpleTest()
    {
        var citation = "Инженерное благоустройство городских территорий: учеб. пособ.(гриф) / Н.В. Иванова, Г.В. Безугомоннов; Волгогр. гос. техн. ун-т. - Волгоград, 2023. - 110 с";

        var expected = "2023";

        var result = StudyGuideWithStampParser.GetYear(citation);
        
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetYear_YearIsNotContainedAfterFirstDotAndHyphenTest()
    {
        var citation = "Микроэкономика: учеб. пособ.(гриф) . Рек. УМО вузов России по образованию в области финансов, учёта и мировой экономики (для студентов направления «Экономика») / И.А. Морозова, Л.С. Шаховская, О.Е. Акимова, С.К. Волков; ВолгГТУ. - 2-е изд., стер. - Волгоград, 2018. - 208 с";

        var expected = "2018";

        var result = StudyGuideWithStampParser.GetYear(citation);
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetCountPages_SimpleTest()
    {
        var citation = "Специальные виды литья. Часть 1: учеб. пособ.(гриф) . Допущено федеральным УМО по укрупнённой группе специальностей и направлений 22.00.00 «Технология материалов» в качестве учебного пособия при подготовке бакалавров, обучающихся по направлению 22.03.02 «Металлургия» / В.А. Гулевский, Н.А. Кидалов, Н.В. Маркина; ВолгГТУ. - Волгоград, 2019. - 80 с";

        var expected = "80";

        var result = StudyGuideWithStampParser.GetCountPages(citation);
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetCountPages_NullTest()
    {
        var citation = "Современные строительные системы гидрозащиты зданий и сооружений [Электронный ресурс]: учеб. пособ.(гриф) / В.Д. Тухарели, А.В. Тухарели, Т.Ф. Чередниченко; Волгогр. гос. техн. ун-т. - Волгоград, 2019 с";
        
        var result = StudyGuideWithStampParser.GetCountPages(citation);
        
        Assert.Null(result);
    }
    
    [Fact]
    public void GetInformationAboutPublication_SimpleTest()
    {
        var citation = " Микроэкономика: учеб. пособ.(гриф) . Рек. УМО вузов России по образованию в области финансов, учёта и мировой экономики (для студентов направления «Экономика») / И.А. Морозова, Л.С. Шаховская, О.Е. Акимова, С.К. Волков; ВолгГТУ. - 2-е изд., стер. - Волгоград, 2018. - 208 с";

        var expected = "2-е изд., стер";

        var result = StudyGuideWithStampParser.GetInformationAboutPublication(citation);
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetInformationAboutPublication_secondTest()
    {
        var citation = "Doing Business: учеб. пособ.(гриф) . Рек. УМО РАЕ по классическому университетскому и техническому образованию / И.В. Алещанова, Т.В. Сорокина, М.В. Мищенко; КТИ (филиал) ВолгГТУ. - 2-е изд. - Волгоград, 2009. - 95 с.";

        var expected = "2-е изд";

        var result = StudyGuideWithStampParser.GetInformationAboutPublication(citation);
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetInformationAboutPublication_PublicationAndStorageTest()
    {
        var citation = "Методы математической физики (с компьютерными вычислениями и анимацией): учеб. пособ.(гриф) . Рек. Федеральным агентством по образованию Российской Федерации / Г.Т. Тарабрин. - 4-е изд. ; 1 электрон. опт. диск (CD-ROM). - Ливны (Орловская обл.), 2011 с";

        var expected = "4-е изд.";

        var result = StudyGuideWithStampParser.GetInformationAboutPublication(citation);
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetDataStorage_SimpleTest()
    {
        var citation = "Комплексная разработка технологии возведения монолитных конструкций высотных и уникальных зданий [Электронный ресурс]: учеб. пособ.(гриф) / С.Г. Абрамян, О.В. Бурлаченко; Волгогр. гос. техн. ун-т. - Волгоград, 2018. - 1 электрон. опт. диск (CD-R) с";

        var expected = "1 электрон. опт. диск (CD-R) с";

        var result = StudyGuideWithStampParser.GetDataStorage(citation);
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetDataStorage_PublicationAndStorageTest()
    {
        var citation = "Методы математической физики (с компьютерными вычислениями и анимацией): учеб. пособ.(гриф) . Рек. Федеральным агентством по образованию Российской Федерации / Г.Т. Тарабрин. - 4-е изд. ; 1 электрон. опт. диск (CD-ROM). - Ливны (Орловская обл.), 2011 с";

        var expected = "1 электрон. опт. диск (CD-ROM)";

        var result = StudyGuideWithStampParser.GetDataStorage(citation);
        
        Assert.Equal(expected, result);
    }
}
using CitationParser.Data.Model;
using CitationParser.Services.Parser;

namespace CitationParser.Test.Data.Services.Parser;

public class MonographParserTest
{
    [Fact]
    public void GetEditor_SimpleTest()
    {
        var citation = " Надёжность артиллерийских систем: монография / В.М. Труханов, А.Г. Тарнаев, М.П. Кухтик; под ред. В. М. Труханова. - Москва, 2020. - 309 с.";

        List<Editor> editors = new List<Editor>();
        editors.Add(new Editor(){Name = "В. М. Труханова"});

        var result = MonographParser.GetEditor(citation);
        
        Assert.Equal(editors.Count, result.Count);
        for (int i = 0; i < editors.Count; i++)
        {
            Assert.Equal(editors[i].Name, result[i].Name);
        }
    }
    
    [Fact]
    public void GetEditor_NullTest()
    {
        var citation = "Повышение надежности и эффективности рельсошлифовальных инструментов на бакелитовой связке. Теория шлифования. Физико-химические основы: монография / В.М. Шумячер, С.А. Крюков, И.Ю. Орлов; ВПИ (филиал) ФГБОУ ВО ВолгГТУ. - Волгоград, 2021. - 161 с";

        var result = MonographParser.GetEditor(citation);
        
        Assert.Null(result);
    }
    
    [Fact]
    public void GetEditor_PublicationsContainsUniversityTest()
    {
        var citation = "Фторполимерные материалы: монография / Н.А. Адаменко, Е.Н. Больбасов, В.М. Бузник, С.Ю. Вавилова, С.В. Гнеденков, В.И. Дяченко, И.В. Зибарева, Л.Н. Игнатьева, С.М. Игумнов, А.В. Казуров, Д.П. Кирюхин, Г.А. Кичигина, Т.Ю. Кумеева, П.П. Кущ, Д.В. Машталяр, О.А. Мельник, В.Г. Назаров, Л.Н. Никитин, А.А. Охлопкова, Н.П. Пророкова, Е.Ю. Сафронова, С.А. Серов, С.Л. Синебрюхов, С.А. Слепцова, В.И. Соколов, В.П. Столяров, С.И. Твердохлебов, С.А. Хатипов, А.К. Цветников, Е.Ю. Шиц, А.Б. Ярославцев; отв. ред.: В. М. Бузник ; Ин-т химии растворов им. Г. А. Крестова РАН, Национальный исследовательский Томский гос. ун-т, ФГУП «Всероссийский НИИ авиационных материалов», Консорциум «Фторполимерные материалы и нанотехнологии». - Томск, 2017. - 596 с";

        List<Editor> editors = new List<Editor>();
        editors.Add(new Editor(){Name = "В. М. Бузник"});

        var result = MonographParser.GetEditor(citation);

        Assert.Equal(editors.Count, result.Count);
        for (int i = 0; i < editors.Count; i++)
        {
            Assert.Equal(editors[i].Name, result[i].Name);
        }
    }
    
    [Fact]
    public void GetEditor_MultipleEditorsTest()
    {
        var citation = "Развитие системы управления энергозатратами на предприятиях материально-технической базы строительства: монография / С.Е. Карпушова, С. М. Бобоев, Л.Н. Чижо, Т.А. Забазнова, В.А. Гец, В.А. Чеванин, Х.Т. Буриев; под общ. ред. С. М. Бобоева, С. Е. Карпушовой ; ВолгГТУ ; СамГАСИ. - изд 2-е, доп. и перераб.. - Волгоград ; Самарканд, 2020. - 139 с.";

        List<Editor> editors = new List<Editor>();
        editors.Add(new Editor(){Name = "С. М. Бобоева"});
        editors.Add(new Editor(){Name = "С. Е. Карпушовой"});


        var result = MonographParser.GetEditor(citation);

        Assert.Equal(editors.Count, result.Count);
        for (int i = 0; i < editors.Count; i++)
        {
            Assert.Equal(editors[i].Name, result[i].Name);
        }
    }
    
    [Fact]
    public void GetUniversities_SimpleTest()
    {
        var citation = "Повышение надежности и эффективности рельсошлифовальных инструментов на бакелитовой связке. Теория шлифования. Физико-химические основы: монография / В.М. Шумячер, С.А. Крюков, И.Ю. Орлов; ВПИ (филиал) ФГБОУ ВО ВолгГТУ. - Волгоград, 2021. - 161 с.";

        List<University> universities = new List<University>();
        universities.Add(new University(){Name = "ВПИ (филиал) ФГБОУ ВО ВолгГТУ"});

        var result = MonographParser.GetUniversity(citation);

        Assert.Equal(universities.Count, result.Count);
        for (int i = 0; i < universities.Count; i++)
        {
            Assert.Equal(universities[i].Name, result[i].Name);
        }
    }
    
    [Fact]
    public void GetUniversities_MultipleUniversitiesTest()
    {
        var citation = "Фторполимерные материалы: монография / Н.А. Адаменко, Е.Н. Больбасов, В.М. Бузник, С.Ю. Вавилова, С.В. Гнеденков, В.И. Дяченко, И.В. Зибарева, Л.Н. Игнатьева, С.М. Игумнов, А.В. Казуров, Д.П. Кирюхин, Г.А. Кичигина, Т.Ю. Кумеева, П.П. Кущ, Д.В. Машталяр, О.А. Мельник, В.Г. Назаров, Л.Н. Никитин, А.А. Охлопкова, Н.П. Пророкова, Е.Ю. Сафронова, С.А. Серов, С.Л. Синебрюхов, С.А. Слепцова, В.И. Соколов, В.П. Столяров, С.И. Твердохлебов, С.А. Хатипов, А.К. Цветников, Е.Ю. Шиц, А.Б. Ярославцев; отв. ред.: В. М. Бузник ; Ин-т химии растворов им. Г. А. Крестова РАН, Национальный исследовательский Томский гос. ун-т, ФГУП «Всероссийский НИИ авиационных материалов», Консорциум «Фторполимерные материалы и нанотехнологии». - Томск, 2017. - 596 с";

        List<University> universities = new List<University>();
        universities.Add(new University(){Name = "Ин-т химии растворов им. Г. А. Крестова РАН"});
        universities.Add(new University(){Name = "Национальный исследовательский Томский гос. ун-т"});
        universities.Add(new University(){Name = "ФГУП «Всероссийский НИИ авиационных материалов»"});
        universities.Add(new University(){Name = "Консорциум «Фторполимерные материалы и нанотехнологии»"});

        var result = MonographParser.GetUniversity(citation);

        Assert.Equal(universities.Count, result.Count);
        for (int i = 0; i < universities.Count; i++)
        {
            Assert.Equal(universities[i].Name, result[i].Name);
        }
    }
    
    [Fact]
    public void GetCities_SimpleTest()
    {
        var citation = "Повышение надежности и эффективности рельсошлифовальных инструментов на бакелитовой связке. Теория шлифования. Физико-химические основы: монография / В.М. Шумячер, С.А. Крюков, И.Ю. Орлов; ВПИ (филиал) ФГБОУ ВО ВолгГТУ. - Волгоград, 2021. - 161 с";

        List<City> cities = new List<City>();
        cities.Add(new City() {Name = "Волгоград"});

        var result = MonographParser.GetCities(citation);

        Assert.Equal(cities.Count, result.Count);
        for (int i = 0; i < cities.Count; i++)
        {
            Assert.Equal(cities[i].Name, result[i].Name);
        }
    }
    
    [Fact]
    public void GetCities_MultipleCitiesTest()
    {
        var citation = " Моделирование погрешностей обработки глубоких отверстий: монография / А.Ю. Горелова, М.Г. Кристаль. - Волгоград ; Старый Оскол, 2021. - 132 с";

        List<City> cities = new List<City>();
        cities.Add(new City() {Name = "Волгоград"});
        cities.Add(new City() {Name = "Старый Оскол"});

        var result = MonographParser.GetCities(citation);

        Assert.Equal(cities.Count, result.Count);
        for (int i = 0; i < cities.Count; i++)
        {
            Assert.Equal(cities[i].Name, result[i].Name);
        }
    }
    
    [Fact]
    public void GetCities_MultipleCitiesAndPublishingHouseTest()
    {
        var citation = "Повышение качества функционирования технологического оборудования: монография / Ю.П. Сердобинцев, О.В. Бурлаченко, А.Г. Схиртладзе. - 2-е изд., стер. - Волгоград : ВолгГТУ ; Старый Оскол : ТНТ, 2021. - 412 с";

        List<City> cities = new List<City>();
        cities.Add(new City() {Name = "Волгоград"});
        cities.Add(new City() {Name = "Старый Оскол"});

        var result = MonographParser.GetCities(citation);

        Assert.Equal(cities.Count, result.Count);
        for (int i = 0; i < cities.Count; i++)
        {
            Assert.Equal(cities[i].Name, result[i].Name);
        }
    }
    
    [Fact]
    public void GetYear_SimpleTest()
    {
        var citation = "Повышение надежности и эффективности рельсошлифовальных инструментов на бакелитовой связке. Теория шлифования. Физико-химические основы: монография / В.М. Шумячер, С.А. Крюков, И.Ю. Орлов; ВПИ (филиал) ФГБОУ ВО ВолгГТУ. - Волгоград, 2021. - 161 с";

        var expected = "2021";

        var result = MonographParser.GetYear(citation);
        
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetYear_YearIsNotContainedAfterFirstDotAndHyphenTest()
    {
        var citation = "Повышение качества функционирования технологического оборудования: монография / Ю.П. Сердобинцев, О.В. Бурлаченко, А.Г. Схиртладзе. - 2-е изд., стер. - Волгоград : ВолгГТУ ; Старый Оскол : ТНТ, 2021. - 412 с";

        var expected = "2021";

        var result = MonographParser.GetYear(citation);
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetCountPages_SimpleTest()
    {
        var citation = "Повышение надежности и эффективности рельсошлифовальных инструментов на бакелитовой связке. Теория шлифования. Физико-химические основы: монография / В.М. Шумячер, С.А. Крюков, И.Ю. Орлов; ВПИ (филиал) ФГБОУ ВО ВолгГТУ. - Волгоград, 2021. - 161 с";

        var expected = "161 с";

        var result = MonographParser.GetCountPages(citation);
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetInformationAboutPublication_SimpleTest()
    {
        var citation = "Краткий курс антидуринга. Монография по социальной экологии: монография / А.Б. Голованчиков. - Изд. 5-е, перераб. и доп. - Волгоград, 2020. - 312 с.";

        var expected = "Изд. 5-е, перераб. и доп";

        var result = MonographParser.GetInformationAboutPublication(citation);
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetDataStorage_SimpleTest()
    {
        var citation = "Страховой, бюджетный и банковский сектора России: тенденции и перспективы развития [Электронный ресурс]: монография / Д.М. Шор, С.П. Сазонов, И.М. Шор, А.С. Сазонов, Д.А. Шелестова; ВолГУ. - Волгоград, 2013. - 1 электрон. опт. диск (CD-ROM) с.";

        var expected = "1 электрон. опт. диск (CD-ROM) с.";

        var result = MonographParser.GetDataStorage(citation);
        
        Assert.Equal(expected, result);
    }
}
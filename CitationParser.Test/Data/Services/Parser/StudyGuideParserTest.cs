using CitationParser.Data.Model;
using CitationParser.Services.Parser;

namespace CitationParser.Test.Data.Services.Parser;

public class StudyGuideParserTest
{
    [Fact]
    public void GetEditor_SimpleTest()
    {
        var citation = "Тепломассообмен: учеб. пособие / В.С. Кузеванов, Г.С. Закожурникова, С.С. Закожурников; под ред. В. С. Кузеванова. - Москва, 2022. - 193 с.";

        List<Editor> editors = new List<Editor>();
        editors.Add(new Editor(){Name = "В. С. Кузеванова"});

        var result = StudyGuideParser.GetEditor(citation);
        
        Assert.Equal(editors.Count, result.Count);
        for (int i = 0; i < editors.Count; i++)
        {
            Assert.Equal(editors[i].Name, result[i].Name);
        }
    }
    
    [Fact]
    public void GetEditor_NullTest()
    {
        var citation = "Мир стритбола: учеб. пособие / И.Н. Прытков, Д.В. Николаев, Н.И. Грицак; КТИ (филиал) ВолгГТУ. - Волгоград, 2022. - 88 с.";

        var result = StudyGuideParser.GetEditor(citation);
        
        Assert.Null(result);
    }
    
    [Fact]
    public void GetEditor_PublicationsContainsUniversityTest()
    {
        var citation = "Надежность машин (теория и практика): учеб. пособие / С.А. Крюков, В.А. Граблин, Н.В. Байдакова; под ред. В. М. Шумячера ; ВПИ (филиал) ФГБОУ ВО ВолгГТУ. - Волжский, 2022 с.";

        List<Editor> editors = new List<Editor>();
        editors.Add(new Editor(){Name = "В. М. Шумячера"});

        var result = StudyGuideParser.GetEditor(citation);

        Assert.Equal(editors.Count, result.Count);
        for (int i = 0; i < editors.Count; i++)
        {
            Assert.Equal(editors[i].Name, result[i].Name);
        }
    }
    
    [Fact]
    public void GetEditor_MultipleEditorsTest()
    {
        var citation = "Внешнеэкономическая деятельность: учеб. пособие / О.Е. Акимова, И.В. Аракелова, А.А. Безлепкина, Е.Э. Головчанская, А.Ф. Джинджолия, И.В. Днепровская, Ю.И. Дубова, А.Ю. Заруднева, Л.Л. Заушицына, А.С. Иванов, В.А. Кабанов, О.Е. Малых, Я.С. Матковская, И.А. Морозова, Д. Тертри, Ж.-Л. Трюэль, А.А. Хрысева, Е.М. Черноуцан, Л.С. Шаховская; под общ. ред. Л. С. Шаховской, А. Ф. Джинджолия, И. А. Морозовой ; ВолгГТУ. - Волгоград ; Москва, 2019. - 307 с";

        List<Editor> editors = new List<Editor>();
        editors.Add(new Editor(){Name = "Л. С. Шаховской"});
        editors.Add(new Editor(){Name = "А. Ф. Джинджолия"});
        editors.Add(new Editor(){Name = "И. А. Морозовой"});



        var result = StudyGuideParser.GetEditor(citation);

        Assert.Equal(editors.Count, result.Count);
        for (int i = 0; i < editors.Count; i++)
        {
            Assert.Equal(editors[i].Name, result[i].Name);
        }
        
    }
    
    [Fact]
    public void GetUniversities_SimpleTest()
    {
        var citation = "Введение в направление: учеб. пособие / Е.Ю. Силаева, Е.Л. Еремина; ВПИ (филиал) ВолгГТУ. - Волжский, 2019 с.";

        List<University> universities = new List<University>();
        universities.Add(new University(){Name = "ВПИ (филиал) ВолгГТУ"});

        var result = StudyGuideParser.GetUniversity(citation);

        Assert.Equal(universities.Count, result.Count);
        for (int i = 0; i < universities.Count; i++)
        {
            Assert.Equal(universities[i].Name, result[i].Name);
        }
    }
    
    [Fact]
    public void GetUniversities_ContainsCollectionTest()
    {
        var citation = "Компьютерная графика : конспект лекций для студентов направлений 230100.62 «Информатика и вычислительная техника» и 231000.62 «Программная инженерия» [Электронный ресурс]: учеб. пособие / О.Ф. Абрамова; ВПИ (филиал) ВолгГТУ // Учебные пособия : сб. Серия «Естественнонаучные и технические дисциплины». Вып. 3. - 1 электрон. опт. диск (CD-ROM) ; формат pdf. - Волжский, 2012. - 165 с";

        List<University> universities = new List<University>();
        universities.Add(new University(){Name = "ВПИ (филиал) ВолгГТУ"});

        var result = StudyGuideParser.GetUniversity(citation);

        Assert.Equal(universities.Count, result.Count);
        for (int i = 0; i < universities.Count; i++)
        {
            Assert.Equal(universities[i].Name, result[i].Name);
        }
    }
    
     [Fact]
    public void GetCities_SimpleTest()
    {
        var citation = "Выполнение и оформление магистерской диссертации: учеб. пособие / Е.Е. Сидорова, В.А. Кабанов; ВолгГТУ. - Волгоград, 2012. - 32 с.";

        List<City> cities = new List<City>();
        cities.Add(new City() {Name = "Волгоград"});

        var result = StudyGuideParser.GetCities(citation);

        Assert.Equal(cities.Count, result.Count);
        for (int i = 0; i < cities.Count; i++)
        {
            Assert.Equal(cities[i].Name, result[i].Name);
        }
    }
    
    [Fact]
    public void GetYear_SimpleTest()
    {
        var citation = "Педагогическое проектирование: учеб. пособие / Р.М. Петрунева, Н.В. Дулина, В.Д. Васильева, Л.А. Федотова; ВолгГТУ. - Волгоград, 2012. - 78 с";

        var expected = "2012";

        var result = StudyGuideParser.GetYear(citation);
        
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetYear_YearIsNotContainedAfterFirstDotAndHyphenTest()
    {
        var citation = "Планирование и организация эксперимента. Ч. 1 [Электронный ресурс]: учеб. пособие / А.В. Авилов, Р.А. Белухин; ВПИ (филиал) ВолгГТУ // Учебные пособия : сб. Серия \"Естественнонаучные и технические дисциплины\". Вып. 6. - 1 электрон. опт. диск (CD-ROM), формат pdf. - Волгоград, 2012. - 34 с";

        var expected = "2012";

        var result = StudyGuideParser.GetYear(citation);
        
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetCountPages_SimpleTest()
    {
        var citation = "Планирование и организация эксперимента. Ч. 1 [Электронный ресурс]: учеб. пособие / А.В. Авилов, Р.А. Белухин; ВПИ (филиал) ВолгГТУ // Учебные пособия : сб. Серия \"Естественнонаучные и технические дисциплины\". Вып. 6. - 1 электрон. опт. диск (CD-ROM), формат pdf. - Волгоград, 2012. - 34 с.";

        var expected = "34 с.";

        var result = StudyGuideParser.GetCountPages(citation);
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetCountPages_NullTest()
    {
        var citation = "Праздники и обычаи немецкого народа. Тексты и упражнения для практических занятий по немецкому языку [Электронный ресурс]: учеб. пособие / И.Р. Балагурова; Волгогр. гос. архит.-строит. ун-т. - Волгоград, 2012 с.";
        
        var result = StudyGuideParser.GetCountPages(citation);
        
        Assert.Null(result);
    }
    
    [Fact]
    public void GetInformationAboutPublication_SimpleTest()
    {
        var citation = "Динамика движения. Регулируемые подвески: учеб. пособие / К.В. Чернышов, И.М. Рябов, В.В. Новиков, А.В. Поздеев, А.М. Ковалев. - 2-е изд. - Москва ; Вологда, 2023. - 160 с.";

        var expected = "2-е изд";

        var result = StudyGuideParser.GetInformationAboutPublication(citation);
        
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetScientificCollection_SimpleTest()
    {
        var citation =
            "Введение в наноматериалы и нанотехнологии [Электронный ресурс]: учеб. пособие / В.Ф. Каблов, М.П. Спиридонова, О.М. Новопольцева; ВПИ (филиал) ВолгГТУ // Учебные пособия : сб. Вып. 5. – 1 электрон. опт. диск (CD-ROM). - Волгоград, 2015. - 92 с.";

        var expected = new ScientificCollection() { Title = "Учебные пособия : сб. Вып. 5" };

        var result = StudyGuideParser.GetScientificCollection(citation);
        
        Assert.Equal(expected.Title, result.Title);
    }
    
    [Fact]
    public void GetDataStorage_SimpleTest()
    {
        var citation = "Введение в наноматериалы и нанотехнологии [Электронный ресурс]: учеб. пособие / В.Ф. Каблов, М.П. Спиридонова, О.М. Новопольцева; ВПИ (филиал) ВолгГТУ // Учебные пособия : сб. Вып. 5. – 1 электрон. опт. диск (CD-ROM). - Волгоград, 2015. - 92 с.";

        var expected = "1 электрон. опт. диск (CD-ROM)";

        var result = StudyGuideParser.GetDataStorage(citation);
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetURL_SimpleTest()
    {
        var citation = "Введение в системный анализ. Методы принятия управленческих решений [Электронный ресурс]: учеб. пособие / А.Н. Салугин; М-во образования и науки Рос. Федерации, Волгогр. гос. архит.-строит. ун-т. - Электрон. изд. сетевого доступа. - Волгоград, 2015. - Режим доступа: http://www.vgasu.ru/publishing/on-line/ с.";

        var expected = "Режим доступа: http://www.vgasu.ru/publishing/on-line/ с.";

        var result = StudyGuideParser.GetURL(citation);
        
        Assert.Equal(expected, result);
    }
}
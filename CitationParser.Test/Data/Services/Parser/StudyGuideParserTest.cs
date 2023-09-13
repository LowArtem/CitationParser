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
    
    
}
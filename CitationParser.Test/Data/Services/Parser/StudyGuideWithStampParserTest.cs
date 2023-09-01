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
        var citation = "Инженерное благоустройство городских территорий: учеб. пособ.(гриф) / Н.В. Иванова, Г.В. Безугомоннов; Волгогр. гос. техн. ун-т. - Волгоград, 2023. - 110 с.";

        var result = StudyGuideWithStampParser.GetEditor(citation);
        
        Assert.Null(result);
    }
    
    [Fact]
    public void GetEditor_PublicationsContainsUniversityTest()
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
}
using CitationParser.Data.Model;
using CitationParser.Services.Parser;

namespace CitationParser.Test.Data.Services.Parser;

public class DepositedManuscriptParserTest
{
    [Fact]
    public void GetYear_SimpleTest()
    {
        var citation = "Ударное взаимодействие поршневого кольца и стенок канавки поршня: Депонированная рукопись/ В.М. Славуцкий, Х.А. Балхавдаров, А.П. Семерня; ВолгПИ. - Волгоград, 1988. - 6 c. - Деп. в Депонированная рукопись 1988-11-29, № 1090.";

        var expected = "1988";
        
        var result = DepositedManuscriptParser.GetYear(citation);
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetCity_SimpleTest()
    {
        var citation = "Ударное взаимодействие поршневого кольца и стенок канавки поршня: Депонированная рукопись/ В.М. Славуцкий, Х.А. Балхавдаров, А.П. Семерня; ВолгПИ. - Волгоград, 1988. - 6 c. - Деп. в Депонированная рукопись 1988-11-29, № 1090.";

        City expected = new City() {Name = "Волгоград"};
        
        City result = DepositedManuscriptParser.GetCity(citation);
        
        Assert.Equal(expected.Name, result.Name);
    }
    
    [Fact]
    public void GetInformation_SimpleTest()
    {
        var citation = "Ударное взаимодействие поршневого кольца и стенок канавки поршня: Депонированная рукопись/ В.М. Славуцкий, Х.А. Балхавдаров, А.П. Семерня; ВолгПИ. - Волгоград, 1988. - 6 c. - Деп. в Депонированная рукопись 1988-11-29, № 1090.";

        string expected = "Деп. в Депонированная рукопись 1988-11-29, № 1090.";
        
        string result = DepositedManuscriptParser.GetInformation(citation);
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetCompany_SimpleTest()
    {
        var citation = "Ударное взаимодействие поршневого кольца и стенок канавки поршня: Депонированная рукопись/ В.М. Славуцкий, Х.А. Балхавдаров, А.П. Семерня; ВолгПИ. - Волгоград, 1988. - 6 c. - Деп. в Депонированная рукопись 1988-11-29, № 1090.";

        List<Company> expected = new List<Company>();
        expected.Add(new Company() {Name = "ВолгПИ"});
        
        List<Company> result = DepositedManuscriptParser.GetCompany(citation);
        
        Assert.Equal(expected[0].Name, result[0].Name);
    }
    
    [Fact]
    public void GetUniversities_SimpleTest()
    {
        var citation = "Ломакин, Н.И. Пути повышения качества и сокращения потерь овощной продукции: Депонированная рукопись/ Н.И. Ломакин; ТСХА, Госагропром СССР // Труды научной конференции молодых учёных, 9-12 июня 1987 г. - М., 1987. - 131141 c. - Деп. в Депонированная рукопись 1988-02-22, № 101/12";

        List<Company> expected = new List<Company>();
        expected.Add(new Company() {Name = "ТСХА"});
        expected.Add(new Company() {Name = "Госагропром СССР"});

        List<Company> result = DepositedManuscriptParser.GetCompany(citation);
        
        Assert.Equal(expected[0].Name, result[0].Name);
        Assert.Equal(expected[1].Name, result[1].Name);
    }
    
    [Fact]
    public void GetTitleOfSource_SimpleTest()
    {
        var citation = "Влияние температуры отпуска на свойства сварных соединений стали ЭП-428, выполненных электронно-лучевой сваркой: Депонированная рукопись/ М.А. Хубрих, Ж.А. Лепилина, М.А. Крикво, Е.Б. Сахновская, В.О. Янушкевич; /Металловедение и прочность материалов /ВолгПИ. - Волгоград, 1987. - 166179 c. - Деп. в Депонированная рукопись 1987-08-31, № 4117.";

        string expected = "Металловедение и прочность материалов";
        
        string result = DepositedManuscriptParser.GetTitleOfSource(citation);
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetTitleOfSourceAfterDoubleSlash_SimpleTest()
    {
        var citation = "О возможности применения слоистых композиций для изготовления элементов шарнирных соединений: Депонированная рукопись/ В.И. Кудряшов, Д.И. Цветков, В.В. Каширин, А.Н. Бугаева; ВолгПИ // Металловедение и прочность материалов. - Волгоград, 1987. - 0.257266 c. - Деп. в Депонированная рукопись 1987-08-31, № 4117";

        string expected = "Металловедение и прочность материалов";
        
        string result = DepositedManuscriptParser.GetTitleOfSource(citation);
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetPages_SimpleTest()
    {
        var citation = "Ударное взаимодействие поршневого кольца и стенок канавки поршня: Депонированная рукопись/ В.М. Славуцкий, Х.А. Балхавдаров, А.П. Семерня; ВолгПИ. - Волгоград, 1988. - 6 c. - Деп. в Депонированная рукопись 1988-11-29, № 1090.";

        var expected = "6";
        
        var result = DepositedManuscriptParser.GetPages(citation);
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetPages_SimpleNullTest()
    {
        var citation = "Информационные возможности электрофизических методов исследования слоистых структур с областями пространственного заряда: Депонированная рукопись/ В.П. Заярный, В.Э. Клюкин, Б.В. Шульгин, В.С. Старцев, А.А. Кошта; *. - *, 1987 c. - Деп. в Депонированная рукопись, № 6463.";

        var result = DepositedManuscriptParser.GetPages(citation);
        
        Assert.Equal(null, result);
    }
}
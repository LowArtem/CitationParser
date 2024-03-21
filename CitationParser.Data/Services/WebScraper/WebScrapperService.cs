using CitationParser.Core.Model.WebSrapper;
using Flurl.Http;

namespace CitationParser.Data.Services.WebScraper;

/// <summary>
/// Получать данные с сайта
/// </summary>
public class WebScraperService
{
    private const string _BASE_URL = "http://library.vstu.ru/publ_2/publ_result.php";

    /// <summary>
    /// Получить публикации заданного типа
    /// </summary>
    /// <param name="typeEnum">тип публикации</param>
    /// <returns></returns>
    public async Task<string> GetPublications(PublicationTypeEnum typeEnum)
    {
        return typeEnum switch
        {
            PublicationTypeEnum.DepositedManuscripts => await GetPublicationsOfDepositedManuscripts(),
            PublicationTypeEnum.Certificate => await GetPublicationsOfCertificate(),
            PublicationTypeEnum.Monograph => await GetPublicationsOfMonograph(),
            PublicationTypeEnum.Other => await GetPublicationsOfOther(),
            PublicationTypeEnum.Patent => await GetPublicationsOfPatent(),
            PublicationTypeEnum.Textbook => await GetPublicationsOfTextbook(),
            PublicationTypeEnum.ReportAbstracts => await GetPublicationsOfReportAbstracts(),
            PublicationTypeEnum.StudyGuide1 => await GetPublicationsOfStudyGuide(),
            PublicationTypeEnum.StudyGuide2 => await GetPublicationsOfStudyGuideWithStamp(),
            PublicationTypeEnum.VstuMagazines => await GetPublicationsOfVstuMagazines(),
            PublicationTypeEnum.VstuNews => await GetPublicationsOfVstuNews(),
            PublicationTypeEnum.EducationalMethodicalComplex => await GetPublicationsOfEducationalAndMethodicalComplex(),
            PublicationTypeEnum.ForeignCollectionArticle => await GetPublicationsOfArticleFromForeignColl(),
            PublicationTypeEnum.ForeignMagazineArticle => await GetPublicationsOfForeignMagazineArticle(),
            PublicationTypeEnum.RussianCollectionArticle => await GetPublicationsOfArticleFromRussianColl(),
            PublicationTypeEnum.RussianMagazineArticle => await GetPublicationsOfRussianMagazineArticle(),
            _ => throw new NotImplementedException()
        };
    }

    private async Task<string> GetPublicationsOfDepositedManuscripts()
    {
        return await _BASE_URL
            .PostUrlEncodedAsync(new
            {
                universitet = "2", fio = "", year_rel = "", year_rel1 = "", year_rel2 = "", year_reg = "",
                year_reg1 = "", year_reg2 = "", faculty = "4", kafedra = "43", v_publ = "6"
            })
            .ReceiveString();
    }
    
    private async Task<string> GetPublicationsOfArticleFromForeignColl()
    {
        return await _BASE_URL
            .PostUrlEncodedAsync(new
            {
                universitet = "2", fio = "", year_rel = "", year_rel1 = "", year_rel2 = "", year_reg = "",
                year_reg1 = "", year_reg2 = "", faculty = "4", kafedra = "43", v_publ = "13"
            })
            .ReceiveString();
    }
    
    private async Task<string> GetPublicationsOfArticleFromRussianColl()
    {
        return await _BASE_URL
            .PostUrlEncodedAsync(new
            {
                universitet = "2", fio = "", year_rel = "", year_rel1 = "", year_rel2 = "", year_reg = "",
                year_reg1 = "", year_reg2 = "", faculty = "4", kafedra = "43", v_publ = "5"
            })
            .ReceiveString();
    }
    
    private async Task<string> GetPublicationsOfEducationalAndMethodicalComplex()
    {
        return await _BASE_URL
            .PostUrlEncodedAsync(new
            {
                universitet = "2", fio = "", year_rel = "", year_rel1 = "", year_rel2 = "", year_reg = "",
                year_reg1 = "", year_reg2 = "", faculty = "4", kafedra = "43", v_publ = "7"
            })
            .ReceiveString();
    }
    
    private async Task<string> GetPublicationsOfForeignMagazineArticle()
    {
        return await _BASE_URL
            .PostUrlEncodedAsync(new
            {
                universitet = "2", fio = "", year_rel = "", year_rel1 = "", year_rel2 = "", year_reg = "",
                year_reg1 = "", year_reg2 = "", faculty = "4", kafedra = "43", v_publ = "12"
            })
            .ReceiveString();
    }
    
    private async Task<string> GetPublicationsOfRussianMagazineArticle()
    {
        return await _BASE_URL
            .PostUrlEncodedAsync(new
            {
                universitet = "2", fio = "", year_rel = "", year_rel1 = "", year_rel2 = "", year_reg = "",
                year_reg1 = "", year_reg2 = "", faculty = "4", kafedra = "43", v_publ = "4"
            })
            .ReceiveString();
    }
    
    private async Task<string> GetPublicationsOfMonograph()
    {
        return await _BASE_URL
            .PostUrlEncodedAsync(new
            {
                universitet = "2", fio = "", year_rel = "", year_rel1 = "", year_rel2 = "", year_reg = "",
                year_reg1 = "", year_reg2 = "", faculty = "4", kafedra = "43", v_publ = "1"
            })
            .ReceiveString();
    }
    
    private async Task<string> GetPublicationsOfOther()
    {
        return await _BASE_URL
            .PostUrlEncodedAsync(new
            {
                universitet = "2", fio = "", year_rel = "", year_rel1 = "", year_rel2 = "", year_reg = "",
                year_reg1 = "", year_reg2 = "", faculty = "4", kafedra = "43", v_publ = "8"
            })
            .ReceiveString();
    }
    
    private async Task<string> GetPublicationsOfPatent()
    {
        return await _BASE_URL
            .PostUrlEncodedAsync(new
            {
                universitet = "2", fio = "", year_rel = "", year_rel1 = "", year_rel2 = "", year_reg = "",
                year_reg1 = "", year_reg2 = "", faculty = "4", kafedra = "43", v_publ = "10"
            })
            .ReceiveString();
    }
    
    private async Task<string> GetPublicationsOfCertificate()
    {
        return await _BASE_URL
            .PostUrlEncodedAsync(new
            {
                universitet = "2", fio = "", year_rel = "", year_rel1 = "", year_rel2 = "", year_reg = "",
                year_reg1 = "", year_reg2 = "", faculty = "4", kafedra = "43", v_publ = "15"
            })
            .ReceiveString();
    }
    
    private async Task<string> GetPublicationsOfReportAbstracts()
    {
        return await _BASE_URL
            .PostUrlEncodedAsync(new
            {
                universitet = "2", fio = "", year_rel = "", year_rel1 = "", year_rel2 = "", year_reg = "",
                year_reg1 = "", year_reg2 = "", faculty = "4", kafedra = "43", v_publ = "9"
            })
            .ReceiveString();
    }
    
    private async Task<string> GetPublicationsOfStudyGuide()
    {
        return await _BASE_URL
            .PostUrlEncodedAsync(new
            {
                universitet = "2", fio = "", year_rel = "", year_rel1 = "", year_rel2 = "", year_reg = "",
                year_reg1 = "", year_reg2 = "", faculty = "4", kafedra = "43", v_publ = "3"
            })
            .ReceiveString();
    }
    
    private async Task<string> GetPublicationsOfStudyGuideWithStamp()
    {
        return await _BASE_URL
            .PostUrlEncodedAsync(new
            {
                universitet = "2", fio = "", year_rel = "", year_rel1 = "", year_rel2 = "", year_reg = "",
                year_reg1 = "", year_reg2 = "", faculty = "4", kafedra = "43", v_publ = "11"
            })
            .ReceiveString();
    }
    
    private async Task<string> GetPublicationsOfTextbook()
    {
        return await _BASE_URL
            .PostUrlEncodedAsync(new
            {
                universitet = "2", fio = "", year_rel = "", year_rel1 = "", year_rel2 = "", year_reg = "",
                year_reg1 = "", year_reg2 = "", faculty = "4", kafedra = "43", v_publ = "2"
            })
            .ReceiveString();
    }
    
    private async Task<string> GetPublicationsOfVstuMagazines()
    {
        return await _BASE_URL
            .PostUrlEncodedAsync(new
            {
                universitet = "2", fio = "", year_rel = "", year_rel1 = "", year_rel2 = "", year_reg = "",
                year_reg1 = "", year_reg2 = "", faculty = "4", kafedra = "43", v_publ = "17"
            })
            .ReceiveString();
    }
    
    private async Task<string> GetPublicationsOfVstuNews()
    {
        return await _BASE_URL
            .PostUrlEncodedAsync(new
            {
                universitet = "2", fio = "", year_rel = "", year_rel1 = "", year_rel2 = "", year_reg = "",
                year_reg1 = "", year_reg2 = "", faculty = "4", kafedra = "43", v_publ = "14"
            })
            .ReceiveString();
    }
}
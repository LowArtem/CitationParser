using CitationParser.Core.Model.WebSrapper;
using Flurl.Http;

namespace CitationParser.Data.Services.WebScraper;

/// <summary>
/// Получать данные с сайта
/// </summary>
public class WebScraperService
{
    private const string _BASE_URL = "http://library.vstu.ru/publ_2/publ_result.php";

    // data
    // universitet=2&fio=&year_rel=&year_rel1=&year_rel2=&year_reg=&year_reg1=&year_reg2=&faculty=4&kafedra=43&v_publ=9

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
}
using AutoMapper;
using CitationParser.Api.Api._Base;
using CitationParser.Core.Repositories;
using CitationParser.Data.Context;
using CitationParser.Data.Model;
using CitationParser.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;

namespace CitationParser.Api.Api;
/// <summary>
/// контроллер для публикаций
/// </summary>
[Route(("api/[controller]"))]
public class PublicationController:BaseCrudController<Publication, Publication, Publication>
{
    /// <inheritdoc />
    public PublicationController(IEfCoreRepository<Publication> repository,
        ILogger<BaseCrudController<Publication, Publication, Publication>> logger, IMapper mapper) : 
        base(repository, logger, mapper)
    {
        
    }
    
    /// <summary>
    /// Получение списка части записей
    /// </summary>
    /// <param name="limit">Количество записей в ответе (выбираются первые {limit} записей из выборки после {skip} элементов)
    /// <br/><br/>
    /// <b>Max value = 1000</b>
    /// </param>
    /// <param name="skip">Пропускается первых {skip} записей</param>
    /// <returns></returns>
    [HttpGet("piece1/")]
    [SwaggerResponse(200, "Список записей успешно получен")]
    public virtual ActionResult<List<Publication>> ListEntitiesPiece(string title, string author=null, string year=null, int type=-1,
        string titleOfSource=null, string doi=null, string city=null, string university= null, int limit = 1000, int skip = 0)
    {
        if (limit is < 0 or > 1000) limit = 1000;
        if (skip < 0) skip = 0;

        var result = List.Where(p => p.Title == title)
            .OrderBy(p => p.DateCreate)
            .Skip(skip)
            .Take(limit)
            .Select(x => _mapper.Map<Publication>(x))
            .ToList();

        return Ok(result);
    }
}
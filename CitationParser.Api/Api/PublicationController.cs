using AutoMapper;
using CitationParser.Api.Api._Base;
using CitationParser.Core.Repositories;
using CitationParser.Data.Context;
using CitationParser.Data.Model;
using CitationParser.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MoreLinq;
using MoreLinq.Extensions;
using Swashbuckle.AspNetCore.Annotations;
using ForEachExtension = MoreLinq.Extensions.ForEachExtension;

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
    [HttpGet("publications/")]
    [SwaggerResponse(200, "Список записей успешно получен")]
    public virtual ActionResult<List<Publication>> PublicationsPiece(string title="", string author="", string year="", int type=-1,
        string titleOfSource="", string doi="", string city="", string university= "", int limit = 1000, int skip = 0)
    {
        if (limit is < 0 or > 1000) limit = 1000;
        if (skip < 0) skip = 0;
        
        var result = _repository.Get(p => 
                p.Title.Contains(title) &&
                (p.Year == null || p.Year.Contains(year)) &&
                (type == -1 || p.Type.Id == type) &&
                (doi == "" || p.Doi == doi),
            
            list => list.OrderBy(p => p.DateCreate),
            "IdScientificCollection,IdAuthors,IdCities,IdEditors,IdUniversities")
            .Select(x => _mapper.Map<Publication>(x))
            .ToList();
        
        result = result.Where(p => 
        (author == "" || !p.IdAuthors.Where(a => a.Name.Contains(author)).IsNullOrEmpty()) &&
        (p.TitleOfSource == null || p.TitleOfSource.Contains(titleOfSource)) &&
         (titleOfSource == "" ||
          !p.IdScientificCollection.Where(s => s.Title.Contains(titleOfSource)).IsNullOrEmpty())
        &&
        (city == "" || !p.IdCities.Where(c => c.Name == city).IsNullOrEmpty()) &&
        (university == "" || !p.IdUniversities.Where(u => u.Name.Contains(university)).IsNullOrEmpty()))
            .Skip(skip)
            .Take(limit)
            .ToList();
        
        result.ForEach(p =>
        {
            p.IdUniversities.ToList().ForEach( u => u.IdPublications.Clear());
            p.IdCities.ToList().ForEach( c => c.IdPublications.Clear());
            p.IdScientificCollection.ToList().ForEach( s => s.IdPublications.Clear());
            p.IdAuthors.ToList().ForEach( a => a.IdPublications.Clear());
            p.IdEditors.ToList().ForEach( e => e.IdPublications.Clear());

        });

        return Ok(result);
    }
}
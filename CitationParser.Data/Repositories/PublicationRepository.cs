using CitationParser.Core.Model._Base;
using CitationParser.Core.Repositories;
using CitationParser.Data.Context;
using CitationParser.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace CitationParser.Data.Repositories;

/// <summary>
/// Репозиторий публикации
/// </summary>
/// <typeparam name="TEntity">модель</typeparam>
public class PublicationRepository : EfCoreRepository<Publication, ApplicationContext>
{
    private readonly ILogger<IEfCoreRepository<Publication>> _logger;

    public PublicationRepository(ApplicationContext context,
        ILogger<IEfCoreRepository<Publication>> logger) : base(context, logger)
    {
    }
    
    /// <summary>
    /// добавить публикацию в базу данных
    /// </summary>
    /// <param name="typeStr">тип публикации</param>
    /// <param name="publication">публикация</param>
    /// <returns></returns>
    public void Add(Publication publication, string typeStr)
    {
        
        var type = _db.TypesOfPublications.Where(t => t.Name == typeStr).ToArray();
            
        publication.Type = type[0];
        
        AddAuthorsToPublication(publication);
        AddCitiesToPublication(publication);
        AddEditorsToPublication(publication);
        AddUniversitiesToPublication(publication);
        AddScientificCollectionToPublication(publication);
        Add(publication);
        SaveChanges();
    }
    
    private Publication AddAuthorsToPublication(Publication publication)
    {
        ICollection<Author> authors = new List<Author>();
        foreach (var a in publication.IdAuthors)
        {
            var author = CheckThereAuthorInDB(a);

            authors.Add(author.IsNullOrEmpty() ? a : author.First());
        }

        publication.IdAuthors = authors;

        return publication;
    }
    
    private Publication AddCitiesToPublication(Publication publication)
    {
        ICollection<City> cities = new List<City>();
        foreach (var c in publication.IdCities)
        {
            var city = CheckThereCityInDB(c);

            cities.Add(city.IsNullOrEmpty() ? c : city.First());
        }

        publication.IdCities = cities;

        return publication;
    }
    
    private Publication AddEditorsToPublication(Publication publication)
    {
        ICollection<Editor> editors = new List<Editor>();
        foreach (var e in publication.IdEditors)
        {
            var editor = CheckThereEditorInDB(e);

            editors.Add(editor.IsNullOrEmpty() ? e : editor.First());
        }

        publication.IdEditors = editors;

        return publication;
    }
    
    private Publication AddUniversitiesToPublication(Publication publication)
    {
        ICollection<Company> universities = new List<Company>();
        foreach (var u in publication.IdUniversities)
        {
            var university = CheckThereUniversityInDB(u);

            universities.Add(university.IsNullOrEmpty() ? u : university.First());
        }

        publication.IdUniversities = universities;

        return publication;
    }
    
    private Publication AddScientificCollectionToPublication(Publication publication)
    {
        ICollection<ScientificCollection> collections = new List<ScientificCollection>();
        foreach (var sc in publication.IdScientificCollection)
        {
            var scientificCollection = CheckThereScientificCollectionInDB(sc);

            collections.Add(scientificCollection.IsNullOrEmpty() ? sc : scientificCollection.First());
        }

        publication.IdScientificCollection = collections;

        return publication;
    }

    /// <summary>
    /// проверить есть ли публикация в бд
    /// </summary>
    /// <param name="publication">публикация</param>
    /// <returns>true - публикация есть в бд, false - публикации нет в бд</returns>
    public bool CheckTherePublicationInDb(Publication publication)
    {
        var publications = Get((p => p.Title == publication.Title),
            includeProperties: "IdScientificCollection,IdAuthors,IdCities,IdEditors,IdUniversities"
            );
        foreach (var d in publications)
        {
            if (publication.Equals(d))
                return true;
        }

        return false;
    }
    
    /// <summary>
    /// проверить есть ли Город в бд
    /// </summary>
    /// <param name="city">город</param>
    /// <returns>true - город есть в бд, false - города нет в бд</returns>
    private IQueryable<City> CheckThereCityInDB(City city)
    {
        return _db.Cities.Where(c => c.Name == city.Name);
    }
    
    /// <summary>
    /// проверить есть ли университет в бд
    /// </summary>
    /// <param name="university">университет</param>
    /// <returns>true - университет есть в бд, false - университета нет в бд</returns>
    private IQueryable<Company> CheckThereUniversityInDB(Company university)
    {
        return _db.Universities.Where(c => c.Name == university.Name);
    }
    
    /// <summary>
    /// проверить есть ли научный сборник в бд
    /// </summary>
    /// <param name="sc">научный сборник</param>
    /// <returns>true - научный сборник есть в бд, false - сборника нет в бд</returns>
    private IQueryable<ScientificCollection> CheckThereScientificCollectionInDB(ScientificCollection sc)
    {
        return _db.ScientificCollections.Where(s => s.Title == sc.Title);
    }
    
    /// <summary>
    /// проверить есть ли автор в бд
    /// </summary>
    /// <param name="author">автор</param>
    /// <returns>true - автор есть в бд, false - автора нет в бд</returns>
    private IQueryable<Author> CheckThereAuthorInDB(Author author)
    {
        return _db.Authors.Where(a => a.Name == author.Name);
    }
    
    /// <summary>
    /// проверить есть ли редактор в бд
    /// </summary>
    /// <param name="editor">редактор</param>
    /// <returns>true - редактор есть в бд, false - редактора нет в бд</returns>
    private IQueryable<Editor> CheckThereEditorInDB(Editor editor)
    {
        return _db.Editors.Where(e => e.Name == editor.Name);
    }
}
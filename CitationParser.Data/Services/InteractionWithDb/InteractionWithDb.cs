using CitationParser.Core.Model.WebSrapper;
using CitationParser.Data.Context;
using CitationParser.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace CitationParser.Data.Services.InteractionWithDb;

/// <summary>
/// взаимодействие с базой данных
/// </summary>
public class InteractionWithDb
{
    
    /// <summary>
    /// добавить публикацию в базу данных
    /// </summary>
    /// <param name="typeStr">тип публикации</param>
    /// <param name="publication">публикация</param>
    /// <param name="db">контекст базы данных</param>
    /// <returns></returns>
    public static void AddPublicationToDb(Publication publication, string typeStr, ApplicationContext db)
    {
        
        var type = db.TypesOfPublications.Where(t => t.Name == typeStr).ToArray();
            
        publication.Type = type[0];
        
        AddAuthorsToPublication(publication, db);
        AddCitiesToPublication(publication, db);
        AddEditorsToPublication(publication, db);
        AddUniversitiesToPublication(publication, db);
        AddScientificCollectionToPublication(publication, db);
        db.Publications.Add(publication);
        db.SaveChanges();
    }
    
    private static Publication AddAuthorsToPublication(Publication publication, ApplicationContext db)
    {
        ICollection<Author> authors = new List<Author>();
        foreach (var a in publication.IdAuthors)
        {
            var author = CheckThereAuthorInDB(a, db);

            authors.Add(author.IsNullOrEmpty() ? a : author.First());
        }

        publication.IdAuthors = authors;

        return publication;
    }
    
    private static Publication AddCitiesToPublication(Publication publication, ApplicationContext db)
    {
        ICollection<City> cities = new List<City>();
        foreach (var c in publication.IdCities)
        {
            var city = CheckThereCityInDB(c, db);

            cities.Add(city.IsNullOrEmpty() ? c : city.First());
        }

        publication.IdCities = cities;

        return publication;
    }
    
    private static Publication AddEditorsToPublication(Publication publication, ApplicationContext db)
    {
        ICollection<Editor> editors = new List<Editor>();
        foreach (var e in publication.IdEditors)
        {
            var editor = CheckThereEditorInDB(e, db);

            editors.Add(editor.IsNullOrEmpty() ? e : editor.First());
        }

        publication.IdEditors = editors;

        return publication;
    }
    
    private static Publication AddUniversitiesToPublication(Publication publication, ApplicationContext db)
    {
        ICollection<Company> universities = new List<Company>();
        foreach (var u in publication.IdUniversities)
        {
            var university = CheckThereUniversityInDB(u, db);

            universities.Add(university.IsNullOrEmpty() ? u : university.First());
        }

        publication.IdUniversities = universities;

        return publication;
    }
    
    private static Publication AddScientificCollectionToPublication(Publication publication, ApplicationContext db)
    {
        ICollection<ScientificCollection> collections = new List<ScientificCollection>();
        foreach (var sc in publication.IdScientificCollection)
        {
            var scientificCollection = CheckThereScientificCollectionInDB(sc, db);

            collections.Add(scientificCollection.IsNullOrEmpty() ? sc : scientificCollection.First());
        }

        publication.IdScientificCollection = collections;

        return publication;
    }

    /// <summary>
    /// проверить есть ли публикация в бд
    /// </summary>
    /// <param name="publication">публикация</param>
    /// <param name="db">контекст базы данных</param>
    /// <returns>true - публикация есть в бд, false - публикации нет в бд</returns>
    public static bool CheckTherePublicationInDb(Publication publication, ApplicationContext db)
    {
        var publications = db.Publications.Include(p => p.IdScientificCollection)
            .Include(p => p.IdAuthors)
            .Include(p => p.IdCities)
            .Include(p => p.IdEditors)
            .Include(p => p.IdUniversities)
            .Where(p => p.Title == publication.Title);
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
    /// <param name="db">контекст базы данных</param>
    /// <returns>true - город есть в бд, false - города нет в бд</returns>
    private static IQueryable<City> CheckThereCityInDB(City city, ApplicationContext db)
    {
        return db.Cities.Where(c => c.Name == city.Name);
    }
    
    /// <summary>
    /// проверить есть ли университет в бд
    /// </summary>
    /// <param name="university">университет</param>
    /// <param name="db">контекст базы данных</param>
    /// <returns>true - университет есть в бд, false - университета нет в бд</returns>
    private static IQueryable<Company> CheckThereUniversityInDB(Company university, ApplicationContext db)
    {
        return db.Universities.Where(c => c.Name == university.Name);
    }
    
    /// <summary>
    /// проверить есть ли научный сборник в бд
    /// </summary>
    /// <param name="sc">научный сборник</param>
    /// <param name="db">контекст базы данных</param>
    /// <returns>true - научный сборник есть в бд, false - сборника нет в бд</returns>
    private static IQueryable<ScientificCollection> CheckThereScientificCollectionInDB(ScientificCollection sc, ApplicationContext db)
    {
        return db.ScientificCollections.Where(s => s.Title == sc.Title);
    }
    
    /// <summary>
    /// проверить есть ли автор в бд
    /// </summary>
    /// <param name="author">автор</param>
    /// <param name="db">контекст базы данных</param>
    /// <returns>true - автор есть в бд, false - автора нет в бд</returns>
    private static IQueryable<Author> CheckThereAuthorInDB(Author author, ApplicationContext db)
    {
        return db.Authors.Where(a => a.Name == author.Name);
    }
    
    /// <summary>
    /// проверить есть ли редактор в бд
    /// </summary>
    /// <param name="editor">редактор</param>
    /// <param name="db">контекст базы данных</param>
    /// <returns>true - редактор есть в бд, false - редактора нет в бд</returns>
    private static IQueryable<Editor> CheckThereEditorInDB(Editor editor, ApplicationContext db)
    {
        return db.Editors.Where(e => e.Name == editor.Name);
    }
}
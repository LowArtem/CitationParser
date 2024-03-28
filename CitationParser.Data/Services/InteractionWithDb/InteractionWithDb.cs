using CitationParser.Data.Context;
using CitationParser.Data.Model;

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
            
        db.Authors.AddRange(publication.IdAuthors);
        db.Cities.AddRange(publication.IdCities);
        db.Editors.AddRange(publication.IdEditors);
        db.Universities.AddRange(publication.IdUniversities);
        db.ScientificCollections.AddRange(publication.IdScientificCollection);
        db.Publications.Add(publication);
        db.SaveChanges();
    }
}
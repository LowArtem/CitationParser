using CitationParser.Core.Model.WebSrapper;
using CitationParser.Data.Context;
using CitationParser.Data.Model;
using CitationParser.Data.Services.InteractionWithDb;
using CitationParser.Data.Services.WebScraper;
using Hangfire;

namespace CitationParser.Api.Services;

/// <summary>
/// Сервис для запуска фоновых задач
/// </summary>
public class TimeHostedService : BackgroundService
{
    private readonly IServiceProvider _scopeFactory;
    private readonly IRecurringJobManager _recurringJobs;
    private readonly IBackgroundJobClient _backgroundJobs;

    public TimeHostedService(IServiceProvider scopeFactory, IRecurringJobManager recurringJobs,
        IBackgroundJobClient backgroundJobs)
    {
        _scopeFactory = scopeFactory;
        _recurringJobs = recurringJobs;
        _backgroundJobs = backgroundJobs;
    }

    /// <inheritdoc />
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _recurringJobs.AddOrUpdate("парсинг новых публикаций",
            () => ParsePublicationsAndWriteToDb(), "0 1 * * *");
    }

    /// <summary>
    /// распарсить и записать в бд цитаты всех типов
    /// </summary>
    public async Task ParsePublicationsAndWriteToDb()
    {
        using var scope = _scopeFactory.CreateScope();
        var webScrapper = scope.ServiceProvider.GetRequiredService<WebScraperService>();
        var htmlParser = scope.ServiceProvider.GetRequiredService<ParseHtmlService>();
        var citationParser = scope.ServiceProvider.GetRequiredService<Data.Services.Parser.CitationParser>();

        using (ApplicationContext db = new ApplicationContext())
        {
            foreach (var type in Enum.GetValues<PublicationTypeEnum>())
            {
                var html = await webScrapper.GetPublications(type);
                var publications = htmlParser.GetPublications(html);

                for (int i = 0; i < publications.Count; i++)
                {
                    Publication citation = citationParser.PublicationParse(type, publications[i]);
                    
                    if (!InteractionWithDb.CheckTherePublicationInDb(citation, db))
                        InteractionWithDb.AddPublicationToDb(citation, type.ToString(), db);
                    else
                        i = publications.Count;
                }

                Console.WriteLine(type.ToString() + " completed");
            }
            Console.WriteLine(DateTime.Now.ToString());
        }
    }
}
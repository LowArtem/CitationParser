using CitationParser.Core.Model.WebSrapper;
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
        using var scope = _scopeFactory.CreateScope();
        var webScrapper = scope.ServiceProvider.GetRequiredService<WebScraperService>();
        var htmlParser = scope.ServiceProvider.GetRequiredService<ParseHtmlService>();

        foreach (var type in Enum.GetValues<PublicationTypeEnum>())
        {
            var html = await webScrapper.GetPublications(type);
            var publications = htmlParser.GetPublications(html);

            // TODO: доделать логику парсинга
            _recurringJobs.AddOrUpdate($"Парсинг публикаций типа {type}", () => htmlParser.GetPublications(html),
                Cron.Weekly);
        }
    }
}
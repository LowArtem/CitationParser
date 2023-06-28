using CitationParser.Core.Model._Base;
using CitationParser.Core.Repositories;
using CitationParser.Data.Context;
using Microsoft.Extensions.Logging;

namespace CitationParser.Data.Repositories;

/// <summary>
/// Базовый репозиторий приложения
/// </summary>
/// <typeparam name="TEntity">модель</typeparam>
public class ApplicationRepository<TEntity> : EfCoreRepository<TEntity, ApplicationContext>
    where TEntity : class, IEntity
{
    private readonly ILogger<IEfCoreRepository<TEntity>> _logger;

    public ApplicationRepository(ApplicationContext context,
        ILogger<IEfCoreRepository<TEntity>> logger) : base(context, logger)
    {
    }
}
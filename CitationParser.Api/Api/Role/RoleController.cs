using AutoMapper;
using CitationParser.Api.Api._Base;
using CitationParser.Api.Attributes;
using CitationParser.Api.Dto.Role;
using CitationParser.Core.Dto;
using CitationParser.Core.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CitationParser.Api.Api.Role;

/// <summary>
/// Контроллер управления ролями
/// </summary>
[ApiController]
[ApiVersion("1.0")]
[SetRoute]
[Authorize]
public class RoleController : BaseCrudController<Core.Model.Auth.Role, RoleRequestDto, RoleResponseDto>
{
    public RoleController(IEfCoreRepository<Core.Model.Auth.Role> repository,
        ILogger<BaseCrudController<Core.Model.Auth.Role, RoleRequestDto, RoleResponseDto>> logger, IMapper mapper) :
        base(repository, logger, mapper)
    {
    }
}
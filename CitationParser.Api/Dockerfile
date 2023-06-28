FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["CitationParser.Api/CitationParser.Api.csproj", "CitationParser.Api/"]
COPY ["CitationParser.Data/CitationParser.Data.csproj", "CitationParser.Data/"]
COPY ["CitationParser.Core/CitationParser.Core.csproj", "CitationParser.Core/"]
RUN dotnet restore "CitationParser.Api/CitationParser.Api.csproj"
COPY . .
WORKDIR "/src/CitationParser.Api"
RUN dotnet build "CitationParser.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CitationParser.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CitationParser.Api.dll"]

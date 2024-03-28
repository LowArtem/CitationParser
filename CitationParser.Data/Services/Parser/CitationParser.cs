using System.Runtime.ConstrainedExecution;
using CitationParser.Core.Model.WebSrapper;
using CitationParser.Data.Context;
using CitationParser.Data.Model;
using CitationParser.Services.Parser;
using Microsoft.EntityFrameworkCore;

namespace CitationParser.Data.Services.Parser;

/// <summary>
/// парсер цитат из строки в классы
/// </summary>
public class CitationParser
{
    /// <summary>
    /// распарсить цитату
    /// </summary>
    /// <param name="type">тип публикации</param>
    /// <param name="publication">публикация</param>
    /// <returns></returns>
    public Publication PublicationParse(PublicationTypeEnum type, string publication)
    {
        switch (type)
        {
            case PublicationTypeEnum.DepositedManuscripts:
                return DepositedManuscriptsParse(publication);
            case PublicationTypeEnum.Certificate:
                return CertificateParse(publication);
            case PublicationTypeEnum.Monograph:
                return MonographParse(publication);
            case PublicationTypeEnum.Other:
                return OtherParse(publication);
            case PublicationTypeEnum.Patent:
                return PatentParse(publication);
            case PublicationTypeEnum.Textbook:
                return TextbookParse(publication);
            case PublicationTypeEnum.ReportAbstracts:
                return ReportAbstractsParse(publication);
            case PublicationTypeEnum.StudyGuide1:
                return StudyGuideParse(publication);
            case PublicationTypeEnum.StudyGuide2:
                return StudyGuideWithStampParse(publication);
            case PublicationTypeEnum.VstuMagazines:
                return VstuMagazinesParse(publication);
            case PublicationTypeEnum.VstuNews:
                return VstuNewsParse(publication);
            case PublicationTypeEnum.EducationalMethodicalComplex:
                return EducationalMethodicalComplexParse(publication);
            case PublicationTypeEnum.ForeignCollectionArticle:
                return ForeignCollectionArticleParse(publication);
            case PublicationTypeEnum.ForeignMagazineArticle:
                return ForeignMagazineArticleParse(publication);
            case PublicationTypeEnum.RussianCollectionArticle:
                return RussianCollectionArticleParse(publication);
            case PublicationTypeEnum.RussianMagazineArticle: 
                return RussianMagazineArticleParse(publication);
            default:
                return null;
        }
    }

    private Publication DepositedManuscriptsParse(string publication)
    {
        Publication p = new Publication()
        {
            Title = CitationParseFunctions.GetName(publication),
            IdAuthors = CitationParseFunctions.GetAuthors(publication),
            IdUniversities = DepositedManuscriptParser.GetCompany(publication),
            TitleOfSource = DepositedManuscriptParser.GetTitleOfSource(publication),
            IdCities = new List<City>() {DepositedManuscriptParser.GetCity(publication)},
            Year = DepositedManuscriptParser.GetYear(publication),
            CountOfPages = DepositedManuscriptParser.GetPages(publication),
            Information = DepositedManuscriptParser.GetInformation(publication)
        };

        return p;
    }
    
    private Publication CertificateParse(string publication)
    {
        Publication p = new Publication()
        {
            Title = CitationParseFunctions.GetName(publication),
            IdAuthors = CitationParseFunctions.GetAuthors(publication, true),
            IdUniversities = PatentDocumentAndCertificateParser.GetCompanies(publication),
            Year = PatentDocumentAndCertificateParser.GetYear(publication)
        };

        return p;
    }
    
    private Publication MonographParse(string publication)
    {
        Publication p = new Publication()
        {
            Title = CitationParseFunctions.GetName(publication),
            IdAuthors = CitationParseFunctions.GetAuthors(publication, true),
            IdUniversities = MonographParser.GetCompany(publication),
            Year = MonographParser.GetYear(publication),
            CountOfPages = MonographParser.GetCountPages(publication),
            DataStorage = MonographParser.GetDataStorage(publication),
            InformationAboutPublication = MonographParser.GetInformationAboutPublication(publication),
            IdCities = MonographParser.GetCities(publication),
            IdEditors = MonographParser.GetEditor(publication)
        };
        
        return p;
    }
    
    private Publication OtherParse(string publication)
    {
        Publication p = new Publication()
        {
            Title = CitationParseFunctions.GetName(publication),
            IdAuthors = CitationParseFunctions.GetAuthors(publication),
            IdUniversities = OtherPublicationsParser.GetCompany(publication),
            Year = OtherPublicationsParser.GetYear(publication),
            CountOfPages = OtherPublicationsParser.GetCountPages(publication),
            Number = OtherPublicationsParser.GetNumber(publication),
            DateIntroduction = OtherPublicationsParser.GetDateIntroduction(publication),
            IdCities = OtherPublicationsParser.GetCities(publication),
            PageNumbers = OtherPublicationsParser.GetPagesNumbers(publication),
            PublishingHouse = OtherPublicationsParser.GetPublishingHouse(publication),
            TitleOfSource = OtherPublicationsParser.GetTitleSource(publication),
            Url = OtherPublicationsParser.GetURL(publication)
        };

        return p;
    }
    
    private Publication PatentParse(string publication)
    {
        Publication p = new Publication()
        {
            Title = CitationParseFunctions.GetName(publication),
            IdAuthors = CitationParseFunctions.GetAuthors(publication, true),
            IdUniversities = PatentDocumentAndCertificateParser.GetCompanies(publication),
            Year = PatentDocumentAndCertificateParser.GetYear(publication)
        };

        return p;
    }
    
    private Publication TextbookParse(string publication)
    {
        Publication p = new Publication()
        {
            Title = CitationParseFunctions.GetName(publication),
            IdAuthors = CitationParseFunctions.GetAuthors(publication),
            IdUniversities = TextbookParser.GetCompany(publication),
            Year = TextbookParser.GetYear(publication),
            CountOfPages = TextbookParser.GetCountPages(publication),
            IdEditors = TextbookParser.GetEditor(publication),
            IdCities = TextbookParser.GetCities(publication),
            VolumeNumber = TextbookParser.GetVolumeNumbers(publication),
            InformationAboutPublication = TextbookParser.GetInformationAboutPublication(publication)
        };

        return p;
    }
    
    private Publication ReportAbstractsParse(string publication)
    {
        Publication p = new Publication()
        {
            Title = CitationParseFunctions.GetName(publication),
            IdAuthors = CitationParseFunctions.GetAuthors(publication),
            IdUniversities = ReportAbstractsParser.GetCompanies(publication),
            Year = ReportAbstractsParser.GetYear(publication),
            CountOfPages = ReportAbstractsParser.GetPages(publication),
            IdEditors = ReportAbstractsParser.GetEditors(publication),
            IdCities = ReportAbstractsParser.GetCity(publication),
            VolumeNumber = ReportAbstractsParser.GetVolume(publication),
            Number = ReportAbstractsParser.GetNumber(publication),
            Language = ReportAbstractsParser.GetLanguage(publication),
            Url = ReportAbstractsParser.GetUrl(publication),
            TitleOfSource = ReportAbstractsParser.GetTitleOfSource(publication),
            PublishingHouse = ReportAbstractsParser.GetPublishingHouse(publication)
        };

        return p;
    }
    
    private Publication StudyGuideParse(string publication)
    {
        var scientificCollection = StudyGuideParser.GetScientificCollection(publication);
        
        Publication p = new Publication()
        {
            Title = CitationParseFunctions.GetName(publication),
            IdAuthors = CitationParseFunctions.GetAuthors(publication, true),
            IdUniversities = StudyGuideParser.GetCompany(publication),
            Year = StudyGuideParser.GetYear(publication),
            CountOfPages = StudyGuideParser.GetCountPages(publication),
            IdEditors = StudyGuideParser.GetEditor(publication),
            IdCities = StudyGuideParser.GetCities(publication),
            InformationAboutPublication = StudyGuideParser.GetInformationAboutPublication(publication),
            IdScientificCollection = scientificCollection != null ? new List<ScientificCollection>(){scientificCollection}
                :new List<ScientificCollection>(),
            DataStorage = StudyGuideParser.GetDataStorage(publication),
            Url = StudyGuideParser.GetURL(publication)
        };

        return p;
    }
    
    private Publication StudyGuideWithStampParse(string publication)
    {
        Publication p = new Publication()
        {
            Title = CitationParseFunctions.GetName(publication),
            IdAuthors = CitationParseFunctions.GetAuthors(publication, true),
            IdUniversities = StudyGuideWithStampParser.GetCompany(publication),
            Year = StudyGuideWithStampParser.GetYear(publication),
            CountOfPages = StudyGuideWithStampParser.GetCountPages(publication),
            IdEditors = StudyGuideWithStampParser.GetEditor(publication),
            IdCities = StudyGuideWithStampParser.GetCities(publication),
            InformationAboutPublication = StudyGuideWithStampParser.GetInformationAboutPublication(publication),
            DataStorage = StudyGuideWithStampParser.GetDataStorage(publication)
        };
        
        return p;
    }
    
    private Publication VstuMagazinesParse(string publication)
    {
        Publication p = new Publication()
        {
            Title = CitationParseFunctions.GetName(publication),
            IdAuthors = CitationParseFunctions.GetAuthors(publication),
            Number = VstuJournalParser.GetNumber(publication),
            Year = VstuJournalParser.GetPublicationYear(publication),
            PageNumbers = VstuJournalParser.GetPageNumbers(publication),
            Doi = VstuJournalParser.GetDoi(publication),
            TitleOfSource = VstuJournalParser.GetSourceName(publication)
        };

        return p;
    }
    
    private Publication VstuNewsParse(string publication)
    {
        Publication p = new Publication()
        {
            Title = CitationParseFunctions.GetName(publication),
            IdAuthors = CitationParseFunctions.GetAuthors(publication),
            Number = VstuJournalParser.GetNumber(publication),
            Year = VstuJournalParser.GetPublicationYear(publication),
            PageNumbers = VstuJournalParser.GetPageNumbers(publication),
            Doi = VstuJournalParser.GetDoi(publication),
            TitleOfSource = VstuJournalParser.GetSourceName(publication)
        };

        return p;
    }
    
    private Publication EducationalMethodicalComplexParse(string publication)
    {
        Publication p = new Publication()
        {
            Title = CitationParseFunctions.GetName(publication),
            IdAuthors = CitationParseFunctions.GetAuthors(publication),
            IdUniversities = EducationalAndMethodicalComplexParser.GetCompany(publication),
            Year = EducationalAndMethodicalComplexParser.GetYear(publication),
            CountOfPages = EducationalAndMethodicalComplexParser.GetCountPages(publication),
            Number = EducationalAndMethodicalComplexParser.GetComplexNumber(publication),
            IdCities = EducationalAndMethodicalComplexParser.GetCities(publication),
            InformationAboutPublication = EducationalAndMethodicalComplexParser.GetInformationAboutPublication(publication),
            DataStorage = EducationalAndMethodicalComplexParser.GetDataStorage(publication),
            Information = EducationalAndMethodicalComplexParser.GetInformation(publication),
            DateOfRegistration = EducationalAndMethodicalComplexParser.GetDateOfRegistration(publication),
            PublishingHouse = EducationalAndMethodicalComplexParser.GetPublishingHouse(publication),
            PlaceOfRegistration = EducationalAndMethodicalComplexParser.GetPlaceOfRegistration(publication),
            RegistrationNumber = EducationalAndMethodicalComplexParser.GetRegistrationNumber(publication)
        };

        return p;
    }
    
    private Publication ForeignCollectionArticleParse(string publication)
    {
        Publication p = new Publication()
        {
            Title = CitationParseFunctions.GetName(publication),
            IdAuthors = CitationParseFunctions.GetAuthors(publication),
            IdUniversities = ArticleFromForeignCollection.GetCompanyScientificCollection(publication),
            Year = ArticleFromForeignCollection.GetYearScientificCollection(publication),
            CountOfPages = ArticleFromForeignCollection.GetCountPagesScientificCollection(publication),
            ArticleNumber = ArticleFromForeignCollection.GetArticleNumberScientificCollection(publication),
            IdCities = ArticleFromForeignCollection.GetCitiesScientificCollection(publication),
            PageNumbers = ArticleFromForeignCollection.GetPagesNumbersScientificCollection(publication),
            Url = ArticleFromForeignCollection.GetURLScientificCollection(publication),
            Doi = ArticleFromForeignCollection.GetDOIScientificCollection(publication),
            IdEditors = ArticleFromForeignCollection.GetEditorScientificCollection(publication),
            PublishingHouse = ArticleFromForeignCollection.GetPublishingHouseScientificCollection(publication),
            IdScientificCollection = new List<ScientificCollection>()
            {
                ArticleFromForeignCollection.GetTitleScientificCollection(publication)
            }
        };

        return p;
    }
    
    private Publication RussianCollectionArticleParse(string publication)
    {
        Publication p = new Publication()
        {
            Title = CitationParseFunctions.GetName(publication),
            IdAuthors = CitationParseFunctions.GetAuthors(publication),
            IdUniversities = ArticleFromRussianCollectionParser.GetCompanyScientificCollection(publication),
            Year = ArticleFromRussianCollectionParser.GetYearScientificCollection(publication),
            CountOfPages = ArticleFromRussianCollectionParser.GetCountPagesScientificCollection(publication),
            ArticleNumber = ArticleFromRussianCollectionParser.GetArticleNumberScientificCollection(publication),
            IdCities = ArticleFromRussianCollectionParser.GetCitiesScientificCollection(publication),
            PageNumbers = ArticleFromRussianCollectionParser.GetPagesNumbersScientificCollection(publication),
            Url = ArticleFromRussianCollectionParser.GetURLScientificCollection(publication),
            Doi = ArticleFromRussianCollectionParser.GetDOIScientificCollection(publication),
            IdEditors = ArticleFromRussianCollectionParser.GetEditorScientificCollection(publication),
            DataStorage = ArticleFromRussianCollectionParser.GetDataStorageScientificCollection(publication),
            PublishingHouse = ArticleFromRussianCollectionParser.GetPublishingHouse(publication),
            IdScientificCollection = new List<ScientificCollection>()
            {
                ArticleFromRussianCollectionParser.GetTitleScientificCollection(publication)
            },
            VolumeNumber = ArticleFromRussianCollectionParser.GetVolumeNumbersScientificCollection(publication)
        };
        
        return p;
    }
    
    private Publication ForeignMagazineArticleParse(string publication)
    {
        Publication p = new Publication()
        {
            Title = CitationParseFunctions.GetName(publication),
            IdAuthors = CitationParseFunctions.GetAuthors(publication),
            IdUniversities = MagazineArticleParser.GetCompanies(publication),
            Year = MagazineArticleParser.GetPublicationYear(publication),
            CountOfPages = MagazineArticleParser.GetCountOfPages(publication),
            ArticleNumber = MagazineArticleParser.GetArticleNumber(publication),
            PageNumbers = MagazineArticleParser.GetPageNumbers(publication),
            Url = MagazineArticleParser.GetUrl(publication),
            Doi = MagazineArticleParser.GetDoi(publication),
            IdEditors = MagazineArticleParser.GetEditors(publication),
            VolumeNumber = MagazineArticleParser.GetVolume(publication),
            Number = MagazineArticleParser.GetNumber(publication),
            TitleOfSource = MagazineArticleParser.GetTitleOfSource(publication)
        };

        return p;
    }
    
    private Publication RussianMagazineArticleParse(string publication)
    {
        Publication p = new Publication()
        {
            Title = CitationParseFunctions.GetName(publication),
            IdAuthors = CitationParseFunctions.GetAuthors(publication),
            PublishingHouse = MagazineArticleParser.GetPublishingHouse(publication),
            Year = MagazineArticleParser.GetPublicationYear(publication),
            CountOfPages = MagazineArticleParser.GetCountOfPages(publication),
            ArticleNumber = MagazineArticleParser.GetArticleNumber(publication),
            PageNumbers = MagazineArticleParser.GetPageNumbers(publication),
            IdCities = MagazineArticleParser.GetCities(publication),
            Url = MagazineArticleParser.GetUrl(publication),
            Doi = MagazineArticleParser.GetDoi(publication),
            IdEditors = MagazineArticleParser.GetEditorsFromRussianMagazine(publication),
            VolumeNumber = MagazineArticleParser.GetVolume(publication),
            Number = MagazineArticleParser.GetNumber(publication),
            TitleOfSource = MagazineArticleParser.GetTitleOfSource(publication)
        };

        return p;
    }
}
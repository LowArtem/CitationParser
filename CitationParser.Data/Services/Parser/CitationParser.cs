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
    public void PublicationParse(PublicationTypeEnum type, string publication, ApplicationContext db)
    {
        switch (type)
        {
            case PublicationTypeEnum.DepositedManuscripts:
                DepositedManuscriptsParse(publication, db);
                break;
            case PublicationTypeEnum.Certificate:
                CertificateParse(publication, db);
                break;
            case PublicationTypeEnum.Monograph:
                MonographParse(publication, db);
                break;
            case PublicationTypeEnum.Other:
                OtherParse(publication, db);
                break;
            case PublicationTypeEnum.Patent:
                PatentParse(publication, db);
                break;
            case PublicationTypeEnum.Textbook:
                TextbookParse(publication, db);
                break;
            case PublicationTypeEnum.ReportAbstracts:
                ReportAbstractsParse(publication, db);
                break;
            case PublicationTypeEnum.StudyGuide1:
                StudyGuideParse(publication, db);
                break;
            case PublicationTypeEnum.StudyGuide2:
                StudyGuideWithStampParse(publication, db);
                break;
            case PublicationTypeEnum.VstuMagazines:
                VstuMagazinesParse(publication, db);
                break;
            case PublicationTypeEnum.VstuNews:
                VstuNewsParse(publication, db);
                break;
            case PublicationTypeEnum.EducationalMethodicalComplex:
                EducationalMethodicalComplexParse(publication, db);
                break;
            case PublicationTypeEnum.ForeignCollectionArticle:
                ForeignCollectionArticleParse(publication, db);
                break;
            case PublicationTypeEnum.ForeignMagazineArticle:
                ForeignMagazineArticleParse(publication, db);
                break;
            case PublicationTypeEnum.RussianCollectionArticle:
                RussianCollectionArticleParse(publication, db);
                break;
            case PublicationTypeEnum.RussianMagazineArticle: 
                RussianMagazineArticleParse(publication, db);
                break;
        }
    }

    private void DepositedManuscriptsParse(string publication, ApplicationContext db)
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

        AddPublicationToDb(p, "DepositedManuscript", db);
    }
    
    private void CertificateParse(string publication, ApplicationContext db)
    {
        Publication p = new Publication()
        {
            Title = CitationParseFunctions.GetName(publication),
            IdAuthors = CitationParseFunctions.GetAuthors(publication, true),
            IdUniversities = PatentDocumentAndCertificateParser.GetCompanies(publication),
            Year = PatentDocumentAndCertificateParser.GetYear(publication)
        };

        AddPublicationToDb(p, "Certificate", db);
    }
    
    private void MonographParse(string publication, ApplicationContext db)
    {
        Publication p = new Publication()
        {
            Title = CitationParseFunctions.GetName(publication),
            IdAuthors = CitationParseFunctions.GetAuthors(publication),
            IdUniversities = MonographParser.GetCompany(publication),
            Year = MonographParser.GetYear(publication),
            CountOfPages = MonographParser.GetCountPages(publication),
            DataStorage = MonographParser.GetDataStorage(publication),
            InformationAboutPublication = MonographParser.GetInformationAboutPublication(publication),
            IdCities = MonographParser.GetCities(publication),
            IdEditors = MonographParser.GetEditor(publication)
        };

        AddPublicationToDb(p, "Monograph", db);
    }
    
    private void OtherParse(string publication, ApplicationContext db)
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

        AddPublicationToDb(p, "Other", db);
    }
    
    private void PatentParse(string publication, ApplicationContext db)
    {
        Publication p = new Publication()
        {
            Title = CitationParseFunctions.GetName(publication),
            IdAuthors = CitationParseFunctions.GetAuthors(publication, true),
            IdUniversities = PatentDocumentAndCertificateParser.GetCompanies(publication),
            Year = PatentDocumentAndCertificateParser.GetYear(publication)
        };

        AddPublicationToDb(p, "Patent", db);
    }
    
    private void TextbookParse(string publication, ApplicationContext db)
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

        AddPublicationToDb(p, "Textbook", db);
    }
    
    private void ReportAbstractsParse(string publication, ApplicationContext db)
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

        AddPublicationToDb(p, "ReportAbstracts", db);
    }
    
    private void StudyGuideParse(string publication, ApplicationContext db)
    {
        Publication p = new Publication()
        {
            Title = CitationParseFunctions.GetName(publication),
            IdAuthors = CitationParseFunctions.GetAuthors(publication),
            IdUniversities = StudyGuideParser.GetCompany(publication),
            Year = StudyGuideParser.GetYear(publication),
            CountOfPages = StudyGuideParser.GetCountPages(publication),
            IdEditors = StudyGuideParser.GetEditor(publication),
            IdCities = StudyGuideParser.GetCities(publication),
            InformationAboutPublication = StudyGuideParser.GetInformationAboutPublication(publication),
            IdScientificCollection = new List<ScientificCollection>(){StudyGuideParser.GetScientificCollection(publication)},
            DataStorage = StudyGuideParser.GetDataStorage(publication),
            Url = StudyGuideParser.GetURL(publication)
        };

        AddPublicationToDb(p, "StudyGuide", db);
    }
    
    private void StudyGuideWithStampParse(string publication, ApplicationContext db)
    {
        Publication p = new Publication()
        {
            Title = CitationParseFunctions.GetName(publication),
            IdAuthors = CitationParseFunctions.GetAuthors(publication),
            IdUniversities = StudyGuideWithStampParser.GetCompany(publication),
            Year = StudyGuideWithStampParser.GetYear(publication),
            CountOfPages = StudyGuideWithStampParser.GetCountPages(publication),
            IdEditors = StudyGuideWithStampParser.GetEditor(publication),
            IdCities = StudyGuideWithStampParser.GetCities(publication),
            InformationAboutPublication = StudyGuideWithStampParser.GetInformationAboutPublication(publication),
            DataStorage = StudyGuideWithStampParser.GetDataStorage(publication)
        };

        AddPublicationToDb(p, "StudyGuideWithStamp", db);
    }
    
    private void VstuMagazinesParse(string publication, ApplicationContext db)
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

        AddPublicationToDb(p, "VstuMagazines", db);
    }
    
    private void VstuNewsParse(string publication, ApplicationContext db)
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

        AddPublicationToDb(p, "VstuNews", db);
    }
    
    private void EducationalMethodicalComplexParse(string publication, ApplicationContext db)
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

        AddPublicationToDb(p, "EducationalMethodicalComplex", db);
    }
    
    private void ForeignCollectionArticleParse(string publication, ApplicationContext db)
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

        AddPublicationToDb(p, "ForeignCollectionArticle", db);
    }
    
    private void RussianCollectionArticleParse(string publication, ApplicationContext db)
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

        AddPublicationToDb(p, "RussianCollectionArticle", db);
    }
    
    private void ForeignMagazineArticleParse(string publication, ApplicationContext db)
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

        AddPublicationToDb(p, "ForeignMagazineArticle", db);
    }
    
    private void RussianMagazineArticleParse(string publication, ApplicationContext db)
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

        AddPublicationToDb(p, "RussianMagazineArticle", db);
          
    }

    private void AddPublicationToDb(Publication p, string typeStr, ApplicationContext db)
    {
        
            var type = db.TypesOfPublications.Where(t => t.Name == typeStr).ToArray();
            
            p.Type = type[0];
            
            db.Authors.AddRange(p.IdAuthors);
            db.Cities.AddRange(p.IdCities);
            db.Editors.AddRange(p.IdEditors);
            db.Universities.AddRange(p.IdUniversities);
            db.ScientificCollections.AddRange(p.IdScientificCollection);
            db.Publications.Add(p);
            db.SaveChanges();
    }
}
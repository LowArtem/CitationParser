namespace CitationParser.Core.Model.WebSrapper;

/// <summary>
/// Типы публикаций
/// </summary>
public enum PublicationTypeEnum
{
    /// <summary>
    /// Депонированная рукопись
    /// </summary>
    DepositedManuscripts,

    /// <summary>
    /// Журналы ВолгГТУ
    /// </summary>
    VstuMagazines,

    /// <summary>
    /// Известия ВолгГТУ
    /// </summary>
    VstuNews,

    /// <summary>
    /// Патентный документ
    /// </summary>
    Patent,

    /// <summary>
    /// Прочие публикации
    /// </summary> 
    Other,

    /// <summary>
    /// Свидетельство
    /// </summary>
    Certificate,

    /// <summary>
    /// Статья из зарубежного журнала
    /// </summary>
    ForeignMagazineArticle,

    /// <summary>
    /// Статья из зарубежного сборника
    /// </summary>
    ForeignCollectionArticle,

    /// <summary>
    /// Статья из российского журнала
    /// </summary> 
    RussianMagazineArticle,

    /// <summary>
    /// Статья из российского сборника
    /// </summary>
    RussianCollectionArticle,

    /// <summary>
    /// Тезисы докладов
    /// </summary> 
    ReportAbstracts,

    /// <summary>
    /// Учебно-методический комплекс
    /// </summary>
    EducationalMethodicalComplex,

    /// <summary>
    /// Монография
    /// </summary>
    Monograph,

    /// <summary>
    /// Учебное пособие (гриф)
    /// </summary>
    StudyGuide1,

    /// <summary>
    /// Учебное пособие
    /// </summary>
    StudyGuide2,

    /// <summary>
    /// Учебник
    /// </summary>
    Textbook
}
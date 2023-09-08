using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using CitationParser.Data.Model;

namespace CitationParser.Data.Services.Parser;

[SuppressMessage("ReSharper", "CommentTypo")]
public class ReportAbstractsParser
{
    /*
     * Синтез и свойства 1,3-дизамещенных мочевин и их биоизостерических аналогов, содержащих полициклические
     * фрагменты – ингибиторов растворимой эпоксидгидролазы (sEH) / В.В. Бурмистров, Г.М. Бутов // Сборник
     * тезисов докладов Восьмой Междисциплинарной конференции «Молекулярные и Биологические аспекты Химии,
     * Фармацевтики и Фармакологии» (МОБИ-ХимФарма2023) (г. Санкт-Петербург, 24-27 апреля 2023 г.) / под ред. К. В.
     * Кудрявцева, Е. М. Паниной ; Российский национальный исследовательский медицинский университет им. Н. И.
     * Пирогова, Российский гос. педагогический университет им. А. И. Герцена, Бюро медицинской и фармацевтической
     * информации «РИХТ». - Москва, 2023. - C. 22
     *
     *
     *
     * Актуальные направления оптимизации отраслевых рисков предприятий трубной промышленности России / О.К.
     * Бойко // Конкурс научно-исследовательских работ студентов Волгоградского государственного технического
     * университета (г. Волгоград, 24-28 апреля 2023 г.) : тез. докл. / редкол.: С. В. Кузьмин (отв. ред.) [и др.] ;
     * ВолгГТУ, Отдел координации научных исследований молодых ученых УНиИ, Общество молодых ученых. - Волгоград,
     * 2023. - C. 217-218
     *
     *
     *
     * Резонансная двухфотонная спектроскопия колебательных состояний молекул при четырёхволновом смешении
     * частот / В.С. Должиков, Ю.С. Должиков, А.А. Макаров, В.Г. Мовшев, Е.А. Рябов // Тезисы докладов
     * XII всесоюзной конференции по когерентной и нелинейной оптике (Москва, 26-29 авг. 1985 г.). Ч. II : Секции
     * X-XIX. - М., 1985. - C. 496-497.
     *
     * 
     *
     * Расчёт акустической мощности , излучаемой пьезокеромическим электроакустическим
     * преобразователем / Н.В. Клочко, А.Ф. Гейер, С.В. Медников // XVII региональная конференция молодых
     * исследователей Волгоградской области, Волгоград, 6-9 нояб. 2012 г. : тез. докл. / ВолгГТУ [и др.]. -
     * Волгоград, 2013. - C. 230-232.
     */

    public static string GetTitleOfSource(string citation)
    {
        return citation.Split(" // ")[1].Split(" / ")[0].Trim();
    }

    public static List<Editor> GetEditors(string citation)
    {
        var editorString = citation.Split(" // ")[1]
            .Split(" / ")[1]
            .Split(';')[0].Trim();

        var answer = new List<Editor>();

        if (editorString.Contains("ред"))
        {
            var regex = new Regex(@"\[.*?\]");
            var regex2 = new Regex(@"\(.*?\)");
            editorString = regex.Replace(editorString, "");
            editorString = regex2.Replace(editorString, "");

            if (editorString.Contains("под ред."))
            {
                editorString = editorString.Split(".", 2)[1].Trim();
            }
            else
            {
                editorString = editorString.Split(":")[1].Trim();
            }

            var editors = editorString
                .Split(", ");

            answer.AddRange(editors.Select(e => new Editor { Name = e.Trim() }));
        }

        return answer;
    }
    //
    // public static University? GetCompany(string citation)
    // {
    //     if (GetEditors(citation).Count != 0)
    //     {
    //         citation = citation.Replace("—", "-");
    //         citation = citation.Replace("–", "-");
    //         citation = citation.Replace("−", "-");
    //         citation = citation.Replace("-", "-");
    //         
    //         var companies = citation.Split(" ; ")[1].Split(" - ")[0]
    //     }
    //     else
    //     {
    //         
    //     }
    // }
}
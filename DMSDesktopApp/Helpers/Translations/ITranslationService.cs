namespace DMS.DesktopApp.Helpers.Translations
{
    public interface ITranslationService
    {
        Dictionary<string, string> LoadTranslations(string languageCode);
        void TranslateControl(Control control, Dictionary<string, string> translations);
    }
}

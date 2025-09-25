using DMS.Context.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;


namespace DMS.DesktopApp.Helpers.Translations
{
    public class TranslationService : ITranslationService
    {
        private readonly IMemoryCache _cache;
        private readonly ApplicationDbContext db;

        public TranslationService(ApplicationDbContext context, IMemoryCache cache)
        {
            _cache = cache;
            db = context;
        }

        public Dictionary<string, string> LoadTranslations(string languageCode)
        {
            var cacheKey = $"translations_{languageCode}";
            if (!_cache.TryGetValue(cacheKey, out Dictionary<string, string> translations))
            {
                translations = db.Translations
                    .Include(t => t.Language)
                    .Where(t => t.Language.Code == languageCode)
                    .ToDictionary(t => t.TextKey, t => t.TextValue);

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromHours(10));

                _cache.Set(cacheKey, translations, cacheEntryOptions);
            }

            return translations;
        }

        public void TranslateControl(Control control, Dictionary<string, string> translations)
        {
            var controlName = control.Tag == null ? null : control.Tag.ToString();
            // Here, we assume the control's Name property matches the key in the database.
            if (!string.IsNullOrEmpty(controlName) && translations.ContainsKey(controlName))
            {
                control.Text = translations[control.Tag.ToString()];
            }

            // Special handling for controls that might hold text in different properties, like tooltips or menu items.
            // You can extend this as needed.

            // Recursively translate child controls.
            foreach (Control child in control.Controls)
            {
                TranslateControl(child, translations);
            }
        }

    }
}

namespace LoLStats.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using Ganss.XSS;

    public class SanitizerService : ISanitizerService
    {
        private HtmlSanitizer sanitizer;

        public SanitizerService()
        {
            this.sanitizer = new HtmlSanitizer();
            this.sanitizer.AllowedTags.Clear();
            this.sanitizer.AllowedCssProperties.Clear();
        }

        public string SanitizeString(string stringToParse)
        {
            return this.sanitizer.Sanitize(stringToParse);
        }
    }
}

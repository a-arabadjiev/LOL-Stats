namespace LoLStats.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

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

        public string SanitizeItemDescription(string description)
        {
            string removedHtmlDescription = Regex.Replace(description, "<(.|\\n)*?>", " ");

            return Regex.Replace(removedHtmlDescription, "[ ]{2,}", " ").Trim();
        }

        public string RemoveSpacesAndSymbols(string stringToParse)
        {
            var parsedString = stringToParse.Replace(" ", string.Empty).Replace(":", string.Empty).Replace("'", string.Empty);

            return parsedString;
        }
    }
}

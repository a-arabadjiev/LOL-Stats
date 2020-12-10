namespace LoLStats.Services
{
    public interface ISanitizerService
    {
        string SanitizeString(string stringToParse);

        string SanitizeItemDescription(string description);
    }
}

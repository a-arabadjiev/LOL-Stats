namespace LoLStats.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IRiotSharpService
    {
        string[] GetAllChampionKeys();
    }
}

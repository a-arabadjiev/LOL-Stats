namespace LoLStats.Services.Data
{
    using System.Collections.Generic;

    public interface ISummonerSpellsService
    {
        IEnumerable<T> GetAll<T>();
    }
}

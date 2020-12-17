namespace LoLStats.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using LoLStats.Web.ViewModels.Champions;

    public interface IChampionsService
    {
        IEnumerable<T> GetAll<T>();

        Task<ChampionStatsViewModel> GetById(string id);
    }
}

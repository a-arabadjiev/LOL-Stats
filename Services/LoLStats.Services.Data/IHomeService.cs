namespace LoLStats.Services.Data
{
    using LoLStats.Web.ViewModels.Home;

    public interface IHomeService
    {
        BaseDataViewModel GetBaseGameCounts();

        TopChampionsListViewModel GetTopChampionsForEachRole();
    }
}

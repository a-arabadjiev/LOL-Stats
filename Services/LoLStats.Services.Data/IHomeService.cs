namespace LoLStats.Services.Data
{
    using LoLStats.Web.ViewModels.Home;

    public interface IHomeService
    {
        LoLBaseDataViewModel GetBaseGameCounts();
    }
}

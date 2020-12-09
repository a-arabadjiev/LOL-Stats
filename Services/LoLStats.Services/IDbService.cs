namespace LoLStats.Services
{
    using System.Threading.Tasks;

    public interface IDbService
    {
        Task AddBaseGameData();
    }
}

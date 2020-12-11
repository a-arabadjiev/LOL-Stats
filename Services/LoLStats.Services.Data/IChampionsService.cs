namespace LoLStats.Services.Data
{
    using System.Collections.Generic;

    using LoLStats.Web.ViewModels.Champions;

    public interface IChampionsService
    {
        IEnumerable<T> GetAll<T>();

        //T GetById<T>();
    }
}

namespace LoLStats.Services.Data
{
    using System.Collections.Generic;

    using LoLStats.Web.ViewModels.Roles;

    public interface IChampionRolesService
    {
        List<RoleViewModel> GetAll();
    }
}

namespace LoLStats.Services.Data
{
    using System;
    using System.Collections.Generic;

    using LoLStats.Data.Models.Enums;
    using LoLStats.Web.ViewModels.Roles;

    public class ChampionRolesService : IChampionRolesService
    {
        public List<RoleViewModel> GetAll()
        {
            var rolesList = new List<RoleViewModel>();

            var roles = Enum.GetValues(typeof(RoleType));

            foreach (var role in roles)
            {
                rolesList.Add(new RoleViewModel
                {
                    Name = role.ToString(),
                    ImagePath = $"/images/roles/{role}.png",
                });
            }

            return rolesList;
        }
    }
}

namespace LoLStats.Web.ViewModels.Home
{
    using System.Collections.Generic;

    public class TopChampionsListViewModel
    {
        public TopChampionsListViewModel()
        {
            this.TopChampions = new List<TopChampionForRoleViewModel>();
        }

        public ICollection<TopChampionForRoleViewModel> TopChampions { get; set; }
    }
}

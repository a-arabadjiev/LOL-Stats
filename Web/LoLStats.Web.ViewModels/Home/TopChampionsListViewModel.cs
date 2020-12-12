namespace LoLStats.Web.ViewModels.Home
{
    using System.Collections.Generic;

    public class TopChampionsListViewModel
    {
        public TopChampionsListViewModel()
        {
            this.TopChampions = new HashSet<TopChampionForRoleViewModel>();
        }

        public ICollection<TopChampionForRoleViewModel> TopChampions { get; set; }
    }
}

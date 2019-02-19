namespace DeNew.Models.ViewModels.Interfaces
{
    public class NavigationItem : INavigationItem
    {
        public string Link { get; set; }
        public string Title { get; set; }
        public bool ActiveLink { get; set; }
    }
}
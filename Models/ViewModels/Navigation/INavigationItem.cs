namespace DeNew.Models.ViewModels.Interfaces
{
    public interface INavigationItem
    {
        string Link { get; set; }

        string Title { get; set; }

        bool ActiveLink { get; set; }
    }
}
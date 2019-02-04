namespace DeNew.Models.ViewModels.Interfaces
{
    public interface IEditable
    {
        bool CanEdit { get; set; }

        string EditMessage { get; set; }
    }
}
using DeNew.Models.Entities;

namespace DeNew.Services.Pages
{
    public interface IPageManipulator
    {
        Page CreateNewPage(int parentId);

        bool DeletePage(int pageId, out string message);
    }
}
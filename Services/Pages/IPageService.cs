using System.Collections.Generic;
using DeNew.Models.Entities;

namespace DeNew.Services.Pages
{
    public interface IPageService
    {
        Page GetPage(string pageAlias1 = null, string pageAlias2 = null);

        Page GetPageById(int id);
        IEnumerable<Page> GetChildPagesFor(int pageId);

        IEnumerable<Page> GetHomePageCategories();
    }
}
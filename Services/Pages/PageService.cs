using System.Collections.Generic;
using System.Linq;
using DeNew.Models;
using DeNew.Models.Entities;
using DeNew.Settings;

namespace DeNew.Services.Pages
{
    public class PageService : IPageService
    {
        private readonly DeContext _context;
        public PageService(DeContext context)
        {
            _context = context;
        }

        Page LinkChildPagesTo(Page page)
        {
            if (page == null)
                return null;
            page.SubPages = GetChildPagesFor(page.Id).ToList();
            return page;
        }

        private Page GetMainpage()
        {
            return _context.Pages.SingleOrDefault(page => page.Id == VariablesSettingsConfig.MAIN_PAGE_ID);
        }


        public Page GetPage(string pageAlias1 = null, string pageAlias2 = null)
        {
            Page result;
            if (string.IsNullOrEmpty(pageAlias1) && string.IsNullOrEmpty(pageAlias2))
                result = GetMainpage();
            else if (string.IsNullOrEmpty(pageAlias2))
                result =_context.Pages.SingleOrDefault(page => page.Alias == pageAlias1);
            else
                result = _context.Pages.SingleOrDefault(page => page.ParentPage.Alias == pageAlias1 && page.Alias == pageAlias2);

            return LinkChildPagesTo(result);
        }

        public IEnumerable<Page> GetChildPagesFor(int pageId)
        {
            return _context.Pages.Where(page => page.ParentPage.Id == pageId);
        }

        public IEnumerable<Page> GetHomePageCategories()
        {
           return _context.Pages.Where(page => page.ParentPage == null);
        }
    }
}
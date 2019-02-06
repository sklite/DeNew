using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeNew.Models;
using DeNew.Models.Entities;
using DeNew.Settings;

namespace DeNew.Services.Pages
{
    public class PageRepository : IPageRepository
    {
        private readonly DeContext _context;
        public PageRepository(DeContext context)
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

        Page GetMainpage()
        {
            return _context.Pages.SingleOrDefault(page => page.Id == VariablesSettingsConfig.MAIN_PAGE_ID);
        }

        Page GetParentPageFor(int pageId)
        {
            return _context.Pages.FirstOrDefault(item => item.SubPages.Any(subPage => subPage.Id == pageId && subPage.IsDeleted == false));
        }


        public Page GetPage(string pageAlias1 = null, string pageAlias2 = null)
        {
            Page result;
            if (string.IsNullOrEmpty(pageAlias1) && string.IsNullOrEmpty(pageAlias2))
                result = GetMainpage();
            else if (string.IsNullOrEmpty(pageAlias2))
                result = _context.Pages.SingleOrDefault(page => page.Alias == pageAlias1 && page.IsDeleted == false);
            else
                result = _context.Pages.SingleOrDefault(page => page.ParentPage.Alias == pageAlias1 && page.Alias == pageAlias2 && page.IsDeleted == false);

            return LinkChildPagesTo(result);
        }

        public IEnumerable<Page> GetChildPagesFor(int pageId)
        {
            return _context.Pages.Where(page => page.ParentPage.Id == pageId && page.IsDeleted == false);
        }

        public IEnumerable<Page> GetHomePageCategories()
        {
           return _context.Pages.Where(page => page.ParentPage == null);
        }

    

        public Page GetPageById(int id)
        {
            var page = _context.Pages.FirstOrDefault(item => item.Id == id);
            page.ParentPage = GetParentPageFor(page.Id);
            if (page.ParentPage != null)
            { 
                page.ParentPage.ParentPage = GetParentPageFor(page.ParentPage.Id);
                if (page.ParentPage.ParentPage != null)
                    page.ParentPage.ParentPage.ParentPage = GetParentPageFor(page.ParentPage.ParentPage.Id);
            }
            return page;
        }
    }
}
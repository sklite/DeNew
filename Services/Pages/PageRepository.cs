using System;
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

        Page FindParentPage(Page page)
        {
            return _context.Pages.Where(item => item.SubPages.Contains(page)).FirstOrDefault();
        }

        void FillParentPagesFor(Page page)
        {
            if (page.Id == VariablesSettingsConfig.MAIN_PAGE_ID)
                return;
            page.ParentPage = FindParentPage(page);
            if (page.ParentPage.Id == VariablesSettingsConfig.MAIN_PAGE_ID)
                return;

            page.ParentPage.ParentPage = FindParentPage(page.ParentPage);
            if (page.ParentPage.ParentPage.Id == VariablesSettingsConfig.MAIN_PAGE_ID)
                return;
            page.ParentPage.ParentPage.ParentPage = FindParentPage(page.ParentPage.ParentPage);
        }

        void LinkChildPagesFor(Page page)
        {
            if (page == null)
                return;
            page.SubPages = GetChildPagesFor(page.Id).ToList();
        }

        Page GetMainpage()
        {
            if (_context == null)
                throw new Exception("_context is Null");

            if (_context.Pages == null)
                throw new Exception("_context.Pages is Null");
            var list = _context.Pages.ToList();
            if (list.Count == 0)
                throw new Exception("list.Count == 0");
            if (!_context.Pages.Any())
                throw new Exception("_context.Pages length == 0");


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

            LinkChildPagesFor(result);
            FillParentPagesFor(result);
            return result;
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
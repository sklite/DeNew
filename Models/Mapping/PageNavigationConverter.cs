using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DeNew.Extensions;
using DeNew.Models.Entities;
using DeNew.Models.ViewModels.Interfaces;
using DeNew.Settings;

namespace DeNew.Models.Mapping
{
    public class PageNavigationConverter : IValueConverter<Page, ICollection<INavigationItem>>
    {
        public ICollection<INavigationItem> Convert(Page sourceMember, ResolutionContext context)
        {
            var result = new List<INavigationItem>();
            //TODO: refactor

            var depth = GetPageDepth(sourceMember);

            var currentPageItem = sourceMember;
            while (depth > 0)
            {
                result.Add(GetNavItemFromPage(currentPageItem, depth));

                depth--;
                currentPageItem = currentPageItem.ParentPage;
            }
            result.Reverse();
            return result;
        }
        

        INavigationItem GetNavItemFromPage(Page page, int level)
        {
            return new NavigationItem()
            {
                Title = page.Id == VariablesSettingsConfig.MAIN_PAGE_ID ? "Главная" : page.Name,
                ActiveLink = true,
                Link = page.GetPageRelativePath()
            };
        }

        int GetPageDepth(Page page)
        {
            if (page.Id == VariablesSettingsConfig.MAIN_PAGE_ID)
                return 1;
            if (page.ParentPage.Id == VariablesSettingsConfig.MAIN_PAGE_ID)
                return 2;
            if (page.ParentPage.ParentPage.Id == VariablesSettingsConfig.MAIN_PAGE_ID)
                return 3;
            if (page.ParentPage.ParentPage.ParentPage.Id == VariablesSettingsConfig.MAIN_PAGE_ID)
                return 4;

            return 0;
        }
    }
}
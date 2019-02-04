using DeNew.Models.Entities;
using DeNew.Settings;
using System.Text;

namespace DeNew.Extensions
{
    public static class PageExtensions
    {
        public static string GetPageRelativePath(this Page page)
        {
            // TODO: refactor this shit. 
            var sb = new StringBuilder("/");
            if (page == null)
                return sb.ToString();
            if (page.Id == VariablesSettingsConfig.MAIN_PAGE_ID)
                return sb.ToString();

            if (page.ParentPage == null)
            {
                //TODO: Logging
                return sb.ToString();
            }

            if (page.ParentPage.Id == VariablesSettingsConfig.MAIN_PAGE_ID)
            {
                sb.Append($"{VariablesSettingsConfig.MainContentPagePrefix}/{page.Alias}");
                return sb.ToString();
            }

            if (page.ParentPage.ParentPage == null)
            {
                //TODO: Logging
                return sb.ToString();
            }

            if (page.ParentPage.ParentPage.Id == VariablesSettingsConfig.MAIN_PAGE_ID)
            {
                sb.Append($"{VariablesSettingsConfig.MainContentPagePrefix}/{page.ParentPage.Alias}/{page.Alias}");
                return sb.ToString();
            }
            //if (page.ParentPage.ParentPage.ParentPage == null)
            //{
            //    //TODO: Logging
            //    return sb.ToString();
            //}
            sb.Append($"{VariablesSettingsConfig.MainContentPagePrefix}/{page.ParentPage.ParentPage.Alias}/{page.ParentPage.Alias}/{page.Alias}");
            return sb.ToString();

        }
    }
}
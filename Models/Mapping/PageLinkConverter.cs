using AutoMapper;
using DeNew.Models.Entities;
using DeNew.Settings;
using System.Collections.Generic;
using DeNew.Extensions;

namespace DeNew.Models.Mapping
{
    public class PageLinkConverter : IValueConverter<Page, string>
    {
        public string Convert(Page sourceMember, ResolutionContext context)
        {

            return sourceMember.GetPageRelativePath();

            //var str = new List<string>();
            //int linksLimit = 5;
            //var page = sourceMember;

            //while (page.Id != VariablesSettingsConfig.MAIN_PAGE_ID)
            //{
            //    str.Add(page.Alias);
            //    page = page.ParentPage;

            //    linksLimit--;
            //    if (linksLimit < 0)
            //        break;
            //}
            //str.Add(VariablesSettingsConfig.MainContentPagePrefix);

            //return string.Join("/", str);

        }
    }
}
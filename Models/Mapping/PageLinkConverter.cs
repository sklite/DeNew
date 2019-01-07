using AutoMapper;
using DeNew.Models.Entities;
using DeNew.Settings;

namespace DeNew.Models.Mapping
{
    public class PageLinkConverter : IValueConverter<Page, string>
    {
        public string Convert(Page sourceMember, ResolutionContext context)
        {
            if (sourceMember == null)
                return string.Empty;
            if (sourceMember.ParentPage == null)
                return $"main/{sourceMember.Alias}";

            if (sourceMember.ParentPage.Id == VariablesSettingsConfig.MAIN_PAGE_ID)
                return $"main/{sourceMember.Alias}";

            return $"main/{sourceMember.ParentPage.Alias}/{sourceMember.Alias}";
        }
    }
}
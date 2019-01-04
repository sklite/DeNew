using AutoMapper;
using DeNew.Models.Entities;

namespace DeNew.Models.Mapping
{
    public class PageLinkConverter : IValueConverter<Page, string>
    {
        public string Convert(Page sourceMember, ResolutionContext context)
        {
            if (sourceMember == null)
                return string.Empty;

            return $"main/{sourceMember.Alias}";
        }
    }
}
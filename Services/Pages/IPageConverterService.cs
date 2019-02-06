using System.Collections.Generic;
using DeNew.Models.Entities;
using DeNew.Models.ViewModels;

namespace DeNew.Services.Pages
{
    public interface IPageConverterService
    {
        PageViewModel ConvertPage(Page page);
        Page ConvertPageVm(PageViewModel pageVm);
        IEnumerable<PageViewModel> ConvertPages(IEnumerable<Page> pages);
        IEnumerable<Page> ConvertPagesVm(IEnumerable<PageViewModel> pagesVm);
    }
}
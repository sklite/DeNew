using System.Collections.Generic;
using DeNew.Models.Entities;
using DeNew.Models.ViewModels;

namespace DeNew.Services.Pages
{
    public interface IPageVmConverterService
    {
        Page ConvertPageVm(PageViewModel pageVm);

        IEnumerable<Page> ConvertPagesVm(IEnumerable<PageViewModel> pagesVm);
    }
}
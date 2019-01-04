using System.Collections.Generic;
using DeNew.Models.Entities;
using DeNew.Models.ViewModels;

namespace DeNew.Services.Pages
{
    public interface IPageConverterService
    {
        PageViewModel ConvertPage(Page page);

        IEnumerable<PageViewModel> ConvertPages(IEnumerable<Page> pages);
    }
}
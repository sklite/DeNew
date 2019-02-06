using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using DeNew.Models.Entities;
using DeNew.Models.ViewModels;

namespace DeNew.Services.Pages
{
    public class PageConverterService : IPageConverterService
    {
        private readonly IMapper _mapper;
        public PageConverterService(IMapper mapper)
        {
            _mapper = mapper;
        }


        public IEnumerable<PageViewModel> ConvertPages(IEnumerable<Page> pages)
        {
            return pages?.Select(ConvertPage).ToList();
        }

        public PageViewModel ConvertPage(Page page)
        {
            var pageVm = _mapper.Map<Page, PageViewModel>(page);
            return pageVm;
        }

        public Page ConvertPageVm(PageViewModel pageVm)
        {
            var page = _mapper.Map<PageViewModel, Page>(pageVm);

            return page;
        }

        public IEnumerable<Page> ConvertPagesVm(IEnumerable<PageViewModel> pagesVm)
        {
            return pagesVm?.Select(ConvertPageVm).ToList();
        }
    }
}
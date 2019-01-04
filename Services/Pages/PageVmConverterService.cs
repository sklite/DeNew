using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DeNew.Models.Entities;
using DeNew.Models.ViewModels;

namespace DeNew.Services.Pages
{
    public class PageVmConverterService : IPageVmConverterService
    {
        private readonly IMapper _mapper;
        public PageVmConverterService(IMapper mapper)
        {
            _mapper = mapper;
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
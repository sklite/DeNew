﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using AutoMapper;
using DeNew.Models.Entities;
using DeNew.Models.ViewModels;
using DeNew.Settings;

namespace DeNew.Models.Mapping
{
    public class MainMappingProfile : Profile
    {
        public MainMappingProfile()
        {
            //   if we want to add prefix to name
            //   .ForMember(pageVm => pageVm.ImageName, config => config.AddTransform(name => VariablesSettingsConfig.PREVIEW_IMG_DIR + name));

            CreateMap<Page, PageViewModel>()
                .ForMember(pageVm => pageVm.ImagePath,
                    config => config.MapFrom(page => VariablesSettingsConfig.PREVIEW_IMG_DIR + page.ImageName))
                .ForMember(pageVm => pageVm.Link, config => config.ConvertUsing<PageLinkConverter, Page>(page => page))
                .ForMember(pageVm => pageVm.SubPages, config => config.MapFrom(page => page.SubPages))
                .ForMember(pageVm => pageVm.NavigationItems,
                    config => config.ConvertUsing<PageNavigationConverter, Page>(page => page));




            CreateMap<PageViewModel,Page>()
                .ForMember(page => page.ImageName, config => config.MapFrom(page => page.ImagePath))
                .ForMember(page => page.Content, config => config.MapFrom(pageVm => HttpUtility.HtmlDecode(pageVm.Content)))
                .ForMember(pageVm => pageVm.SubPages, config => config.MapFrom(page => page.SubPages));

        }
    }
}
using AutoMapper;
using HelpMeApp.DatabaseAccess.Entities.ReportEntity;
using HelpMeApp.Services.Models.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.Services.MappingProfiles
{
    public class ReportMappingProfile : Profile
    {
        public ReportMappingProfile()
        {
            CreateMap<Report, ReportData>()
                .ForMember(src => src.Email, opt =>
                {
                    opt.MapFrom(src => src.User.Email);
                })
                .ForMember(src => src.AdvertTitle, opt =>
                {
                    opt.MapFrom(src => src.Advert.Header);
                });

            CreateMap<ReportData, Report>();
        }
    }
}

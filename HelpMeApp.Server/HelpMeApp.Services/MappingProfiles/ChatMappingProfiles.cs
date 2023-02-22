using AutoMapper;
using HelpMeApp.DatabaseAccess.Entities.ChatEntity;
using HelpMeApp.Services.Models.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.Services.MappingProfiles
{
    public class ChatMappingProfiles : Profile
    {
        public ChatMappingProfiles()
        {
            CreateMap<Chat, ChatPreviewData>()
                .ForMember(src => src.LastMessage, opt =>
                {
                    opt.MapFrom(src => src.Messages.OrderBy(m => m.CreationDate).LastOrDefault());
                })
                .ForMember(src => src.AdvertTitle, opt =>
                {
                    opt.MapFrom(src => src.Advert.Header);
                });
                
        }
    }
}

using AutoMapper;
using HelpMeApp.DatabaseAccess.Entities.MessageEntity;
using HelpMeApp.Services.Models.Enums;
using HelpMeApp.Services.Models.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.Services.MappingProfiles
{
    public class MessageMappingProfiles : Profile
    {
        public MessageMappingProfiles()
        {
            CreateMap<MessageData, Message>()
                .ForMember(src => src.CreationDate, opt =>
                {
                    opt.MapFrom(src => src.SentTime);
                });

            CreateMap<Message, MessageData>()
                .ForMember(src => src.SentTime, opt =>
                {
                    opt.MapFrom(src => src.CreationDate);
                })
                .ForMember(src => src.SenderId, opt =>
                {
                    opt.MapFrom(src => src.SenderRoleId == (int)SenderRoles.Creator ? src.Chat.Advert.CreatorId : src.Chat.UserId);
                });
        }
    }
}

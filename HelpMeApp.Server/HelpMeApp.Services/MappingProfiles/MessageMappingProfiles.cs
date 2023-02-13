using AutoMapper;
using HelpMeApp.DatabaseAccess.Entities.MessageEntity;
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
            CreateMap<MessageData, Message>();

            CreateMap<Message, MessageData>()
                .ForMember(src => src.SentTime, opt =>
                {
                    opt.MapFrom(src => src.CreationDate);
                });
        }
    }
}

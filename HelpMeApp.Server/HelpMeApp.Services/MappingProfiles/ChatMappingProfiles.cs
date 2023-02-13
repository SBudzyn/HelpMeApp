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
            CreateMap<Chat, ChatPreviewData>();
        }
    }
}

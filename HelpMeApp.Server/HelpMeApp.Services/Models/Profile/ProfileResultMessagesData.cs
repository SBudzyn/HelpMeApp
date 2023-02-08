using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.Services.Models.Profile
{
    public class ProfileResultMessagesData<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
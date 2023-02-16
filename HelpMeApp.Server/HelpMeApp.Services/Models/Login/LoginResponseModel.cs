using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.Services.Models.Login
{
    public class LoginResponseModel
    {
        public bool IsSuccessful { get; set; }
        public string Token { get; set; }
        public Guid UserId { get; set; }
    }
}

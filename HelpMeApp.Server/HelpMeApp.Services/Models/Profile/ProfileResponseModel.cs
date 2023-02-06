using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.Services.Models.Profile
{
    public class ProfileResponseModel<T>
    {
            public T? Data { get; set; }
            public bool Success { get; set; } = true;
            public string Message { get; set; } = string.Empty; 
    }
}

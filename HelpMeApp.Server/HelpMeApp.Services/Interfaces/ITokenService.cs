using HelpMeApp.DatabaseAccess.Entities.AppUserEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(AppUser user);
    }
}

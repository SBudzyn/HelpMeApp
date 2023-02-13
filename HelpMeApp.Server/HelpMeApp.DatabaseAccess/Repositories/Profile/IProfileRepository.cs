using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpMeApp.DatabaseAccess.Entities.AppUserEntity;

namespace HelpMeApp.DatabaseAccess.Repositories.Profile
{
    internal interface IProfileRepository
    {
        AppUser GetUserById(int id);

        AppUser GetMyInfo();

        void Update(AppUser user);

        void Delete(AppUser user);
    }
}

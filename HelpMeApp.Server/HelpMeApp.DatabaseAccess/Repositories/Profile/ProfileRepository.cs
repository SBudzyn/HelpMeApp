using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpMeApp.DatabaseAccess.Entities.AppUserEntity;

using Microsoft.AspNetCore.Identity;
namespace HelpMeApp.DatabaseAccess.Repositories.Profile
{
    // UserManager
    //
    internal class ProfileRepository :  IdentityUser<Guid>
    {
        private HelpMeDbContext _context;
        /*
        public ProfileRepository(HelpMeDbContext context) {
            _context = context; 
        }
        public void Update(AppUser appUser) {
            var userDB = _context.;
        }

        public void IProfileRepository.Delete(AppUser user)
        {
            throw new NotImplementedException();
        }

        public AppUser IProfileRepository.GetMyInfo()
        {
            throw new NotImplementedException();
        }

        public AppUser IProfileRepository.GetUserById(int id)
        {
            throw new NotImplementedException();
        } */
    }
}

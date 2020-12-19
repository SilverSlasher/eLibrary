using System;
using System.Collections.Generic;
using System.Text;
using eLibraryClasses.Models;

namespace eLibraryClasses.Interfaces
{
    public interface ILibraryWelcomeService
    {
        void NewBookNotification(UserModel loggedUser);

        void UpdateUserInfo(ref UserModel loggedUser);

    }
}

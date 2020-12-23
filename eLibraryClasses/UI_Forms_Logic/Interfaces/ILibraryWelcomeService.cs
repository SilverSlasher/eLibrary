using eLibraryClasses.Models;

namespace eLibraryClasses.UI_Forms_Logic.Interfaces
{
    public interface ILibraryWelcomeService
    {
        void NewBookNotification(UserModel loggedUser);

        void UpdateUserInfo(UserModel loggedUser);

    }
}

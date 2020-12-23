using System.Collections.Generic;
using eLibraryClasses.Models;

namespace eLibraryClasses.UI_Forms_Logic.Interfaces
{
    public interface IFavoriteAuthorsService
    {
        List<string> AvailableAuthors();

        void DeleteAuthorFromUserFavoriteList(UserModel loggedUser, string selectedAuthor);

        void SettingUpSubscription(bool subscriptionCheckBox, UserModel loggedUser);

        void SettingUpCheckBox(bool subscriptionCheckBox, UserModel loggedUser);

        void AddAuthorToUserFavoriteList(UserModel loggedUser, string newFavoriteAuthor);

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using eLibraryClasses.Models;

namespace eLibraryClasses.Interfaces
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

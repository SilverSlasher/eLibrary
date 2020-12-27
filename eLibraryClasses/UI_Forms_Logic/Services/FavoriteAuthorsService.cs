using System;
using System.Collections.Generic;
using System.Linq;
using eLibraryClasses.DataAccess;
using eLibraryClasses.Models;
using eLibraryClasses.UI_Forms_Logic.Interfaces;

namespace eLibraryClasses.UI_Forms_Logic.Services
{
    public class FavoriteAuthorsService : IFavoriteAuthorsService
    {
        private readonly List<BookModel> _allBooks;

        public FavoriteAuthorsService(IDataConnection dataConnection)
        {
            _allBooks = dataConnection.GetBook_All();
        }


        public List<string> AvailableAuthors()
        {
            List<string> output = new List<string>();

            foreach (BookModel book in _allBooks)
            {
                if (!output.Contains(book.Author))
                {
                    output.Add(book.Author);
                }
            }

            return output;
        }

        //Check if the authors is already in users favorite authors list
        private void ValidateExisting(List<string> favoriteAuthors, string selectedItem)
        {
            foreach (string author in favoriteAuthors)
            {
                if (author == selectedItem)
                {
                    throw new Exception("Autor znajduje się na liście ulubionych!");
                }
            }
        }

        public void DeleteAuthorFromUserFavoriteList(UserModel loggedUser, string selectedAuthor)
        {
            if (!loggedUser.FavoriteAuthors.Any())
            {
                throw new Exception("Brak ulubionych autorów możliwych do usunięcia!");
            }

            if (selectedAuthor != null)
            {
                loggedUser.FavoriteAuthors.Remove(selectedAuthor);

                DataConnectionService.UpdateDataOfLoggedUser(loggedUser).SaveToUsersFile();
            }
        }

        //Assign checkbox with user's property
        public void SettingUpSubscription(bool subscriptionCheckBox, UserModel loggedUser)
        {
            if (subscriptionCheckBox == true)
            {
                loggedUser.IsSubscribing = true;
            }
            else if (subscriptionCheckBox == false)
            {
                loggedUser.IsSubscribing = false;
            }

            DataConnectionService.UpdateDataOfLoggedUser(loggedUser).SaveToUsersFile();
        }

        //Checking if user is already subscribing favorite authors 
        public void SettingUpCheckBox(bool subscriptionCheckBox, UserModel loggedUser)
        {
            if (loggedUser.IsSubscribing)
            {
                subscriptionCheckBox = true;
            }
        }

        public void AddAuthorToUserFavoriteList(UserModel loggedUser, string newFavoriteAuthor)
        {
            if (loggedUser.FavoriteAuthors == null)
            {
                loggedUser.FavoriteAuthors = new List<string>();
            }

            //Check if the authors which user is trying to add to favorite, is already existing in users favorite authors list
            ValidateExisting(loggedUser.FavoriteAuthors, newFavoriteAuthor);

            loggedUser.FavoriteAuthors.Add(newFavoriteAuthor);

            DataConnectionService.UpdateDataOfLoggedUser(loggedUser).SaveToUsersFile();
        }
    }
}

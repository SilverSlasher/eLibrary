using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eLibraryClasses.DataAccess;
using eLibraryClasses.Models;

namespace eLibraryClasses.UserInterfaceServices
{
    public class FavoriteAuthorsService
    {
        //Create a list of book models and fill it from file .txt
        private List<BookModel> allBooks = GlobalConfig.Connection.GetBook_All();


        //Fill in all authors existing in books
        public List<string> AvailableAuthors()
        {
            List<string> output = new List<string>();

            foreach (BookModel book in allBooks)
            {
                //If the author was not appeared before, add author to list of authors
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
            //Take every single available author from favorite authors of user - one by one
            foreach (string author in favoriteAuthors)
            {
                //If user has already authors in users favorite authors list, set existing to true
                if (author == selectedItem)
                {
                    throw new Exception("Autor znajduje się na liście ulubionych!");
                }
            }
        }

        //Delete selected author from user's "favorite authors" list
        public void DeleteAuthorFromUserFavoriteList(UserModel loggedUser, string selectedAuthor)
        {
            if (!loggedUser.FavoriteAuthors.Any())
            {
                throw new Exception("Brak ulubionych autorów możliwych do usunięcia!");
            }

            if (selectedAuthor != null)
            {
                loggedUser.FavoriteAuthors.Remove(selectedAuthor);
                //Update user info to userfile .txt
                FileConnectorCore.UpdateDataOfLoggedUser(loggedUser).SaveToUsersFile();
            }
        }

        //Assign checkbox with user's property
        public void SettingUpSubscription(bool subscriptionCheckBox, UserModel loggedUser)
        {
            if (subscriptionCheckBox == true)
            {
                //Set user value of subscribing to true
                loggedUser.IsSubscribing = true;
            }
            else if (subscriptionCheckBox == false)
            {
                //Set user value of subscribing to false
                loggedUser.IsSubscribing = false;
            }
            //Update user info to userfile .txt
            FileConnectorCore.UpdateDataOfLoggedUser(loggedUser).SaveToUsersFile();
        }

        //Checking if user is already subscribing favorite authors 
        public void SettingUpCheckBox(bool subscriptionCheckBox, UserModel loggedUser)
        {
            //If user is already subscribing, select checkbox
            if (loggedUser.IsSubscribing)
            {
                subscriptionCheckBox = true;
            }
        }

        //Add selected author to user's "favorite authors" list
        public void AddAuthorToUserFavoriteList(UserModel loggedUser, string newFavoriteAuthor)
        {
            //If list of users favorite authors is not created before, create a new one
            if (loggedUser.FavoriteAuthors == null)
            {
                loggedUser.FavoriteAuthors = new List<string>();
            }

            //Check if the authors which user is trying to add to favorite, is already existing in users favorite authors list
            ValidateExisting(loggedUser.FavoriteAuthors, newFavoriteAuthor);

            loggedUser.FavoriteAuthors.Add(newFavoriteAuthor);
            //Update user info to user file .txt
            FileConnectorCore.UpdateDataOfLoggedUser(loggedUser).SaveToUsersFile();
        }
    }
}

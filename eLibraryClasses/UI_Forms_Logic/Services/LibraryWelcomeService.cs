using System;
using System.Collections.Generic;
using System.Linq;
using eLibraryClasses.DataAccess;
using eLibraryClasses.Models;
using eLibraryClasses.UI_Forms_Logic.Interfaces;

namespace eLibraryClasses.UI_Forms_Logic.Services
{
    public class LibraryWelcomeService : ILibraryWelcomeService
    {
        private List<BookModel> allBooks = GlobalConfig.Connection.GetBook_All();

        private int FindMaxBookId()
        {
            if (allBooks.Count > 0)
            {
                return allBooks.OrderByDescending(x => x.Id).First().Id;
            }

            return 0;
        }

        //Compare user data with data of all books, and return if there are any new book of subscribed authors
        private bool VerifyNewBookOfSubscribed(UserModel loggedUser)
        {
            int maxBookId = FindMaxBookId();

            if (maxBookId > loggedUser.LastLoggedInfo)
            {
                //Make a range of new books (count how many books were added)
                int range = maxBookId - loggedUser.LastLoggedInfo;
                //If list of favorite authors of user is not created, creates a new one
                loggedUser = PreventNullError(loggedUser);

                //Take every book, which was added after last login of user (from max book Id of last login of user, to current max book Id)
                foreach (BookModel book in allBooks.GetRange(loggedUser.LastLoggedInfo, range))
                {
                    foreach (string author in loggedUser.FavoriteAuthors)
                    {
                        if (author == book.Author)
                        {
                            //If author of the new book is same as user favorite authors, return true (New book of favorite author was added during offline)
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private UserModel PreventNullError(UserModel loggedUser)
        {
            if (loggedUser.FavoriteAuthors == null)
            {
                loggedUser.FavoriteAuthors = new List<string>();
            }

            return loggedUser;
        }

        public void NewBookNotification(UserModel loggedUser)
        {
            if (VerifyNewBookOfSubscribed(loggedUser))
            {
                throw new Exception("Pojawiła się w bazie nowa książka Twojego ulubionego autora!");
            }
        }

        public void UpdateUserInfo(UserModel loggedUser)
        {
            //Save to user data a variable of max Id of books
            loggedUser.LastLoggedInfo = FindMaxBookId();

            DataConnectionService.UpdateDataOfLoggedUser(loggedUser).SaveToUsersFile();
        }
    }
}

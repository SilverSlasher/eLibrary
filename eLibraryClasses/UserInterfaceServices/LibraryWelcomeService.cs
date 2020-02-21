using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eLibraryClasses.DataAccess;
using eLibraryClasses.Models;

namespace eLibraryClasses.UserInterfaceServices
{
    public class LibraryWelcomeService
    {
        //Create a list of book models and fill it from file .txt
        private List<BookModel> allBooks = GlobalConfig.Connection.GetBook_All();

        //Find the max Id from all available books took from file .txt
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

            //If max Id of current book list is higher then max Id of list of books in last login of user 
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

            //If there are no new books, or authors of new books are not in user favorite authors list, return false
            return false;
        }

        //If list of favorite authors of user is not created, creates a new one
        private UserModel PreventNullError(UserModel loggedUser)
        {
            if (loggedUser.FavoriteAuthors == null)
            {
                //Create a new list of favorite authors (prevent from null error)
                loggedUser.FavoriteAuthors = new List<string>();
            }

            return loggedUser;
        }

        //Send to user notification about new book of his favorite author in library
        public void NewBookNotification(UserModel loggedUser)
        {
            //If verification was successful, send a message box to user
            if (VerifyNewBookOfSubscribed(loggedUser))
            {
                throw new Exception("Pojawiła się w bazie nowa książka Twojego ulubionego autora!");
            }
        }

        //Update user data with current max Id of available books in library
        public void UpdateUserInfo(ref UserModel loggedUser)
        {
            //Save to user data a variable of max Id of books
            loggedUser.LastLoggedInfo = FindMaxBookId();
            //Update user info to userfile .txt
            FileConnectorCore.UpdateDataOfLoggedUser(loggedUser).SaveToUsersFile();
        }
    }
}

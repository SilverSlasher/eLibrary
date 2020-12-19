using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using eLibraryClasses.DataAccess;
using eLibraryClasses.Interfaces;
using eLibraryClasses.Models;

namespace eLibraryClasses.Services
{
    public class RandomBookService : IRandomBookService
    {
        private static bool isAdded = false;

        private List<BookModel> RandomizedBooks { get; } = new List<BookModel>();

        public RandomBookService(UserModel loggedUser)
        {
            RandomizedBooks = BooksNotUsedBefore(loggedUser);
        }

        public List<BookModel> GetRandomizedBooks()
        {
            return RandomizedBooks;
        }

        private List<BookModel> BooksNotUsedBefore(UserModel loggedUser)
        {
            List<BookModel> allBooks = GlobalConfig.Connection.GetBook_All();

            List<BookModel> output = new List<BookModel>();

            List<BookModel> userUsedBooks = new List<BookModel>();

            //A temporary list of books which are not correct to be matched
            List<BookModel> booksToDelete = new List<BookModel>();

            //If any of user list is not created. Create a new list
            PreventNullError(loggedUser);

            foreach (BookModel book in loggedUser.ReadBooks)
            {
                userUsedBooks.Add(book);
            }

            foreach (BookModel book in loggedUser.ToReadBooks)
            {
                userUsedBooks.Add(book);
            }

            //Compare every book read or selected "to read" by user to every book available in eLibrary
            foreach (BookModel singleBook in userUsedBooks)
            {
                //Compare books. If they matched, add them to list of books to delete
                foreach (BookModel book in allBooks)
                {
                    if (singleBook.Id == book.Id)
                    {
                        booksToDelete.Add(book);
                    }
                }

                //Delete all books which cannot be randomized
                foreach (BookModel book in booksToDelete)
                {
                    allBooks.Remove(book);
                }
            }

            //Save all books not read or selected "to read" to the variable
            output = allBooks;

            //Randomize and return books
            return output.OrderBy(o => Guid.NewGuid()).ToList(); ;
        }

        //Validate if lists are created before, if not, create a new ones
        private void PreventNullError(UserModel loggedUser)
        {
            if (loggedUser.ReadBooks == null)
            {
                loggedUser.ReadBooks = new List<BookModel>();
            }

            if (loggedUser.ToReadBooks == null)
            {
                loggedUser.ToReadBooks = new List<BookModel>();
            }
        }

 
        public void AddBookToUserToReadBookshelf(UserModel loggedUser, int buttonClicked)
        {
            if (isAdded)
            {
                throw new Exception("Dodałeś już tę książkę do swojego zbioru!");
            }

            //Button starts from 1, and list index start at 0 so right book is clicked button number - 1 )
            loggedUser.ToReadBooks.Add(RandomizedBooks.ElementAt(buttonClicked - 1));

            FileConnectorCore.UpdateDataOfLoggedUser(loggedUser).SaveToUsersFile();

            isAdded = true;
        }
    }
}

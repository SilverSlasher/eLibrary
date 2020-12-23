﻿using System;
using System.Collections.Generic;
using System.Linq;
using eLibraryClasses.DataAccess;
using eLibraryClasses.Models;
using eLibraryClasses.UI_Forms_Logic.Interfaces;

namespace eLibraryClasses.UI_Forms_Logic.Services
{
    public class RandomBookService : IRandomBookService
    {
        private readonly UserModel _loggedUser;
        private static bool _isAdded = false;

        private List<BookModel> _randomizedBooks;

        public RandomBookService(UserModel loggedUser)
        {
            _loggedUser = loggedUser;
        }

        public List<BookModel> GetRandomizedBooks()
        {
            return _randomizedBooks;
        }

        public void RandomizeBooks()
        {
            _randomizedBooks = BooksNotUsedBefore();
        }



        private List<BookModel> BooksNotUsedBefore()
        {
            List<BookModel> allBooks = GlobalConfig.Connection.GetBook_All();

            List<BookModel> output = new List<BookModel>();

            List<BookModel> userUsedBooks = new List<BookModel>();

            //A temporary list of books which are not correct to be matched
            List<BookModel> booksToDelete = new List<BookModel>();

            //If any of user list is not created. Create a new list
            PreventNullError(_loggedUser);

            foreach (BookModel book in _loggedUser.ReadBooks)
            {
                userUsedBooks.Add(book);
            }

            foreach (BookModel book in _loggedUser.ToReadBooks)
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
            if (_isAdded)
            {
                throw new Exception("Dodałeś już tę książkę do swojego zbioru!");
            }

            //Button starts from 1, and list index start at 0 so right book is clicked button number - 1 )
            loggedUser.ToReadBooks.Add(_randomizedBooks.ElementAt(buttonClicked - 1));

            DataConnectionService.UpdateDataOfLoggedUser(loggedUser).SaveToUsersFile();

            _isAdded = true;
        }
    }
}

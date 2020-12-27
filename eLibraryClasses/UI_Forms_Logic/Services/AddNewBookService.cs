using System;
using System.Collections.Generic;
using System.Linq;
using eLibraryClasses.DataAccess;
using eLibraryClasses.Models;
using eLibraryClasses.UI_Forms_Logic.Interfaces;

namespace eLibraryClasses.UI_Forms_Logic.Services
{
    public class AddNewBookService : IAddNewBookService
    {
        private readonly IDataConnection _dataConnection;

        public AddNewBookService(IDataConnection dataConnection)
        {
            _dataConnection = dataConnection;
        }

        public void ValidateForm(string authorName, string title, string pages)
        {
            bool pagesValidNumber = int.TryParse(pages, out int pagesValue);

            if (authorName.Length == 0 ||
                title.Length == 0 ||
                pages.Length == 0 ||
                !pagesValidNumber ||
                pagesValue < 1)
            {
                throw new Exception("Wprowadzono nieprawidłowe lub niepełne dane");
            }
        }

        //Add book to user info, to prevent getting message about new book in next login (User add the book, so he knows about existing)
        private void UpdateUserLastLoggedInfo(UserModel loggedUser)
        {
            List<BookModel> allBooks = _dataConnection.GetBook_All();
            //Add to user model and info about highest Id of book in file (add info about added book in this form)
            loggedUser.LastLoggedInfo = allBooks.OrderByDescending(x => x.Id).First().Id;

            DataConnectionService.UpdateDataOfLoggedUser(loggedUser).SaveToUsersFile();
        }

        //Prepares new book model with data got from user, next fill it with ID and save it to file
        public void PrepareNewBook(string authorName, string title, string pages, string genre, string description, UserModel loggedUser)
        {
            BookModel book = new BookModel(
                authorName,
                title,
                genre,
                pages,
                description);

            //Fill book model with Id and save it to file
            _dataConnection.CreateBook(book);

            //Add book to user info, to prevent getting message about new book in next login (User add the book, so he knows about existing)
            UpdateUserLastLoggedInfo(loggedUser);
        }

        //Filling a list of genres with available options
        public List<string> ListOfGenres()
        {
            List<string> output = new List<string>
            {
                "fantastyka",
                "horror",
                "przygodowa",
                "kryminał",
                "historyczna",
                "inna"
            };

            return output;
        }

    }
}

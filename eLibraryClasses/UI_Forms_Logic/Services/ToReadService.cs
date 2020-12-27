using System;
using System.Collections.Generic;
using System.Linq;
using eLibraryClasses.DataAccess;
using eLibraryClasses.Models;
using eLibraryClasses.UI_Forms_Logic.Interfaces;

namespace eLibraryClasses.UI_Forms_Logic.Services
{
    public class ToReadService : IToReadService
    {

        public void AddBookToUserReadBookshelf(UserModel loggedUser, BookModel selectedItem)
        {
            //Check if book lists of user are created. If not, create a new ones
            PreventNullError(loggedUser);

            if (!loggedUser.ToReadBooks.Any())
            {
                throw new Exception("Brak książek w grupie 'Do przeczytania'");
            }

            if (ValidateExisting(loggedUser.ReadBooks, selectedItem))
            {
                throw new Exception("Książka znajduje się już w grupie 'Przeczytane'");
            }

            loggedUser.ReadBooks.Add(selectedItem);
            loggedUser.ToReadBooks.Remove(selectedItem);

            DataConnectionService.UpdateDataOfLoggedUser(loggedUser).SaveToUsersFile();
        }


        //Check if selected book already exists in bookshelf, if yes return false
        private bool ValidateExisting(List<BookModel> bookshelf, BookModel selectedItem)
        {
            bool output = false;

            foreach (BookModel book in bookshelf)
            {
                if (selectedItem.Id == book.Id)
                {
                    output = true;
                }
            }

            return output;
        }

        //Check if book lists of user are created. If not, create a new ones
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
    }
}

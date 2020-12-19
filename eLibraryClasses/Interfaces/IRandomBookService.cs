using System;
using System.Collections.Generic;
using System.Text;
using eLibraryClasses.Models;

namespace eLibraryClasses.Interfaces
{
    public interface IRandomBookService
    {
        void AddBookToUserToReadBookshelf(UserModel loggedUser, int buttonClicked);

        List<BookModel> GetRandomizedBooks();
    }
}

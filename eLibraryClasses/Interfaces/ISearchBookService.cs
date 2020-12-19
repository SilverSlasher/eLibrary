using System;
using System.Collections.Generic;
using System.Text;
using eLibraryClasses.Models;

namespace eLibraryClasses.Interfaces
{
    public interface ISearchBookService
    {
        List<string> FillListOfSearchTypes();

        List<BookModel> SearchForBooks(string type, string value);

        void AddBookToUserToReadBookshelf(ref UserModel loggedUser, BookModel selectedItem);



    }
}

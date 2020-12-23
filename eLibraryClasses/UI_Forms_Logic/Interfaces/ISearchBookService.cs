using System.Collections.Generic;
using eLibraryClasses.Models;

namespace eLibraryClasses.UI_Forms_Logic.Interfaces
{
    public interface ISearchBookService
    {
        List<string> FillListOfSearchTypes();

        List<BookModel> SearchForBooks(string type, string value);

        void AddBookToUserToReadBookshelf(UserModel loggedUser, BookModel selectedItem);



    }
}

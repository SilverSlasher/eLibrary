using System.Collections.Generic;
using eLibraryClasses.Models;

namespace eLibraryClasses.UI_Forms_Logic.Interfaces
{
    public interface IAddNewBookService
    {
        void ValidateForm(string authorName, string title, string pages);

        void PrepareNewBook(string authorName, string title, string pages, string genre, string description, UserModel loggedUser);

        List<string> ListOfGenres();
    }
}

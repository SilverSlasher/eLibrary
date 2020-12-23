using System.Collections.Generic;
using eLibraryClasses.Models;

namespace eLibraryClasses.UI_Forms_Logic.Interfaces
{
    public interface IRandomBookService
    {
        void AddBookToUserToReadBookshelf(UserModel loggedUser, int buttonClicked);

        List<BookModel> GetRandomizedBooks();

        void RandomizeBooks();
    }
}

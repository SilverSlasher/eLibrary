using eLibraryClasses.Models;

namespace eLibraryClasses.UI_Forms_Logic.Interfaces
{
    public interface IToReadService
    {
        void AddBookToUserReadBookshelf(UserModel loggedUser, BookModel selectedItem);
    }
}

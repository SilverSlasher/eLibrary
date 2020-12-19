using System;
using System.Collections.Generic;
using System.Text;
using eLibraryClasses.Models;

namespace eLibraryClasses.Interfaces
{
    public interface IToReadService
    {
        void AddBookToUserReadBookshelf(UserModel loggedUser, BookModel selectedItem);
    }
}

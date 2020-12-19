using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eLibraryClasses.DataAccess;
using eLibraryClasses.Models;

namespace eLibraryClasses.Interfaces
{
    public interface IAddNewBookService
    {
        void ValidateForm(string authorName, string title, string pages);

        void PrepareNewBook(string authorName, string title, string pages, string genre, string description, UserModel loggedUser);

        List<string> ListOfGenres();
    }
}

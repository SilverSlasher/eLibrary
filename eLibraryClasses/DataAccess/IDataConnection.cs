using eLibraryClasses.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace eLibraryClasses.DataAccess
{
    public interface IDataConnection
    {
        void CreateUser(UserModel user);
        void CreateBook(BookModel book);
        List<UserModel> GetUser_All();
        List<BookModel> GetBook_All();
        List<QuestionModel> GetQuestion_All();
        List<string> GetQuotes_All();

    }
}

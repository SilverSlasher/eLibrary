using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eLibraryClasses.Models;
using System.Threading.Tasks;
using System.Configuration;

namespace eLibraryClasses.DataAccess
{
    class FilesConnector : IDataConnection
    {
        //Last part of creating new user. Taking all infos wrote before. Checking highest Id in file .txt. Adding to new user a highest Id + 1. Saving complete user
        public void CreateUser(UserModel user)
        {
            //Loading all users from text file
            List<UserModel> users = GetUser_All();

            //Looking for max ID
            int currentId = 1;

            if (users.Count > 0)
            {
                currentId = users.OrderByDescending(x => x.Id).First().Id + 1;
            }
            user.Id = currentId;

            //Add the new user with ID (max +1)
            users.Add(user);

            //Save the list<UserModel> including new user to file
            users.SaveToUsersFile();
        }
        //Last part of creating new book. Taking all infos wrote before. Checking highest Id in file .txt. Adding to new book a highest Id + 1. Saving complete book
        public void CreateBook(BookModel book)
        {
            //Loading all books from text file
            List<BookModel> books = GlobalConfig.BooksFile.FullFilePath().LoadFile().ConvertToBookModels();


            //Looking for max ID
            int currentId = 1;

            if (books.Count > 0)
            {
                currentId = books.OrderByDescending(x => x.Id).First().Id + 1;
            }
            book.Id = currentId;

            //Add the new book with ID (max +1)
            books.Add(book);

            //Save the list<BookModel> including new book to file
            books.SaveToBooksFile();
        }
        //Shortcut for full sentence of loading and converting users from file
        public List<UserModel> GetUser_All()
        {
            return GlobalConfig.UsersFile.FullFilePath().LoadFile().ConvertToUserModels();
        }
        //Shortcut for full sentence of loading and converting books from file
        public List<BookModel> GetBook_All()
        {
            return GlobalConfig.BooksFile.FullFilePath().LoadFile().ConvertToBookModels();
        }
    }
}

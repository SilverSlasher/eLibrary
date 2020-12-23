using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eLibraryClasses.Models;
using System.Threading.Tasks;
using System.Configuration;

namespace eLibraryClasses.DataAccess
{
    public class DataConnection : IDataConnection
    {
        //Last part of creating new user. Taking all infos wrote before. Checking highest Id in file .txt. Adding to new user a highest Id + 1. Saving complete user
        public void CreateUser(UserModel user)
        {
            List<UserModel> users = GetUser_All();

            int currentId = 1;

            if (users.Count > 0)
            {
                currentId = users.OrderByDescending(x => x.Id).First().Id + 1;
            }
            user.Id = currentId;

            users.Add(user);

            users.SaveToUsersFile();
        }

        public void CreateBook(BookModel book)
        {
            List<BookModel> books = GlobalConfig.BooksFile.FullFilePath().LoadFile().ConvertToBookModels();

            int currentId = 1;

            if (books.Count > 0)
            {
                currentId = books.OrderByDescending(x => x.Id).First().Id + 1;
            }
            book.Id = currentId;

            books.Add(book);

            books.SaveToBooksFile();
        }

        public List<UserModel> GetUser_All()
        {
            return GlobalConfig.UsersFile.FullFilePath().LoadFile().ConvertToUserModels();
        }

        public List<BookModel> GetBook_All()
        {
            return GlobalConfig.BooksFile.FullFilePath().LoadFile().ConvertToBookModels();
        }
    }
}

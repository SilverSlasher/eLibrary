using System;
using System.Collections.Generic;
using eLibraryClasses.DataAccess;
using eLibraryClasses.Models;
using eLibraryClasses.UI_Forms_Logic.Interfaces;

namespace eLibraryClasses.UI_Forms_Logic.Services
{
    public class LibraryAccessService : ILibraryAccessService
    {


        //Validate info got from user with data from file, and return user model if data is correct
        public UserModel UserLoginIn(string userName, string password)
        {
            List<UserModel> users = GlobalConfig.UsersFile.FullFilePath().LoadFile().ConvertToUserModels();

            if (userName.Length == 0)
            {
                throw new Exception("Nie wprowadzono nazwy użytkownika");
            }

            if (password.Length == 0)
            {
                throw new Exception("Nie wprowadzono hasła");
            }

            foreach (UserModel user in users)
            {
                if (userName.Equals(user.UserName, StringComparison.OrdinalIgnoreCase))
                {
                    if (password == user.Password)
                    {
                        return user;
                    }

                    throw new Exception("Wprowadzone hasło jest nieprawidłowe");
                }
            }

            throw new Exception("Nie znaleziono takiego użytkownika w bazie");
        }
    }
}

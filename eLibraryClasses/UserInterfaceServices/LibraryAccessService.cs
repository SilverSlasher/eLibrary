using System;
using System.Collections.Generic;
using System.Text;
using eLibraryClasses.DataAccess;
using eLibraryClasses.Models;

namespace eLibraryClasses.UserInterfaceServices
{
    public class LibraryAccessService
    {


        //Validate info got from user with data from file, and return user model if data is correct
        public UserModel UserLoginIn(string userName, string password)
        {
            //Create a new list of user models, and fill it with all users got from file .txt
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
                //Look if are there username in text file with all users
                if (userName.Equals(user.UserName, StringComparison.OrdinalIgnoreCase))
                {
                    //Check if password wrote down by user is same as password connected to username in text file
                    if (password == user.Password)
                    {
                        return user;
                    }

                    //If passwords is incorrect, inform user about mistake
                    throw new Exception("Wprowadzone hasło jest nieprawidłowe");
                }
            }
            //If username is not same as any username in file, throw exception
            throw new Exception("Nie znaleziono takiego użytkownika w bazie");
        }
    }
}

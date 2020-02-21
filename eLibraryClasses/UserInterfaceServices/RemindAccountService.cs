﻿using System;
using System.Collections.Generic;
using System.Text;
using eLibraryClasses.DataAccess;
using eLibraryClasses.Models;

namespace eLibraryClasses.UserInterfaceServices
{
    public class RemindAccountService
    {
        public void RemindEmail(string emailAddress)
        {
            //Check if user wrote any email address
            if (emailAddress.Length == 0)
            {
                throw new Exception("Nie wprowadzono adresu email");
            }

            //Create a new list of user models, and fill it with all users got from file .txt
            List<UserModel> users = GlobalConfig.UsersFile.FullFilePath().LoadFile().ConvertToUserModels();

            //Check if any existing user has same email address as requested
            foreach (UserModel user in users)
            {
                if (emailAddress == user.EmailAddress)
                {
                    //Send email with data on requested email
                    EmailService.SendRemindEmail(emailAddress, user.FirstName, user.UserName, user.Password);
                    return;
                }
            }

            throw new Exception("Nie znaleziono takiego adresu email w bazie");
        }
    }
}
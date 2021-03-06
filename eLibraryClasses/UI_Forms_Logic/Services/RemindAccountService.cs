﻿using System;
using System.Collections.Generic;
using eLibraryClasses.DataAccess;
using eLibraryClasses.Models;
using eLibraryClasses.UI_Forms_Logic.Interfaces;

namespace eLibraryClasses.UI_Forms_Logic.Services
{
    public class RemindAccountService : IRemindAccountService
    {
        private readonly IDataConnection _dataConnection;

        public RemindAccountService(IDataConnection dataConnection)
        {
            _dataConnection = dataConnection;
        }

        public void RemindEmail(string emailAddress)
        {
            if (emailAddress.Length == 0)
            {
                throw new Exception("Nie wprowadzono adresu email");
            }

            List<UserModel> users = _dataConnection.GetUser_All();

            //Check if any existing user has same email address as requested
            foreach (UserModel user in users)
            {
                if (emailAddress == user.EmailAddress)
                {
                    EmailService.SendRemindEmail(emailAddress, user.FirstName, user.UserName, user.Password);
                    return;
                }
            }

            throw new Exception("Nie znaleziono takiego adresu email w bazie");
        }
    }
}

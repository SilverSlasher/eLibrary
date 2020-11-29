using System;
using System.Collections.Generic;
using System.Text;
using eLibraryClasses.DataAccess;
using eLibraryClasses.Models;

namespace eLibraryClasses.UserInterfaceServices
{
    public class CreateUserService
    {
        public void IsUsernameOrEmailCurrentlyExisting(string userName, string email)
        {
            List<UserModel> users = GlobalConfig.UsersFile.FullFilePath().LoadFile().ConvertToUserModels();

            foreach (UserModel user in users)
            {
                //Check if the user name already exists (ignoring letter case)
                if (userName.Equals(user.UserName, StringComparison.OrdinalIgnoreCase))
                {
                    throw new Exception("Użytkownik o takim loginie już istnieje!");
                }

                //Check if the email address already exists (ignoring letter case)
                if (email.Equals(user.EmailAddress, StringComparison.OrdinalIgnoreCase))
                {
                    throw new Exception("Ten adres email znajduje się już w bazie!");
                }
            }
        }

        //Prepares new user model with data got from user, next fill it with ID and save it to file
        public void PrepareNewUser(string firstName, string lastName, string userName, string password, string email)
        {
            UserModel user = new UserModel(
                firstName,
                lastName,
                userName,
                password,
                email);

            //Fill user model with Id and save it to file
            GlobalConfig.Connection.CreateUser(user);

            EmailService.SendWelcomeEmail(user.EmailAddress, user.FirstName);

            EmailService.SendEmailToAppCreator(user.FirstName, user.LastName);
        }

        public void ValidateForm(
            string userName,
            string password,
            string repeatPassword,
            string firstName,
            string lastName,
            string email
            )
        {
            bool lengthValidate = (userName.Length > 0 &&
                                   password.Length > 0 &&
                                   repeatPassword.Length > 0 &&
                                   firstName.Length > 0 &&
                                   lastName.Length > 0 &&
                                   email.Length > 0);


            IsUsernameOrEmailCurrentlyExisting(userName, email);

            if (!lengthValidate)
            {
                throw new Exception("Nie wprowadzono wszystkich danych");
            }

            if (password != repeatPassword)
            {
                throw new Exception("Hasła muszą być identyczne");
            }

            if (!IsValidEmail(email))
            {
                throw new Exception("Wprowadź poprawny adres email");
            }

        }

        public bool IsValidEmail(string email)
        {
            //Try to send fake mail to email address provided by user
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                //If operation didn't crash then mail address is correct
                return true;
            }
            catch
            {
                //If it didn't work then email address is incorrect
                return false;
            }
        }
    }
}

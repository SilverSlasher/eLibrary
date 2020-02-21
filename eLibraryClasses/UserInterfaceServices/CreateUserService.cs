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
            //Create a new list of user models, and fill it with all users got from file .txt
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
            //Send a welcome email to user on the email address provided before
            EmailService.SendWelcomeEmail(user.EmailAddress, user.FirstName);
            //Send email to app creator, more info in readme.txt and EmailConfig.cs
            EmailService.SendEmailToAppCreator(user.FirstName, user.LastName);
        }

        //Validating every possible mistake of user
        public void ValidateForm(
            string userName,
            string password,
            string repeatPassword,
            string firstName,
            string lastName,
            string email
            )
        {
            //Checking if every necessary info is provided by user 
            bool lengthValidate = (userName.Length > 0 &&
                                   password.Length > 0 &&
                                   repeatPassword.Length > 0 &&
                                   firstName.Length > 0 &&
                                   lastName.Length > 0 &&
                                   email.Length > 0);


            //Check if is there user with same username of email address
            IsUsernameOrEmailCurrentlyExisting(userName, email);

            if (!lengthValidate)
            {
                //If every necessary info is not provided, inform user about mistake
                throw new Exception("Nie wprowadzono wszystkich danych");
            }

            if (password != repeatPassword)
            {
                //If passwords are not same, inform user about mistake
                throw new Exception("Hasła muszą być identyczne");
            }

            if (!IsValidEmail(email))
            {
                //If email is not correct, inform user about mistake
                throw new Exception("Wprowadź poprawny adres email");
            }

        }

        //Validating form of email address
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

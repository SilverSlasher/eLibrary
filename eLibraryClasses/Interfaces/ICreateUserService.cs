using System;
using System.Collections.Generic;
using System.Text;

namespace eLibraryClasses.Interfaces
{
    public interface ICreateUserService
    {
        void IsUsernameOrEmailCurrentlyExisting(string userName, string email);

        void PrepareNewUser(string firstName, string lastName, string userName, string password, string email);
        void ValidateForm(
            string userName,
            string password,
            string repeatPassword,
            string firstName,
            string lastName,
            string email
        );

        bool IsValidEmail(string email);

    }
}

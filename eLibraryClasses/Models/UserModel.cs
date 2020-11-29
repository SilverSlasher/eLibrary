using System;
using System.Collections.Generic;
using System.Text;

namespace eLibraryClasses.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public List<BookModel> ReadBooks { get; set; }
        public List<BookModel> ToReadBooks { get; set; }
        public List<string> FavoriteAuthors { get; set; }
        //If isSubscribing is "True", user will get notification after login if new books of his favorite authors was added to base
        public bool IsSubscribing { get; set; }
        //Get highest Id of existing book in base after login in. Used for checking if there are any of new books in base compared to last login
        public int LastLoggedInfo { get; set; }

        public UserModel(string firstName, string lastName, string userName, string password, string emailAddress)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Password = password;
            EmailAddress = emailAddress;
        }

        public UserModel()
        {

        }
    }
}

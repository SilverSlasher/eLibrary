using System;
using System.Collections.Generic;
using System.Text;

namespace eLibraryClasses.Models
{
    public class UserModel
    {
        //Unique Id of the book
        public int Id { get; set; }
        //First name of the user
        public string FirstName { get; set; }
        //Second name of the user
        public string LastName { get; set; }
        //Username / login of the user
        public string UserName { get; set; }
        //Password of the user
        public string Password { get; set; }
        //Email address of the user
        public string EmailAddress { get; set; }
        //List of books read by user
        public List<BookModel> ReadBooks { get; set; }
        //List of books which user would like to read
        public List<BookModel> ToReadBooks { get; set; }
        //List of favorite authors of user
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

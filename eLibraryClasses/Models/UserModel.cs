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

        public List<string> FavoriteAuthors { get; set; }

        public bool IsSubscribing { get; set; }

    }
}

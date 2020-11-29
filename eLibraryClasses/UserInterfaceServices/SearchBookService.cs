using System;
using System.Collections.Generic;
using System.Text;
using eLibraryClasses.DataAccess;
using eLibraryClasses.Models;

namespace eLibraryClasses.UserInterfaceServices
{
    public class SearchBookService
    {
        //Create a list of available types of search
        public List<string> FillListOfSearchTypes()
        {
            List<string> output = new List<string>
            {
                //Author
                "Autor",
                //Title
                "Tytuł",
                //Genre
                "Gatunek"
            };

            return output;
        }


        public List<BookModel> SearchForBooks(string type, string value)
        {
            List<BookModel> output = new List<BookModel>();

            List<BookModel> allBooks = GlobalConfig.Connection.GetBook_All();

            //If user didn't specify any value, return all available books
            if (value == "")
            {
                foreach (BookModel book in allBooks)
                {
                    output.Add(book);
                }

                return output;
            }

            switch (type)
            {
                case "Autor":

                    foreach (BookModel book in allBooks)
                    {
                        //Check if any author contains searched value (Not exactly the same. "Sapk" will return "Sapkowski" etc)
                        if (book.Author.Contains(value))
                        {
                            output.Add(book);
                        }

                    }
                    break;


                case "Tytuł":

                    foreach (BookModel book in allBooks)
                    {
                        if (book.Title.Contains(value))
                        {
                            output.Add(book);
                        }

                    }
                    break;


                case "Gatunek":

                    foreach (BookModel book in allBooks)
                    {
                        if (book.Genre.Contains(value))
                        {
                            output.Add(book);
                        }

                    }
                    break;
            }

            return output;
        }

        private void PreventNullError(UserModel loggedUser)
        {
            if (loggedUser.ReadBooks == null)
            {
                loggedUser.ReadBooks = new List<BookModel>();
            }

            if (loggedUser.ToReadBooks == null)
            {
                loggedUser.ToReadBooks = new List<BookModel>();
            }
        }

        public void AddBookToUserToReadBookshelf(ref UserModel loggedUser, BookModel selectedItem)
        {
            PreventNullError(loggedUser);
            ExistingWarning(loggedUser, selectedItem);
            loggedUser.ToReadBooks.Add(selectedItem);
            FileConnectorCore.UpdateDataOfLoggedUser(loggedUser).SaveToUsersFile();
        }

        //Check if book exists in user bookshelf, and inform user if positive
        private void ExistingWarning(UserModel loggedUser, BookModel selectedItem)
        {
            if (ValidateExisting(loggedUser.ToReadBooks, selectedItem))
            {
                throw new Exception("Książka znajduje się już w grupie 'Do przeczytania'");
            }
            if (ValidateExisting(loggedUser.ReadBooks, selectedItem))
            {
                throw new Exception("Książka znajduje się już w grupie 'Przeczytane'");
            }
        }

        //Validate if selected book exists in list of book models. If yes, return false
        private bool ValidateExisting(List<BookModel> bookshelf, BookModel selectedItem)
        {
            bool output = false;

            foreach (BookModel book in bookshelf)
            {
                if (selectedItem.Id == book.Id)
                {
                    output = true;
                }
            }

            return output;
        }
    }
}

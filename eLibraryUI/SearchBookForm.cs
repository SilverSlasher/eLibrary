using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eLibraryClasses;
using eLibraryClasses.DataAccess;
using eLibraryClasses.Models;

namespace eLibraryUI
{
    public partial class SearchBookForm : Form
    {
        //Create new list of string to store types of search
        private List<String> searchTypes = new List<string>();
        //Create a list of book models and fill it from file .txt
        private List<BookModel> availableBooks = GlobalConfig.Connection.GetBook_All();
        //Create a list of book models to store matched books
        private List<BookModel> foundBooks = new List<BookModel>();

        //Create new local UserModel to store logged user data got from form closed before
        private UserModel loggedUser = new UserModel();

        public SearchBookForm(UserModel model)
        {
            InitializeComponent();
            //Save active user data to local variable 
            loggedUser = model;
            //Fill dropdown of search types
            searchTypeDropDown.DataSource = fillListOfSearchTypes(searchTypes);
        }

        //Create a list of available types of search
        private List<String> fillListOfSearchTypes(List<string> searchTypes)
        {
            //Author
            searchTypes.Add("Autor");
            //Title
            searchTypes.Add("Tytuł");
            //Genre
            searchTypes.Add("Gatunek");

            return searchTypes;
        }

        //Fill listbox of read books with user data
        private void WireUpList()
        {
            foundBooksListBox.DataSource = null;
            foundBooksListBox.DataSource = foundBooks;
            foundBooksListBox.DisplayMember = "Title";
        }

        //Refresh description panel with detail of highlight book
        private void UpdateBookDescriptionPanel()
        {
            //Store selected item from list box, to local variable
            BookModel descriptionPanelBook = (BookModel)foundBooksListBox.SelectedItem;
            if (descriptionPanelBook != null)
            {
                authorLabel.Text = descriptionPanelBook.Author;
                titleLabel.Text = descriptionPanelBook.Title;
                genreLabel.Text = descriptionPanelBook.Genre;
                bookDescriptionLabel.Text = descriptionPanelBook.Description;
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            //Assign info got from user (type of searching, value to search) to list of books to show (foundBooks)
            foundBooks = SearchForBook(availableBooks, searchTypeDropDown.SelectedItem.ToString(), titleValue.Text);
            //Refresh the list
            WireUpList();
        }

        private List<BookModel> SearchForBook(List<BookModel> allBooks,string type, string value)
        {
            //Create a list of book models to return at the end of function
            List<BookModel> output = new List<BookModel>();

            //If user didn't specify any value, return all available books
            if (value == "")
            {
                foreach (BookModel book in allBooks)
                {
                    output.Add(book);
                }

                return output;
            }
            
            //If user is searching by author name
            if (type == "Autor")
            {
                foreach (BookModel book in allBooks)
                {
                    //Check if any author contains searched value (Not exactly the same. "Sapk" will return "Sapkowski" etc)
                    if (book.Author.Contains(value))
                    {
                        output.Add(book);
                    }

                }
            }

            //If user is searching by title name
            if (type == "Tytuł")
            {
                foreach (BookModel book in allBooks)
                {
                    //Check if any title contains searched value (Not exactly the same. "Har" will return "Harry Potter" etc)
                    if (book.Title.Contains(value))
                    {
                        output.Add(book);
                    }

                }
            }

            //If user is searching by genre
            if (type == "Gatunek")
            {
                foreach (BookModel book in allBooks)
                {
                    //Check if any genre contains searched value (Not exactly the same. "fan" will return "fantastyka" etc)
                    if (book.Genre.Contains(value))
                    {
                        output.Add(book);
                    }

                }
            }
            
            return output;
        }

        private void foundBooksListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //When user click on another item in list box, the description panel show the info about new highlighted item
            UpdateBookDescriptionPanel();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            //Create a new form, and send logged user data
            ChooseBookForm frm = new ChooseBookForm(loggedUser);
            //Show a created form
            frm.Show();
            //Close current form
            this.Close();
        }

        private void toReadButton_Click(object sender, EventArgs e)
        {
            bool validateAddition = true;

            //Check if book lists of user are created. If not, create a new ones
            ValidateNulls();

            //If user is trying to add book which exists in user's "to read bookshelf" or "read books bookshelf",
            //return false to validation
            if (!validateExisting(loggedUser.ToReadBooks,(BookModel)foundBooksListBox.SelectedItem) ||
                !validateExisting(loggedUser.ReadBooks, (BookModel)foundBooksListBox.SelectedItem)
                )
            {
                validateAddition = false;
            }

            //If book doesn't exist in user bookshelf, add the book, and update user info and save it to file
            if (validateAddition)
            {
                loggedUser.ToReadBooks.Add((BookModel)foundBooksListBox.SelectedItem);
                FileConnectorCore.UpdateDataOfLoggedUser(loggedUser).SaveToUsersFile();
            }
            else
            {
                //If book exists in user bookshelf, inform user
                ExistingWarning();
            }
        }

        //Check if book lists of user are created. If not, create a new ones
        private void ValidateNulls()
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

        //Check if book exists in user bookshelf, and inform user if positive
        private void ExistingWarning()
        {
            if (!validateExisting(loggedUser.ToReadBooks, (BookModel)foundBooksListBox.SelectedItem))
            {
                MessageBox.Show("Książka znajduje się już w grupie 'Do przeczytania'");
            }
            else if (!validateExisting(loggedUser.ReadBooks, (BookModel)foundBooksListBox.SelectedItem))
            {
                MessageBox.Show("Książka znajduje się już w grupie 'Przeczytane'");
            }
        }

        //Validate if selected book exists in list of book models. If yes, return false
        private bool validateExisting(List<BookModel> bookshelf, BookModel selectedItem)
        {
            bool output = true;

            foreach (BookModel book in bookshelf)
            {
                if (selectedItem.Id == book.Id)
                {
                    output = false;
                }
            }

            return output;
        }

        private void bookDescriptionLabel_Click(object sender, EventArgs e)
        {
            MessageBox.Show(bookDescriptionLabel.Text);
        }
    }
}

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
    public partial class AddNewBookForm : Form
    {
        //Create new list of genres, selectable in dropdown
        private List<String> genres = new List<string>();

        //Create new local UserModel to store logged user data got from form closed before
        private UserModel loggedUser = new UserModel();

        //Create new local list to get later all books wrote in file .txt
        private List<BookModel> allBooks;

        public AddNewBookForm(UserModel model)
        {
            InitializeComponent();
            //Save active user data to local variable 
            loggedUser = model;
            //Assign to dropdown with genres a list of predefined ones
            genreDropDown.DataSource = fillListOfGenres(genres);
        }

        //Validating every possible mistake of user
        private bool ValidateForm()
        {
            //Setting the output to normally true
            bool output = true;

            //Setting the default value of pages to 0
            int pages = 0;

            //Try to parse value wrote by user to integer
            bool pagesValidNumber = int.TryParse(pagesValue.Text, out pages);

            //If author name is not wrote down, return validating false
            if (authorValue.Text.Length == 0)
            {
                output = false;
            }

            //If title is not wrote down, return validating false
            if (titleValue.Text.Length == 0)
            {
                output = false;
            }

            //If number of pages is not wrote down, return validating false
            if (pagesValue.Text.Length == 0)
            {
                output = false;
            }

            //If it is impossible to parse value wrote by user (non integer value wrote), return false
            if (!pagesValidNumber)
            {
                output = false;
            }

            //If number of pages is 0 or it is negative value, return false
            if (pages < 1)
            {
                output = false;
            }

            //Return value of output
            return output;
        }

        private void addBookButton_Click(object sender, EventArgs e)
        {
            //Check the validating of every variable in form
            if (ValidateForm())
            {
                //If everything is okey, create a new book model and write down values provide by user
                BookModel book = new BookModel(
                    authorValue.Text,
                    titleValue.Text,
                    genreDropDown.SelectedItem.ToString(),
                    pagesValue.Text,
                    descriptionValue.Text);

                //Fill book model with Id and save it to file
                GlobalConfig.Connection.CreateBook(book);
                //Add book to user info, to prevent getting message about new book in next login (User add the book, so he knows about existing)
                UpdateUserLastLoggedInfo();
                //Close this form
                this.Close();
                //Send message to user about successful operation
                MessageBox.Show($"Poprawnie dodano książkę o tytule {book.Title}");
            }
            else
            {
                //If validating gone wrong, inform user about mistake
                MessageBox.Show("Wprowadzono nieprawidłowe lub niepełne dane");
            }
        }

        //Add book to user info, to prevent getting message about new book in next login (User add the book, so he knows about existing)
        private void UpdateUserLastLoggedInfo()
        {
            //Fill the allBooks variable with books from file .txt (It couldn't be done before, because new book was added during working of form, not starting)
            allBooks = GlobalConfig.Connection.GetBook_All();
            //Add to user model and info about highest Id of book in file (add info about added book in this form)
            loggedUser.LastLoggedInfo = allBooks.OrderByDescending(x => x.Id).First().Id;
            //Update user info to userfile .txt
            FileConnectorCore.UpdateDataOfLoggedUser(loggedUser).SaveToUsersFile();
        }

        //Filling a list of genres with available options
        private List<String> fillListOfGenres(List<string> genres)
        {
            genres.Add("fantastyka");
            genres.Add("horror");
            genres.Add("przygodowa");
            genres.Add("kryminał");
            genres.Add("historyczna");
            genres.Add("inna");

            return genres;
        }
    }
}

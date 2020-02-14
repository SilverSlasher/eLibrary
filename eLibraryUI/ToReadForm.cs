using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eLibraryClasses.DataAccess;
using eLibraryClasses.Models;

namespace eLibraryUI
{
    public partial class ToReadForm : Form
    {
        //Create new local UserModel to store logged user data got from form closed before
        private UserModel loggedUser = new UserModel();

        public ToReadForm(UserModel model)
        {
            InitializeComponent();
            //Save active user data to local variable 
            loggedUser = model;
            //Fill listbox of read books with user data
            WireUpToReadList();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            //Create a new form, and send logged user data
            ReadBooksForm frm = new ReadBooksForm(loggedUser);
            //Show a created form
            frm.Show();
            //Close current form
            this.Close();
        }

        //Fill listbox of read books with user data
        private void WireUpToReadList()
        {
            toReadListBox.DataSource = null;
            toReadListBox.DataSource = loggedUser.ToReadBooks;
            toReadListBox.DisplayMember = "Title";
        }

        //Refresh description panel with detail of highlight book
        private void UpdateBookDescriptionPanel()
        {
            //Store selected item from list box, to local variable
            BookModel descriptionPanelBook = (BookModel)toReadListBox.SelectedItem;

            //If any item on listbox is selected
            if (descriptionPanelBook != null)
            {
                authorLabel.Text = descriptionPanelBook.Author;
                titleLabel.Text = descriptionPanelBook.Title;
                genreLabel.Text = descriptionPanelBook.Genre;
                bookDescriptionLabel.Text = descriptionPanelBook.Description;
            }
        }

        private void toReadListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //When selected item is changed, update labels in book description panel
            UpdateBookDescriptionPanel();
        }

        //Try to add selected book from "to read bookshelf" to "read books bookshelf"
        private void readBookButton_Click(object sender, EventArgs e)
        {
            bool validateAddition = true;

            //Check if book lists of user are created. If not, create a new ones
            ValidateNulls();

            //If there are no books in user "to read" bookshelf, send message to user
            if (!loggedUser.ToReadBooks.Any())
            {
                MessageBox.Show("Brak książek w grupie 'Do przeczytania'");
                return;
            }

            //Check if selected book already exists in bookshelf, if yes return false
            if (!validateExisting(loggedUser.ReadBooks, (BookModel)toReadListBox.SelectedItem))
            {
                validateAddition = false;
            }

            //If any book is selected, and book didn't exists in user "read books" bookshelf
            if (toReadListBox.SelectedItem != null && validateAddition)
            {
                //Add selected book to user "read books bookshelf"
                loggedUser.ReadBooks.Add((BookModel)toReadListBox.SelectedItem);
                //Remove selected book from user "to read bookshelf"
                loggedUser.ToReadBooks.Remove((BookModel)toReadListBox.SelectedItem);
                //Update user data, and save new data to file
                FileConnectorCore.UpdateDataOfLoggedUser(loggedUser).SaveToUsersFile();
                //Refresh list in the form
                WireUpToReadList();

                //If there are any more books in user "to read bookshelf", select the first one
                if (loggedUser.ToReadBooks.Any())
                {
                    toReadListBox.SelectedIndex = 0;
                }
                //If there are no books anymore, write down "No book"
                else
                {
                    authorLabel.Text = "Brak książki";
                    titleLabel.Text = "Brak książki";
                    genreLabel.Text = "Brak książki";
                    bookDescriptionLabel.Text = "Brak książki";
                }
            }
            //If user is trying to add book which is already in user "read books bookshelf", inform user
            else
            {
                MessageBox.Show("Książka znajduje się już w grupie 'Przeczytane'");
            }
        }

        //Check if selected book already exists in bookshelf, if yes return false
        private bool validateExisting(List<BookModel> readBooks, BookModel selectedItem)
        {
            bool output = true;

            foreach (BookModel book in readBooks)
            {
                if (selectedItem.Id == book.Id)
                {
                    output = false;
                }
            }

            return output;
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

        private void bookDescriptionLabel_Click(object sender, EventArgs e)
        {
            MessageBox.Show(bookDescriptionLabel.Text);
        }
    }
}

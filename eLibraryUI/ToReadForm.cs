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
using eLibraryClasses.UserInterfaceServices;

namespace eLibraryUI
{
    public partial class ToReadForm : Form
    {
        ToReadService service = new ToReadService();

        //Create new local UserModel to store logged user data got from form closed before
        private UserModel loggedUser;

        public ToReadForm(UserModel model)
        {
            InitializeComponent();
            loggedUser = model;
            //Fill listbox of read books with user data
            WireUpToReadList();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            ReadBooksForm frm = new ReadBooksForm(loggedUser);
            frm.Show();
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
            BookModel descriptionPanelBook = (BookModel)toReadListBox.SelectedItem;

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
            UpdateBookDescriptionPanel();
        }

        //Try to add selected book from "to read bookshelf" to "read books bookshelf"
        private void readBookButton_Click(object sender, EventArgs e)
        {
            try
            {
                service.AddBookToUserReadBookshelf(ref loggedUser, (BookModel)toReadListBox.SelectedItem);
                RefreshThisForm();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }


        private void bookDescriptionLabel_Click(object sender, EventArgs e)
        {
            MessageBox.Show(bookDescriptionLabel.Text);
        }

        private void RefreshThisForm()
        {
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
    }
}

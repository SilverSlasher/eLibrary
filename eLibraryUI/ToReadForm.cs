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
using eLibraryClasses.Interfaces;
using eLibraryClasses.Models;
using eLibraryClasses.Services;

namespace eLibraryUI
{
    public partial class ToReadForm : Form
    {
        private IToReadService service;
        private UserModel loggedUser;

        public ToReadForm(UserModel model, IToReadService service)
        {
            InitializeComponent();
            this.service = service;
            loggedUser = model;
            WireUpToReadList();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            ReadBooksForm frm = new ReadBooksForm(loggedUser, new ReadBooksService());
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
                service.AddBookToUserReadBookshelf(loggedUser, (BookModel)toReadListBox.SelectedItem);
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

﻿using System;
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
using eLibraryClasses.UserInterfaceServices;

namespace eLibraryUI
{
    public partial class SearchBookForm : Form
    {
        SearchBookService service = new SearchBookService();
        private UserModel loggedUser;

        public SearchBookForm(UserModel model)
        {
            InitializeComponent();
            loggedUser = model;
            searchTypeDropDown.DataSource = service.FillListOfSearchTypes();
        }


        //Fill listbox of read books with user data
        private void WireUpList(List<BookModel> foundBooks)
        {
            foundBooksListBox.DataSource = null;
            foundBooksListBox.DataSource = foundBooks;
            foundBooksListBox.DisplayMember = "Title";
        }

        //Refresh description panel with detail of highlight book
        private void UpdateBookDescriptionPanel()
        {
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
            //Refresh the list
            WireUpList(service.SearchForBooks(searchTypeDropDown.SelectedItem.ToString(), searchValue.Text));
        }

        private void foundBooksListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateBookDescriptionPanel();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            ChooseBookForm frm = new ChooseBookForm(loggedUser);
            frm.Show();
            this.Close();
        }

        private void toReadButton_Click(object sender, EventArgs e)
        {
            try
            {
                service.AddBookToUserToReadBookshelf(ref loggedUser, (BookModel)foundBooksListBox.SelectedItem);
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
    }
}

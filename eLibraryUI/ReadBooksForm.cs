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
using eLibraryClasses.Interfaces;
using eLibraryClasses.Models;
using eLibraryClasses.Services;

namespace eLibraryUI
{
    public partial class ReadBooksForm : Form
    {
        private UserModel loggedUser;

        public ReadBooksForm(UserModel model, IReadBooksService service)
        {
            InitializeComponent();
            loggedUser = model;
            WireUpList();
            quotationLabel.Text = service.RandomizeAndReturnQuote();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            LibraryWelcomeForm frm = new LibraryWelcomeForm(loggedUser, new LibraryWelcomeService());
            frm.Show();
            this.Close();
        }

        private void booksToReadButton_Click(object sender, EventArgs e)
        {
            ToReadForm frm = new ToReadForm(loggedUser, new ToReadService());
            frm.Show();
            this.Close();
        }

        //Fill listbox of read books with user data
        private void WireUpList()
        {
            readBooksListBox.DataSource = null;
            readBooksListBox.DataSource = loggedUser.ReadBooks;
            readBooksListBox.DisplayMember = "Title";
        }

        private void UpdateBookDescriptionPanel()
        {
            BookModel descriptionPanelBook = (BookModel)readBooksListBox.SelectedItem;

            if (descriptionPanelBook != null)
            {
                authorLabel.Text = descriptionPanelBook.Author;
                titleLabel.Text = descriptionPanelBook.Title;
                genreLabel.Text = descriptionPanelBook.Genre;
                bookDescriptionLabel.Text = descriptionPanelBook.Description;
            }
        }

        private void readBooksListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //When selected item is changed, update labels in book description panel
            UpdateBookDescriptionPanel();
        }

        private void favoriteAuthorsButton_Click(object sender, EventArgs e)
        {
            FavoriteAuthorsForm frm = new FavoriteAuthorsForm(loggedUser, new FavoriteAuthorsService());
            frm.Show();
        }
        private void bookDescriptionLabel_Click(object sender, EventArgs e)
        {
            MessageBox.Show(bookDescriptionLabel.Text);
        }
    }
}

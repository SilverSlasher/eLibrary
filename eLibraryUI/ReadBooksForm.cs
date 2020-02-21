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
using eLibraryClasses.UserInterfaceServices;

namespace eLibraryUI
{
    public partial class ReadBooksForm : Form
    {
        private ReadBooksService service = new ReadBooksService();

        //Create new local UserModel to store logged user data got from form closed before
        private UserModel loggedUser;
        

        public ReadBooksForm(UserModel model)
        {
            InitializeComponent();
            loggedUser = model;
            //Fill listbox of read books with user data
            WireUpList();
            //Randomize order of list of quotes and change text of label to quote
            quotationLabel.Text = service.RandomizeAndReturnQuote();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            LibraryWelcomeForm frm = new LibraryWelcomeForm(loggedUser);
            frm.Show();
            this.Close();
        }

        private void booksToReadButton_Click(object sender, EventArgs e)
        {
            ToReadForm frm = new ToReadForm(loggedUser);
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

        //Refresh description panel with detail of highlight book
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
            FavoriteAuthorsForm frm = new FavoriteAuthorsForm(loggedUser);
            frm.Show();
        }
        private void bookDescriptionLabel_Click(object sender, EventArgs e)
        {
            MessageBox.Show(bookDescriptionLabel.Text);
        }
    }
}

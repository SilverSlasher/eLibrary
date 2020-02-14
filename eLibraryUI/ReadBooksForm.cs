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
    public partial class ReadBooksForm : Form
    {
        //Create new local UserModel to store logged user data got from form closed before
        private UserModel loggedUser = new UserModel();
        //Create a list of quotes and fill it from file .txt
        private List<string> quotes = GlobalConfig.QuotesFile.FullFilePath().LoadFile().ConvertToQuoteModels();

        public ReadBooksForm(UserModel model)
        {
            InitializeComponent();
            //Save active user data to local variable 
            loggedUser = model;
            //Fill listbox of read books with user data
            WireUpList();
            //Randomize order of list of quotes and change text of label to quote
            RandomizeAndWriteQuote();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            //Create a new form, and send logged user data
            LibraryWelcomeForm frm = new LibraryWelcomeForm(loggedUser);
            //Show a created form
            frm.Show();
            //Close current form
            this.Close();
        }

        private void booksToReadButton_Click(object sender, EventArgs e)
        {
            //Create a new form, and send logged user data
            ToReadForm frm = new ToReadForm(loggedUser);
            //Show a created form
            frm.Show();
            //Close current form
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
            //Store selected item from list box, to local variable
            BookModel descriptionPanelBook = (BookModel)readBooksListBox.SelectedItem;

            //If any item on listbox is selected
            if (descriptionPanelBook != null)
            {
                //Change following labels
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
            //Create a new form, and send logged user data
            FavoriteAuthorsForm frm = new FavoriteAuthorsForm(loggedUser);
            //Show a created form
            frm.Show();
        }

        //Randomize order of list of quotes and change text of label to quote
        private void RandomizeAndWriteQuote()
        {
            quotes = quotes.OrderBy(o => Guid.NewGuid()).ToList();
            quotationLabel.Text = quotes[0];
        }

        private void bookDescriptionLabel_Click(object sender, EventArgs e)
        {
            MessageBox.Show(bookDescriptionLabel.Text);
        }
    }
}

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
    public partial class RandomBookForm : Form
    {
        //Create new local UserModel to store logged user data got from form closed before
        private UserModel loggedUser = new UserModel();

        //Create a list of book models and fill it from file .txt
        private List<BookModel> allBooks = GlobalConfig.Connection.GetBook_All();

        //Create a new list of books, which will be able to randomize
        private List<BookModel> availableBooks = new List<BookModel>();

        //Variable to store index of selected button
        private int buttonClicked;

        //Check if the book is already added by user to bookshelf
        private bool isAdded = false;

        public RandomBookForm(UserModel model)
        {
            InitializeComponent();
            //Save active user data to local variable 
            loggedUser = model;
            //Save all books not read or selected "to read" to the variable
            availableBooks = booksNotUsedBefore(allBooks);
            //Randomize all available books
            availableBooks = availableBooks.OrderBy(o => Guid.NewGuid()).ToList();
            //Assign randomized books to buttons
            WriteDownRandomizedBooks(availableBooks);
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

        private void randomBook1Button_Click(object sender, EventArgs e)
        {
            //Not clicked buttons are disabled.
            BlockRestOfTheButtons(randomBook2Button,randomBook3Button,randomBook4Button,randomBook5Button,randomBook6Button);
            //Hide button which cover answer
            randomBook1Button.Visible = false;
            //Add option to add randomized book to "To read" bookshelf
            toReadButton.Visible = true;
            //Return index of clicked button
            buttonClicked = 1;
        }

        private void randomBook2Button_Click(object sender, EventArgs e)
        {
            //Not clicked buttons are disabled.
            BlockRestOfTheButtons(randomBook1Button, randomBook3Button, randomBook4Button, randomBook5Button, randomBook6Button);
            //Hide button which cover answer
            randomBook2Button.Visible = false;
            //Add option to add randomized book to "To read" bookshelf
            toReadButton.Visible = true;
            //Return index of clicked button
            buttonClicked = 2;
        }

        private void randomBook3Button_Click(object sender, EventArgs e)
        {
            //Not clicked buttons are disabled.
            BlockRestOfTheButtons(randomBook1Button, randomBook2Button, randomBook4Button, randomBook5Button, randomBook6Button);
            //Hide button which cover answer
            randomBook3Button.Visible = false;
            //Add option to add randomized book to "To read" bookshelf
            toReadButton.Visible = true;
            //Return index of clicked button
            buttonClicked = 3;
        }

        private void randomBook4Button_Click(object sender, EventArgs e)
        {
            //Not clicked buttons are disabled.
            BlockRestOfTheButtons(randomBook1Button, randomBook2Button, randomBook3Button, randomBook5Button, randomBook6Button);
            //Hide button which cover answer
            randomBook4Button.Visible = false;
            //Add option to add randomized book to "To read" bookshelf
            toReadButton.Visible = true;
            //Return index of clicked button
            buttonClicked = 4;
        }

        private void randomBook5Button_Click(object sender, EventArgs e)
        {
            //Not clicked buttons are disabled.
            BlockRestOfTheButtons(randomBook1Button, randomBook2Button, randomBook3Button, randomBook4Button, randomBook6Button);
            //Hide button which cover answer
            randomBook5Button.Visible = false;
            //Add option to add randomized book to "To read" bookshelf
            toReadButton.Visible = true;
            //Return index of clicked button
            buttonClicked = 5;
        }

        private void randomBook6Button_Click(object sender, EventArgs e)
        {
            //Not clicked buttons are disabled.
            BlockRestOfTheButtons(randomBook1Button, randomBook2Button, randomBook3Button, randomBook4Button, randomBook5Button);
            //Hide button which cover answer
            randomBook6Button.Visible = false;
            //Add option to add randomized book to "To read" bookshelf
            toReadButton.Visible = true;
            //Return index of clicked button
            buttonClicked = 6;
        }

        //When 1 button is clicked by user, rest of buttons will be not available anymore
        private void BlockRestOfTheButtons(Button button1, Button button2, Button button3, Button button4, Button button5)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
        }

        //Getting list of books which user didn't read (and didn't add to "To read" bookshelf) before
        private List<BookModel> booksNotUsedBefore(List<BookModel> _allBooks)
        {
            //Create a new temporary list of books
            List<BookModel> output = new List<BookModel>();
            //A variable to store books which user read before, or put to "to read" bookshelf
            List<BookModel> userUsedBooks = new List<BookModel>();
            //A temporary list of books which are not correct to be matched
            List<BookModel> booksToDelete = new List<BookModel>();

            //If any of user list is not created. Create a new list
            ValidateNulls();

            //Add every of user read books to temporary list
            foreach (BookModel book in loggedUser.ReadBooks)
            {
                userUsedBooks.Add(book);
            }

            //Add every of user to read books to same temporary list
            foreach (BookModel book in loggedUser.ToReadBooks)
            {
                userUsedBooks.Add(book);
            }

            //Compare every book read or selected "to read" by user to every book available in eLibrary
            for (int i = 0; i < userUsedBooks.Count ; i++)
            {
                //Take books read by user one by one 
                BookModel singleBook = userUsedBooks.ElementAt(i);

                //Compare books. If they matched, add them to list of books to delete
                foreach (BookModel book in _allBooks)
                {
                    if (singleBook.Id == book.Id)
                    {
                        booksToDelete.Add(book);
                    }
                }

                //Delete all books which cannot be randomized
                foreach (BookModel book in booksToDelete)
                {
                    _allBooks.Remove(book);
                }
            }

            output = _allBooks;
            return output;

        }

        //Validate if lists are created before, if not, create a new ones
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

        //Assign randomized books to buttons
        private void WriteDownRandomizedBooks(List<BookModel> _availableBooks)
        {
            author1Label.Text = _availableBooks.ElementAt(0).Author;
            title1Label.Text = _availableBooks.ElementAt(0).Title;
            genre1Label.Text = _availableBooks.ElementAt(0).Genre;

            author2Label.Text = _availableBooks.ElementAt(1).Author;
            title2Label.Text = _availableBooks.ElementAt(1).Title;
            genre2Label.Text = _availableBooks.ElementAt(1).Genre;

            author3Label.Text = _availableBooks.ElementAt(2).Author;
            title3Label.Text = _availableBooks.ElementAt(2).Title;
            genre3Label.Text = _availableBooks.ElementAt(2).Genre;

            author4Label.Text = _availableBooks.ElementAt(3).Author;
            title4Label.Text = _availableBooks.ElementAt(3).Title;
            genre4Label.Text = _availableBooks.ElementAt(3).Genre;

            author5Label.Text = _availableBooks.ElementAt(4).Author;
            title5Label.Text = _availableBooks.ElementAt(4).Title;
            genre5Label.Text = _availableBooks.ElementAt(4).Genre;

            author6Label.Text = _availableBooks.ElementAt(5).Author;
            title6Label.Text = _availableBooks.ElementAt(5).Title;
            genre6Label.Text = _availableBooks.ElementAt(5).Genre;
        }

        //Add randomized book to user "To read" bookshelf
        private void toReadButton_Click(object sender, EventArgs e)
        {
            //Check if user didn't add this book a moment ago
            if (!isAdded)
            {
                //Button starts from 1, and list index start at 0 so right book is clicked button number - 1 )
                loggedUser.ToReadBooks.Add(availableBooks.ElementAt(buttonClicked - 1));
                //Save user data to file
                FileConnectorCore.UpdateDataOfLoggedUser(loggedUser).SaveToUsersFile();
                //Set a flag, that user added the book to bookshelf already
                isAdded = true;
            }
            else
            {
                //If the book is added, show a message box
                MessageBox.Show("Dodałeś już tę książkę do swojego zbioru!");
            }

        }
    }
}

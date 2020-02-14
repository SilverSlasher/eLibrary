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
    public partial class LibraryWelcomeForm : Form
    {
        //Create new local UserModel to store logged user data got from form closed before
        private UserModel loggedUser = new UserModel();

        //Create a list of book models and fill it from file .txt
        private List<BookModel> allBooks = GlobalConfig.Connection.GetBook_All();

        //Variable use to store max Id of available books
        private int maxBookId;

        public LibraryWelcomeForm(UserModel model)
        {
            InitializeComponent();
            //Save active user data to local variable 
            loggedUser = model;
            //Personalize welcome form with users first name
            firstNameLabel.Text = loggedUser.FirstName;
            //Find max Id from all books and save it to variable
            maxBookId = FindMaxBookId();
            //If there is a new book of users favorite authors, send a notification
            NewBookNotification();
            //If user is notificated about new book, update his data to prevent sending notification about same book in the future
            UpdateUserInfo(maxBookId);
        }

        private void readBooksButton_Click(object sender, EventArgs e)
        {
            //Create a new form, and send logged user data
            ReadBooksForm frm = new ReadBooksForm(loggedUser);
            //Show a created form
            frm.Show();
            //Close current form
            this.Close();
        }

        private void chooseBookButton_Click(object sender, EventArgs e)
        {
            //Create a new form, and send logged user data
            ChooseBookForm frm = new ChooseBookForm(loggedUser);
            //Show a created form
            frm.Show();
            //Close current form
            this.Close();
        }

        private void addNewBookButton_Click(object sender, EventArgs e)
        {
            //Create a new form, and send logged user data
            AddNewBookForm frm = new AddNewBookForm(loggedUser);
            //Show a created form
            frm.Show();
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            //Show a message box to confirm willingness of exit
            DialogResult decision = MessageBox.Show("Czy na pewno chcesz wyłączyć?", "Uwaga", MessageBoxButtons.YesNo);

            if (decision == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        //Find the max Id from all available books took from file .txt
        private int FindMaxBookId()
        {
            if (allBooks.Count > 0)
            {
                return allBooks.OrderByDescending(x => x.Id).First().Id;
            }

            return 0;
        }
        //Compare user data with data of all books, and return if there are any new book of subscribed authors
        private bool VerifyNewBookOfSubscribed(int _maxBookId, int lastLoggedUserInfo)
        {
            //If max Id of current book list is higher then max Id of list of books in last login of user 
            if (_maxBookId > lastLoggedUserInfo)
            {
                //Make a range of new books (count how many books were added)
                int range = _maxBookId - lastLoggedUserInfo;

                //If list of favorite authors of user is not created
                if (loggedUser.FavoriteAuthors == null)
                {
                    //Create a new list of favorite authors (prevent from null error)
                    loggedUser.FavoriteAuthors = new List<string>();
                }

                //Take every book, which was added after last login of user (from max book Id of last login of user, to current max book Id)
                foreach (BookModel book in allBooks.GetRange(lastLoggedUserInfo, range))
                {
                    //For every single author in user favorite authors list
                    for (int i = 0; i < loggedUser.FavoriteAuthors.Count; i++)
                    {
                        //Check if the author is same as new book author
                        if (book.Author == loggedUser.FavoriteAuthors[i])
                        {
                            //If author of the new book is same as user favorite authors, return true (New book of favorite author was added during offline)
                            return true;
                        }
                    }
                }
            }

            //If there are no new books, or authors of new books are not in user favorite authors list, return false
            return false;
        }

        //Send to user notification about new book of his favorite author in library
        private void NewBookNotification()
        {
            //If verification was successful, send a message box to user
            if (VerifyNewBookOfSubscribed(maxBookId, loggedUser.LastLoggedInfo))
            {
                MessageBox.Show("Pojawiła się w bazie nowa książka Twojego ulubionego autora!");
            }
        }

        //Update user data with current max Id of available books in library
        private void UpdateUserInfo(int _maxBookId)
        {
            //Save to user data a variable of max Id of books
            loggedUser.LastLoggedInfo = _maxBookId;
            //Update user info to userfile .txt
            FileConnectorCore.UpdateDataOfLoggedUser(loggedUser).SaveToUsersFile();
        }

        private void statisticsButton_Click(object sender, EventArgs e)
        {
            //Create a new form, and send logged user data
            StatisticsForm frm = new StatisticsForm(loggedUser);
            //Show a created form
            frm.Show();
            //Close current form
            this.Close();
        }

    }
}

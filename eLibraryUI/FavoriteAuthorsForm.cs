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
    public partial class FavoriteAuthorsForm : Form
    {
        //Create new local UserModel to store logged user data got from form closed before
        private UserModel loggedUser = new UserModel();

        //Create a list of book models and fill it from file .txt
        private List<BookModel> allBooks = GlobalConfig.Connection.GetBook_All();

        //Create an empty list of authors
        private List<string> allAuthors = new List<string>();

        public FavoriteAuthorsForm(UserModel model)
        {
            InitializeComponent();
            //Save active user data to local variable 
            loggedUser = model;
            //Fill in all authors existing in books
            FillAvailableAuthors();
            //Wire up dropdowns with data from user and all authors
            WireUpAuthors();
            //Checking if user is already subscribing favorite authors 
            SettingUpCheckBox();
        }

        //Wire up dropdowns with data from user and all authors
        private void WireUpAuthors()
        {
            favoriteAuthorsDropDown.DataSource = null;
            //Assign to dropdown with favorite authors of user
            favoriteAuthorsDropDown.DataSource = loggedUser.FavoriteAuthors;

            addFavoriteAuthorDropDown.DataSource = null;
            //Assign to dropdown with all existing authors
            addFavoriteAuthorDropDown.DataSource = allAuthors;
        }

        //Fill in all authors existing in books
        private void FillAvailableAuthors()
        {
            //Take every single available book one by one
            foreach (BookModel book in allBooks)
            {
                //If the author was not appeared before, add author to list of authors
                if (!allAuthors.Contains(book.Author))
                {
                    allAuthors.Add(book.Author);
                }
            }
        }

        private void addAuthorButton_Click(object sender, EventArgs e)
        {
            //If list of users favorite authors is not created before, create a new one
            if (loggedUser.FavoriteAuthors == null)
            {
                loggedUser.FavoriteAuthors = new List<string>();
            }

            //Check if the authors which user is trying to add to favorite, is already existing in users favorite authors list
            if (!validateExisting(loggedUser.FavoriteAuthors, (string)addFavoriteAuthorDropDown.SelectedItem))
            {
                //If author doesn't exist. Add author to users favorite authors list
                loggedUser.FavoriteAuthors.Add((string)addFavoriteAuthorDropDown.SelectedItem);
                //Update user info to userfile .txt
                FileConnectorCore.UpdateDataOfLoggedUser(loggedUser).SaveToUsersFile();
                //Update dropdowns because of new author in user list
                WireUpAuthors();
            }
            else
            {
                //Inform user about existing of this author in user favorite author list
                MessageBox.Show("Autor znajduje się na liście ulubionych!");
            }
        }

        //Check if the authors is already in users favorite authors list
        private bool validateExisting(List<string> favoriteAuthors, string selectedItem)
        {
            //Setting the output to normally false
            bool output = false;

            //Take every single available author from favorite authors of user - one by one
            foreach (string author in favoriteAuthors)
            {
                //If user has already authors in users favorite authors list, set existing to true
                if (author == selectedItem)
                {
                    output = true;
                }
            }

            //Return value of output
            return output;
        }

        private void deleteAuthorButton_Click(object sender, EventArgs e)
        {
            //Check if there are any favorite authors in user "favorite authors list"
            if (!loggedUser.FavoriteAuthors.Any())
            {
                //If there are no favorite authors, inform user
                MessageBox.Show("Brak ulubionych autorów możliwych do usunięcia!");
                return;
            }

            //If there is any selected authors in the list
            if (favoriteAuthorsDropDown.SelectedItem != null)
            {
                //Delete from user list this one specified author
                loggedUser.FavoriteAuthors.Remove((string)favoriteAuthorsDropDown.SelectedItem);
                //Update user info to userfile .txt
                FileConnectorCore.UpdateDataOfLoggedUser(loggedUser).SaveToUsersFile();
                //Update dropdowns because of new author in user list
                WireUpAuthors();
                //If there are more authors on the list, take a focus on first
                if (loggedUser.FavoriteAuthors.Any())
                {
                    favoriteAuthorsDropDown.SelectedIndex = 0;
                }
            }

        }

        private void subscriptionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //If user selected checkbox, and new state is true
            if (subscriptionCheckBox.Checked == true)
            {
                //Set user value of subscribing to true
                loggedUser.IsSubscribing = true;
            }
            //If user unselected checkbox, and new state is false
            else if (subscriptionCheckBox.Checked == false)
            {
                //Set user value of subscribing to false
                loggedUser.IsSubscribing = false;
            }
            //Update user info to userfile .txt
            FileConnectorCore.UpdateDataOfLoggedUser(loggedUser).SaveToUsersFile();
        }

        //Checking if user is already subscribing favorite authors 
        private void SettingUpCheckBox()
        {
            //If user is already subscribing, select checkbox
            if (loggedUser.IsSubscribing)
            {
                subscriptionCheckBox.Checked = true;
            }
        }
    }
}

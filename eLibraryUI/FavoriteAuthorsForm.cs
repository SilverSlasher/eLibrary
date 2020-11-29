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
    public partial class FavoriteAuthorsForm : Form
    {
        private FavoriteAuthorsService service = new FavoriteAuthorsService();

        private UserModel loggedUser;


        public FavoriteAuthorsForm(UserModel model)
        {
            InitializeComponent();
            loggedUser = model;
            WireUpAuthors();
            //Checking if user is already subscribing favorite authors 
            service.SettingUpCheckBox(subscriptionCheckBox.Checked, loggedUser);
        }

        //Wire up dropdowns with data from user and all authors
        private void WireUpAuthors()
        {
            favoriteAuthorsDropDown.DataSource = null;
            favoriteAuthorsDropDown.DataSource = loggedUser.FavoriteAuthors;

            addFavoriteAuthorDropDown.DataSource = null;
            addFavoriteAuthorDropDown.DataSource = service.AvailableAuthors();
        }

        private void addAuthorButton_Click(object sender, EventArgs e)
        {
            try
            {
                service.AddAuthorToUserFavoriteList(loggedUser, (string)addFavoriteAuthorDropDown.SelectedItem);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return;
            }
            
            //Update dropdowns because of new author in user list
            WireUpAuthors();
        }

        private void deleteAuthorButton_Click(object sender, EventArgs e)
        {
            try
            {
                service.DeleteAuthorFromUserFavoriteList(loggedUser, (string)favoriteAuthorsDropDown.SelectedItem);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return;
            }

            //Update dropdowns because of deleted author in user list
            WireUpAuthors();

            //If are there more authors on the list, take a focus on first
            FocusFirstAuthorOnDropDown();
        }

        private void subscriptionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            service.SettingUpSubscription(subscriptionCheckBox.Checked,loggedUser);
        }

        //If there are more authors on the list, take a focus on first
        public void FocusFirstAuthorOnDropDown()
        {
            if (loggedUser.FavoriteAuthors.Any())
            {
                favoriteAuthorsDropDown.SelectedIndex = 0;
            }
        }

    }
}


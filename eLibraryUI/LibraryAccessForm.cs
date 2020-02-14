using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using eLibraryClasses;
using eLibraryClasses.DataAccess;
using eLibraryClasses.Models;

namespace eLibraryUI
{
    public partial class LibraryAccessForm : Form
    {

        public LibraryAccessForm()
        {
            InitializeComponent();
        }

        private void createAccountLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Create a new form of creating new user
            CreateUserForm frm = new CreateUserForm();
            //Show a created form
            frm.Show();
        }

        private void reminderAccountLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Create a new form of reminding of user data
            RemindAccountForm frm = new RemindAccountForm();
            //Show a created form
            frm.Show();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            //Check if user wrote any username
            bool isUserNameWritten = userNameValue.Text.Length > 0;
            //Check if user wrote any password
            bool isPasswordWritten = passwordValue.Text.Length > 0;
            //Setting the variable to normally false
            bool isUserFound = false;

            if (isUserNameWritten == false)
            {
                //If there are no username wrote, inform user about mistake
                MessageBox.Show("Nie wprowadzono nazwy użytkownika");
                return;
            }
            else if (isPasswordWritten == false)
            {
                //If there are no password wrote, inform user about mistake
                MessageBox.Show("Nie wprowadzono hasła");
                return;
            }

            //If user wrote down any username and password
            if (isUserNameWritten && isPasswordWritten)
            {
                //Create a new list of user models, and fill it with all users got from file .txt
                List<UserModel> users = GlobalConfig.UsersFile.FullFilePath().LoadFile().ConvertToUserModels();

                //Write down username wrote by user to variable
                string requestUserName = userNameValue.Text;
                //Write down password wrote by user to variable
                string requestPassword = passwordValue.Text;

                //Take every single available user one by one
                foreach (UserModel user in users)
                {
                    //Look if are there username in text file with all users
                    if (requestUserName == user.UserName)
                    {
                        //If username is found, set variable to true
                        isUserFound = true;

                        //Check if password wrote down by user is same as password connected to username in textfile
                        if (passwordValue.Text == user.Password)
                        {
                            //If everything gone good, create welcome form
                            LibraryWelcomeForm frm = new LibraryWelcomeForm(user);
                            //Show a created form
                            frm.Show();
                            //Hide current form (it's a main form of application, so it shouldn't be closed)
                            this.Hide();
                        }
                        else
                        {
                            //If passwords are not same, inform user about mistake
                            MessageBox.Show("Wprowadzone hasło jest nieprawidłowe");
                        }
                    }
                }
                //If there are same username found in text file, inform user about mistake
                if (isUserFound == false)
                {
                    MessageBox.Show("Nie znaleziono takiego użytkownika w bazie");
                }
            }
        }

        private void userNameValue_MouseClick(object sender, MouseEventArgs e)
        {
            //Clear user name text after click
            userNameValue.Text = "";
        }

        private void passwordValue_MouseClick(object sender, MouseEventArgs e)
        {
            //Clear password text after click
            passwordValue.Text = "";
        }

    }
}

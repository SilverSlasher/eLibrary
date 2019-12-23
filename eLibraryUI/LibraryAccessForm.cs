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
    public partial class LibraryAccessForm : Form
    {

        public LibraryAccessForm()
        {
            InitializeComponent();
        }

        private void LibraryAccessForm_Load(object sender, EventArgs e)
        {

        }

        private void createAccountLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateUserForm frm = new CreateUserForm();
            frm.Show();
        }

        private void reminderAccountLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RemindAccountForm frm = new RemindAccountForm();
            frm.Show();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            bool isUserNameWritten = userNameValue.Text.Length > 0;
            bool isPasswordWritten = passwordValue.Text.Length > 0;
            bool isUserFound = false;

            if (isUserNameWritten == false)
            {
                MessageBox.Show("Nie wprowadzono nazwy użytkownika");
                return;
            }
            else if (isPasswordWritten == false)
            {
                MessageBox.Show("Nie wprowadzono hasła");
                return;
            }

            if (isUserNameWritten && isPasswordWritten)
            {
                List<UserModel> users = GlobalConfig.UsersFile.FullFilePath().LoadFile().ConvertToUserModels();

                string requestUserName = userNameValue.Text;

                string requestPassword = passwordValue.Text;

                foreach (UserModel user in users)
                {
                    if (requestUserName == user.UserName)
                    {
                        isUserFound = true;
                        if (passwordValue.Text == user.Password)
                        {
                            LibraryWelcomeForm frm = new LibraryWelcomeForm(user);
                            frm.Show();
                        }
                        else
                        {
                            MessageBox.Show("Wprowadzone hasło jest nieprawidłowe");
                        }
                    }
                }
                if (isUserFound == false)
                {
                    MessageBox.Show("Nie znaleziono takiego użytkownika w bazie");
                    return;
                }
            }
        }

        private void userNameValue_MouseClick(object sender, MouseEventArgs e)
        {
            userNameValue.Text = "";
        }

        private void passwordValue_MouseClick(object sender, MouseEventArgs e)
        {
            passwordValue.Text = "";
        }

    }
}

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
using eLibraryClasses.UserInterfaceServices;

namespace eLibraryUI
{
    public partial class LibraryAccessForm : Form
    {
        private LibraryAccessService service;

        public LibraryAccessForm(LibraryAccessService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void createAccountLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateUserForm frm = new CreateUserForm(new CreateUserService());
            frm.Show();
        }

        private void reminderAccountLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RemindAccountForm frm = new RemindAccountForm(new RemindAccountService());
            frm.Show();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            try
            {
                LibraryWelcomeForm frm = new LibraryWelcomeForm(service.UserLoginIn(userNameValue.Text,passwordValue.Text), new LibraryWelcomeService());
                frm.Show();
                this.Hide();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
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

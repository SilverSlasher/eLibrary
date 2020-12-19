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
    public partial class CreateUserForm : Form
    {
        private ICreateUserService service;

        public CreateUserForm(ICreateUserService service)
        {
            this.service = service;
            InitializeComponent();
        }

        private void addUserButton_Click(object sender, EventArgs e)
        {
            try
            {
                service.ValidateForm(
                    userNameValue.Text,
                    passwordValue.Text,
                    repeatPasswordValue.Text,
                    firstNameValue.Text,
                    lastNameValue.Text,
                    emailValue.Text
                    );
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return;
            }

            service.PrepareNewUser(firstNameValue.Text, lastNameValue.Text, userNameValue.Text, passwordValue.Text, emailValue.Text);
            this.Close();
            MessageBox.Show("Pomyślnie utworzono konto!");

        }

        private void backButton_Click(object sender, EventArgs e)
        {
            LibraryAccessForm frm = new LibraryAccessForm(new LibraryAccessService());
            frm.Show();
            this.Close();
        }
    }
}

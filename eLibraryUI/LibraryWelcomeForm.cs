using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eLibraryClasses.Models;

namespace eLibraryUI
{
    public partial class LibraryWelcomeForm : Form
    {
        public LibraryWelcomeForm(UserModel model)
        {
            InitializeComponent();
            UserModel loggedUser = model;
            firstNameLabel.Text = loggedUser.FirstName;
        }

        private void readBooksButton_Click(object sender, EventArgs e)
        {
            ReadBooksForm frm = new ReadBooksForm();
            frm.Show();
        }

        private void chooseBookButton_Click(object sender, EventArgs e)
        {

        }

        private void addNewBookButton_Click(object sender, EventArgs e)
        {
            AddNewBookForm frm = new AddNewBookForm();
            frm.Show();
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            DialogResult decision = MessageBox.Show("Czy na pewno chcesz wyłączyć?", "Uwaga", MessageBoxButtons.YesNo);
            if (decision == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}

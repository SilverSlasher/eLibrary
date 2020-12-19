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
    public partial class LibraryWelcomeForm : Form
    {
        private ILibraryWelcomeService service;

        private UserModel loggedUser;


        public LibraryWelcomeForm(UserModel model, ILibraryWelcomeService service)
        {
            InitializeComponent();
            loggedUser = model;
            this.service = service;
            firstNameLabel.Text = loggedUser.FirstName;
            //If there is a new book of users favorite authors, send a notification
            service.NewBookNotification(loggedUser);
            //If user is notificated about new book, update his data to prevent sending notification about same book in the future
            service.UpdateUserInfo(ref loggedUser);
        }

        private void readBooksButton_Click(object sender, EventArgs e)
        {
            ReadBooksForm frm = new ReadBooksForm(loggedUser, new ReadBooksService());
            frm.Show();
            this.Close();
        }

        private void chooseBookButton_Click(object sender, EventArgs e)
        {
            ChooseBookForm frm = new ChooseBookForm(loggedUser);
            frm.Show();
            this.Close();
        }

        private void addNewBookButton_Click(object sender, EventArgs e)
        {
            AddNewBookForm frm = new AddNewBookForm(loggedUser, new AddNewBookService());
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

        private void statisticsButton_Click(object sender, EventArgs e)
        {
            StatisticsForm frm = new StatisticsForm(loggedUser, new StatisticsService());
            frm.Show();
            this.Close();
        }

    }
}

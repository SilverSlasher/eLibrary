﻿using System;
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
    public partial class LibraryWelcomeForm : Form
    {
        private LibraryWelcomeService service = new LibraryWelcomeService();

        //Create new local UserModel to store logged user data got from form closed before
        private UserModel loggedUser;


        public LibraryWelcomeForm(UserModel model)
        {
            InitializeComponent();
            loggedUser = model;
            firstNameLabel.Text = loggedUser.FirstName;
            //If there is a new book of users favorite authors, send a notification
            service.NewBookNotification(loggedUser);
            //If user is notificated about new book, update his data to prevent sending notification about same book in the future
            service.UpdateUserInfo(ref loggedUser);
        }

        private void readBooksButton_Click(object sender, EventArgs e)
        {
            ReadBooksForm frm = new ReadBooksForm(loggedUser);
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
            AddNewBookForm frm = new AddNewBookForm(loggedUser);
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

        private void statisticsButton_Click(object sender, EventArgs e)
        {
            StatisticsForm frm = new StatisticsForm(loggedUser);
            frm.Show();
            this.Close();
        }

    }
}

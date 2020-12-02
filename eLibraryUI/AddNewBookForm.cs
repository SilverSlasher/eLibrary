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
    public partial class AddNewBookForm : Form
    {
        private AddNewBookService service;

        //Create new local UserModel to store logged user data got from form closed before
        private UserModel loggedUser;


        public AddNewBookForm(UserModel model, AddNewBookService service)
        {
            InitializeComponent();
            loggedUser = model;
            this.service = service;
            //Assign to dropdown with genres a list of predefined ones
            genreDropDown.DataSource = service.ListOfGenres();
        }



        private void addBookButton_Click(object sender, EventArgs e)
        {
            try
            {
                service.ValidateForm(authorValue.Text, titleValue.Text, pagesValue.Text);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return;
            }

            service.PrepareNewBook(
                authorValue.Text,
                titleValue.Text,
                pagesValue.Text,
                genreDropDown.SelectedItem.ToString(),
                descriptionValue.Text,
                loggedUser);

            this.Close();
            MessageBox.Show($"Poprawnie dodano książkę o tytule {titleValue.Text}");

        }
    }
}

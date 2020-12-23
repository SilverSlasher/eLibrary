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
using eLibraryClasses.UI_Forms_Logic.Interfaces;

namespace eLibraryUI
{
    public partial class AddNewBookForm : Form
    {
        private readonly IAddNewBookService _service;

        //Create new local UserModel to store logged user data got from form closed before
        private readonly UserModel _loggedUser;


        public AddNewBookForm(UserModel model, IAddNewBookService service)
        {
            InitializeComponent();
            _loggedUser = model;
            _service = service;
            //Assign to dropdown with genres a list of predefined ones
            genreDropDown.DataSource = service.ListOfGenres();
        }



        private void addBookButton_Click(object sender, EventArgs e)
        {
            try
            {
                _service.ValidateForm(authorValue.Text, titleValue.Text, pagesValue.Text);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return;
            }

            _service.PrepareNewBook(
                authorValue.Text,
                titleValue.Text,
                pagesValue.Text,
                genreDropDown.SelectedItem.ToString(),
                descriptionValue.Text,
                _loggedUser);

            this.Close();
            MessageBox.Show($"Poprawnie dodano książkę o tytule {titleValue.Text}");

        }
    }
}

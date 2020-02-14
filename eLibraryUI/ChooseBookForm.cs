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
    public partial class ChooseBookForm : Form
    {
        //Create new local UserModel to store logged user data got from form closed before
        private UserModel loggedUser = new UserModel();

        public ChooseBookForm(UserModel model)
        {
            InitializeComponent();
            //Save active user data to local variable 
            loggedUser = model;
        }

        private void searchBookButton_Click(object sender, EventArgs e)
        {
            //Create a new form, and send logged user data
            SearchBookForm frm = new SearchBookForm(loggedUser);
            //Show a created form
            frm.Show();
            //Close current form
            this.Close();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            //Create a new form, and send logged user data
            LibraryWelcomeForm frm = new LibraryWelcomeForm(loggedUser);
            //Show a created form
            frm.Show();
            //Close current form
            this.Close();
        }

        private void randomBook_Click(object sender, EventArgs e)
        {
            //Create a new form, and send logged user data
            RandomBookForm frm = new RandomBookForm(loggedUser);
            //Show a created form
            frm.Show();
            //Close current form
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Create a new form, and send logged user data
            QuizForm frm = new QuizForm(loggedUser);
            //Show a created form
            frm.Show();
            //Close current form
            this.Close();
        }
    }
}

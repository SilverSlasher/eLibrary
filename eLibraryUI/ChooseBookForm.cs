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
using eLibraryClasses.UserInterfaceServices;

namespace eLibraryUI
{
    public partial class ChooseBookForm : Form
    {
        private UserModel loggedUser;

        public ChooseBookForm(UserModel model)
        {
            InitializeComponent();
            loggedUser = model;
        }

        private void searchBookButton_Click(object sender, EventArgs e)
        {
            SearchBookForm frm = new SearchBookForm(loggedUser, new SearchBookService());
            frm.Show();
            this.Close();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            LibraryWelcomeForm frm = new LibraryWelcomeForm(loggedUser, new LibraryWelcomeService());
            frm.Show();
            this.Close();
        }

        private void randomBook_Click(object sender, EventArgs e)
        {
            RandomBookForm frm = new RandomBookForm(loggedUser, new RandomBookService(loggedUser));
            frm.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            QuizForm frm = new QuizForm(loggedUser, new QuizService());
            frm.Show();
            this.Close();
        }
    }
}

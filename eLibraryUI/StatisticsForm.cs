using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eLibraryClasses;
using eLibraryClasses.Models;
using eLibraryClasses.UserInterfaceServices;

namespace eLibraryUI
{
    public partial class StatisticsForm : Form
    {
        StatisticsService service = new StatisticsService();

        //Create new local UserModel to store logged user data got from form closed before
        private UserModel loggedUser;

        public StatisticsForm(UserModel model)
        {
            InitializeComponent();
            loggedUser = model;
            //Check if book lists of user are created. If not, create a new ones
            service.PreventNullError(ref loggedUser);
            //Write down values of user in the form
            WireUpStatistics();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            LibraryWelcomeForm frm = new LibraryWelcomeForm(loggedUser);
            frm.Show();
            this.Close();
        }

        private void WireUpStatistics()
        {
            readPagesLabel.Text = service.GetReadPages(loggedUser);

            toReadPagesLabel.Text = service.GetToReadPages(loggedUser);

            favoriteAuthorsLabel.Text = service.GetNumberOfFavoriteAuthors(loggedUser);

            favoriteGenreLabel.Text = service.GetFavoriteGenre(loggedUser);

        }
    }
}

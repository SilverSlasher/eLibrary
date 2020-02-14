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

namespace eLibraryUI
{
    public partial class StatisticsForm : Form
    {

        //Create new local UserModel to store logged user data got from form closed before
        private UserModel loggedUser = new UserModel();

        public StatisticsForm(UserModel model)
        {
            InitializeComponent();
            //Save active user data to local variable 
            loggedUser = model;
            //Check if book lists of user are created. If not, create a new ones
            ValidateNulls();
            //Write down values of user in the form
            WireUpStatistics();

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

        //Check if book lists of user are created. If not, create a new ones
        private void ValidateNulls()
        {
            if (loggedUser.ReadBooks == null)
            {
                loggedUser.ReadBooks = new List<BookModel>();
            }

            if (loggedUser.ToReadBooks == null)
            {
                loggedUser.ToReadBooks = new List<BookModel>();
            }

            if (loggedUser.FavoriteAuthors == null)
            {
                loggedUser.FavoriteAuthors = new List<string>();
            }
        }

        private void WireUpStatistics()
        {
            ImplementReadPages();

            ImplementToReadPages();

            ImplementFavoriteAuthors();

            ImplementFavoriteGenre();

        }

        //Get the number of summary pages of all books read by user, and write it down to form
        private void ImplementReadPages()
        {
            int numberOfReadPages = 0;

            foreach (BookModel book in loggedUser.ReadBooks)
            {
                numberOfReadPages += book.Pages;
            }

            //Write down number of pages
            readPagesLabel.Text = numberOfReadPages.ToString();
        }

        //Get the number of summary pages of all books selected to read by user, and write it down to form
        private void ImplementToReadPages()
        {
            int numberOfToReadPages = 0;

            foreach (BookModel book in loggedUser.ToReadBooks)
            {
                numberOfToReadPages += book.Pages;
            }

            //Write down number of pages
            toReadPagesLabel.Text = numberOfToReadPages.ToString();
        }

        //Get the number of favorite authors of user, and write it down to form
        private void ImplementFavoriteAuthors()
        {
            int numberOfFavoriteAuthors = 0;

            numberOfFavoriteAuthors = loggedUser.FavoriteAuthors.Count;

            //Write down number of favorite authors
            favoriteAuthorsLabel.Text = numberOfFavoriteAuthors.ToString();
        }

        private void ImplementFavoriteGenre()
        {
            //Create a new temporary list of all books read or to read by user
            List<BookModel> userAllBooks = new List<BookModel>();

            //Add to temporary list every book which user read
            foreach (BookModel book in loggedUser.ReadBooks)
            {
                userAllBooks.Add(book);
            }

            //Add to temporary list every book which user selected "to read"
            foreach (BookModel book in loggedUser.ToReadBooks)
            {
                userAllBooks.Add(book);
            }

            //Create a new structure
            genres genresCount = new genres();

            //Set all values to 0
            genresCount = SetStartingValuesOfGenres(genresCount);

            //Count the number of repetitions of each book genre
            foreach (BookModel book in userAllBooks)
            {
                switch (book.Genre)
                {
                    case "fantastyka":
                        genresCount.fantastyka++;
                        break;

                    case "horror":
                        genresCount.horror++;
                        break;

                    case "historyczna":
                        genresCount.historyczna++;
                        break;

                    case "inna":
                        genresCount.inna++;
                        break;

                    case "przygodowa":
                        genresCount.przygodowa++;
                        break;

                    case "kryminał":
                        genresCount.kryminał++;
                        break;
                }
            }

            //Get name of genre with highest value from structure, and assign it to label
            favoriteGenreLabel.Text = genresCount.GetType().GetFields().OrderByDescending(x => x.GetValue(genresCount)).First().Name;

            //If there are no books in user bookshelf, return "No info"
            if (loggedUser.ReadBooks.Count  == 0 && loggedUser.ToReadBooks.Count == 0)
            {
                favoriteGenreLabel.Text = "Brak info";
            }
        }

        //Create a new structure with all available genres
        public struct genres
        {
            public int fantastyka, horror, historyczna, inna, przygodowa, kryminał;
        }

        //Starting value to count of every genre is 0;
        public genres SetStartingValuesOfGenres(genres counter)
        {
            counter.fantastyka = 0;
            counter.horror = 0;
            counter.historyczna = 0;
            counter.inna = 0;
            counter.przygodowa = 0;
            counter.kryminał = 0;

            return counter;
        }

    }
}

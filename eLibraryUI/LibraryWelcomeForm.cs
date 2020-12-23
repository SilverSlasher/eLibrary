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
using eLibraryClasses.UI_Forms_Logic.Services;

namespace eLibraryUI
{
    public partial class LibraryWelcomeForm : Form
    {
        private readonly ILibraryWelcomeService _welcomeService;
        private readonly IReadBooksService _readBooksService;
        private readonly IAddNewBookService _newBookService;
        private readonly IStatisticsService _statisticsService;
        private readonly IToReadService _toReadService;
        private readonly IFavoriteAuthorsService _favoriteAuthorsService;
        private readonly IAddNewBookService _addNewBookService;
        private readonly ISearchBookService _searchBookService;
        private readonly IRandomBookService _randomBookService;
        private readonly IQuizService _quizService;

        private readonly UserModel _loggedUser;


        public LibraryWelcomeForm(UserModel model,
            ILibraryWelcomeService welcomeService,
            IReadBooksService readBooksService,
            IAddNewBookService newBookService,
            IStatisticsService statisticsService,
            IToReadService toReadService,
            IFavoriteAuthorsService favoriteAuthorsService,
            IAddNewBookService addNewBookService,
            ISearchBookService searchBookService,
            IRandomBookService randomBookService,
            IQuizService quizService)
        {
            InitializeComponent();
            _loggedUser = model;
            _welcomeService = welcomeService;
            _readBooksService = readBooksService;
            _newBookService = newBookService;
            _statisticsService = statisticsService;
            _toReadService = toReadService;
            _favoriteAuthorsService = favoriteAuthorsService;
            _addNewBookService = addNewBookService;
            _searchBookService = searchBookService;
            _randomBookService = randomBookService;
            _quizService = quizService;

            firstNameLabel.Text = _loggedUser.FirstName;
            //If there is a new book of users favorite authors, send a notification
            welcomeService.NewBookNotification(_loggedUser);
            //If user is notificated about new book, update his data to prevent sending notification about same book in the future
            welcomeService.UpdateUserInfo(_loggedUser);
        }

        private void readBooksButton_Click(object sender, EventArgs e)
        {
            ReadBooksForm frm = new ReadBooksForm(_loggedUser, _readBooksService, _welcomeService, _toReadService, _favoriteAuthorsService, _readBooksService, _addNewBookService, _statisticsService, _searchBookService, _randomBookService, _quizService);
            frm.Show();
            this.Close();
        }

        private void chooseBookButton_Click(object sender, EventArgs e)
        {
            ChooseBookForm frm = new ChooseBookForm(_loggedUser, _searchBookService, _welcomeService, _readBooksService, _randomBookService, _quizService, _addNewBookService, _statisticsService, _toReadService, _favoriteAuthorsService);
            frm.Show();
            this.Close();
        }

        private void addNewBookButton_Click(object sender, EventArgs e)
        {
            AddNewBookForm frm = new AddNewBookForm(_loggedUser, _newBookService);
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
            StatisticsForm frm = new StatisticsForm(_loggedUser, _statisticsService, _welcomeService, _readBooksService, _addNewBookService, _toReadService, _favoriteAuthorsService, _searchBookService, _randomBookService, _quizService);
            frm.Show();
            this.Close();
        }

    }
}

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
using eLibraryClasses.UI_Forms_Logic.Interfaces;
using eLibraryClasses.UI_Forms_Logic.Services;

namespace eLibraryUI
{
    public partial class StatisticsForm : Form
    {
        private readonly IStatisticsService _statisticsService;
        private readonly ILibraryWelcomeService _welcomeService;
        private readonly IReadBooksService _readBooksService;
        private readonly IAddNewBookService _addNewBookService;
        private readonly IToReadService _toReadService;
        private readonly IFavoriteAuthorsService _favoriteAuthorsService;
        private readonly ISearchBookService _searchBookService;
        private readonly IRandomBookService _randomBookService;
        private readonly IQuizService _quizService;
        private readonly UserModel _loggedUser;

        public StatisticsForm(UserModel model,
            IStatisticsService statisticsService,
            ILibraryWelcomeService welcomeService,
            IReadBooksService readBooksService,
            IAddNewBookService addNewBookService,
            IToReadService toReadService,
            IFavoriteAuthorsService favoriteAuthorsService,
            ISearchBookService searchBookService,
            IRandomBookService randomBookService,
            IQuizService quizService)
        {
            InitializeComponent();
            _statisticsService = statisticsService;
            _welcomeService = welcomeService;
            _readBooksService = readBooksService;
            _addNewBookService = addNewBookService;
            _toReadService = toReadService;
            _favoriteAuthorsService = favoriteAuthorsService;
            _searchBookService = searchBookService;
            _randomBookService = randomBookService;
            _quizService = quizService;
            _loggedUser = model;

            //Check if book lists of user are created. If not, create a new ones
            statisticsService.PreventNullError(_loggedUser);
            //Write down values of user in the form
            WireUpStatistics();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            LibraryWelcomeForm frm = new LibraryWelcomeForm(_loggedUser, _welcomeService, _readBooksService, _addNewBookService, _statisticsService, _toReadService, _favoriteAuthorsService, _addNewBookService, _searchBookService, _randomBookService, _quizService);
            frm.Show();
            this.Close();
        }

        private void WireUpStatistics()
        {
            readPagesLabel.Text = _statisticsService.GetReadPages(_loggedUser);

            toReadPagesLabel.Text = _statisticsService.GetToReadPages(_loggedUser);

            favoriteAuthorsLabel.Text = _statisticsService.GetNumberOfFavoriteAuthors(_loggedUser);

            favoriteGenreLabel.Text = _statisticsService.GetFavoriteGenre(_loggedUser);

        }
    }
}

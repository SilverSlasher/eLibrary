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
using eLibraryClasses.UI_Forms_Logic.Interfaces;
using eLibraryClasses.UI_Forms_Logic.Services;

namespace eLibraryUI
{
    public partial class ChooseBookForm : Form
    {
        private readonly UserModel _loggedUser;
        private readonly ISearchBookService _searchBookService;
        private readonly ILibraryWelcomeService _welcomeService;
        private readonly IReadBooksService _readBooksService;
        private readonly IRandomBookService _randomBookService;
        private readonly IQuizService _quizService;
        private readonly IAddNewBookService _addNewBookService;
        private readonly IStatisticsService _statisticsService;
        private readonly IToReadService _toReadService;
        private readonly IFavoriteAuthorsService _favoriteAuthorsService;

        public ChooseBookForm(UserModel model,
            ISearchBookService searchBookService,
            ILibraryWelcomeService welcomeService,
            IReadBooksService readBooksService,
            IRandomBookService randomBookService,
            IQuizService quizService,
            IAddNewBookService addNewBookService,
            IStatisticsService statisticsService,
            IToReadService toReadService,
            IFavoriteAuthorsService favoriteAuthorsService)
        {
            InitializeComponent();
            _loggedUser = model;
            _searchBookService = searchBookService;
            _welcomeService = welcomeService;
            _readBooksService = readBooksService;
            _randomBookService = randomBookService;
            _quizService = quizService;
            _addNewBookService = addNewBookService;
            _statisticsService = statisticsService;
            _toReadService = toReadService;
            _favoriteAuthorsService = favoriteAuthorsService;
        }

        private void searchBookButton_Click(object sender, EventArgs e)
        {
            SearchBookForm frm = new SearchBookForm(_loggedUser, _searchBookService, _welcomeService, _readBooksService, _randomBookService, _quizService, _addNewBookService, _statisticsService, _toReadService, _favoriteAuthorsService);
            frm.Show();
            this.Close();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            LibraryWelcomeForm frm = new LibraryWelcomeForm(_loggedUser, _welcomeService, _readBooksService, _addNewBookService, _statisticsService, _toReadService, _favoriteAuthorsService, _addNewBookService, _searchBookService, _randomBookService, _quizService);
            frm.Show();
            this.Close();
        }

        private void randomBook_Click(object sender, EventArgs e)
        {
            RandomBookForm frm = new RandomBookForm(_loggedUser, _randomBookService, _searchBookService, _welcomeService, _readBooksService, _quizService, _addNewBookService, _statisticsService, _toReadService, _favoriteAuthorsService);
            frm.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            QuizForm frm = new QuizForm(_loggedUser, _quizService, _searchBookService, _readBooksService, _welcomeService, _randomBookService, _quizService, _addNewBookService, _statisticsService, _toReadService, _favoriteAuthorsService);
            frm.Show();
            this.Close();
        }
    }
}

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
    public partial class ReadBooksForm : Form
    {
        private readonly UserModel _loggedUser;
        private readonly ILibraryWelcomeService _welcomeService;
        private readonly IToReadService _toReadService;
        private readonly IFavoriteAuthorsService _authorsService;
        private readonly IReadBooksService _readBooksService;
        private readonly IAddNewBookService _addNewBookService;
        private readonly IStatisticsService _statisticsService;
        private readonly ISearchBookService _searchBookService;
        private readonly IRandomBookService _randomBookService;
        private readonly IQuizService _quizService;

        public ReadBooksForm(UserModel model, 
            IReadBooksService service,
            ILibraryWelcomeService welcomeService,
            IToReadService toReadService,
            IFavoriteAuthorsService authorsService,
            IReadBooksService readBooksService,
            IAddNewBookService addNewBookService,
            IStatisticsService statisticsService,
            ISearchBookService searchBookService,
            IRandomBookService randomBookService,
            IQuizService quizService)
        {
            InitializeComponent();
            _loggedUser = model;
            _welcomeService = welcomeService;
            _toReadService = toReadService;
            _authorsService = authorsService;
            _readBooksService = readBooksService;
            _addNewBookService = addNewBookService;
            _statisticsService = statisticsService;
            _searchBookService = searchBookService;
            _randomBookService = randomBookService;
            _quizService = quizService;

            WireUpList();
            quotationLabel.Text = service.RandomizeAndReturnQuote();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            LibraryWelcomeForm frm = new LibraryWelcomeForm(_loggedUser, _welcomeService, _readBooksService, _addNewBookService, _statisticsService, _toReadService, _authorsService, _addNewBookService, _searchBookService, _randomBookService, _quizService);
            frm.Show();
            this.Close();
        }

        private void booksToReadButton_Click(object sender, EventArgs e)
        {
            ToReadForm frm = new ToReadForm(_loggedUser, _toReadService, _readBooksService, _welcomeService, _authorsService, _addNewBookService, _statisticsService, _searchBookService, _randomBookService, _quizService);
            frm.Show();
            this.Close();
        }

        //Fill listbox of read books with user data
        private void WireUpList()
        {
            readBooksListBox.DataSource = null;
            readBooksListBox.DataSource = _loggedUser.ReadBooks;
            readBooksListBox.DisplayMember = "Title";
        }

        private void UpdateBookDescriptionPanel()
        {
            BookModel descriptionPanelBook = (BookModel)readBooksListBox.SelectedItem;

            if (descriptionPanelBook != null)
            {
                authorLabel.Text = descriptionPanelBook.Author;
                titleLabel.Text = descriptionPanelBook.Title;
                genreLabel.Text = descriptionPanelBook.Genre;
                bookDescriptionLabel.Text = descriptionPanelBook.Description;
            }
        }

        private void readBooksListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //When selected item is changed, update labels in book description panel
            UpdateBookDescriptionPanel();
        }

        private void favoriteAuthorsButton_Click(object sender, EventArgs e)
        {
            FavoriteAuthorsForm frm = new FavoriteAuthorsForm(_loggedUser, _authorsService);
            frm.Show();
        }
        private void bookDescriptionLabel_Click(object sender, EventArgs e)
        {
            MessageBox.Show(bookDescriptionLabel.Text);
        }
    }
}

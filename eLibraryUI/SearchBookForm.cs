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
    public partial class SearchBookForm : Form
    {
        private readonly ISearchBookService _searchBookService;
        private readonly ILibraryWelcomeService _welcomeService;
        private readonly IReadBooksService _readBooksService;
        private readonly IRandomBookService _randomBookService;
        private readonly IQuizService _quizService;
        private readonly IAddNewBookService _addNewBookService;
        private readonly IStatisticsService _statisticsService;
        private readonly IToReadService _toReadService;
        private readonly IFavoriteAuthorsService _favoriteAuthorsService;
        private readonly UserModel _loggedUser;

        public SearchBookForm(UserModel model,
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
            _searchBookService = searchBookService;
            _welcomeService = welcomeService;
            _readBooksService = readBooksService;
            _randomBookService = randomBookService;
            _quizService = quizService;
            _addNewBookService = addNewBookService;
            _statisticsService = statisticsService;
            _toReadService = toReadService;
            _favoriteAuthorsService = favoriteAuthorsService;
            _loggedUser = model;
            searchTypeDropDown.DataSource = searchBookService.FillListOfSearchTypes();
        }


        //Fill listbox of read books with user data
        private void WireUpList(List<BookModel> foundBooks)
        {
            foundBooksListBox.DataSource = null;
            foundBooksListBox.DataSource = foundBooks;
            foundBooksListBox.DisplayMember = "Title";
        }

        //Refresh description panel with detail of highlight book
        private void UpdateBookDescriptionPanel()
        {
            BookModel descriptionPanelBook = (BookModel)foundBooksListBox.SelectedItem;
            if (descriptionPanelBook != null)
            {
                authorLabel.Text = descriptionPanelBook.Author;
                titleLabel.Text = descriptionPanelBook.Title;
                genreLabel.Text = descriptionPanelBook.Genre;
                bookDescriptionLabel.Text = descriptionPanelBook.Description;
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            //Refresh the list
            WireUpList(_searchBookService.SearchForBooks(searchTypeDropDown.SelectedItem.ToString(), searchValue.Text));
        }

        private void foundBooksListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateBookDescriptionPanel();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            ChooseBookForm frm = new ChooseBookForm(_loggedUser, _searchBookService, _welcomeService, _readBooksService, _randomBookService, _quizService, _addNewBookService, _statisticsService, _toReadService, _favoriteAuthorsService);
            frm.Show();
            this.Close();
        }

        private void toReadButton_Click(object sender, EventArgs e)
        {
            try
            {
                _searchBookService.AddBookToUserToReadBookshelf(_loggedUser, (BookModel)foundBooksListBox.SelectedItem);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void bookDescriptionLabel_Click(object sender, EventArgs e)
        {
            MessageBox.Show(bookDescriptionLabel.Text);
        }
    }
}

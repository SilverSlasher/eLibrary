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
    public partial class CreateUserForm : Form
    {
        private readonly ICreateUserService _userService;
        private readonly ILibraryAccessService _accessService;
        private readonly IDataConnection _connection;
        private readonly IRemindAccountService _reminderService;
        private readonly ILibraryWelcomeService _welcomeService;
        private readonly IReadBooksService _readBooksService;
        private readonly IAddNewBookService _addNewBookService;
        private readonly IStatisticsService _statisticsService;
        private readonly IToReadService _toReadService;
        private readonly IFavoriteAuthorsService _favoriteAuthorsService;
        private readonly ISearchBookService _searchBookService;
        private readonly IQuizService _quizService;
        private readonly IRandomBookService _randomBookService;

        public CreateUserForm(ICreateUserService userService,
            ILibraryAccessService accessService,
            IDataConnection connection,
            IRemindAccountService reminderService,
            ILibraryWelcomeService welcomeService,
            IReadBooksService readBooksService,
            IAddNewBookService addNewBookService,
            IStatisticsService statisticsService,
            IToReadService toReadService,
            IFavoriteAuthorsService favoriteAuthorsService,
            ISearchBookService searchBookService,
            IQuizService quizService,
            IRandomBookService randomBookService)
        {
            _userService = userService;
            _accessService = accessService;
            _connection = connection;
            _reminderService = reminderService;
            _welcomeService = welcomeService;
            _readBooksService = readBooksService;
            _addNewBookService = addNewBookService;
            _statisticsService = statisticsService;
            _toReadService = toReadService;
            _favoriteAuthorsService = favoriteAuthorsService;
            _searchBookService = searchBookService;
            _quizService = quizService;
            _randomBookService = randomBookService;
            InitializeComponent();
        }

        private void addUserButton_Click(object sender, EventArgs e)
        {
            try
            {
                _userService.ValidateForm(
                    userNameValue.Text,
                    passwordValue.Text,
                    repeatPasswordValue.Text,
                    firstNameValue.Text,
                    lastNameValue.Text,
                    emailValue.Text
                    );
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return;
            }

            _userService.PrepareNewUser(firstNameValue.Text, lastNameValue.Text, userNameValue.Text, passwordValue.Text, emailValue.Text);
            this.Close();
            MessageBox.Show("Pomyślnie utworzono konto!");
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            LibraryAccessForm frm = new LibraryAccessForm(_accessService, _connection, _userService, _reminderService, _welcomeService, _readBooksService, _addNewBookService, _statisticsService, _toReadService, _favoriteAuthorsService, _searchBookService, _randomBookService, _quizService);
            frm.Show();
            this.Close();
        }
    }
}

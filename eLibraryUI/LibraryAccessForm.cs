using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using eLibraryClasses;
using eLibraryClasses.DataAccess;
using eLibraryClasses.Models;
using eLibraryClasses.UI_Forms_Logic.Interfaces;

namespace eLibraryUI
{
    public partial class LibraryAccessForm : Form
    {
        private readonly ILibraryAccessService _accessService;
        private readonly IDataConnection _connection;
        private readonly ICreateUserService _userService;
        private readonly IRemindAccountService _reminderService;
        private readonly ILibraryWelcomeService _welcomeService;
        private readonly IReadBooksService _readBooksService;
        private readonly IAddNewBookService _newBookService;
        private readonly IStatisticsService _statisticsService;
        private readonly IToReadService _toReadService;
        private readonly IFavoriteAuthorsService _favoriteAuthorsService;
        private readonly ISearchBookService _searchBookService;
        private readonly IRandomBookService _randomBookService;
        private readonly IQuizService _quizService;

        public LibraryAccessForm(ILibraryAccessService accessService,
            IDataConnection connection,
            ICreateUserService userService,
            IRemindAccountService reminderService,
            ILibraryWelcomeService welcomeService,
            IReadBooksService readBooksService,
            IAddNewBookService newBookService,
            IStatisticsService statisticsService,
            IToReadService toReadService,
            IFavoriteAuthorsService favoriteAuthorsService,
            ISearchBookService searchBookService,
            IRandomBookService randomBookService,
            IQuizService quizService)
        {
            InitializeComponent();
            _accessService = accessService;
            _connection = connection;
            _userService = userService;
            _reminderService = reminderService;
            _welcomeService = welcomeService;
            _readBooksService = readBooksService;
            _newBookService = newBookService;
            _statisticsService = statisticsService;
            _toReadService = toReadService;
            _favoriteAuthorsService = favoriteAuthorsService;
            _searchBookService = searchBookService;
            _randomBookService = randomBookService;
            _quizService = quizService;
        }

        private void createAccountLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateUserForm frm = new CreateUserForm(_userService, _accessService, _connection, _reminderService, _welcomeService, _readBooksService, _newBookService, _statisticsService, _toReadService, _favoriteAuthorsService, _searchBookService, _quizService, _randomBookService);
            frm.Show();
        }

        private void reminderAccountLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RemindAccountForm frm = new RemindAccountForm(_reminderService);
            frm.Show();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            try
            {
                LibraryWelcomeForm frm = new LibraryWelcomeForm(_accessService.UserLoginIn(userNameValue.Text,passwordValue.Text), _welcomeService, _readBooksService, _newBookService, _statisticsService, _toReadService, _favoriteAuthorsService, _newBookService, _searchBookService, _randomBookService, _quizService);
                frm.Show();
                this.Hide();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void userNameValue_MouseClick(object sender, MouseEventArgs e)
        {
            userNameValue.Text = "";
        }

        private void passwordValue_MouseClick(object sender, MouseEventArgs e)
        {
            passwordValue.Text = "";
        }

    }
}

using System.Windows.Forms;
using eLibraryClasses.DataAccess;
using eLibraryClasses.UI_Forms_Logic.Interfaces;

namespace eLibraryUI.Autofac_logic
{
    public class StartUp : IStartUp
    {
        private readonly ILibraryAccessService _accessService;
        private readonly IDataConnection _connection;
        private readonly ICreateUserService _userService;
        private readonly IRemindAccountService _reminderService;
        private readonly ILibraryWelcomeService _welcomeService;
        private readonly IReadBooksService _readBooksService;
        private readonly IAddNewBookService _addNewBookService;
        private readonly IStatisticsService _statisticsService;
        private readonly IToReadService _toReadService;
        private readonly IFavoriteAuthorsService _favoriteAuthorsService;
        private readonly ISearchBookService _searchBookService;
        private readonly IRandomBookService _randomBookService;
        private readonly IQuizService _quizService;

        public StartUp(ILibraryAccessService accessService,
            IDataConnection connection,
            ICreateUserService userService,
            IRemindAccountService reminderService,
            ILibraryWelcomeService welcomeService,
            IReadBooksService readBooksService,
            IAddNewBookService addNewBookService,
            IStatisticsService statisticsService,
            IToReadService toReadService,
            IFavoriteAuthorsService favoriteAuthorsService,
            ISearchBookService searchBookService,
            IRandomBookService randomBookService,
            IQuizService quizService)
        {
            _accessService = accessService;
            _connection = connection;
            _userService = userService;
            _reminderService = reminderService;
            _welcomeService = welcomeService;
            _readBooksService = readBooksService;
            _addNewBookService = addNewBookService;
            _statisticsService = statisticsService;
            _toReadService = toReadService;
            _favoriteAuthorsService = favoriteAuthorsService;
            _searchBookService = searchBookService;
            _randomBookService = randomBookService;
            _quizService = quizService;
        }

        public void Run()
        {
            Application.Run(new LibraryAccessForm(_accessService, _connection, _userService, _reminderService, _welcomeService, _readBooksService, _addNewBookService, _statisticsService, _toReadService, _favoriteAuthorsService, _searchBookService, _randomBookService, _quizService));
        }
    }
}

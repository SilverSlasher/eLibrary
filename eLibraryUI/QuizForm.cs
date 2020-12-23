using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using eLibraryClasses;
using eLibraryClasses.DataAccess;
using eLibraryClasses.Models;
using eLibraryClasses.UI_Forms_Logic.Interfaces;

namespace eLibraryUI
{
    public partial class QuizForm : Form
    {
        /*
         *This form is not the intuitive one. I recommend that you should open a QuizFile.txt and check concurrently with reading code.
         *Some Questions give too general infos, and it's needed to jump to next one connected with the one before
         *Order is strict so sometimes is like "jump to 2" what means jump to question number 2 which is complement to first one
         *When more than 1 book is matched, the one is taking randomly
         */

        private readonly IQuizService _service;
        private readonly ISearchBookService _searchBookService;
        private readonly IReadBooksService _readBooksService;
        private readonly ILibraryWelcomeService _welcomeService;
        private readonly IRandomBookService _randomBookService;
        private readonly IQuizService _quizService;
        private readonly IAddNewBookService _addNewBookService;
        private readonly IStatisticsService _statisticsService;
        private readonly IToReadService _toReadService;
        private readonly IFavoriteAuthorsService _favoriteAuthorsService;

        //Every anwser has 2 items. First is text of answer so AnswerText is 0, and variable is more understandable
        private const int AnswerText = 0;
        private bool _isNextQuestionButtonVisible;
        private readonly UserModel _loggedUser;



        public QuizForm(UserModel model,
            IQuizService service,
            ISearchBookService searchBookService,
            IReadBooksService readBooksService,
            ILibraryWelcomeService welcomeService,
            IRandomBookService randomBookService,
            IQuizService quizService,
            IAddNewBookService addNewBookService,
            IStatisticsService statisticsService,
            IToReadService toReadService,
            IFavoriteAuthorsService favoriteAuthorsService

        )
        {
            InitializeComponent();
            _service = service;
            _searchBookService = searchBookService;
            _readBooksService = readBooksService;
            _welcomeService = welcomeService;
            _randomBookService = randomBookService;
            _quizService = quizService;
            _addNewBookService = addNewBookService;
            _statisticsService = statisticsService;
            _toReadService = toReadService;
            _favoriteAuthorsService = favoriteAuthorsService;
            _loggedUser = model;
            service.SetCurrentStepIndex(0);
            InitializeQuestion();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            ChooseBookForm frm = new ChooseBookForm(_loggedUser, _searchBookService, _welcomeService, _readBooksService, _randomBookService, _quizService, _addNewBookService, _statisticsService, _toReadService, _favoriteAuthorsService);
            frm.Show();
            this.Close();
        }

        private void backSecondButton_Click(object sender, EventArgs e)
        {
            ChooseBookForm frm = new ChooseBookForm(_loggedUser, _searchBookService, _welcomeService, _readBooksService, _randomBookService, _quizService, _addNewBookService, _statisticsService, _toReadService, _favoriteAuthorsService);
            frm.Show();
            this.Close();
        }

        private void InitializeQuestion()
        {
            //Change text of question label to text of the question got from text file. Number of question is same as current step of form
            questionLabel.Text = _service.GetQuestion(_service.GetCurrentStepIndex()).Inquiry;
            
            //Change text of first answer label to text of the answer got from text file.
            firstAnswerButton.Text = _service.GetQuestion(_service.GetCurrentStepIndex()).FirstAnswer[AnswerText];
            secondAnswerButton.Text = _service.GetQuestion(_service.GetCurrentStepIndex()).SecondAnswer[AnswerText];
            thirdAnswerButton.Text = _service.GetQuestion(_service.GetCurrentStepIndex()).ThirdAnswer[AnswerText];
            fourthAnswerButton.Text = _service.GetQuestion(_service.GetCurrentStepIndex()).FourthAnswer[AnswerText];

            //Next question button shouldn't be visible after load a new question, so set variable to false
            _isNextQuestionButtonVisible = false;
        }

        private bool AnyRadioButtonClicked()
        {
            bool output = firstAnswerButton.Checked || secondAnswerButton.Checked || thirdAnswerButton.Checked || fourthAnswerButton.Checked;

            return output;
        }

        //If user clicked any option, show the "Next question" button
        private void mainPanel_MouseMove(object sender, MouseEventArgs e)
        {

            if (AnyRadioButtonClicked() && !_isNextQuestionButtonVisible)
            {
                nextQuestionButton.Visible = true;
                _isNextQuestionButtonVisible = true;
            }
        }

        private int GetSelectedRadioButton()
        {
            if (firstAnswerButton.Checked)
            {
                return 1;
            }

            if (secondAnswerButton.Checked)
            {
                return 2;
            }

            if (thirdAnswerButton.Checked)
            {
                return 3;
            }

            if (fourthAnswerButton.Checked)
            {
                return 4;
            }

            return 0;
        }

        private void nextQuestionButton_Click(object sender, EventArgs e)
        {
            int selectedOption = GetSelectedRadioButton();

            switch (selectedOption)
            {
                case 1:
                    _service.FirstAnswerMatchingMethod(selectedOption);
                    //Check if all info is got. If yes, show the best matched book
                    MatchBook();
                    //Jump to - means jump to question specified in QuizFile. Order is strict, as are the numbers.
                    //Every question is known and it's not in random order, so we can jump to strict numbers
                    _service.SetNextStepIndex(1);
                    //Next question will be shown so hide "Next question" button, so user has to choose next option
                    HideNextQuestionButton();
                    firstAnswerButton.Checked = false;

                    InitializeQuestion();
                    break;

                case 2:
                    _service.SecondAnswerMatchingMethod(selectedOption);
                    MatchBook();
                    _service.SetNextStepIndex(3);
                    HideNextQuestionButton();
                    secondAnswerButton.Checked = false;
                    InitializeQuestion();
                    break;

                case 3:
                    _service.ThirdAnswerMatchingMethod(selectedOption);
                    MatchBook();
                    _service.SetNextStepIndex(2);
                    HideNextQuestionButton();
                    thirdAnswerButton.Checked = false;
                    InitializeQuestion();
                    break;

                case 4:
                    _service.FourthAnswerMatchingMethod(selectedOption);
                    MatchBook();
                    _service.SetNextStepIndex(3);
                    HideNextQuestionButton();
                    fourthAnswerButton.Checked = false;
                    InitializeQuestion();
                    break;
            }

        }

        //After going to next question, the option of going forth should be disabled
        private void HideNextQuestionButton()
        {
            _isNextQuestionButtonVisible = false;
            nextQuestionButton.Visible = false;
        }

        private void MatchBook()
        {
            //If current index is 3 (max one), show finish panel of this form
            if (_service.GetCurrentStepIndex() == 3)
            {
                finalBookPanel.Visible = true;
                _service.RandomizeMatchedBooks();
                WriteDownMatchedBook();
            }
        }

        private void WriteDownMatchedBook()
        {
            authorLabel.Text = _service.GetMatchedBook(0).Author;
            titleLabel.Text = _service.GetMatchedBook(0).Title;
            genreLabel.Text = _service.GetMatchedBook(0).Genre;
        }

        private void toReadButton_Click(object sender, EventArgs e)
        {
            try
            {
                _service.TryToAddBookToBookshelf(_loggedUser);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}


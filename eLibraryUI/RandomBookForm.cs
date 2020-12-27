using System;
using System.Linq;
using System.Windows.Forms;
using eLibraryClasses.Models;
using eLibraryClasses.UI_Forms_Logic.Interfaces;


namespace eLibraryUI
{
    public partial class RandomBookForm : Form
    {
        private readonly IRandomBookService _randomBookService;
        private readonly ISearchBookService _searchBookService;
        private readonly ILibraryWelcomeService _welcomeService;
        private readonly IReadBooksService _readBooksService;
        private readonly IQuizService _quizService;
        private readonly IAddNewBookService _addNewBookService;
        private readonly IStatisticsService _statisticsService;
        private readonly IToReadService _toReadService;
        private readonly IFavoriteAuthorsService _favoriteAuthorsService;
        private readonly UserModel _loggedUser;
        private int _buttonClicked;


        public RandomBookForm(UserModel model,
            IRandomBookService randomBookService,
            ISearchBookService searchBookService,
            ILibraryWelcomeService welcomeService,
            IReadBooksService readBooksService,
            IQuizService quizService,
            IAddNewBookService addNewBookService,
            IStatisticsService statisticsService,
            IToReadService toReadService, 
            IFavoriteAuthorsService favoriteAuthorsService)
        {
            InitializeComponent();
            _randomBookService = randomBookService;
            _searchBookService = searchBookService;
            _welcomeService = welcomeService;
            _readBooksService = readBooksService;
            _quizService = quizService;
            _addNewBookService = addNewBookService;
            _statisticsService = statisticsService;
            _toReadService = toReadService;
            _favoriteAuthorsService = favoriteAuthorsService;
            _loggedUser = model;

            //Make new randomize of books every time form is open
            _randomBookService.RandomizeBooks(_loggedUser);


            //Assign randomized books to buttons
            WriteDownRandomizedBook(author1Label, title1Label, genre1Label, 0);
            WriteDownRandomizedBook(author2Label, title2Label, genre2Label, 1);
            WriteDownRandomizedBook(author3Label, title3Label, genre3Label, 2);
            WriteDownRandomizedBook(author4Label, title4Label, genre4Label, 3);
            WriteDownRandomizedBook(author5Label, title5Label, genre5Label, 4);
            WriteDownRandomizedBook(author6Label, title6Label, genre6Label, 5);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            ChooseBookForm frm = new ChooseBookForm(_loggedUser, _searchBookService, _welcomeService, _readBooksService, _randomBookService, _quizService, _addNewBookService, _statisticsService, _toReadService, _favoriteAuthorsService);
            frm.Show();
            this.Close();
        }

        private void randomBook1Button_Click(object sender, EventArgs e)
        {
            //Not clicked buttons are disabled.
            BlockRestOfTheButtons(
                randomBook2Button,
                randomBook3Button,
                randomBook4Button,
                randomBook5Button,
                randomBook6Button
                );
            ShowDrawnBook(randomBook1Button, toReadButton, 1);
        }

        private void randomBook2Button_Click(object sender, EventArgs e)
        {
            BlockRestOfTheButtons(
                randomBook1Button,
                randomBook3Button,
                randomBook4Button,
                randomBook5Button,
                randomBook6Button
                );

            ShowDrawnBook(randomBook2Button, toReadButton, 2);
        }

        private void randomBook3Button_Click(object sender, EventArgs e)
        {
            BlockRestOfTheButtons(
                randomBook1Button,
                randomBook2Button,
                randomBook4Button,
                randomBook5Button,
                randomBook6Button
                );

            ShowDrawnBook(randomBook3Button, toReadButton, 3);
        }

        private void randomBook4Button_Click(object sender, EventArgs e)
        {
            BlockRestOfTheButtons(
                randomBook1Button,
                randomBook2Button,
                randomBook3Button,
                randomBook5Button,
                randomBook6Button
                );

            ShowDrawnBook(randomBook4Button, toReadButton, 4);
        }

        private void randomBook5Button_Click(object sender, EventArgs e)
        {
            BlockRestOfTheButtons(
                randomBook1Button,
                randomBook2Button,
                randomBook3Button,
                randomBook4Button,
                randomBook6Button
                );

            ShowDrawnBook(randomBook5Button, toReadButton, 5);
        }

        private void randomBook6Button_Click(object sender, EventArgs e)
        {
            BlockRestOfTheButtons(
                randomBook1Button,
                randomBook2Button,
                randomBook3Button,
                randomBook4Button,
                randomBook5Button
                );

            ShowDrawnBook(randomBook6Button, toReadButton, 6);
        }

        //Add randomized book to user "To read" bookshelf
        private void toReadButton_Click(object sender, EventArgs e)
        {
            try
            {
                _randomBookService.AddBookToUserToReadBookshelf(_loggedUser, _buttonClicked);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void ShowDrawnBook(Button clickedButton, Button toReadButton, int buttonNumber)
        {
            //Hide button which cover answer
            clickedButton.Visible = false;
            //Add option to add randomized book to "To read" bookshelf
            toReadButton.Visible = true;
            //Return index of clicked button
            _buttonClicked = buttonNumber;
        }

        //Assign randomized books to buttons
        private void WriteDownRandomizedBook(
            Label authorLabel,
            Label titleLabel,
            Label genreLabel,
            int optionNumber
        )
        {
            
            authorLabel.Text = _randomBookService.GetRandomizedBooks().ElementAt(optionNumber).Author;
            titleLabel.Text = _randomBookService.GetRandomizedBooks().ElementAt(optionNumber).Title;
            genreLabel.Text = _randomBookService.GetRandomizedBooks().ElementAt(optionNumber).Genre;
        }

        //When 1 button is clicked by user, rest of buttons will be not available anymore
        private void BlockRestOfTheButtons(
            Button buttonOne,
            Button buttonTwo,
            Button buttonThree,
            Button buttonFour,
            Button buttonFive
        )
        {
            buttonOne.Enabled = false;
            buttonTwo.Enabled = false;
            buttonThree.Enabled = false;
            buttonFour.Enabled = false;
            buttonFive.Enabled = false;
        }
    }
}

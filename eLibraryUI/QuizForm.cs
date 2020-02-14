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

namespace eLibraryUI
{
    public partial class QuizForm : Form
    {
        /*
         *This form is not the intuitive one. I recommend that you should open a QuizFile.txt and check concurrently with reading code.
         *Some questions give too general infos, and it's needed to jump to next one connected with the one before
         *Order is strict so sometimes is like "jump to 2" what means jump to question number 2 which is complement to first one
         *When more than 1 book is matched, the one is taking randomly
         */

        //Every anwser has 2 items. First is text of answer so answerText is 0, and variable is more understandable
        private const int answerText = 0;

        //Every answer has 2 items. Second is attribute of answer so answerAttribute is 1, and variable is more understandable
        //The attribute is the best-matching genre to answer (in first answers) or number of pages (in last answer)
        private const int answerAttribute = 1;

        //Variable helps to save data of visible of button use to go to next question
        private bool isNextQuestionButtonVisible;

        //Variable is changed, when matched books are matched by genre
        private bool areBooksMatchedByGenre = false;

        //Variable is changed, when matched books are matched by pages
        private bool areBooksMatchedByPages = false;

        //Check if user already added the book to his own library
        private bool isAddedNow = false;

        //Get all question models from file .txt
        private List<QuestionModel> questions = GlobalConfig.QuizFile.FullFilePath().LoadFile().ConvertToQuestionModels();

        //Get all books from file .txt
        private List<BookModel> allBooks = GlobalConfig.Connection.GetBook_All();

        //Create a new list of matched books (books will be added during this form)
        private List<BookModel> matchedBooks = new List<BookModel>();

        //Create new local UserModel to store logged user data got from form closed before
        private UserModel loggedUser = new UserModel();

        //Variable to store info about step of the form
        private int currentStepIndex;

        public QuizForm(UserModel model)
        {
            InitializeComponent();
            //Save active user data to local variable 
            loggedUser = model;
            //The form just started, so current step is 0
            currentStepIndex = 0;
            //Initialize first question of quiz
            InitializeQuestion();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            //Create a new form, and send logged user data
            ChooseBookForm frm = new ChooseBookForm(loggedUser);
            //Show a created form
            frm.Show();
            //Close current form
            this.Close();
        }

        private void backSecondButton_Click(object sender, EventArgs e)
        {
            //Create a new form, and send logged user data
            ChooseBookForm frm = new ChooseBookForm(loggedUser);
            //Show a created form
            frm.Show();
            //Close current form
            this.Close();
        }

        //Changing text of label in form to text of questions got from text file
        private void InitializeQuestion()
        {
            //Change text of question label to text of the question got from text file. Number of question is same as current step of form
            questionLabel.Text = questions[currentStepIndex].Inquiry;
            //Change text of first answer label to text of the answer got from text file.
            firstAnswerButton.Text = questions[currentStepIndex].FirstAnswer[answerText];
            //Change text of second answer label to text of the answer got from text file.
            secondAnswerButton.Text = questions[currentStepIndex].SecondAnswer[answerText];
            //Change text of third answer label to text of the answer got from text file.
            thirdAnswerButton.Text = questions[currentStepIndex].ThirdAnswer[answerText];
            //Change text of fourth answer label to text of the answer got from text file.
            fourthAnswerButton.Text = questions[currentStepIndex].FourthAnswer[answerText];
            //Next question button shouldn't be visible after load a new question, so set variable to false
            isNextQuestionButtonVisible = false;
        }

        //Taking attribute from chosen answer, and add books with right genre from all books, to matched books.
        private void RefreshMatchedBooksByGenre(int _selectedOption)
        {
            //If user chose first option (first radio button) and books are not matched before
            if (_selectedOption == 1 && !areBooksMatchedByGenre)
            {
                //Find all matching books in all books with genre took from answer attribute
                foreach (BookModel book in allBooks)
                {
                    if (questions[currentStepIndex].FirstAnswer[answerAttribute] == book.Genre)
                    {
                        matchedBooks.Add(book);
                    }
                }
                //Set flag of matching by genre
                areBooksMatchedByGenre = true;
            }

            //If user chose second option (second radio button) and books are not matched before
            if (_selectedOption == 2 && !areBooksMatchedByGenre)
            {
                foreach (BookModel book in allBooks)
                {
                    //Find all matching books in all books with genre took from answer attribute
                    if (questions[currentStepIndex].SecondAnswer[answerAttribute] == book.Genre)
                    {
                        matchedBooks.Add(book);
                    }
                }
                //Set flag of matching by genre
                areBooksMatchedByGenre = true;
            }

            //If user chose third option (third radio button) and books are not matched before
            if (_selectedOption == 3 && !areBooksMatchedByGenre)
            {
                //It's the specific one. Answers are known before, and the third one is correct to both genres, so both have to be added
                foreach (BookModel book in allBooks)
                {
                    if (questions[currentStepIndex].FirstAnswer[answerAttribute] == book.Genre ||
                        questions[currentStepIndex].SecondAnswer[answerAttribute] == book.Genre)
                    {
                        matchedBooks.Add(book);
                    }
                }
                //Set flag of matching by genre
                areBooksMatchedByGenre = true;
            }

            //If user chose fourth option (fourth radio button) and books are not matched before
            if (_selectedOption == 4 && !areBooksMatchedByGenre)
            {
                //Answers are known before. The fourth one didn't specify any genres, so every book is correct
                foreach (BookModel book in allBooks)
                {
                    matchedBooks.Add(book);
                }
                //Set flag of matching by genre
                areBooksMatchedByGenre = true;
            }

        }

        //Taking attribute from chosen answer, and add books with right number of pages from all books, to matched books.
        private void RefreshMatchedBooksByPages(int _selectedOption)
        {
            //We have to take out books which are shorter than requested
            List<BookModel> booksToDelete = new List<BookModel>();

            //Every last answer in form has attribute with number of pages. Compare number of pages with matched books.
            if (_selectedOption == 1 && !areBooksMatchedByPages)
            {
                foreach (BookModel book in matchedBooks)
                {
                    if (int.Parse(questions[currentStepIndex].FirstAnswer[answerAttribute]) < book.Pages)
                    {
                        booksToDelete.Add(book);
                    }
                }
                //Set flag of matching by pages
                areBooksMatchedByPages = true;
            }

            //Every last answer in form has attribute with number of pages. Compare number of pages with matched books.
            if (_selectedOption == 2 && !areBooksMatchedByPages)
            {
                foreach (BookModel book in matchedBooks)
                {
                    if (int.Parse(questions[currentStepIndex].SecondAnswer[answerAttribute]) < book.Pages)
                    {
                        booksToDelete.Add(book);
                    }
                }
                //Set flag of matching by pages
                areBooksMatchedByPages = true;
            }

            //Every last answer in form has attribute with number of pages. Compare number of pages with matched books.
            if (_selectedOption == 3 && !areBooksMatchedByPages)
            {
                foreach (BookModel book in matchedBooks)
                {
                    if (int.Parse(questions[currentStepIndex].ThirdAnswer[answerAttribute]) < book.Pages)
                    {
                        booksToDelete.Add(book);
                    }
                }
                //Set flag of matching by pages
                areBooksMatchedByPages = true;
            }

            //Every last answer in form has attribute with number of pages. Compare number of pages with matched books.
            if (_selectedOption == 4 && !areBooksMatchedByPages)
            {
                foreach (BookModel book in matchedBooks)
                {
                    if (int.Parse(questions[currentStepIndex].FourthAnswer[answerAttribute]) < book.Pages)
                    {
                        booksToDelete.Add(book);
                    }
                }
                //Set flag of matching by pages
                areBooksMatchedByPages = true;
            }

            //Deleting from matched books all books which are shorter than requested
            foreach (BookModel book in booksToDelete)
            {
                matchedBooks.Remove(book);
            }
        }

        //Chech if any of radiobutton are clicked by user
        private bool AnyRadioButtonClicked()
        {
            bool output = false;

            if (firstAnswerButton.Checked)
            {
                output = true;
            }

            if (secondAnswerButton.Checked)
            {
                output = true;
            }

            if (thirdAnswerButton.Checked)
            {
                output = true;
            }

            if (fourthAnswerButton.Checked)
            {
                output = true;
            }

            return output;
        }

        //If user clicked any option, show the "Next question" button
        private void mainPanel_MouseMove(object sender, MouseEventArgs e)
        {

            if (AnyRadioButtonClicked() && !isNextQuestionButtonVisible)
            {
                nextQuestionButton.Visible = true;
                isNextQuestionButtonVisible = true;
            }
        }

        //Check which button is clicked and return its number
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
            //Store info which radiobutton is clicked
            int selectedOption = GetSelectedRadioButton();

            switch (selectedOption)
            {
                case 1:
                    //If index is 0, books are not matched, because first answer in first loop didn't send complete information and has to be filled with second one
                    if (currentStepIndex != 0)
                    {
                        //In this loop info is complete so books can be matched (It's quite unintuitive, because answers&questions are constant)
                        RefreshMatchedBooksByGenre(selectedOption);
                    }

                    //In step number 3, question is about length 
                    if (currentStepIndex == 3)
                    {
                        //Matching books by number of pages
                        RefreshMatchedBooksByPages(selectedOption);
                    }

                    //Check if all info is got. If yes, show the best matched book
                    MatchBook();

                    //Jump to - means jump to question specified in QuizFile. Order is strict, as are the numbers.
                    //Every question is known and it's not in random order, so we can jump to strict numbers
                    currentStepIndex = SetNextStepIndex(currentStepIndex, 1);

                    //Next question will be shown so hide "Next question" button, so user has to choose next option
                    HideNextQuestionButton();

                    //Uncheck the button
                    firstAnswerButton.Checked = false;
                    //Initialize next question
                    InitializeQuestion();
                    break;

                case 2:
                    //In this case first loop gives complete information about genre, so it can be matched.
                    RefreshMatchedBooksByGenre(selectedOption);

                    //In step number 3, question is about length 
                    if (currentStepIndex == 3)
                    {
                        //Matching books by number of pages
                        RefreshMatchedBooksByPages(selectedOption);
                    }

                    //Check if all info is got. If yes, show the best matched book
                    MatchBook();

                    //Every question is known and it's not in random order, so we can jump to strict numbers
                    currentStepIndex = SetNextStepIndex(currentStepIndex, 3);

                    //Next question will be shown so hide "Next question" button, so user has to choose next option
                    HideNextQuestionButton();
                    //Uncheck the button
                    secondAnswerButton.Checked = false;
                    //Initialize next question
                    InitializeQuestion();
                    break;

                case 3:
                    //If index is 0, books are not matched, because first answer in first loop didn't send complete information and has to be filled with second one
                    if (currentStepIndex != 0)
                    {
                        //In this loop info is complete so books can be matched (It's quite unintuitive, because answers&questions are constant)
                        RefreshMatchedBooksByGenre(selectedOption);
                    }

                    //In step number 3, question is about length 
                    if (currentStepIndex == 3)
                    {
                        //Matching books by number of pages
                        RefreshMatchedBooksByPages(selectedOption);
                    }

                    //Check if all info is got. If yes, show the best matched book
                    MatchBook();

                    //Every question is known and it's not in random order, so we can jump to strict numbers
                    currentStepIndex = SetNextStepIndex(currentStepIndex, 2);
                    //Next question will be shown so hide "Next question" button, so user has to choose next option
                    HideNextQuestionButton();
                    //Uncheck the button
                    thirdAnswerButton.Checked = false;
                    //Initialize next question
                    InitializeQuestion();
                    break;

                case 4:
                    //In this case first loop gives complete information about genre, so it can be matched.
                    RefreshMatchedBooksByGenre(selectedOption);

                    //In step number 3, question is about length 
                    if (currentStepIndex == 3)
                    {
                        //Matching books by number of pages
                        RefreshMatchedBooksByPages(selectedOption);
                    }

                    //Check if all info is got. If yes, show the best matched book
                    MatchBook();

                    //Every question is known and it's not in random order, so we can jump to strict numbers
                    currentStepIndex = SetNextStepIndex(currentStepIndex, 3);
                    //Next question will be shown so hide "Next question" button, so user has to choose next option
                    HideNextQuestionButton();
                    //Uncheck the button
                    fourthAnswerButton.Checked = false;
                    //Initialize next question
                    InitializeQuestion();
                    break;
            }

        }

        //After going to next question, the option of going forth should be disabled
        private void HideNextQuestionButton()
        {
            isNextQuestionButtonVisible = false;
            nextQuestionButton.Visible = false;
        }

        //Validate if lists are created before, if not, create a new ones
        private void ValidateNulls()
        {
            if (loggedUser.ReadBooks == null)
            {
                loggedUser.ReadBooks = new List<BookModel>();
            }

            if (loggedUser.ToReadBooks == null)
            {
                loggedUser.ToReadBooks = new List<BookModel>();
            }
        }

        //I didn't disabled option of showing books, which user read before, because something it's nice to remind yourself about good one
        private bool VerifyBookExistingInUserBookshelf()
        {
            //Create a new temporary list 
            List<BookModel> userUsedBooks = new List<BookModel>();

            //Validate if lists of user are created
            ValidateNulls();

            //Add to temporary list every book which user read before
            foreach (BookModel book in loggedUser.ReadBooks)
            {
                userUsedBooks.Add(book);
            }

            //Add to temporary list every book which would like to read (saved it on "To read bookshelf") 
            foreach (BookModel book in loggedUser.ToReadBooks)
            {
                userUsedBooks.Add(book);
            }

            //Take best matched book
            BookModel singleBook = matchedBooks[0];

            //Compare best matched book with every book of user bookshelf
            foreach (BookModel book in userUsedBooks)
            {
                if (singleBook.Id == book.Id)
                {
                    //If user has the book on read bookshelf or "to read" bookshelf, return true
                    return true;
                }
            }

            //If best matched book is not on any user bookshelf, return false
            return false;
        }

        //If it's first loop, and question need additional info to be able to match best books for user, jump to specific index of question.
        //If it's not first one, so every info is already got, and jump to index number 3 what is choosing length of book
        private int SetNextStepIndex(int currentStepIndex, int jumpTo)
        {
            if (currentStepIndex == 0)
            {
                currentStepIndex = jumpTo;
            }
            else
            {
                currentStepIndex = 3;
            }

            return currentStepIndex;
        }

        //Check if all info is got. If yes, show the best matched book
        private void MatchBook()
        {
            //If current index is 3 (max one), show finish panel of this form
            if (currentStepIndex == 3)
            {
                finalBookPanel.Visible = true;
                //From every matched books, take one randomly
                matchedBooks = matchedBooks.OrderBy(o => Guid.NewGuid()).ToList();
                //Write it down on the panel
                WriteDownMatchedBook();
            }
        }

        //Write down author name, title and genre of best matched book (took randomly from all matched books)
        private void WriteDownMatchedBook()
        {
            authorLabel.Text = matchedBooks[0].Author;
            titleLabel.Text = matchedBooks[0].Title;
            genreLabel.Text = matchedBooks[0].Genre;
        }

        private void toReadButton_Click(object sender, EventArgs e)
        {
            //If user click on button "To read", check if is it possible
            TryToAddBookToBookshelf();
        }

        //Check if is it possible to add matched book to "To read" bookshelf
        private void TryToAddBookToBookshelf()
        {
            //If user added book to bookshelf a moment before, give a warning
            if (isAddedNow)
            {
                MessageBox.Show("Dodałeś już tę książkę do swojej bazy!");
                return;
            }

            //If book is not is user bookshelf, add it and save user info to file
            if (!VerifyBookExistingInUserBookshelf())
            {
                loggedUser.ToReadBooks.Add(matchedBooks.ElementAt(0));
                //Save user data to file
                FileConnectorCore.UpdateDataOfLoggedUser(loggedUser).SaveToUsersFile();
                //Set a flag, that user added the book to bookshelf already
                isAddedNow = true;
            }
            //If book was in user "to read" bookshelf before, and user didn't add it now, send message box
            else
            {
                //You have this book in your bookshelf, but I show it now for you. Maybe you read it again? :)
                MessageBox.Show("Posiadasz już tę książkę w swojej bazie," +
                                " lecz podsunąłem ją ponownie. Być może przeczytasz ją jeszcze raz? :)");
            }
        }
    }
}

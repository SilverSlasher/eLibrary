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
using eLibraryClasses.Interfaces;
using eLibraryClasses.Models;
using eLibraryClasses.Services;

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

        private IQuizService service;

        //Every anwser has 2 items. First is text of answer so AnswerText is 0, and variable is more understandable
        private const int AnswerText = 0;
        private bool isNextQuestionButtonVisible;
        private UserModel loggedUser;



        public QuizForm(UserModel model, IQuizService service)
        {
            InitializeComponent();
            this.service = service;
            loggedUser = model;
            service.SetCurrentStepIndex(0);
            InitializeQuestion();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            ChooseBookForm frm = new ChooseBookForm(loggedUser);
            frm.Show();
            this.Close();
        }

        private void backSecondButton_Click(object sender, EventArgs e)
        {
            ChooseBookForm frm = new ChooseBookForm(loggedUser);
            frm.Show();
            this.Close();
        }

        private void InitializeQuestion()
        {
            //Change text of question label to text of the question got from text file. Number of question is same as current step of form
            questionLabel.Text = service.GetQuestion(service.GetCurrentStepIndex()).Inquiry;
            
            //Change text of first answer label to text of the answer got from text file.
            firstAnswerButton.Text = service.GetQuestion(service.GetCurrentStepIndex()).FirstAnswer[AnswerText];
            secondAnswerButton.Text = service.GetQuestion(service.GetCurrentStepIndex()).SecondAnswer[AnswerText];
            thirdAnswerButton.Text = service.GetQuestion(service.GetCurrentStepIndex()).ThirdAnswer[AnswerText];
            fourthAnswerButton.Text = service.GetQuestion(service.GetCurrentStepIndex()).FourthAnswer[AnswerText];

            //Next question button shouldn't be visible after load a new question, so set variable to false
            isNextQuestionButtonVisible = false;
        }

        private bool AnyRadioButtonClicked()
        {
            bool output = firstAnswerButton.Checked || secondAnswerButton.Checked || thirdAnswerButton.Checked || fourthAnswerButton.Checked;

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
                    service.FirstAnswerMatchingMethod(selectedOption);
                    //Check if all info is got. If yes, show the best matched book
                    MatchBook();
                    //Jump to - means jump to question specified in QuizFile. Order is strict, as are the numbers.
                    //Every question is known and it's not in random order, so we can jump to strict numbers
                    service.SetNextStepIndex(1);
                    //Next question will be shown so hide "Next question" button, so user has to choose next option
                    HideNextQuestionButton();
                    firstAnswerButton.Checked = false;

                    InitializeQuestion();
                    break;

                case 2:
                    service.SecondAnswerMatchingMethod(selectedOption);
                    MatchBook();
                    service.SetNextStepIndex(3);
                    HideNextQuestionButton();
                    secondAnswerButton.Checked = false;
                    InitializeQuestion();
                    break;

                case 3:
                    service.ThirdAnswerMatchingMethod(selectedOption);
                    MatchBook();
                    service.SetNextStepIndex(2);
                    HideNextQuestionButton();
                    thirdAnswerButton.Checked = false;
                    InitializeQuestion();
                    break;

                case 4:
                    service.FourthAnswerMatchingMethod(selectedOption);
                    MatchBook();
                    service.SetNextStepIndex(3);
                    HideNextQuestionButton();
                    fourthAnswerButton.Checked = false;
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

        private void MatchBook()
        {
            //If current index is 3 (max one), show finish panel of this form
            if (service.GetCurrentStepIndex() == 3)
            {
                finalBookPanel.Visible = true;
                service.RandomizeMatchedBooks();
                WriteDownMatchedBook();
            }
        }

        private void WriteDownMatchedBook()
        {
            authorLabel.Text = service.GetMatchedBook(0).Author;
            titleLabel.Text = service.GetMatchedBook(0).Title;
            genreLabel.Text = service.GetMatchedBook(0).Genre;
        }

        private void toReadButton_Click(object sender, EventArgs e)
        {
            try
            {
                service.TryToAddBookToBookshelf(loggedUser);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}


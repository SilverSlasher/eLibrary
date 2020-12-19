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
using eLibraryClasses.Interfaces;
using eLibraryClasses.Models;
using eLibraryClasses.Services;


namespace eLibraryUI
{
    public partial class RandomBookForm : Form
    {
        private IRandomBookService service;
        private UserModel loggedUser;
        private int buttonClicked;


        public RandomBookForm(UserModel model, IRandomBookService service)
        {
            InitializeComponent();
            this.service = service;
            loggedUser = model;
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
            ChooseBookForm frm = new ChooseBookForm(loggedUser);
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
                service.AddBookToUserToReadBookshelf(loggedUser, buttonClicked);
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
            buttonClicked = buttonNumber;
        }

        //Assign randomized books to buttons
        private void WriteDownRandomizedBook(
            Label authorLabel,
            Label titleLabel,
            Label genreLabel,
            int optionNumber
        )
        {
            
            authorLabel.Text = service.GetRandomizedBooks().ElementAt(optionNumber).Author;
            titleLabel.Text = service.GetRandomizedBooks().ElementAt(optionNumber).Title;
            genreLabel.Text = service.GetRandomizedBooks().ElementAt(optionNumber).Genre;
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

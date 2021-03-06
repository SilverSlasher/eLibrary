﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eLibraryClasses.DataAccess;
using eLibraryClasses.Models;
using eLibraryClasses.UI_Forms_Logic.Interfaces;
using eLibraryClasses.UI_Forms_Logic.Services;

namespace eLibraryUI
{
    public partial class ToReadForm : Form
    {
        private readonly IToReadService _toReadService;
        private readonly IReadBooksService _readBooksService;
        private readonly ILibraryWelcomeService _welcomeService;
        private readonly IFavoriteAuthorsService _favoriteAuthorsService;
        private readonly IAddNewBookService _addNewBookService;
        private readonly IStatisticsService _statisticsService;
        private readonly ISearchBookService _searchBookService;
        private readonly IRandomBookService _randomBookService;
        private readonly IQuizService _quizService;
        private readonly UserModel _loggedUser;

        public ToReadForm(UserModel model,
            IToReadService toReadService,
            IReadBooksService readBooksService,
            ILibraryWelcomeService welcomeService,
            IFavoriteAuthorsService favoriteAuthorsService,
            IAddNewBookService addNewBookService,
            IStatisticsService statisticsService,
            ISearchBookService searchBookService,
            IRandomBookService randomBookService,
            IQuizService quizService)
        {
            InitializeComponent();
            _toReadService = toReadService;
            _readBooksService = readBooksService;
            _welcomeService = welcomeService;
            _favoriteAuthorsService = favoriteAuthorsService;
            _addNewBookService = addNewBookService;
            _statisticsService = statisticsService;
            _searchBookService = searchBookService;
            _randomBookService = randomBookService;
            _quizService = quizService;
            _loggedUser = model;
            WireUpToReadList();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            ReadBooksForm frm = new ReadBooksForm(_loggedUser, _readBooksService, _welcomeService, _toReadService, _favoriteAuthorsService, _readBooksService, _addNewBookService, _statisticsService, _searchBookService, _randomBookService, _quizService );
            frm.Show();
            this.Close();
        }

        //Fill listbox of read books with user data
        private void WireUpToReadList()
        {
            toReadListBox.DataSource = null;
            toReadListBox.DataSource = _loggedUser.ToReadBooks;
            toReadListBox.DisplayMember = "Title";
        }

        private void UpdateBookDescriptionPanel()
        {
            BookModel descriptionPanelBook = (BookModel)toReadListBox.SelectedItem;

            if (descriptionPanelBook != null)
            {
                authorLabel.Text = descriptionPanelBook.Author;
                titleLabel.Text = descriptionPanelBook.Title;
                genreLabel.Text = descriptionPanelBook.Genre;
                bookDescriptionLabel.Text = descriptionPanelBook.Description;
            }
        }

        private void toReadListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateBookDescriptionPanel();
        }

        //Try to add selected book from "to read bookshelf" to "read books bookshelf"
        private void readBookButton_Click(object sender, EventArgs e)
        {
            try
            {
                _toReadService.AddBookToUserReadBookshelf(_loggedUser, (BookModel)toReadListBox.SelectedItem);
                RefreshThisForm();
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

        private void RefreshThisForm()
        {
            //Refresh list in the form
            WireUpToReadList();

            //If there are any more books in user "to read bookshelf", select the first one
            if (_loggedUser.ToReadBooks.Any())
            {
                toReadListBox.SelectedIndex = 0;
            }
            //If there are no books anymore, write down "No book"
            else
            {
                authorLabel.Text = "Brak książki";
                titleLabel.Text = "Brak książki";
                genreLabel.Text = "Brak książki";
                bookDescriptionLabel.Text = "Brak książki";
            }
        }
    }
}

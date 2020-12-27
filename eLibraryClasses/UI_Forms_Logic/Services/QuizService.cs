using System;
using System.Collections.Generic;
using System.Linq;
using eLibraryClasses.DataAccess;
using eLibraryClasses.Models;
using eLibraryClasses.UI_Forms_Logic.Interfaces;

namespace eLibraryClasses.UI_Forms_Logic.Services
{
    public class QuizService : IQuizService
    {
        /*
         *This form is not the intuitive one. I recommend that you should open a QuizFile.txt and check concurrently with reading code.
         *Some Questions give too general infos, and it's needed to jump to next one connected with the one before
         *Order is strict so sometimes is like "jump to 2" what means jump to question number 2 which is complement to first one
         *When more than 1 book is matched, the one is taking randomly
         */


        //Every answer has 2 items. Second is attribute of answer so AnswerAttribute is 1, and variable is more understandable
        //The attribute is the best-matching genre to answer (in first answers) or number of pages (in last answer)
        private const int AnswerAttribute = 1;

        private bool _areBooksMatchedByGenre = false;

        private bool _areBooksMatchedByPages = false;

        private readonly List<QuestionModel> _questions;

        private readonly List<BookModel> _allBooks;

        public List<BookModel> MatchedBooks = new List<BookModel>();

        private int _currentStepIndex;

        private bool _isAddedNow = false;

        public QuizService(IDataConnection dataConnection)
        {
            _questions = dataConnection.GetQuestion_All();
            _allBooks = dataConnection.GetBook_All();
        }

        public int GetCurrentStepIndex()
        {
            return _currentStepIndex;
        }
        public void SetCurrentStepIndex(int stepNumber)
        {
            _currentStepIndex = stepNumber;
        }

        public BookModel GetMatchedBook(int index)
        {
            return MatchedBooks[index];
        }

        public QuestionModel GetQuestion(int stepNumber)
        {
            return _questions[stepNumber];
        }

        //Taking attribute from chosen answer, and add books with right genre from all books, to matched books.
        private void RefreshMatchedBooksByGenre(int selectedOption)
        {
            if (selectedOption == 1 && !_areBooksMatchedByGenre)
            {
                foreach (var book in _allBooks.Where(book => _questions[_currentStepIndex].FirstAnswer[AnswerAttribute] == book.Genre))
                {
                    MatchedBooks.Add(book);
                }

                _areBooksMatchedByGenre = true;
            }

            if (selectedOption == 2 && !_areBooksMatchedByGenre)
            {
                foreach (var book in _allBooks.Where(book => _questions[_currentStepIndex].SecondAnswer[AnswerAttribute] == book.Genre))
                {
                    MatchedBooks.Add(book);
                }

                _areBooksMatchedByGenre = true;
            }

            if (selectedOption == 3 && !_areBooksMatchedByGenre)
            {
                //It's the specific one. Answers are known before, and the third one is correct to both genres, so both have to be added
                foreach (BookModel book in _allBooks)
                {
                    if (_questions[_currentStepIndex].FirstAnswer[AnswerAttribute] == book.Genre ||
                        _questions[_currentStepIndex].SecondAnswer[AnswerAttribute] == book.Genre)
                    {
                        MatchedBooks.Add(book);
                    }
                }

                _areBooksMatchedByGenre = true;
            }

            if (selectedOption == 4 && !_areBooksMatchedByGenre)
            {
                //Answers are known before. The fourth one didn't specify any genres, so every book is correct
                foreach (BookModel book in _allBooks)
                {
                    MatchedBooks.Add(book);
                }

                _areBooksMatchedByGenre = true;
            }

        }

        //Taking attribute from chosen answer, and add books with right number of pages from all books, to matched books.
        private void RefreshMatchedBooksByPages(int selectedOption)
        {
            //We have to take out books which are shorter than requested
            List<BookModel> booksToDelete = new List<BookModel>();

            //Every last answer in form has attribute with number of pages. Compare number of pages with matched books.

            //Option 1
            try
            {
                booksToDelete = BooksNotMatchingByPages(selectedOption, 1, _questions[_currentStepIndex].FirstAnswer[AnswerAttribute]);
            }
            catch
            {
                // ignored
            }

            //Option 2
            try
            {
                booksToDelete = BooksNotMatchingByPages(selectedOption, 2, _questions[_currentStepIndex].SecondAnswer[AnswerAttribute]);
            }
            catch
            {
                // ignored
            }

            //Option 3
            try
            {
                booksToDelete = BooksNotMatchingByPages(selectedOption, 3, _questions[_currentStepIndex].ThirdAnswer[AnswerAttribute]);
            }
            catch
            {
                // ignored
            }

            //Option 4
            try
            {
                booksToDelete = BooksNotMatchingByPages(selectedOption, 4, _questions[_currentStepIndex].FourthAnswer[AnswerAttribute]);
            }
            catch
            {
                // ignored
            }

            //Deleting from matched books all books which are shorter than requested
            foreach (BookModel book in booksToDelete)
            {
                MatchedBooks.Remove(book);
            }
        }

        private List<BookModel> BooksNotMatchingByPages(int selectedOption, int numberOfAnswer, string requestNumberOfPages)
        {
            //We have to take out books which are shorter than requested
            List<BookModel> booksToDelete = new List<BookModel>();

            //Every last answer in form has attribute with number of pages. Compare number of pages with matched books.
            if (selectedOption == numberOfAnswer && !_areBooksMatchedByPages)
            {
                foreach (BookModel book in MatchedBooks)
                {
                    if (int.Parse(requestNumberOfPages) < book.Pages)
                    {
                        booksToDelete.Add(book);
                    }
                }

                _areBooksMatchedByPages = true;

                return booksToDelete;
            }

            throw new Exception();
        }

        public void FirstAnswerMatchingMethod(int selectedOption)
        {
            //If index is 0, books are not matched, because first answer in first loop didn't send complete information and has to be filled with second one
            if (_currentStepIndex != 0)
            {
                //In this loop info is complete so books can be matched (It's quite unintuitive, because answers&Questions are constant)
                RefreshMatchedBooksByGenre(selectedOption);
            }

            //In step number 3, question is about length 
            if (_currentStepIndex == 3)
            {
                //Matching books by number of pages
                RefreshMatchedBooksByPages(selectedOption);
            }
        }

        public void SecondAnswerMatchingMethod(int selectedOption)
        {
            //In this case first loop gives complete information about genre, so it can be matched.
            RefreshMatchedBooksByGenre(selectedOption);

            //In step number 3, question is about length 
            if (_currentStepIndex == 3)
            {
                //Matching books by number of pages
                RefreshMatchedBooksByPages(selectedOption);
            }
        }

        public void ThirdAnswerMatchingMethod(int selectedOption)
        {
            //If index is 0, books are not matched, because first answer in first loop didn't send complete information and has to be filled with second one
            if (_currentStepIndex != 0)
            {
                //In this loop info is complete so books can be matched (It's quite unintuitive, because answers&Questions are constant)
                RefreshMatchedBooksByGenre(selectedOption);
            }

            //In step number 3, question is about length 
            if (_currentStepIndex == 3)
            {
                //Matching books by number of pages
                RefreshMatchedBooksByPages(selectedOption);
            }
        }

        public void FourthAnswerMatchingMethod(int selectedOption)
        {
            //In this case first loop gives complete information about genre, so it can be matched.
            RefreshMatchedBooksByGenre(selectedOption);

            //In step number 3, question is about length 
            if (_currentStepIndex == 3)
            {
                //Matching books by number of pages
                RefreshMatchedBooksByPages(selectedOption);
            }
        }

        //Validate if lists are created before, if not, create a new ones
        private void PreventNullError(UserModel loggedUser)
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

        //I didn't disabled option of showing books, which user read before, because sometimes it's nice to remind yourself about good one
        private bool VerifyBookExistingInUserBookshelf(ref UserModel loggedUser)
        {
            List<BookModel> userUsedBooks = new List<BookModel>();

            PreventNullError(loggedUser);

            foreach (BookModel book in loggedUser.ReadBooks)
            {
                userUsedBooks.Add(book);
            }

            foreach (BookModel book in loggedUser.ToReadBooks)
            {
                userUsedBooks.Add(book);
            }

            BookModel singleBook = MatchedBooks[0];

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
        public void SetNextStepIndex(int jumpTo)
        {
            if (_currentStepIndex == 0)
            {
                _currentStepIndex = jumpTo;
            }
            else
            {
                _currentStepIndex = 3;
            }
        }

        public void TryToAddBookToBookshelf(UserModel loggedUser)
        {
            //If user added book to bookshelf a moment before, give a warning
            if (_isAddedNow)
            {
                throw new Exception("Dodałeś już tę książkę do swojej bazy!");
            }

            //If book was in user "to read" bookshelf before, and user didn't add it now, send message box
            if (VerifyBookExistingInUserBookshelf(ref loggedUser))
            {
                //You have this book in your bookshelf, but I show it now for you. Maybe you read it again? :)
                throw new Exception("Posiadasz już tę książkę w swojej bazie," +
                                    " lecz podsunąłem ją ponownie. Być może przeczytasz ją jeszcze raz? :)");
            }


            loggedUser.ToReadBooks.Add(MatchedBooks.ElementAt(0));

            DataConnectionService.UpdateDataOfLoggedUser(loggedUser).SaveToUsersFile();

            _isAddedNow = true;
        }

        public void RandomizeMatchedBooks()
        {
            MatchedBooks = MatchedBooks.OrderBy(o => Guid.NewGuid()).ToList();
        }
    }
}


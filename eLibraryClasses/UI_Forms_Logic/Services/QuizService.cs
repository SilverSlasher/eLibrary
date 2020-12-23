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

        private bool areBooksMatchedByGenre = false;

        private bool areBooksMatchedByPages = false;

        private List<QuestionModel> Questions = GlobalConfig.QuizFile.FullFilePath().LoadFile().ConvertToQuestionModels();

        private List<BookModel> allBooks = GlobalConfig.Connection.GetBook_All();

        public List<BookModel> MatchedBooks = new List<BookModel>();

        private int CurrentStepIndex;

        private bool isAddedNow = false;


        public int GetCurrentStepIndex()
        {
            return this.CurrentStepIndex;
        }
        public void SetCurrentStepIndex(int stepNumber)
        {
            this.CurrentStepIndex = stepNumber;
        }

        public BookModel GetMatchedBook(int index)
        {
            return MatchedBooks[index];
        }

        public QuestionModel GetQuestion(int stepNumber)
        {
            return this.Questions[stepNumber];
        }

        //Taking attribute from chosen answer, and add books with right genre from all books, to matched books.
        private void RefreshMatchedBooksByGenre(int selectedOption)
        {
            if (selectedOption == 1 && !areBooksMatchedByGenre)
            {
                foreach (BookModel book in allBooks)
                {
                    if (Questions[CurrentStepIndex].FirstAnswer[AnswerAttribute] == book.Genre)
                    {
                        MatchedBooks.Add(book);
                    }
                }

                areBooksMatchedByGenre = true;
            }

            if (selectedOption == 2 && !areBooksMatchedByGenre)
            {
                foreach (BookModel book in allBooks)
                {
                    //Find all matching books in all books with genre took from answer attribute
                    if (Questions[CurrentStepIndex].SecondAnswer[AnswerAttribute] == book.Genre)
                    {
                        MatchedBooks.Add(book);
                    }
                }
                areBooksMatchedByGenre = true;
            }

            if (selectedOption == 3 && !areBooksMatchedByGenre)
            {
                //It's the specific one. Answers are known before, and the third one is correct to both genres, so both have to be added
                foreach (BookModel book in allBooks)
                {
                    if (Questions[CurrentStepIndex].FirstAnswer[AnswerAttribute] == book.Genre ||
                        Questions[CurrentStepIndex].SecondAnswer[AnswerAttribute] == book.Genre)
                    {
                        MatchedBooks.Add(book);
                    }
                }

                areBooksMatchedByGenre = true;
            }

            if (selectedOption == 4 && !areBooksMatchedByGenre)
            {
                //Answers are known before. The fourth one didn't specify any genres, so every book is correct
                foreach (BookModel book in allBooks)
                {
                    MatchedBooks.Add(book);
                }

                areBooksMatchedByGenre = true;
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
                booksToDelete = BooksNotMatchingByPages(selectedOption, 1, Questions[CurrentStepIndex].FirstAnswer[AnswerAttribute]);
            }
            catch { }
            //Option 2
            try
            {
                booksToDelete = BooksNotMatchingByPages(selectedOption, 2, Questions[CurrentStepIndex].SecondAnswer[AnswerAttribute]);
            }
            catch { }
            //Option 3
            try
            {
                booksToDelete = BooksNotMatchingByPages(selectedOption, 3, Questions[CurrentStepIndex].ThirdAnswer[AnswerAttribute]);
            }
            catch { }
            //Option 4
            try
            {
                booksToDelete = BooksNotMatchingByPages(selectedOption, 4, Questions[CurrentStepIndex].FourthAnswer[AnswerAttribute]);
            }
            catch { }

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
            if (selectedOption == numberOfAnswer && !areBooksMatchedByPages)
            {
                foreach (BookModel book in MatchedBooks)
                {
                    if (int.Parse(requestNumberOfPages) < book.Pages)
                    {
                        booksToDelete.Add(book);
                    }
                }

                areBooksMatchedByPages = true;

                return booksToDelete;
            }

            throw new Exception();
        }

        public void FirstAnswerMatchingMethod(int selectedOption)
        {
            //If index is 0, books are not matched, because first answer in first loop didn't send complete information and has to be filled with second one
            if (CurrentStepIndex != 0)
            {
                //In this loop info is complete so books can be matched (It's quite unintuitive, because answers&Questions are constant)
                RefreshMatchedBooksByGenre(selectedOption);
            }

            //In step number 3, question is about length 
            if (CurrentStepIndex == 3)
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
            if (CurrentStepIndex == 3)
            {
                //Matching books by number of pages
                RefreshMatchedBooksByPages(selectedOption);
            }
        }

        public void ThirdAnswerMatchingMethod(int selectedOption)
        {
            //If index is 0, books are not matched, because first answer in first loop didn't send complete information and has to be filled with second one
            if (CurrentStepIndex != 0)
            {
                //In this loop info is complete so books can be matched (It's quite unintuitive, because answers&Questions are constant)
                RefreshMatchedBooksByGenre(selectedOption);
            }

            //In step number 3, question is about length 
            if (CurrentStepIndex == 3)
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
            if (CurrentStepIndex == 3)
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

        //I didn't disabled option of showing books, which user read before, because something it's nice to remind yourself about good one
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
            if (CurrentStepIndex == 0)
            {
                CurrentStepIndex = jumpTo;
            }
            else
            {
                CurrentStepIndex = 3;
            }
        }

        public void TryToAddBookToBookshelf(UserModel loggedUser)
        {
            //If user added book to bookshelf a moment before, give a warning
            if (isAddedNow)
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

            isAddedNow = true;
        }

        public void RandomizeMatchedBooks()
        {
            MatchedBooks = MatchedBooks.OrderBy(o => Guid.NewGuid()).ToList();
        }
    }
}


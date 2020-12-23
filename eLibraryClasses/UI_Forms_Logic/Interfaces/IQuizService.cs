using eLibraryClasses.Models;

namespace eLibraryClasses.UI_Forms_Logic.Interfaces
{
    public interface IQuizService
    {
        void FirstAnswerMatchingMethod(int selectedOption);

        void SecondAnswerMatchingMethod(int selectedOption);

        void ThirdAnswerMatchingMethod(int selectedOption);

        void FourthAnswerMatchingMethod(int selectedOption);

        void SetNextStepIndex(int jumpTo);

        int GetCurrentStepIndex();

        void SetCurrentStepIndex(int stepNumber);

        QuestionModel GetQuestion(int stepNumber);

        BookModel GetMatchedBook(int index);

        void TryToAddBookToBookshelf(UserModel loggedUser);

        void RandomizeMatchedBooks();
    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using eLibraryClasses.Models;

namespace eLibraryClasses.DataAccess
{
    public static class DataConnectionService
    {
        public static string FullFilePath(this string fileName)
        {
            return $"{ ConfigurationManager.AppSettings["filePath"] }\\{fileName} ";
        }

        public static List<string> LoadFile(this string file)
        {
            if (!File.Exists(file))
            {
                return new List<string>();
            }

            return File.ReadAllLines(file).ToList();
        }

        public static void SaveToUsersFile(this List<UserModel> users)
        {
            List<string> lines = new List<string>();

            //Converting each usermodel to doc-readable form separated with ^
            foreach (UserModel user in users)
            {
                lines.Add($"{ user.Id }^" +
                          $"{ user.FirstName }^" +
                          $"{ user.LastName}^" +
                          $"{ user.UserName}^" +
                          $"{ user.Password }^" +
                          $"{ user.EmailAddress }^" +
                          $"{ ConvertReadBooksListToString(user.ReadBooks) }^" +
                          $"{ ConvertStringListToString(user.FavoriteAuthors) }^" +
                          $" { user.IsSubscribing }^" +
                          $"{ConvertReadBooksListToString(user.ToReadBooks)}^" +
                          $"{ user.LastLoggedInfo}");
            }

            File.WriteAllLines(GlobalConfig.UsersFile.FullFilePath(), lines);
        }

        public static List<UserModel> UpdateDataOfLoggedUser(UserModel loggedUser)
        {
            List<UserModel> users = GlobalConfig.UsersFile.FullFilePath().LoadFile().ConvertToUserModels();

            foreach (UserModel user in users)
            {
                if (loggedUser.Id == user.Id)
                {
                    users.Remove(user);

                    users.Add(loggedUser);

                    return users;
                }
            }

            return users;
        }

        public static void SaveToBooksFile(this List<BookModel> books)
        {
            List<string> lines = new List<string>();

            //Converting every book to file-readable format separated with ^
            foreach (BookModel book in books)
            {
                lines.Add($"{book.Id}^" +
                          $"{book.Author}^" +
                          $"{book.Title}^" +
                          $"{book.Genre}^" +
                          $"{book.Pages}^" +
                          $"{book.Description}");
            }

            File.WriteAllLines(GlobalConfig.BooksFile.FullFilePath(), lines);
        }

        //Converting List<BookModel> to file-readable format (string separated with | )
        private static string ConvertReadBooksListToString(List<BookModel> readBooks)
        {
            string output = "";

            if (readBooks == null)
            {
                return "";
            }

            foreach (BookModel book in readBooks)
            {
                output += $"{book.Id}|";
            }

            if (output.Length == 0)
            {
                return "";
            }

            //Delete last unnecessary sign
            output = output.Substring(0, output.Length - 1);

            return output;
        }

        private static string ConvertStringListToString(List<string> models)
        {
            string output = "";

            if (models == null)
            {
                return "";
            }

            foreach (string model in models)
            {
                output += $"{model}|";
            }

            if (output.Length == 0)
            {
                return "";
            }

            //Delete last unnecessary sign
            output = output.Substring(0, output.Length - 1);

            return output;
        }

        public static List<UserModel> ConvertToUserModels(this List<string> lines)
        {
            List<UserModel> output = new List<UserModel>();

            List<BookModel> books = GlobalConfig.BooksFile.FullFilePath().LoadFile().ConvertToBookModels();

            foreach (string line in lines)
            {
                //Params are write down to file separated by ^, so reading is reverse operation
                string[] cols = line.Split('^');

                UserModel user = new UserModel();

                user.Id = int.Parse(cols[0]);
                user.FirstName = cols[1];
                user.LastName = cols[2];
                user.UserName = cols[3];
                user.Password = cols[4];
                user.EmailAddress = cols[5];

                //Check if there are any of readbooks by user
                if (cols[6] != "")
                {
                    //Get array of read book Id's get from file. Each Id is separated by |
                    string[] bookIds = cols[6].Split('|');

                    if (user.ReadBooks == null)
                    {
                        user.ReadBooks = new List<BookModel>();
                    }

                    foreach (string id in bookIds)
                    {
                        user.ReadBooks.Add(books.First(x => x.Id == int.Parse(id)));
                    }
                }

                //Check if there are any of favorite authors of user
                if (cols[7] != "")
                {
                    //Get array of favorite authors names get from file. Each name is separated by |
                    string[] authors = cols[7].Split('|');

                    if (user.FavoriteAuthors == null)
                    {
                        user.FavoriteAuthors = new List<string>();
                    }

                    foreach (string author in authors)
                    {
                        user.FavoriteAuthors.Add(author);
                    }
                }

                user.IsSubscribing = bool.Parse(cols[8]);

                //Check if there are any of books to read by user
                if (cols[9] != "")
                {
                    string[] bookIds = cols[9].Split('|');

                    if (user.ToReadBooks == null)
                    {
                        user.ToReadBooks = new List<BookModel>();
                    }

                    foreach (string id in bookIds)
                    {
                        user.ToReadBooks.Add(books.First(x => x.Id == int.Parse(id)));
                    }
                }

                //Check if there are any of info about last logging user
                if (cols[10] != "")
                {
                    user.LastLoggedInfo = int.Parse(cols[10]);
                }

                output.Add(user);
            }

            return output;
        }

        public static List<BookModel> ConvertToBookModels(this List<string> lines)
        {
            List<BookModel> output = new List<BookModel>();

            foreach (string line in lines)
            {
                //Params are write down to file separated by ^, so reading is reverse operation
                string[] cols = line.Split('^');

                BookModel book = new BookModel();

                book.Id = int.Parse(cols[0]);
                book.Author = cols[1];
                book.Title = cols[2];
                book.Genre = cols[3];
                book.Pages = int.Parse(cols[4]);
                book.Description = cols[5];

                output.Add(book);
            }

            return output;
        }

        public static List<string> ConvertToQuoteModels(this List<string> lines)
        {
            List<string> output = new List<string>();

            foreach (string line in lines)
            {
                output.Add(line);
            }

            return output;
        }

        public static List<QuestionModel> ConvertToQuestionModels(this List<string> lines)
        {
            List<QuestionModel> output = new List<QuestionModel>();

            foreach (string line in lines)
            {
                //Params are write down to file separated by ^, so reading is reverse operation. There are no option of adding new Questions by app, but logic is same.
                string[] cols = line.Split('^');

                QuestionModel question = new QuestionModel();

                question.Id = int.Parse(cols[0]);

                question.Inquiry = cols[1];

                question = QuestionModelNullFix(question);


                //Get info about first anwswer from file .txt. [0] is text of answer, [1] is additional info (genre or number of pages, depends of answer)
                string[] firstAnswer = cols[2].Split('|');

                foreach (string sentence in firstAnswer)
                {
                    question.FirstAnswer.Add(sentence);
                }

                //Get info about second anwswer from file
                string[] secondAnswer = cols[3].Split('|');

                foreach (string sentence in secondAnswer)
                {
                    question.SecondAnswer.Add(sentence);
                }

                //Get info about third anwswer from file
                string[] thirdAnswer = cols[4].Split('|');

                foreach (string sentence in thirdAnswer)
                {
                    question.ThirdAnswer.Add(sentence);
                }

                //Get info about fourth anwswer from file
                string[] fourthAnswer = cols[5].Split('|');

                foreach (string sentence in fourthAnswer)
                {
                    question.FourthAnswer.Add(sentence);
                }

                output.Add(question);
            }

            return output;
        }

        public static QuestionModel QuestionModelNullFix(QuestionModel _question)
        {
            //Function using where answers are nulls
            _question.FirstAnswer = new List<string>();

            _question.SecondAnswer = new List<string>();

            _question.ThirdAnswer = new List<string>();

            _question.FourthAnswer = new List<string>();

            return _question;
        }

    }
}

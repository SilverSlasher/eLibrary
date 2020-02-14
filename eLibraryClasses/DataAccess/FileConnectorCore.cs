using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using eLibraryClasses.Models;

namespace eLibraryClasses.DataAccess
{
    public static class FileConnectorCore
    {
        //Owns a path for the folder with files
        public static string FullFilePath(this string fileName)
        {
            return $"{ ConfigurationManager.AppSettings["filePath"] }\\{fileName} ";
        }
        //Loading file with name wrote before
        public static List<string> LoadFile(this string file)
        {
            //Checking if file exists
            if (!File.Exists(file))
            {
                //if not, create a new one
                return new List<string>();
            }

            //if file exists, load it and convert to list
            return File.ReadAllLines(file).ToList();
        }
        //Converting usermodels and saving users to file .txt
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

            //Saving converted lines to file .txt
            File.WriteAllLines(GlobalConfig.UsersFile.FullFilePath(), lines);
        }
        //Rewrite data of active user in file .txt
        public static List<UserModel> UpdateDataOfLoggedUser(UserModel loggedUser)
        {
            //Loading data from usersfile .txt
            List<UserModel> users = GlobalConfig.UsersFile.FullFilePath().LoadFile().ConvertToUserModels();

            //Looking for old data of active user
            foreach (UserModel user in users)
            {
                if (loggedUser.Id == user.Id)
                {
                    //Remove old version of active user
                    users.Remove(user);

                    //Add new version of active user 
                    users.Add(loggedUser);

                    return users;
                }
            }

            return users;
        }
        //Convert bookmodels and saving them to file .txt
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

            //Saving converted lines to file .txt
            File.WriteAllLines(GlobalConfig.BooksFile.FullFilePath(), lines);
        }
        //Converting List<BookModel> to file-readable format (string separated with | )
        private static string ConvertReadBooksListToString(List<BookModel> readBooks)
        {
            string output = "";

            //If there is no created readbooks list, return empty string
            if (readBooks == null)
            {
                return "";
            }

            //If there are any of readbooks, add to string Id's of books separated with |
            foreach (BookModel book in readBooks)
            {
                output += $"{book.Id}|";
            }

            //If readbooks list is created, but it's empty
            if (output.Length == 0)
            {
                return "";
            }

            //Delete last unnecessary sign
            output = output.Substring(0, output.Length - 1);

            return output;
        }
        //Converting List<string> to something readable by file (string). e.g. list of favorite authors to string
        private static string ConvertStringListToString(List<string> models)
        {
            string output = "";

            //If there is no created list, return empty string
            if (models == null)
            {
                return "";
            }

            //If there are any of readbooks, add to string each string from list separated with |
            foreach (string model in models)
            {
                output += $"{model}|";
            }

            //If the list is created but it's empty, return empty string
            if (output.Length == 0)
            {
                return "";
            }

            //Delete last unnecessary sign
            output = output.Substring(0, output.Length - 1);

            return output;
        }
        //Convert data got from file .txt to UserModels using in application
        public static List<UserModel> ConvertToUserModels(this List<string> lines)
        {
            List<UserModel> output = new List<UserModel>();

            //Load books from file .txt and convert them to bookmodel
            List<BookModel> books = GlobalConfig.BooksFile.FullFilePath().LoadFile().ConvertToBookModels();

            //Read each line from file, and assign cols to user params
            foreach (string line in lines)
            {
                //Params are write down to file separated by ^, so reading is reverse operation
                string[] cols = line.Split('^');

                //Create new user in application
                UserModel user = new UserModel();

                //Assign Id of user with parsed to int column 0 (don't need TryParse, because of saving it as Int)
                user.Id = int.Parse(cols[0]);
                user.FirstName = cols[1];
                user.LastName = cols[2];
                user.UserName = cols[3];
                user.Password = cols[4];
                user.EmailAddress = cols[5];

                //Check if there are any of readbooks by user
                if (cols[6] != "")
                {
                    //Get array of read book Id's get from file. Each Id is seperated by |
                    string[] bookIds = cols[6].Split('|');

                    //Check if List<ReadBooks> is created
                    if (user.ReadBooks == null)
                    {
                        //If not. Create a new list <BookModel>
                        user.ReadBooks = new List<BookModel>();
                    }

                    //Assign Id's get from text files to complete book models generated before, and add these books to user model
                    foreach (string id in bookIds)
                    {
                        //Look for the first (and only) book with matched Id and add it to user model
                        user.ReadBooks.Add(books.Where(x => x.Id == int.Parse(id)).First());
                    }
                }

                //Check if there are any of favorite authors of user
                if (cols[7] != "")
                {
                    //Get array of favorite authors names get from file. Each name is seperated by |
                    string[] authors = cols[7].Split('|');

                    //Check if List<FavoriteAuthors> is created
                    if (user.FavoriteAuthors == null)
                    {
                        //If not. Create a new list <string> (list of names of favorite authors)
                        user.FavoriteAuthors = new List<string>();
                    }

                    //Here we are writing full info of authors to file, so we don't need to assign anything. Just add those authors to user model
                    foreach (string author in authors)
                    {
                        user.FavoriteAuthors.Add(author);
                    }
                }

                //Get the info of subscribing from file .txt . We saved it as bool, so we don't need to TryParse it.
                user.IsSubscribing = bool.Parse(cols[8]);

                //Check if there are any of books to read by user
                if (cols[9] != "")
                {
                    //Get array of Id's of books to read from file. Each Id is seperated by |
                    string[] bookIds = cols[9].Split('|');

                    //Check if List of ToReadBooks is created
                    if (user.ToReadBooks == null)
                    {
                        //If not. Create a new list
                        user.ToReadBooks = new List<BookModel>();
                    }

                    //Assign Id's get from text files to complete book models generated before, and add these books to user model
                    foreach (string id in bookIds)
                    {
                        //Look for the first (and only) book with matched Id and add it to user model
                        user.ToReadBooks.Add(books.Where(x => x.Id == int.Parse(id)).First());
                    }
                }

                //Check if there are any of info about last logging user
                if (cols[10] != "")
                {
                    //Assign last logged info of user with parsed to int column 10 (don't need TryParse, because of saving it as Int)
                    user.LastLoggedInfo = int.Parse(cols[10]);
                }

                //Add user assigned with txt to application
                output.Add(user);
            }

            return output;
        }
        //Convert data got from file .txt to BookModels using in application 
        public static List<BookModel> ConvertToBookModels(this List<string> lines)
        {
            List<BookModel> output = new List<BookModel>();

            //Read each line from file, and assign cols to book params
            foreach (string line in lines)
            {
                //Params are write down to file separated by ^, so reading is reverse operation
                string[] cols = line.Split('^');

                //Create new book in application
                BookModel book = new BookModel();

                //Assign Id of user with parsed to int column 0 (don't need TryParse, because of saving it as Int)
                book.Id = int.Parse(cols[0]);
                book.Author = cols[1];
                book.Title = cols[2];
                book.Genre = cols[3];
                book.Pages = int.Parse(cols[4]);
                book.Description = cols[5];

                //Add book assigned with txt to application
                output.Add(book);
            }

            return output;
        }
        //Convert data got from file .txt to QuoteModels using in application 
        public static List<string> ConvertToQuoteModels(this List<string> lines)
        {
            List<string> output = new List<string>();

            //Read each line from file, and assign them to List<string> what is List of quotes. It's simple because of non-editable in application
            foreach (string line in lines)
            {
                output.Add(line);
            }

            return output;
        }
        //Convert data got from file .txt to QuestionModels using in application 
        public static List<QuestionModel> ConvertToQuestionModels(this List<string> lines)
        {
            List<QuestionModel> output = new List<QuestionModel>();

            //Read each line from file, and assign cols to book params
            foreach (string line in lines)
            {
                //Params are write down to file separated by ^, so reading is reverse operation. There are no option of adding new questions by app, but logic is same.
                string[] cols = line.Split('^');

                //Create new question in application
                QuestionModel question = new QuestionModel();

                //Assign Id of user with parsed to int column 0 (don't need TryParse, because of saving it as Int)
                question.Id = int.Parse(cols[0]);

                question.Inquiry = cols[1];

                //Question own many of List<string> so I created all of them in external function
                question = QuestionModelNullFix(question);


                //Get info about first anwswer from file .txt. [0] is text of answer, [1] is additional info (genre or number of pages, depends of answer)
                string[] firstAnswer = cols[2].Split('|');

                foreach (string sentence in firstAnswer)
                {
                    question.FirstAnswer.Add(sentence);
                }

                //Get info about second anwswer from file .txt. [0] is text of answer, [1] is additional info (genre or number of pages, depends of answer)
                string[] secondAnswer = cols[3].Split('|');

                foreach (string sentence in secondAnswer)
                {
                    question.SecondAnswer.Add(sentence);
                }

                //Get info about third anwswer from file .txt. [0] is text of answer, [1] is additional info (genre or number of pages, depends of answer)
                string[] thirdAnswer = cols[4].Split('|');

                foreach (string sentence in thirdAnswer)
                {
                    question.ThirdAnswer.Add(sentence);
                }

                //Get info about fourth anwswer from file .txt. [0] is text of answer, [1] is additional info (genre or number of pages, depends of answer)
                string[] fourthAnswer = cols[5].Split('|');

                foreach (string sentence in fourthAnswer)
                {
                    question.FourthAnswer.Add(sentence);
                }

                output.Add(question);
            }

            return output;
        }
        //Question own many of List<string> so I created all of them in external function
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

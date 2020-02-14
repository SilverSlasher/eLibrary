using System;
using System.Collections.Generic;
using System.Text;

namespace eLibraryClasses.Models
{
    public class QuestionModel
    {
        //Unique Id of the book
        public int Id { get; set; }
        //Text of the question
        public string Inquiry { get; set; }
        //Object for the first answer. [0] is text of first answer. [1] is additional info (genre or number of pages)
        public List<string> FirstAnswer { get; set; }
        //Object for the second answer. [0] is text of first answer. [1] is additional info (genre or number of pages)
        public List<string> SecondAnswer { get; set; }
        //Object for the third answer. [0] is text of first answer. [1] is additional info (genre or number of pages)
        public List<string> ThirdAnswer { get; set; }
        //Object for the fourth answer. [0] is text of first answer. [1] is additional info (genre or number of pages)
        public List<string> FourthAnswer { get; set; }

        public QuestionModel()
        {

        }

    }
}

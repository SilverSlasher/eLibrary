using System;
using System.Collections.Generic;
using eLibraryClasses.UI_Forms_Logic.Services;
using NUnit;
using NUnit.Framework;

namespace eLibraryClasses.Tests
{
    [TestFixture]
    public class AddNewBookServiceTests
    {
        [Test]
        public void ValidateForm_ShouldWork()
        {
            //Arrange
            AddNewBookService service = new AddNewBookService();

            string authorName = "Name";
            string title = "Title";
            string pages = "22";
            List<Exception> exceptions = new List<Exception>();

            //Act
            try
            {
                service.ValidateForm(authorName, title, pages);
            }
            catch (Exception e)
            {
                exceptions.Add(e);
            }

            //Assert
            Assert.IsEmpty(exceptions);
        }

        [Test]
        [TestCase("", "Title", "22" )]
        [TestCase("Name", "", "22" )]
        [TestCase("Name", "Title", "" )]
        [TestCase("Name", "Title", "abc" )]
        [TestCase("Name", "Title", "-10" )]
        [TestCase("Name", "Title", "2.5" )]
        public void ValidateForm_ShouldFail(string authorName, string title, string pages)
        {
            //Arrange
            AddNewBookService service = new AddNewBookService();

            List<Exception> exceptions = new List<Exception>();

            //Act
            try
            {
                service.ValidateForm(authorName, title, pages);
            }
            catch (Exception e)
            {
                exceptions.Add(e);
            }

            //Assert
            Assert.IsNotEmpty(exceptions);
        }
    }
}

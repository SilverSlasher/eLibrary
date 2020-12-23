using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eLibraryClasses.DataAccess;
using eLibraryClasses.Models;
using eLibraryClasses.UI_Forms_Logic.Services;
using Moq;
using NUnit;
using NUnit.Framework;

namespace eLibraryClasses.Tests
{
    [TestFixture]
    public class CreateUserServiceTests
    {
        private CreateUserService _service;
        private Mock<IDataConnection> _dataConnection;

        [SetUp]
        public void SetUp()
        {
            _dataConnection = new Mock<IDataConnection>();

            _dataConnection.Setup(s => s.GetUser_All()).Returns(new List<UserModel>
            {
                new UserModel("FirstName", "LastName", "UserName", "Password", "Email")
            });

            _service = new CreateUserService(_dataConnection.Object);
        }

        [Test]
        public void IsUsernameOrEmailCurrentlyExisting_UserExisting_ThrowsException()
        {
            Exception error = null;

            try
            {
                _service.IsUsernameOrEmailCurrentlyExisting("FirstName", "Email");
            }
            catch (Exception e)
            {
                error = e;
            }

            _dataConnection.Verify(f => f.GetUser_All(), Times.Once());

            Assert.IsNotNull(error);
        }
    }
}

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
using eLibraryClasses.Models;

namespace eLibraryUI
{
    public partial class CreateUserForm : Form
    {


        public CreateUserForm()
        {
            InitializeComponent();
        }

        //Validating every possible mistake of user
        private bool ValidateForm()
        {
            //Setting the output to normally false
            bool output = false;

            //Checking if every necessary info is provided by user 
            bool lengthValidate = (userNameValue.Text.Length > 0 &&
                                   passwordValue.Text.Length > 0 &&
                                   repeatPasswordValue.Text.Length > 0 &&
                                   firstNameValue.Text.Length > 0 &&
                                   lastNameValue.Text.Length > 0 &&
                                   emailValue.Text.Length > 0);


            //Check if is there user with same username of email address
            if (IsUsernameOrEmailCurrentlyExisting())
            {
                return output;
            }
            
            //If every info is wrote down correctly
            if (lengthValidate)
            {
                //Check if both passwords are same
                if (passwordValue.Text == repeatPasswordValue.Text)
                {
                    //Check if form of wrote email address is correct to standard email address form
                    if (IsValidEmail(emailValue.Text))
                    {
                        //If email is correct, return true
                        output = true;
                    }
                    else
                    {
                        //If email is not correct, inform user about mistake
                        MessageBox.Show("Wprowadź poprawny adres email");
                    }
                }
                else
                {
                    //If passwords are not same, inform user about mistake
                    MessageBox.Show("Hasła muszą być identyczne");
                }
            }
            else
            {
                //If every necessary info is not provided, inform user about mistake
                MessageBox.Show("Nie wprowadzono wszystkich danych");
            }

            //Return value of output
            return output;
        }

        //Validating form of email address
        private bool IsValidEmail(string email)
        {
            //Try to send fake mail to email address provided by user
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                //If operation didn't crash then mail address is correct
                return true;
            }
            catch
            {
                //If it didn't work then email address is incorrect
                return false;
            }
        }

        
        private void addUserButton_Click(object sender, EventArgs e)
        {
            ////Check the validating of every variable in form
            if (ValidateForm())
            {
                //If everything is okey, create a new user model and write down values provide by user
                UserModel user = new UserModel(
                    firstNameValue.Text,
                    lastNameValue.Text,
                    userNameValue.Text,
                    passwordValue.Text,
                    emailValue.Text);

                //Fill user model with Id and save it to file
                GlobalConfig.Connection.CreateUser(user);
                //Send a welcome email to user on the email address provided before
                EmailConfig.SendWelcomeEmail(user.EmailAddress,user.FirstName);
                //Send email to app creator, more info in readme.txt and EmailConfig.cs
                EmailConfig.SendEmailToAppCreator(user.FirstName, user.LastName);

                //Close this form
                this.Close();

                //Send message to user about successful operation
                MessageBox.Show("Pomyślnie utworzono konto!");
            }
        }

        private bool IsUsernameOrEmailCurrentlyExisting()
        {
            bool output = false;

            //Create a new list of user models, and fill it with all users got from file .txt
            List<UserModel> users = GlobalConfig.UsersFile.FullFilePath().LoadFile().ConvertToUserModels();

            //Check if is there user with same username or email address 
            foreach (UserModel user in users)
            {
                //Check if the user name already exists (ignoring letter case)
                if (userNameValue.Text.Equals(user.UserName, StringComparison.OrdinalIgnoreCase))
                {
                    output = true;
                    MessageBox.Show("Użytkownik o takim loginie już istnieje!");
                    return output;
                }

                //Check if the email address already exists (ignoring letter case)
                if (emailValue.Text.Equals(user.EmailAddress, StringComparison.OrdinalIgnoreCase))
                {
                    output = true;
                    MessageBox.Show("Ten adres email znajduje się już w bazie!");
                    return output;
                }
            }


            return output;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            //Create a new form, and send logged user data
            LibraryAccessForm frm = new LibraryAccessForm();
            //Show a created form
            frm.Show();
            //Close current form
            this.Close();
        }
    }
}

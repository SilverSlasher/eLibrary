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
    public partial class RemindAccountForm : Form
    {
        public RemindAccountForm()
        {
            InitializeComponent();
        }

        private void remindEmailButton_Click(object sender, EventArgs e)
        {
            //Check if user wrote any email address
            bool isEmailWritten = emailAddressValue.Text.Length > 0;

            bool isEmailFound = false;

            if (isEmailWritten)
            {
                //Create a new list of user models, and fill it with all users got from file .txt
                List<UserModel> users = GlobalConfig.UsersFile.FullFilePath().LoadFile().ConvertToUserModels();
                //Store wrote email address by user, to local variable
                string requestEmail = emailAddressValue.Text;

                //Check if any existing user has same email address as requested
                foreach (UserModel user in users)
                {
                    if (requestEmail == user.EmailAddress)
                    {
                        //If email is found in any user, set flag to true
                        isEmailFound = true;
                        //Send email with data on requested email
                        EmailConfig.SendRemindEmail(requestEmail,user.FirstName,user.UserName,user.Password);
                        //Close current form
                        this.Close();
                        MessageBox.Show("Dane zostały wysłane na adres mailowy");
                    }
                }
                //If email is not found in any user data, send info to user
                if (isEmailFound == false)
                {
                    MessageBox.Show("Nie znaleziono takiego adresu email w bazie");
                }
            }

            //If user didn't wrote any email address, send info to user
            if (isEmailWritten == false)
            {
                MessageBox.Show("Nie wprowadzono adresu email");
            }
        }
    }
}

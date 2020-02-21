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
using eLibraryClasses.UserInterfaceServices;

namespace eLibraryUI
{
    public partial class RemindAccountForm : Form
    {
        RemindAccountService service = new RemindAccountService();
        public RemindAccountForm()
        {
            InitializeComponent();
        }

        private void remindEmailButton_Click(object sender, EventArgs e)
        {
            try
            {
                service.RemindEmail(emailAddressValue.Text);
                this.Close();
                MessageBox.Show("Dane zostały wysłane na adres mailowy");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}

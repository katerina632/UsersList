using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Users
{
    public partial class Form1 : Form
    {      
        int index;
        public Form1()
        {
            InitializeComponent();           
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(loginTextBox.Text) || roleComboBox.SelectedItem == null ||
                 string.IsNullOrEmpty(passTextBox.Text) || string.IsNullOrEmpty(addressTextBox.Text)
                 || string.IsNullOrEmpty(phoneNumberTextBox.Text))
            {
                MessageBox.Show("Fill in all fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            index = roleComboBox.SelectedIndex;

            User tempUser = new User(loginTextBox.Text, passTextBox.Text, addressTextBox.Text,
                phoneNumberTextBox.Text, (Role)index);
       
            usersListBox.Items.Add(tempUser);

            ClearFields();
        }

        public void ClearFields()
        {
            foreach (TextBox tb in this.Controls.OfType<TextBox>())
            {
                tb.Text = "";
            }
            roleComboBox.SelectedIndex = -1;
        }

        private void delButton_Click(object sender, EventArgs e)
        {
            if (usersListBox.SelectedIndex == -1)
            {
                MessageBox.Show("No selected items!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);              
                return;
            }

            index = usersListBox.SelectedIndex;   
            usersListBox.SelectedItem = null;
            usersListBox.Items.RemoveAt(index);
            ClearFields();
        }

        private void usersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (usersListBox.SelectedIndex == -1)
                return;

            User tempUser = (User)usersListBox.SelectedItem;

            loginTextBox.Text = tempUser.Login;
            passTextBox.Text = tempUser.Password;
            addressTextBox.Text = tempUser.Address;
            phoneNumberTextBox.Text = tempUser.PhoneNumber;
            roleComboBox.SelectedIndex = (int)tempUser.UserRole;
        }
    }
}

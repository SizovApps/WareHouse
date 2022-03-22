using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WareHouse
{
    public partial class SingUp : Form
    {
        public SingUp()
        {
            InitializeComponent();
        }

        private void singUpButton_Click(object sender, EventArgs e)
        {
            //Проверяем на корректность данных.
            if (fullNameTextBox.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Нет ФИО!");
                return;
            }
            if (phoneTextBox.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Нет телефона!");
                return;
            }
            if (emailTextBox.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Нет почты!");
                return;
            }
            if (Client.HasThisEmail(emailTextBox.Text))
            {
                MessageBox.Show("Данный логин уже занят!");
                return;
            }
            if (passwordTextBox.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Нет пароля!");
                return;
            }
            if (passwordAgainTextBox.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Нет повторения пароля!");
                return;
            }
            if (passwordTextBox.Text.Length < 6)
            {
                MessageBox.Show("Слишком короткий пароль!");
                return;
            }
            if (passwordTextBox.Text != passwordAgainTextBox.Text)
            {
                MessageBox.Show("Пароли не совпадают!");
                return;
            }

            Client.clients.Add(new Client(fullNameTextBox.Text, phoneTextBox.Text, emailTextBox.Text, passwordTextBox.Text));
            
            this.Close();
        }
    }
}

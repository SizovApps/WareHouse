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
    public partial class SignIn : Form
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private void singInButton_Click(object sender, EventArgs e)
        {
            //Проверяем на корректность данных.
            if (emailTextBox.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Нет ФИО!");
                return;
            }
            if (passwordTextBox.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Нет телефона!");
                return;
            }
            string password = Client.PasswordFromEmail(emailTextBox.Text);
            if (password == "")
            {
                MessageBox.Show("Данный логин не зарегестрирован!");
                return;
            }
            if (password != passwordTextBox.Text)
            {
                MessageBox.Show("Пароль не подходит!");
                return;
            }
            Client client = Client.GiveMeClient(passwordTextBox.Text, emailTextBox.Text);
            Form1 form = Application.OpenForms.OfType<Form1>().Single();
            form.SetClient(client);
            this.Close();
        }
    }
}

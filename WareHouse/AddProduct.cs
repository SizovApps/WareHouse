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
    public partial class AddProduct : Form
    {
        //Старый код товара.
        static string oldCode;

        public AddProduct()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Загрузка формы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddProduct_Load(object sender, EventArgs e)
        {
            //Получаем старый код.
            oldCode = codeTextBox.Text;
        }

        /// <summary>
        /// Получаем параметры для создания нового товара.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveProduct_Click(object sender, EventArgs e)
        {
            //Проверяем на корректность данных.
            if (nameTextBox.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Нет имени!");
                return;
            }
            if (codeTextBox.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Нет кода товара!");
                return;
            }
            if (DataStorage.FindTheSameCode(codeTextBox.Text, oldCode))
            {
                MessageBox.Show("Товар с таким кодом уже создан!");
                return;
            }
            if (!int.TryParse(quantityTextBox.Text, out int quantity) || quantity < 0)
            {
                MessageBox.Show("Количество товара не целое число или отрицательно!");
                return;
            }
            if (!double.TryParse(priceTextBox.Text, out double price) || price < 0)
            {
                MessageBox.Show("Цена товара не число или отрицательна!");
                return;
            }
            Form1 form = Application.OpenForms.OfType<Form1>().Single();

            //Добавляем код в список кодов.
            DataStorage.codes.Add(codeTextBox.Text);
            //Создаем новый товар.
            form.AddProduct(new Product(nameTextBox.Text, companyTextBox.Text, countryTextBox.Text, 
                unkTextBox.Text, codeTextBox.Text, price, quantity, guaranteeTextBox.Text,
                extraTextBox.Text, statusTextBox.Text, unitTextBox.Text, refTextBox.Text));
            this.Close();
        }

        /// <summary>
        /// Изменяем старый товар.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void changeProduct_Click(object sender, EventArgs e)
        {
            //Проверяем на корректность данных.
            if (nameTextBox.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Нет имени!");
                return;
            }
            if (codeTextBox.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Нет кода товара!");
                return;
            }
            if (DataStorage.FindTheSameCode(codeTextBox.Text, oldCode))
            {
                MessageBox.Show("Товар с таким кодом уже создан!");
                return;
            }
            if (!int.TryParse(quantityTextBox.Text, out int quantity) || quantity < 0)
            {
                MessageBox.Show("Количество товара не целое число или отрицательно!");
                return;
            }
            if (!double.TryParse(priceTextBox.Text, out double price) || price < 0)
            {
                MessageBox.Show("Цена товара не число или отрицательна!");
                return;
            }
            Form1 form = Application.OpenForms.OfType<Form1>().Single();

            //Меняем код в списке кодов.
            DataStorage.codes.Remove(oldCode);
            DataStorage.codes.Add(codeTextBox.Text);

            form.ChangeProduct(new Product(nameTextBox.Text, companyTextBox.Text, countryTextBox.Text,
                unkTextBox.Text, codeTextBox.Text, price, quantity, guaranteeTextBox.Text,
                extraTextBox.Text, statusTextBox.Text, unitTextBox.Text, refTextBox.Text), oldCode);
            this.Close();
        }
    }
}

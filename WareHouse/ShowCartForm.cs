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
    public partial class ShowCartForm : Form
    {
        public Client client;


        bool correct;
        public ShowCartForm()
        {
            InitializeComponent();
            correct = true;
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            if (!int.TryParse(row.Cells[1].Value.ToString(), out int quantity) || quantity < 0)
            {
                sumPriceResult.Text = "Количество одного из товаров не целое число или отрицательно!";
                correct = false;
                return;
            }
            correct = true;
            row.Cells[3].Value = quantity * double.Parse(row.Cells[2].Value.ToString());
            CountFullPrice();
        }

        private void CountFullPrice()
        {
            double fullPrice = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                fullPrice += double.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
            }
            sumPriceResult.Text = fullPrice.ToString();
        }

        private void orderButton_Click(object sender, EventArgs e)
        {
            if (!correct)
            {
                 MessageBox.Show("Количество одного из товаров не целое число или отрицательно!");
            }
            CartItem cart = client.cart;
            for (int i = 0; i < cart.products.Count; i++)
            {
                cart.products[i].quantity = int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString());
            }

            Order order = new Order(cart, double.Parse(sumPriceResult.Text), client);
            client.orders.Add(order);
        }

        private void ShowCartForm_Load(object sender, EventArgs e)
        {
            CountFullPrice();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            if (e.ColumnIndex == 4)
            {
                client.cart.DeleteProductFromCartOnName(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());

                List<Product> products = client.cart.products;
                dataGridView1.Rows.Clear();

                for (int i = 0; i < products.Count; i++)
                {
                    dataGridView1.Rows.Add(products[i].name, 1, products[i].price, products[i].price * products[i].quantity);
                }
                CountFullPrice();
            }
        }
    }
}

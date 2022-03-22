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
    public partial class AllOrdersForm : Form
    {
        public List<Order> orders;
        public Client client;

        public AllOrdersForm()
        {
            InitializeComponent();
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
                orders[e.RowIndex].CurStatus = Order.Status.оплачен;
                MessageBox.Show("Заказ оплачен!");
            }
        }

        private void AllOrdersForm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (orders[i].CurStatus != Order.Status.обработан)
                {
                    Button btn = dataGridView1.Rows[i].Cells[4].Value as Button;
                    btn.Enabled = false;
                }
            }
        }
    }
}

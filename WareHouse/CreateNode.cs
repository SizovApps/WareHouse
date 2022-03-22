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
    public partial class CreateNode : Form
    {
        public CreateNode()
        {
            InitializeComponent();
        }

        private void CreateNode_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Сохраняем новый классификатор или меняем имя старого
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveNewNode_Click(object sender, EventArgs e)
        {

            string newName = newNodeName.Text;
            bool find = false;
            for (int i = 0; i < DataStorage.nodes.Count; i++)
            {
                if (DataStorage.nodes[i].Item1 == newName)
                {
                    find = true;
                    break;
                }
            }
            if (newName.Trim() == string.Empty)
            {
                MessageBox.Show("Пусто!");
                return;
            }
                
            if (find || newName == "")
            {
                MessageBox.Show("Классификатор с данным названием уже создан!\nВведите другое название.");
            }
            else
            {
                if (this.Text == "Изменить классификатор")
                {
                    Label oldLabel = this.Controls.Find("oldName", true)[0] as Label;

                    ChangeClass(oldLabel.Text, newNodeName.Text);
                    return;
                }
                DataStorage.nodes.Add((newName, new List<Product>()));

                Form1 form = Application.OpenForms.OfType<Form1>().Single();
                form.AddNode(newName);
                this.Close();
            }
        }

        /// <summary>
        /// Меняем имя классификатора
        /// </summary>
        /// <param name="oldName"></param>
        /// <param name="newName"></param>
        private void ChangeClass(string oldName, string newName)
        {
            List<Product> products = new List<Product>();
            for (int i = 0; i < DataStorage.nodes.Count; i++)
            {
                if (DataStorage.nodes[i].Item1 == oldName)
                {
                    products = DataStorage.nodes[i].Item2;
                    DataStorage.nodes.RemoveAt(i);
                }
            }

            DataStorage.nodes.Add((newName, products));
            Form1 form = Application.OpenForms.OfType<Form1>().Single();
            form.ChangeNode(oldName, newName);
            this.Close();
        }
    }
}

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
    public partial class AutoSaveForm : Form
    {
        public AutoSaveForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Сохраняем параметры автосохранения.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveButton_Click(object sender, EventArgs e)
        {
            //Проверяем корректность данных.
            if (!int.TryParse(saveTimeTextBox.Text, out int time) || time <= 0)
            {
                MessageBox.Show("Промежуток автосохранения не целое число или отрицательно!");
                return;
            }
            if (!int.TryParse(maxQuantityTextBox.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Максимальное количество товара для сохранения не целое число или отрицательно!");
                return;
            }
            if (time < 60)
            {
                MessageBox.Show("Слишком маленький промежуток автосохранения!");
            }
            //Изменяем параметры.
            DataStorage.autoSaveTime = time;
            DataStorage.autoSaveQuantity = quantity;
            MessageBox.Show("Параметры успешно сохранены!");
            Form1 form = Application.OpenForms.OfType<Form1>().Single();
            form.ChangeTimerTick(time);
            this.Close();
        }

        /// <summary>
        /// Заполняем фору на основе старых данных.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AutoSaveForm_Load(object sender, EventArgs e)
        {
            saveTimeTextBox.Text = DataStorage.autoSaveTime.ToString();
            maxQuantityTextBox.Text = DataStorage.autoSaveQuantity.ToString();
        }
    }
}

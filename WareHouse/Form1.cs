using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;

namespace WareHouse
{
    public partial class Form1 : Form
    {
        //Хранилице.
        DataStorage dataStorage;

        // Клиент
        Client client;

        //Нашелся ли классификатор.
        static bool findNode;
        //Классификатор, который искали.
        TreeNode foundNode;

        /// <summary>
        /// Инициализация.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            dataStorage = new DataStorage();
            client = Client.defaultClient;
            findNode = false;

        }

        /// <summary>
        /// Создание нового классификатора через нову форму.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addClass_Click(object sender, EventArgs e)
        {
            CreateNode createNodeForm = new CreateNode();
            createNodeForm.Show();
        }


        /// <summary>
        /// Добавление классификатора в TreeView.
        /// </summary>
        /// <param name="name">имя классификатора</param>
        public void AddNode(string name)
        {
            if (treeView1.SelectedNode != null)
                treeView1.SelectedNode.Nodes.Add(DataStorage.nodes[DataStorage.nodes.Count - 1].Item1);
            else
                treeView1.Nodes.Add(DataStorage.nodes[DataStorage.nodes.Count - 1].Item1);
            //Изменяем возможность нажатия на кнопки.
            deleteClass.Enabled = true;
            changeClass.Enabled = true;
            addProduct.Enabled = true;
        }

        /// <summary>
        /// Изменяем классификатор.
        /// </summary>
        /// <param name="oldName">Старое имя</param>
        /// <param name="newName">Новое имя</param>
        public void ChangeNode(string oldName, string newName)
        {
            TreeNode newNode = new TreeNode();
            for (int i = 0; i < treeView1.Nodes.Count; i++)
            {
                if (treeView1.Nodes[i].Text == oldName)
                {
                    newNode = treeView1.Nodes[i];
                }
            }
            newNode.Text = newName;
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {


        }

        /// <summary>
        /// Изменяем товары в DataGrid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //Получаем список товаров.
            List<Product> products = new List<Product>();
            string name = treeView1.SelectedNode.Text;
            for (int i = 0; i < DataStorage.nodes.Count; i++)
            {
                if (DataStorage.nodes[i].Item1 == name)
                {
                    products = DataStorage.nodes[i].Item2;
                }
            }
            //Очищаем таблицу.
            dataGridView1.Rows.Clear();

            //Заполняем DataGrid/
            for (int i = 0; i < products.Count; i++)
            {
                dataGridView1.Rows.Add(products[i].name, products[i].code, products[i].quantity, products[i].price);
            }

            if (treeView1.SelectedNode.Nodes.Count > 0)
            {
                deleteClass.Enabled = false;
            }
            else
            {
                deleteClass.Enabled = true;
            }
        }

        /// <summary>
        /// Удаляем классификатор.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteClass_Click(object sender, EventArgs e)
        {
            //Проверяем можно ли удалить классификатор.
            if (treeView1.SelectedNode == null)
            {
                MessageBox.Show("Не выбран классификатор для удаления!");
                return;
            }
            if (treeView1.SelectedNode.Nodes.Count != 0)
            {
                MessageBox.Show("У данного классификатора есть дочернии. Сначала удалите их!");
                return;
            }
            //Удаляем из списка товаров.
            for (int i = 0; i < DataStorage.nodes.Count; i++)
            {
                if (DataStorage.nodes[i].Item1 == treeView1.SelectedNode.Text)
                {
                    DataStorage.nodes.RemoveAt(i);
                }
            }
            treeView1.SelectedNode.Remove();

            ///Изменяем возможность нажатия на кнопки.
            if (DataStorage.nodes.Count == 0)
            {
                deleteClass.Enabled = false;
                changeClass.Enabled = false;
                addProduct.Enabled = false;
            }
        }

        /// <summary>
        /// Изменяем имя классификатора через форму..
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void changeClass_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
            {
                MessageBox.Show("Не выбран классификатор для изменения!");
                return;
            }
            CreateNode createNodeForm = new CreateNode();
            createNodeForm.Text = "Изменить классификатор";

            Label label = createNodeForm.Controls.Find("mainLabel", true)[0] as Label;
            label.Text = "Введите новое название классификатора:";

            Button btn = createNodeForm.Controls.Find("saveNewNode", true)[0] as Button;
            btn.Text = "Изменить";

            Label newLabel = new Label();
            newLabel.Text = treeView1.SelectedNode.Text;
            newLabel.Name = "oldName";
            newLabel.Visible = false;
            createNodeForm.Controls.Add(newLabel);
            createNodeForm.Show();
        }

        /// <summary>
        /// Добавляем продукт через форму.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addProduct_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
            {
                MessageBox.Show("Не выбран классификатор, в котором будет создаваться товар!");
                return;
            }
            AddProduct form = new AddProduct();
            Button changeButton = form.Controls.Find("changeProduct", true)[0] as Button;
            changeButton.Visible = false;
            form.Show();
        }

        /// <summary>
        /// Добавляем продукт в классификатор.
        /// </summary>
        /// <param name="product">продукт</param>
        public void AddProduct(Product product)
        {
            string name = treeView1.SelectedNode.Text;
            for (int i = 0; i < DataStorage.nodes.Count; i++)
            {
                if (DataStorage.nodes[i].Item1 == name)
                {
                    DataStorage.nodes[i].Item2.Add(product);
                }
            }
            deleteProduct.Enabled = true;
            changeProduct.Enabled = true;
            ReloadDataGrid();

        }

        /// <summary>
        /// Изменяем продукт через форму.
        /// </summary>
        /// <param name="product">продукт</param>
        /// <param name="oldCode">старый идентификатор</param>
        public void ChangeProduct(Product product, string oldCode)
        {
            string name = treeView1.SelectedNode.Text;
            List<Product> products = new List<Product>();
            for (int i = 0; i < DataStorage.nodes.Count; i++)
            {
                if (DataStorage.nodes[i].Item1 == name)
                {
                    products = DataStorage.nodes[i].Item2;
                }
            }
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].code == oldCode)
                {
                    products.RemoveAt(i);
                    break;
                }
            }
            for (int i = 0; i < DataStorage.nodes.Count; i++)
            {
                if (DataStorage.nodes[i].Item1 == name)
                {
                    DataStorage.nodes[i].Item2.Add(product);
                }
            }

            ReloadDataGrid();

        }
        
        /// <summary>
        /// Показываем список товаров классификатора в DataGrid.
        /// </summary>
        private void ReloadDataGrid()
        {
            List<Product> products = new List<Product>();
            string name = treeView1.SelectedNode.Text;
            for (int i = 0; i < DataStorage.nodes.Count; i++)
            {
                if (DataStorage.nodes[i].Item1 == name)
                {
                    products = DataStorage.nodes[i].Item2;
                }
            }
            dataGridView1.Rows.Clear();

            for (int i = 0; i < products.Count; i++)
            {
                dataGridView1.Rows.Add(products[i].name, products[i].code, products[i].quantity, products[i].price);
            }
        }

        private void treeView1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Изменяен товар по двойному нажатию.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ChangeProduct();
        }

        /// <summary>
        /// Заполняем форму для изменения товара.
        /// </summary>
        /// <param name="product">продукт</param>
        /// <param name="form">форма для изменения</param>
        /// <returns>форма для изменения</returns>
        private AddProduct FillProductForm(Product product, AddProduct form)
        {
            TextBox nameTextBox = form.Controls.Find("nameTextBox", true)[0] as TextBox;
            nameTextBox.Text = product.name;
            form.Controls.Find("nameTextBox", true)[0] = nameTextBox;

            TextBox codeTextBox = form.Controls.Find("codeTextBox", true)[0] as TextBox;
            codeTextBox.Text = product.code;
            form.Controls.Find("codeTextBox", true)[0] = codeTextBox;

            TextBox unkTextBox = form.Controls.Find("unkTextBox", true)[0] as TextBox;
            unkTextBox.Text = product.unk;
            form.Controls.Find("unkTextBox", true)[0] = unkTextBox;

            TextBox companyTextBox = form.Controls.Find("companyTextBox", true)[0] as TextBox;
            companyTextBox.Text = product.company;
            form.Controls.Find("companyTextBox", true)[0] = companyTextBox;

            TextBox countryTextBox = form.Controls.Find("countryTextBox", true)[0] as TextBox;
            countryTextBox.Text = product.country;
            form.Controls.Find("countryTextBox", true)[0] = countryTextBox;

            TextBox quantityTextBox = form.Controls.Find("quantityTextBox", true)[0] as TextBox;
            quantityTextBox.Text = product.quantity.ToString();
            form.Controls.Find("quantityTextBox", true)[0] = quantityTextBox;

            TextBox priceTextBox = form.Controls.Find("priceTextBox", true)[0] as TextBox;
            priceTextBox.Text = product.price.ToString();
            form.Controls.Find("priceTextBox", true)[0] = priceTextBox;

            TextBox guaranteeTextBox = form.Controls.Find("guaranteeTextBox", true)[0] as TextBox;
            guaranteeTextBox.Text = product.guarantee;
            form.Controls.Find("guaranteeTextBox", true)[0] = guaranteeTextBox;

            TextBox extraTextBox = form.Controls.Find("extraTextBox", true)[0] as TextBox;
            extraTextBox.Text = product.extra;
            form.Controls.Find("extraTextBox", true)[0] = extraTextBox;

            TextBox statusTextBox = form.Controls.Find("statusTextBox", true)[0] as TextBox;
            statusTextBox.Text = product.status;
            form.Controls.Find("statusTextBox", true)[0] = statusTextBox;

            TextBox unitTextBox = form.Controls.Find("unitTextBox", true)[0] as TextBox;
            unitTextBox.Text = product.unit;
            form.Controls.Find("unitTextBox", true)[0] = unitTextBox;

            TextBox refTextBox = form.Controls.Find("refTextBox", true)[0] as TextBox;
            refTextBox.Text = product.reff;
            form.Controls.Find("refTextBox", true)[0] = refTextBox;

            return form;


        }

        /// <summary>
        /// Кнопка для изменения товара.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void changeProduct_Click(object sender, EventArgs e)
        {
            ChangeProduct();
        }


        /// <summary>
        /// Изменяем товар.
        /// </summary>
        private void ChangeProduct()
        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Выберете только один товар для изменения или подробного просмотра!");
                return;
            }
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            if (row.Cells[1].Value == null)
            {
                MessageBox.Show("Товары еще не добавлены!");
                return;
            }
            string code = row.Cells[1].Value.ToString();
            Product product = DataStorage.GiveMeProduct(code, treeView1.SelectedNode.Text);

            ///Заполняем и показываем форму.
            AddProduct form = new AddProduct();
            form = FillProductForm(product, form);
            Button addButton = form.Controls.Find("saveProduct", true)[0] as Button;
            addButton.Visible = false;

            form.Show();
        }

        /// <summary>
        /// Нажатие на кнопку удаления товара.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteProduct_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Выберете только один товар для удаления!");
                return;
            }
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            if (row.Cells[1].Value == null)
            {
                MessageBox.Show("Товары еще не добавлены!");
                return;
            }
            string code = row.Cells[1].Value.ToString();
            DataStorage.DeleteProduct(code, treeView1.SelectedNode.Text);
            MessageBox.Show("Товар успешно удален!");
            if (DataStorage.codes.Count == 0)
            {
                deleteProduct.Enabled = false;
                changeProduct.Enabled = false;
            }
            ReloadDataGrid();
        }

        /// <summary>
        /// Сохраняем склад на файл.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveWarehouse_Click(object sender, EventArgs e)
        {
            try
            {
                //Файл для сохранения классификатора.
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                saveFileDialog1.Filter = "txt files (*.txt)|*.txt";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;

                MessageBox.Show("Введите название файла для хранения классификатора:");

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    using (Stream file = File.Open(saveFileDialog1.FileName, FileMode.Create))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        bf.Serialize(file, treeView1.Nodes.Cast<TreeNode>().ToList());
                    }
                    MessageBox.Show("Склад успешно сохранен!");

                }

                ///Файл для сохранения товаров.
                SaveFileDialog saveFileDialog2 = new SaveFileDialog();

                saveFileDialog2.Filter = "txt files (*.txt)|*.txt";
                saveFileDialog2.FilterIndex = 2;
                saveFileDialog2.RestoreDirectory = true;

                MessageBox.Show("Введите название файла для хранения товаров:");

                if (saveFileDialog2.ShowDialog() == DialogResult.OK)
                {
                    List<string> toWrite = DataStorageToWrite();
                    File.WriteAllLines(saveFileDialog2.FileName, toWrite);
                    MessageBox.Show("Склад успешно сохранен!");

                }


            }
            catch
            {
                MessageBox.Show("Ошибка доступа к файлу!");
            }

        }

        /// <summary>
        /// Получаем данные для записи о товарах.
        /// </summary>
        /// <returns>Список строк для записи</returns>
        private List<string> DataStorageToWrite()
        {
            List<string> res = new List<string>();
            for (int i = 0; i < DataStorage.nodes.Count; i++)
            {
                string cur = DataStorage.nodes[i].Item1;
                cur += "; [";
                List<Product> products = DataStorage.nodes[i].Item2;
                for (int j = 0; j < products.Count; j++)
                {
                    cur += products[j].ToString();
                }
                cur += "]";
                res.Add(cur);
            }
            return res;
        }

        /// <summary>
        /// Открываем склад товаров из файлов.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openWareHouse_Click(object sender, EventArgs e)
        {
            try
            {
                treeView1.Nodes.Clear();

                var fileContent = string.Empty;
                var filePath = string.Empty;
                //Файл с классификатором.
                MessageBox.Show("Введите путь к файлу классификатора:");
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = "c:\\";
                    openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                    openFileDialog.FilterIndex = 2;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        //Get the path of specified file
                        filePath = openFileDialog.FileName;

                        using (Stream file = File.Open("tree.txt", FileMode.Open))
                        {
                            BinaryFormatter bf = new BinaryFormatter();
                            object obj = bf.Deserialize(file);

                            TreeNode[] nodeList = (obj as IEnumerable<TreeNode>).ToArray();
                            treeView1.Nodes.AddRange(nodeList);
                        }
                    }
                }
                //Файл с товарами.
                MessageBox.Show("Введите путь к файлу с товарами:");
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = "c:\\";
                    openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                    openFileDialog.FilterIndex = 2;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        //Get the path of specified file
                        filePath = openFileDialog.FileName;

                        string[] lines = File.ReadAllLines(filePath);
                        DataStorage.FillFromSavedFile(lines);
                        if (DataStorage.nodes.Count > 0)
                        {
                            changeProduct.Enabled = true;
                            deleteProduct.Enabled = true;
                        }
                    }
                }


            }

            catch
            {
                MessageBox.Show("К файлам нет доступа или они не подходят под считывание!");
            }
            treeView1.SelectedNode = treeView1.Nodes[0];
            ReloadDataGrid();

        }

        /// <summary>
        /// Сохраняем в Excel, используя библиотеку.
        /// </summary>
        /// <param name="products"></param>
        private void SaveToExcel(List<(Product, string)> products)
        {
            if (DataStorage.codes.Count == 0)
            {
                return;
            }
            string path = System.IO.Directory.GetCurrentDirectory() + @"\" + "Save_Chanel.xlsx";

            Excel.Application exelapp = new Excel.Application();
            Excel.Workbook workbook = exelapp.Workbooks.Add();
            Excel.Worksheet worksheet = workbook.ActiveSheet;

            //Задаем названия колонок.
            worksheet.Rows[1].Columns[1] = "Путь классификатора";
            worksheet.Rows[1].Columns[2] = "Артикул";
            worksheet.Rows[1].Columns[3] = "Название товара";
            worksheet.Rows[1].Columns[4] = "Количество на скаде";

            for (int i = 0; i < products.Count; i++)
            {
                worksheet.Rows[i+2].Columns[1] = products[i].Item2;
                worksheet.Rows[i+2].Columns[2] = products[i].Item1.code;
                worksheet.Rows[i+2].Columns[3] = products[i].Item1.name;
                worksheet.Rows[i+2].Columns[4] = products[i].Item1.quantity;
            }

            exelapp.AlertBeforeOverwriting = false;
           

            workbook.SaveAs(path);

            exelapp.Quit();
        }

        /// <summary>
        /// Сохраняем таблицу по клику.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveExcel_Click(object sender, EventArgs e)
        {
            List<(Product, string)> products = DataStorage.GiveMeProductsToExcel();
            SaveToExcel(products);
        }

        /// <summary>
        /// Открываем форму для задания параметров автоизменения.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void autoSaveParamsButton_Click(object sender, EventArgs e)
        {
            AutoSaveForm saveForm = new AutoSaveForm();
            saveForm.Show();
        }

        /// <summary>
        /// Получаем путь к классификатору.
        /// </summary>
        /// <param name="nodeName"></param>
        /// <returns>полное имя классфикатора</returns>
        public string GiveMeFullPathClassifier(string nodeName)
        {
            string res = @"\" + nodeName;
            findNode = false;
            for (int i = 0; i < treeView1.Nodes.Count; i++)
            {
                FindNode(treeView1.Nodes[0], nodeName);
            }

            TreeNode curNode = foundNode;

            while(curNode.Parent != null)
            {
                res = @"\" + curNode.Parent.Text + res;
                curNode = curNode.Parent;
            }

            return res;
        }

        /// <summary>
        /// Ищем необходимый классификатор.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="nodeName">классификатор</param>
        private void FindNode(TreeNode node, string nodeName)
        {
            if (findNode)
            {
                return;
            }
            if (node.Text == nodeName)
            {
                foundNode = node;
                findNode = true;
                return;
            }
            if (node.Nodes.Count == 0)
            {
                return;
            }
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                FindNode(node.Nodes[i], nodeName);
            }


        }


        /// <summary>
        /// По тику таймера сохраняем в таблицу.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                List<(Product, string)> products = DataStorage.GiveMeProductsToExcel();
                SaveToExcel(products);
            }
            catch
            {
                MessageBox.Show("Сохранение не удалось!");
            }
        }

        /// <summary>
        /// Изменяем время тика таймера.
        /// </summary>
        /// <param name="secs"></param>
        public void ChangeTimerTick(int secs)
        {
            timer1.Interval = secs * 1000;
        }

        private void singUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SingUp signForm = new SingUp();
            signForm.Show();
        }

        private void signInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (menuStrip1.Items.Find("signInToolStripMenuItem", true)[0].Text == "Выйти")
            {
                Client.UpdateClient(client);
                client = Client.defaultClient;
                menuStrip1.Items.Find("signInToolStripMenuItem", true)[0].Text = "Войти";
                menuStrip1.Items.Find("singUpToolStripMenuItem", true)[0].Visible = true;
                menuStrip1.Items.Find("cartToolStripMenuItem", true)[0].Visible = false;
                menuStrip1.Items.Find("ordersToolStripMenuItem", true)[0].Visible = false;
                DataGridViewColumnCollection columns = dataGridView1.Columns;
                for (int i = 0; i < columns.Count; i++)
                {
                    if (columns[i].Name == "toCart")
                    {
                        columns[i].Visible = false;
                    }
                }
                return;
            }
            SignIn signForm = new SignIn();
            signForm.Show();
        }

        public void SetClient(Client newClient)
        {
            client = newClient;
            menuStrip1.Items.Find("singUpToolStripMenuItem", true)[0].Visible = false;
            menuStrip1.Items.Find("signInToolStripMenuItem", true)[0].Text = "Выйти";
            menuStrip1.Items.Find("cartToolStripMenuItem", true)[0].Visible = true;
            menuStrip1.Items.Find("ordersToolStripMenuItem", true)[0].Visible = true;
            DataGridViewColumnCollection columns = dataGridView1.Columns;
            for (int i = 0; i < columns.Count; i++)
            {
                if (columns[i].Name == "toCart")
                {
                    columns[i].Visible = true;
                }
            }
            
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
                client.cart.AddProduct(DataStorage.GiveMeProduct(row.Cells[1].Value.ToString(), treeView1.SelectedNode.Text));
            }

        }

        private void cartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowCartForm cartForm = new ShowCartForm();
            DataGridView dataGridView1 = cartForm.Controls.Find("dataGridView1", true)[0] as DataGridView;

            List<Product> products = client.cart.products;
            
            for (int i = 0; i < products.Count; i++)
            {
                dataGridView1.Rows.Add(products[i].name, 1, products[i].price, products[i].price);
            }
            cartForm.client = client;
            cartForm.Show();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
           
        }

        private void ordersStripMenuItem1_Click(object sender, EventArgs e)
        {
            AllOrdersForm ordersForm = new AllOrdersForm();
            ordersForm.orders = client.orders;
            DataGridView dataGridView1 = ordersForm.Controls.Find("dataGridView1", true)[0] as DataGridView;

            for (int i = 0; i < client.orders.Count; i++)
            {
                dataGridView1.Rows.Add(client.orders[i].FullPrice, client.orders[i].Date);
            }
            ordersForm.client = client;
            ordersForm.Show();
        }
    }
}
